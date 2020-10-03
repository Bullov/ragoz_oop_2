using System;
using System.Collections.Generic;
using System.Windows;
using ragoz_oop_2.Components;

namespace ragoz_oop_2.ViewModels.Wheels
{
    public class SquareWheelVM : WheelVM
    {
        public double SquareHeight => Diameter / Math.Sqrt(2.0);

        public override void OnRadiusChanged()
        {
            OnPropertyChanged(nameof(Radius));
            OnPropertyChanged(nameof(Diameter));
            OnPropertyChanged(nameof(SmallDiameter));
            OnPropertyChanged(nameof(SquareHeight));
        } 
        public override List<Spoke> GetSpokes()
        {
            var result = new List<Spoke>();
            var currentAngle = Angle;
            var center = Point.Parse($"{Radius},{Radius}");
            var smallRadius = SmallDiameter / 2;
            var angleStep = 90;
            for (var i = 0; i < 4; i++)
            {
                var spoke = new Spoke();
                var startLine = new Point( center.X + smallRadius * Utils.GetCos(currentAngle), center.Y + smallRadius * Utils.GetSin(currentAngle));
                var endLine = new Point( center.X + SquareHeight / 2 * Utils.GetCos(currentAngle), center.Y + SquareHeight / 2 * Utils.GetSin(currentAngle));
                spoke.X1 = startLine.X;
                spoke.Y1 = startLine.Y;
                spoke.X2 = endLine.X;
                spoke.Y2 = endLine.Y;
                result.Add(spoke);
                currentAngle += angleStep;
            }
            
            if (SpokeNum == 8)
            {
                currentAngle = 45 + Angle;
                for (var i = 0; i < 4; i++)
                {
                    var spoke = new Spoke();
                    var startLine = new Point( center.X + smallRadius * Utils.GetCos(currentAngle), center.Y + smallRadius * Utils.GetSin(currentAngle));
                    var endLine = new Point( center.X + Diameter / 2 * Utils.GetCos(currentAngle), center.Y + Diameter / 2 * Utils.GetSin(currentAngle));
                    spoke.X1 = startLine.X;
                    spoke.Y1 = startLine.Y;
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
        }

        public override double GetArea()
        {
            return SquareHeight * SquareHeight;
        }
    }
}