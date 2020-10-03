using System.Collections.Generic;
using ragoz_oop_2.Components;

namespace ragoz_oop_2.ViewModels.Wheels
{
    public abstract class WheelVM : BaseViewModel
    {
        public int Id { get; set; }
        private double _radius;
        private int _spokeNum;
        private double _angle;
        private bool _isPrintable;
        
        public double Diameter => Radius * 2;
        public double SmallDiameter => Diameter * 0.2;

        public double Radius
        {
            get => _radius;
            set
            {
                if (value > 0)
                {
                    _radius = value;
                    OnRadiusChanged();   
                }
            }
        }

        public abstract void OnRadiusChanged();

        public List<Spoke> SpokeList => GetSpokes();

        public abstract List<Spoke> GetSpokes();

        public int SpokeNum
        {
            get => _spokeNum;
            set
            {
                _spokeNum = value;
                OnPropertyChanged(nameof(SpokeNum));
                OnPropertyChanged(nameof(SpokeList));
            }
        }

        public double Angle
        {
            get => _angle;
            set
            {
                _angle = value % 360;
                OnAngleChanged();
            }
        }

        public bool IsPrintable
        {
            get => _isPrintable;
            set
            {
                _isPrintable = value;
                OnPropertyChanged(nameof(IsPrintable));
            }
        }

        public abstract void OnAngleChanged();

        public abstract double GetArea();

        public void MultiplyBy(object value)
        {
            if (value is int i)
            {
                Radius *= i;
            }
            else if (value is double d)
            {
                Radius *= d;
            } 
            else if (value is float f)
            {
                Radius *= f;
            }
            else if (value is string s)
            {
                Radius *= double.Parse(s);
            }
        }
        
        public void DivideBy(object value)
        {
            if (value is int i)
            {
                Radius /= i;
            }
            else if (value is double d)
            {
                Radius /= d;
            } 
            else if (value is float f)
            {
                Radius /= f;
            }
            else if (value is string s)
            {
                Radius /= double.Parse(s);
            }
        }

        public static bool operator ==(WheelVM wheel1, object wheel2)
        {
            if ((object)wheel1 == null && wheel2 == null)
            {
                return true;
            } 
            if ((object)wheel1 == null || wheel2 == null)
            {
                return false;
            }

            if (wheel2 is WheelVM wheelVm)
            {
                return wheel1.GetArea() == wheelVm.GetArea();
            }
            return false;

        }

        public static bool operator !=(WheelVM wheel1, object wheel2)
        {
            return !(wheel1 == wheel2);
        }

        public static bool operator >(WheelVM wheel1, WheelVM wheel2)
        {
            return wheel1.GetArea() > wheel2.GetArea();
        }

        public static bool operator <(WheelVM wheel1, WheelVM wheel2)
        {
            return wheel1.GetArea() < wheel2.GetArea(); 
        }
    }
}