using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Concretec.Pedidos.Utils
{
    public class UtilsArchivos
    {

        public bool TransferirArchivos(string NombreArchivo, string origen, string destino)
        {

            string sourceFile = System.IO.Path.Combine(origen, NombreArchivo);
            NombreArchivo = NombreArchivo.Substring(0, NombreArchivo.Length - 3) + '_' + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString()  + ".db";
            string destFile = System.IO.Path.Combine(destino, NombreArchivo);

            //Valida la ruta en caso de no existir la crea
            if (!System.IO.Directory.Exists(destino))
            {
                System.IO.Directory.CreateDirectory(destino);
            }
            System.IO.File.Copy(sourceFile, destFile, true);
            //System.IO.File.Delete(sourceFile);

            return true;
        }
    }
}
