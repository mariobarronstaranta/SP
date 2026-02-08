using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Concretec.Pedidos.Utils
{
    public class CalculaDistancias
    {
    double haversineDistance(double Lat1,double Lon1,double Lat2,double Lon2)
        {
            var lat1 = DegtoRad(Lat1);
            var lon1 = DegtoRad(Lon1);
            var lat2 = DegtoRad(Lat2);
            var lon2 = DegtoRad(Lon2);
            var earthRadius = 6371;

            var dLat = lat2-lat1;
            var dLon = lon2-lon1;

            var cordLength = Math.Pow(Math.Sin(dLat/2),2)+Math.Cos(lat1)*Math.Cos(lat2)*Math.Pow(Math.Sin(dLon/2),2);
            var centralAngle = 2 * Math.Atan2(Math.Sqrt(cordLength), Math.Sqrt(1- cordLength));
            return earthRadius * centralAngle;
        }

        double DegtoRad(double x)
        {
               return x*Math.PI / 180;
        }

        double RadtoDeg(double x)
        {
            return x*180/Math.PI;
        }

       

    }
}
