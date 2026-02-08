using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using Concretec.Pedidos.BE;

namespace Concretec.Pedidos.Utils
{
    public class EnvioCorreos
    {
        private void EnviarCorreo(Correo entidad)
        {

            //Declarando Variables 
            string From = entidad.From;
            string To = entidad.To;
            string Message = entidad.Message;
            string Subject = entidad.Subject;
            string smtpServer = entidad.smtpServer;

            System.Net.Mail.MailMessage Email;
            //Aplicando los campos a cada variable 

            //Establesco El Email 
            Email = new System.Net.Mail.MailMessage(From, To, Subject, Message);
            System.Net.Mail.SmtpClient smtpMail = new System.Net.Mail.SmtpClient("smtp.gmail.com");
            Email.IsBodyHtml = false;
            smtpMail.EnableSsl = true;
            smtpMail.UseDefaultCredentials = false;
            smtpMail.Host = "smtp.gmail.com";
            smtpMail.Port = 25;
            smtpMail.Host = "smtp.gmail.com";
            smtpMail.Credentials = new System.Net.NetworkCredential("mario.barron@coyotess.com", "Pato12345");
            smtpMail.Send(Email);



        }

        string ObtenerCorreo(string UserName)
        {

            return "mariobarron@gmail.com";
        }

        string ObtenerPasswordActual(string UserName)
        {

            return "Concretec";
        }

        void EnviaContraseña(string UserName)
        {
            Correo correo = new Correo();
            correo.From = "ProgramacionDePedidos@concretostecnicos.com";
            correo.To = ObtenerCorreo(UserName);
            correo.Message = "Estimado Usuario " + UserName + " Su contraseña para ingresar al sistema de programacion de pedidos es : " + ObtenerPasswordActual(UserName);
            correo.Subject = "Recuperacion de Contraseña";
            correo.smtpServer = "";

            EnviarCorreo(correo);
        }
    }
}
