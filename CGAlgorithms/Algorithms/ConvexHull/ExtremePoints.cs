using CGUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGAlgorithms.Algorithms.ConvexHull
{
    public class ExtremePoints : Algorithm
    {
        public override void Run(List<Point> points, List<Line> lines, List<Polygon> polygons, ref List<Point> outPoints, ref List<Line> outLines, ref List<Polygon> outPolygons)
        {
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = 0; j < points.Count; j++)
                {
                    for (int k = 0; k < points.Count; k++)
                    {
                        for (int y = 0; y < points.Count; y++)
                        {
                            if (isUniqe(points[i], points[j], points[k]) && 
                                isUniqe(points[i], points[j], points[y]) &&
                                isUniqe(points[i], points[k], points[y]) &&
                            isUniqe(points[j], points[k], points[y]))
                            {
                                Enums.PointInPolygon state = HelperMethods.PointInTriangle(
                                    points[y],
                                    points[i],
                                    points[j],
                                    points[k]);
                                if (state == Enums.PointInPolygon.Inside)
                                {
                                    points.RemoveAt(y);
                                }
                            }
                        }
                    }
                }
            }
            outPoints = points;
        }

        public bool isUniqe(Point a, Point b, Point c)
        {
            if (a.Equals(b) || a.Equals(c) || b.Equals(c))
                return false;
            return true;
        }
        public override string ToString()
        {
            return "Convex Hull - Extreme Points";
        }
    }
}
