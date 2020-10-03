using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ragoz_oop_2.Components.CircleWheel;

namespace ragoz_oop_2.Components.SquareWheel
{
    public partial class SquareWheelControl : UserControl
    {
        private static readonly DependencyProperty AngleProperty = DependencyProperty.Register("Angle", typeof(double), typeof(SquareWheelControl), new FrameworkPropertyMetadata(0.0));
        private static readonly DependencyProperty SpokeListProperty = DependencyProperty.Register("SpokeList", typeof(List<Spoke>), typeof(SquareWheelControl), new FrameworkPropertyMetadata(new List<Spoke>()));
        private static readonly DependencyProperty SmallDiameterProperty = DependencyProperty.Register("SmallDiameter", typeof(int), typeof(SquareWheelControl), new FrameworkPropertyMetadata(0));
        private static readonly DependencyProperty DiameterProperty = DependencyProperty.Register("Diameter", typeof(int), typeof(SquareWheelControl), new FrameworkPropertyMetadata(0));
        private static readonly DependencyProperty SquareHeightProperty = DependencyProperty.Register("SquareHeight", typeof(double), typeof(SquareWheelControl), new FrameworkPropertyMetadata(0.0));
        
        public int Diameter
        {
            get => (int) GetValue(DiameterProperty);
            set => SetValue(DiameterProperty, value);
        }

        public int SmallDiameter
        {
            get => (int) GetValue(SmallDiameterProperty);
            set => SetValue(SmallDiameterProperty, value);
        }

        public double Angle
        {
            get => (double) GetValue(AngleProperty);
            set => SetValue(AngleProperty, value);
        }

        public double SquareHeight
        {
            get => (double) GetValue(SquareHeightProperty);
            set => SetValue(SquareHeightProperty, value);
        }
        
        public List<Spoke> SpokeList
        {
            get => (List<Spoke>) GetValue(SpokeListProperty);
            set => SetValue(SpokeListProperty, value);
        }

        public SquareWheelControl()
        {
            InitializeComponent();
        }
    }
}