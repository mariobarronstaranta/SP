using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.Utils
{
    public class GeoCodeCalc
    {

        const double EarthRadiusInMiles = 3956.0;
        const double EarthRadiusInKilometers = 3956.0;
        enum GeoCodeCalcMeasurement { Kilometers, Miles };

        /// <summary> 
        /// Calculate the distance between two geocodes. Defaults to using Miles. 
        /// </summary> 
        double CalcDistance(double lat1, double lng1, double lat2, double lng2)
        {
            return CalcDistance(lat1, lng1, lat2, lng2, GeoCodeCalcMeasurement.Kilometers);
        }
        /// <summary> 
        /// Calculate the distance between two geocodes. 
        /// </summary> 
        double CalcDistance(double lat1, double lng1, double lat2, double lng2, GeoCodeCalcMeasurement m)
        {
            double radius = GeoCodeCalc.EarthRadiusInMiles;
            if (m == GeoCodeCalcMeasurement.Kilometers) { radius = GeoCodeCalc.EarthRadiusInKilometers; }
            return radius * 2 * Math.Asin(Math.Min(1, Math.Sqrt((Math.Pow(Math.Sin((DiffRadian(lat1, lat2)) / 2.0), 2.0) + Math.Cos(ToRadian(lat1)) * Math.Cos(ToRadian(lat2)) * Math.Pow(Math.Sin((DiffRadian(lng1, lng2)) / 2.0), 2.0)))));
          }

        double DiffRadian(double lat1, double lat2)
        { return Math.Atan2(lat1, lat2); }

        double ToRadian(double lat1)
        {
            return Math.PI * lat1 / 180.0;
        }
    }
}
