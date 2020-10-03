using System;
using System.Collections.Generic;
using System.Windows;
using ragoz_oop_2.Components;

namespace ragoz_oop_2.ViewModels.Wheels
{
    public class CircleWheelVM : WheelVM
    {
        public override void OnAngleChanged()
        {
            OnPropertyChanged(nameof(Angle));
            OnPropertyChanged(nameof(SpokeList));
        }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override void OnRadiusChanged()
        {
            OnPropertyChanged(nameof(Radius));
            OnPropertyChanged(nameof(Diameter));
            OnPropertyChanged(nameof(SmallDiameter));
        }

        public override List<Spoke> GetSpokes()
        {
            if (SpokeNum == 0) return new List<Spoke>();
            var result = new List<Spoke>();
            var angleStep = 360 / SpokeNum;
            var currentAngle = angleStep + Angle;
            var center = Point.Parse($"{Radius},{Radius}");
            var smallRadius = SmallDiameter / 2;
            var bigRadius = Radius;
            
            for (var i = 0; i < SpokeNum; i++)
            {
                var spoke = new Spoke();
                var startLine = new Point( center.X + smallRadius * Utils.GetCos(currentAngle), center.Y + smallRadius * Utils.GetSin(currentAngle));
                var endLine = new Point( center.X + bigRadius * Utils.GetCos(currentAngle), center.Y + bigRadius * Utils.GetSin(currentAngle));
                spoke.X1 = startLine.X;
                spoke.Y1 = startLine.Y;
                spoke.X2 = endLine.X;
                spoke.Y2 = endLine.Y;
                result.Add(spoke);
                currentAngle += angleStep;
            }

            return result;
        }
    }
}