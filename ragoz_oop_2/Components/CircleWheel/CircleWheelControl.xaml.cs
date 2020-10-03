using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ragoz_oop_2.Components.CircleWheel
{
    public partial class CircleWheelControl : UserControl
    {
        private static readonly DependencyProperty SpokeListProperty = DependencyProperty.Register("SpokeList", typeof(List<Spoke>), typeof(CircleWheelControl), new FrameworkPropertyMetadata(new List<Spoke>()));
        private static readonly DependencyProperty SmallDiameterProperty = DependencyProperty.Register("SmallDiameter", typeof(int), typeof(CircleWheelControl), new FrameworkPropertyMetadata(0));
        private static readonly DependencyProperty DiameterProperty = DependencyProperty.Register("Diameter", typeof(int), typeof(CircleWheelControl), new FrameworkPropertyMetadata(0));
        
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

        public List<Spoke> SpokeList
        {
            get => (List<Spoke>) GetValue(SpokeListProperty);
            set => SetValue(SpokeListProperty, value);
        }

        public CircleWheelControl()
        {
            InitializeComponent();
        }
    }
}