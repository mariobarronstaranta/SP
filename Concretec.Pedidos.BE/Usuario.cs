using System;
using System.Collections.Generic;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class Usuario
    {
        public int Id_Usuario
        { set; get; }

        public Guid IDUsuario
        { set; get; }

        public int IDPerfil
        { set; get; }

        public int IDCiudad
        { set; get; }

        public string UserName
        { set; get; }

        public string Password
        { set; get; }

        public string Nombre
        { set; get; }

        public string APaterno
        { set; get; }

        public string AMaterno
        { set; get; }

        public string Correo
        { set; get; }

        public string Ciudad
        { set; get; }

        public string Perfil
        { set; get; }

        public bool Estatus
        { set; get; }

        public string Accion
        { set; get; }

        public int IDPlanta
        { set; get; }
    }
}
