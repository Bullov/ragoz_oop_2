using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;
using ragoz_oop_2.Components;
using ragoz_oop_2.Components.WheelModal;
using ragoz_oop_2.ViewModels.Wheels;

namespace ragoz_oop_2.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private int _idGenerator = 1;
        private WheelVM _selectedWheel1;
        private WheelVM _selectedWheel2;
        private string _compareResult;
        
        private bool _isRotate;

        private RelayCommand _addWheel;
        private RelayCommand _editWheel;
        private RelayCommand _deleteWheel;
        
        private RelayCommand _startAnimation;
        private RelayCommand _stopAnimation;
        private RelayCommand _sortByArea;
        private RelayCommand _compare;

        public ObservableCollection<WheelVM> Wheels { get; set; } = new ObservableCollection<WheelVM>();

        public bool IsRotate
        {
            get => _isRotate;
            set
            {
                _isRotate = value;
                OnPropertyChanged(nameof(IsRotate));
            }
        }

        public RelayCommand StartAnimation => _startAnimation ??= new RelayCommand(_ =>
        {
            IsRotate = true;
            var animate = new Task(() =>
            {
                while (IsRotate)
                {
                    foreach (var wheelVm in Wheels)
                    {
                        wheelVm.Angle = (wheelVm.Angle + 5) % 360;
                    }
                    Thread.Sleep(500);
                } 
            });
            animate.Start();
            
        }, _ => !_isRotate || Wheels.Count == 0);

        public RelayCommand StopAnimation => _stopAnimation ??= new RelayCommand(_ => IsRotate = false, _ => _isRotate);

        public RelayCommand AddWheel => _addWheel ??= new RelayCommand(async _ =>
        {
            var dialog = new WheelModal
            {
                DataContext = new WheelModalVM
                {
                    WheelType = new WheelType(1, "Круглое")
                }
            };
            var result =  await DialogHost.Show(dialog, "rootDialog");
            if (result is WheelVM newWheel)
            {
                newWheel.Id = _idGenerator;
                Wheels.Add(newWheel);
                _idGenerator++;
            }
        }, null);

        public RelayCommand EditWheel => _editWheel ??= new RelayCommand(async param =>
        {
            if (param is WheelVM wheel)
            {
                var wheelType = new WheelType(1, "Круглое");
                if (wheel is SquareWheelVM) wheelType = new WheelType(2, "Квадратное");
                if (wheel is OctahedronWheelVM) wheelType = new WheelType(3, "Восьмигранное");
                
                var dialog = new WheelModal
                {
                    DataContext = new WheelModalVM
                    {
                        Angle = wheel.Angle,
                        Radius = wheel.Radius,
                        SpokeNum = wheel.SpokeNum,
                        WheelType = wheelType
                    }
                };
                var result =  await DialogHost.Show(dialog, "rootDialog");
                if (result is WheelVM newWheel)
                {
                    newWheel.Id = wheel.Id;
                    Wheels.Insert(Wheels.IndexOf(wheel), newWheel);
                    Wheels.Remove(wheel);
                }
            }
            
        }, null);

        public RelayCommand DeleteWheel => _deleteWheel ??= new RelayCommand(param =>
        {
            if (param is WheelVM wheel)
            {
                Wheels.Remove(wheel);
            }
        }, null);

        public RelayCommand SortByArea => _sortByArea ??= new RelayCommand(_ =>
        {
            Wheels = new ObservableCollection<WheelVM>(Wheels.OrderBy(item => item.GetArea()).ToList());
            OnPropertyChanged(nameof(Wheels));
        }, null);

        public RelayCommand Compare => _compare ??= new RelayCommand(_ =>
        {
            if (SelectedWheel1 == SelectedWheel2)
            {
                CompareResult = "equals";
            }
            else
            {
                CompareResult = SelectedWheel1 < SelectedWheel2 ? "Wheel1 < Wheel2" : "Wheel1 > Wheel2";
            }

        }, _ => _selectedWheel1 != null && _selectedWheel2 != null);

        public WheelVM SelectedWheel1
        {
            get => _selectedWheel1;
            set
            {
                _selectedWheel1 = value;
                OnPropertyChanged(nameof(SelectedWheel1));
            }
        }

        public WheelVM SelectedWheel2
        {
            get => _selectedWheel2;
            set
            {
                _selectedWheel2 = value;
                OnPropertyChanged(nameof(SelectedWheel2));
            }
        }

        public string CompareResult
        {
            get => _compareResult;
            set
            {
                _compareResult = value;
                OnPropertyChanged(nameof(CompareResult));
            }
        }
    }
}