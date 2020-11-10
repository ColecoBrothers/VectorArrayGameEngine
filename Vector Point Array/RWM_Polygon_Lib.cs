using System;
using System.Drawing;

namespace Vector_Point_Array
{
    class RWM_Polygon_Lib
    {
        // Carlos Nin - 10-31-2020 
        // 
        // Copywrite 2020 Josh Records and Reznor Worldwide Multimedia
        // Open liscense to use freely for any purpose as long as this header is retained.
        // Removal of this header is a violation of copyright.
        // Polygon functions
        // These don't work perfectly
        // TODO error checking, type sync all should be float or double
        // ANGLE IN RADIANS

        public static PointF[] ScalePolygon(PointF[] polygon, float Scale)
        {
            for (int i = 0; i < polygon.Length; i++)
            {
                polygon[i].X *= Scale;
                polygon[i].Y *= Scale;
            }

            return polygon;
        }

        public static PointF[] rotatePolygon(PointF[] polygon, PointF centroid, double angle)
        {
            for (int i = 0; i < polygon.Length; i++)
            {
                polygon[i] = rotatePoint(polygon[i], centroid, angle);
            }

            return polygon;
        }

        public static PointF rotatePoint(PointF point, PointF centroid, double angle)
        {
            double x = centroid.X + ((point.X - centroid.X) * Math.Cos(angle) - (point.Y - centroid.Y) * Math.Sin(angle));

            double y = centroid.Y + ((point.X - centroid.X) * Math.Sin(angle) + (point.Y - centroid.Y) * Math.Cos(angle));

            return new PointF((float)x, (float)y);
        }

        public static PointF[] OffsetPolygon(PointF[] polygon, PointF Start)
        {
            for (int i = 0; i < polygon.Length; i++)
            {
                polygon[i] = new PointF(polygon[i].X + Start.X, polygon[i].Y + Start.Y);
            }

            return polygon;
        }

        public static double ConvertDegreesToRadians(double angleDegrees)
        {
            double radians = (Math.PI / 180) * angleDegrees;
            return (radians);
        }

        public static double ConvertRadiansToDegrees(double angleRadians)
        {
            double degrees = (180 / Math.PI) * angleRadians;
            return (degrees);
        }

        public static PointF EndPoint(double angle, double Length)
        {

            double x1 = 0;
            double y1 = 0;
            double x2 = x1 + (Math.Cos(angle) * Length);
            double y2 = y1 + (Math.Sin(angle) * Length);

            float intX2 = Convert.ToInt32(x2);
            float intY2 = Convert.ToInt32(y2);

            return new PointF(intX2, intY2);

        }
   
    } //class
}// namespace
