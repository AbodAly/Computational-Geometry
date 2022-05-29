using CGUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGAlgorithms.Algorithms.ConvexHull
{
    public class ExtremeSegments : Algorithm
    {
        public override void Run(List<Point> points, List<Line> lines, List<Polygon> polygons, ref List<Point> outPoints, ref List<Line> outLines, ref List<Polygon> outPolygons)
        {
            if (points.Count == 1)
            {
                outPoints.Add(points[0]);
            }
            for (int i=0 ;i <points.Count;i++)
            {
                 for (int j=0 ;j <points.Count;j++)
                {
                     if(i!=j){
                         Line obj=new Line(points[i],points[j]);
                         lines.Add(obj);
                     }
              }
            }
            foreach (var line in lines)
            {
                bool right = false;
                bool left = false;

                foreach (var point in points)
                {
                    var x = HelperMethods.CheckTurn(line, point);
                    if (x == Enums.TurnType.Left)
                    {
                        left = true;
                        if (right == true)
                        {
                            break;
                        }
                    }
                    else if (x == Enums.TurnType.Right)
                    {
                        right = true;
                        if (left == true)
                        {
                            break;
                        }
                    }
                    if (point == points.Last())
                    {
                        if (!outPoints.Contains(line.Start))
                        {
                            outPoints.Add(line.Start);
                        }
                        if (!outPoints.Contains(line.End))
                        {
                            outPoints.Add(line.End);
                        }
                        
                        
                    }

                }

            }   
        }

        public override string ToString()
        {
            return "Convex Hull - Extreme Segments";
        }
        public bool isUniqe(Point a, Point b, Point c)
        {
            if (a.Equals(b) || a.Equals(c) || b.Equals(c))
                return false;
            return true;
        }
    }
}
