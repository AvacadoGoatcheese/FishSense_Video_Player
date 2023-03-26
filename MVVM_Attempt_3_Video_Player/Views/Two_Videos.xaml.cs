using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM_Attempt_3_Video_Player.Views
{
    /// <summary>
    /// Interaction logic for Two_Videos.xaml
    /// </summary>
    public partial class Two_Videos : UserControl
    {
        public Two_Videos()
        {
            InitializeComponent();
        }

        public void play_button1(object sender, RoutedEventArgs e)
        {
            Video1.Play();
        }
        public void pause_button1(object sender, RoutedEventArgs e)
        {
            Video1.Pause();
        }
        public void restart_button1(object sender, RoutedEventArgs e)
        {
            Video1.Stop();
            Video1.Play();
        }
        public void play_button2(object sender, RoutedEventArgs e)
        {
            Video2.Play();
        }
        public void pause_button2(object sender, RoutedEventArgs e)
        {
            Video2.Pause();
        }
        public void restart_button2(object sender, RoutedEventArgs e)
        {
            Video2.Stop();
            Video2.Play();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double proportion = 1.0 * Slider1.Value / Slider1.Maximum;
            Video1.Pause();
            Video1.Position = Video1.NaturalDuration.TimeSpan * proportion;
            Video1.Play();
        }

        private void Slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double proportion = 1.0 * Slider2.Value / Slider2.Maximum;
            Video2.Pause();
            Video2.Position = Video1.NaturalDuration.TimeSpan * proportion;
            Video2.Play();
        }
    }
}
