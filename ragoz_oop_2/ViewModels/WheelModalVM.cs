using System.Collections.Generic;
using MaterialDesignThemes.Wpf;
using ragoz_oop_2.Components;
using ragoz_oop_2.ViewModels.Wheels;

namespace ragoz_oop_2.ViewModels
{
    public class WheelModalVM : BaseViewModel
    {
        private double _radius;
        private int _spokeNum;
        private double _angle;
        private WheelType _wheelType = new WheelType(1, "Круглое");

        private double _radiusMuliplier;
        
        public List<WheelType> WheelTypes => new List<WheelType>
        {
            new WheelType(1, "Круглое"),
            new WheelType(2, "Квадратное"),
            new WheelType(3, "Восьмигранное"),
        };

        private RelayCommand _multiply;
        private RelayCommand _divide;
        private RelayCommand _save;
        public double Radius
        {
            get => _radius;
            set
            {
                if (value > 0)
                {
                    _radius = value;
                    OnPropertyChanged(nameof(Radius));   
                }
            }
        }
        
        public int SpokeNum
        {
            get => _spokeNum;
            set
            {
                switch (WheelType.Id)
                {
                    case 1:
                        if (value >= 4 && value <= 20)
                        {
                            _spokeNum = value;
                            OnPropertyChanged(nameof(SpokeNum));
                        }
                        break;
                    case 2:
                        if (value == 4 || value == 8)
                        {
                            _spokeNum = value;
                            OnPropertyChanged(nameof(SpokeNum));
                        }
                        break;
                    default:
                        if (value == 8 || value == 16)
                        {
                            _spokeNum = value;
                            OnPropertyChanged(nameof(SpokeNum));
                        }
                        break;
                }
                
            }
        }

        public double Angle
        {
            get => _angle;
            set
            {
                _angle = value % 360;
                OnPropertyChanged(nameof(Angle));
            }
        }

        public WheelType WheelType
        {
            get => _wheelType;
            set
            {
                SpokeNum = value.Id switch
                {
                    1 => 4,
                    2 => 4,
                    3 => 8,
                    _ => SpokeNum
                };
                _wheelType = value;
                OnPropertyChanged(nameof(WheelType));
            }
        }
        
        public double RadiusMuliplier
        {
            get => _radiusMuliplier;
            set
            {
                _radiusMuliplier = value;
                OnPropertyChanged(nameof(RadiusMuliplier));
            }
        }
        
        public RelayCommand Save => _save ??= new RelayCommand(_ =>
        {
            WheelVM wheel = WheelType.Id switch
            {
                1 => new CircleWheelVM(),
                2 => new SquareWheelVM(),
                _ => new OctahedronWheelVM()
            };

            wheel.Radius = Radius;
            wheel.Angle = Angle;
            wheel.SpokeNum = SpokeNum;
            wheel.IsPrintable = true;
            DialogHost.Close("rootDialog", wheel);
        }, null);

        public RelayCommand Multiply => _multiply ??= new RelayCommand(_ => Radius *= _radiusMuliplier , null);
        
        public RelayCommand Divide => _divide ??= new RelayCommand(_ => Radius /= _radiusMuliplier, null);
    }
}