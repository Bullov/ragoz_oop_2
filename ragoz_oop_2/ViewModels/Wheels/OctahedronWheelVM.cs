using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using ragoz_oop_2.Components;

namespace ragoz_oop_2.ViewModels.Wheels
{
    public class OctahedronWheelVM : WheelVM
    {
        public PointCollection PolygonPoints => GetPolygonPoints();
        public override void OnRadiusChanged()
        {
            OnPropertyChanged(nameof(Radius));
            OnPropertyChanged(nameof(Diameter));
            OnPropertyChanged(nameof(SmallDiameter));
            OnPropertyChanged(nameof(PolygonPoints));
        }

        public override List<Spoke> GetSpokes()
        {
            var result = new List<Spoke>();
            var currentAngle = Angle;
            var center = Point.Parse($"{Radius},{Radius}");
            var angleStep = 45;
            for (var i = 0; i < 8; i++)
            {
                var spoke = new Spoke();
                var endLine = new Point( center.X + Radius * Utils.GetCos(currentAngle), center.Y + Radius * Utils.GetSin(currentAngle));
                spoke.X1 = center.X;
                spoke.Y1 = center.Y;
                spoke.X2 = endLine.X;
                spoke.Y2 = endLine.Y;
                result.Add(spoke);
                currentAngle += angleStep;
            }

            if (SpokeNum == 16)
            {
                currentAngle = 45 / 2 + Angle;
                var point1 = new Point( center.X + Radius * Utils.GetCos(0), center.Y + Radius * Utils.GetSin(0));
                var point2 = new Point( center.X + Radius * Utils.GetCos(45), center.Y + Radius * Utils.GetSin(45));
                var a = Math.Sqrt((point1.X - point2.X) * (point1.X - point2.X) + (point1.Y - point2.Y) * (point1.Y - point2.Y));
                var innerRadius = a * (1 + Math.Sqrt(2.0)) / 2;
                
                for (var i = 0; i < 8; i++)
                {
                    var spoke = new Spoke();
                    var endLine = new Point( center.X + innerRadius * Utils.GetCos(currentAngle), center.Y + innerRadius * Utils.GetSin(currentAngle));
                    spoke.X1 = center.X;
                    spoke.Y1 = center.Y;
                    spoke.X2 = endLine.X;
                    spoke.Y2 = endLine.Y;
                    result.Add(spoke);
                    currentAngle += angleStep;
                }
                
            }

            return result;
        }

        public override void OnAngleChanged()
        {
            OnPropertyChanged(nameof(Angle));
            OnPropertyChanged(nameof(SpokeList));
            OnPropertyChanged(nameof(PolygonPoints));
        }

        public override double GetArea()
        {           
            var center = Point.Parse($"{Radius},{Radius}");
            var point1 = new Point( center.X + Radius * Utils.GetCos(0), center.Y + Radius * Utils.GetSin(0));
            var point2 = new Point( center.X + Radius * Utils.GetCos(45), center.Y + Radius * Utils.GetSin(45));

            var a = Math.Sqrt((point1.X - point2.X) * (point1.X - point2.X) + (point1.Y - point2.Y) * (point1.Y - point2.Y));
            return 2 * a * a * (1 + Math.Sqrt(2.0));
        }

        private PointCollection GetPolygonPoints()
        {
            var result = new PointCollection();
            var currentAngle = Angle;
            const int angleStep = 45;
            var center = Point.Parse($"{Radius},{Radius}");
            for (var i = 0; i < 8; i++)
            {
                var point = new Point( center.X + Radius * Utils.GetCos(currentAngle), center.Y + Radius * Utils.GetSin(currentAngle));
                result.Add(point);
                currentAngle += angleStep;
            }
            return result;
        }
    }
}