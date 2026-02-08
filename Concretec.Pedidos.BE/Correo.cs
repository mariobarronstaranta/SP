using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class Correo
    {
        public string From
        { set; get; }

        public string To
        { set; get; }

        public string Message
        { set; get; }

        public string Subject
        { set; get; }

        public string smtpServer
        { set; get; }
    }
}
