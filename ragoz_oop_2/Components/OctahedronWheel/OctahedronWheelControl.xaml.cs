using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ragoz_oop_2.Components.CircleWheel;

namespace ragoz_oop_2.Components.OctahedronWheel
{
    public partial class OctahedronWheelControl : UserControl
    {
        private static readonly DependencyProperty AngleProperty = DependencyProperty.Register("Angle", typeof(double), typeof(OctahedronWheelControl), new FrameworkPropertyMetadata(0.0));
        private static readonly DependencyProperty SpokeListProperty = DependencyProperty.Register("SpokeList", typeof(List<Spoke>), typeof(OctahedronWheelControl), new FrameworkPropertyMetadata(new List<Spoke>()));
        private static readonly DependencyProperty DiameterProperty = DependencyProperty.Register("Diameter", typeof(int), typeof(OctahedronWheelControl), new FrameworkPropertyMetadata(0));
        private static readonly DependencyProperty PolygonPointsProperty = DependencyProperty.Register("PolygonPoints", typeof(PointCollection), typeof(OctahedronWheelControl), new FrameworkPropertyMetadata(null));
        
        public int Diameter
        {
            get => (int) GetValue(DiameterProperty);
            set => SetValue(DiameterProperty, value);
        }

        public double Angle
        {
            get => (double) GetValue(AngleProperty);
            set => SetValue(AngleProperty, value);
        }
        
        public List<Spoke> SpokeList
        {
            get => (List<Spoke>) GetValue(SpokeListProperty);
            set => SetValue(SpokeListProperty, value);
        }

        public PointCollection PolygonPoints
        {
            get => (PointCollection) GetValue(PolygonPointsProperty);
            set => SetValue(PolygonPointsProperty, value);
        }
        public OctahedronWheelControl()
        {
            InitializeComponent();
        }
    }
}