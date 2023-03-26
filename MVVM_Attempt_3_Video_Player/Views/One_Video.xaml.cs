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
    /// Interaction logic for One_Video.xaml
    /// </summary>
    public partial class One_Video : UserControl
    {
        public One_Video()
        {
            InitializeComponent();
        }

        public void play_button(object sender, RoutedEventArgs e)
        {
            Video1.Play();
        }
        public void pause_button(object sender, RoutedEventArgs e)
        {
            Video1.Pause();
        }
        public void restart_button(object sender, RoutedEventArgs e)
        {
            Video1.Stop();
            Video1.Play();

            //Slider.Value = 0;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           //double proportion = 1.0 * Slider.Value / Slider.Maximum;
           //Video1.Pause();
           //
           //Video1.Position = Video1.NaturalDuration.TimeSpan * proportion;
           //Video1.Play();
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right || e.Key == Key.Left)
            {
                Video1.Pause();
                double frame_rate = 0;
                if (fps_30_box != null && (bool)fps_30_box.IsChecked)
                {
                    frame_rate = 29.97;
                }
                else if (fps_60_box != null && (bool)fps_60_box.IsChecked)
                {
                    frame_rate = 29.97 * 2;
                }
                else
                {
                    MessageBox.Show("Pressing the arrow keys skips frames. Please enter a framerate using the checkboxes before using them.");
                }

                int ticks = (int)(1.0 / frame_rate * 1000 * 10000); // 1000 ms per second, 10000 ticks per ms
                if (e.Key == Key.Right)
                {
                    Video1.Position += TimeSpan.FromTicks(ticks);
                    //MessageBox.Show("Moving forward " + ticks.ToString());
                }
                else
                {
                    Video1.Position -= TimeSpan.FromTicks(ticks);
                }
            }
            Video1.Play();
            Video1.Pause();
                
                
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.KeyDown += UserControl_KeyDown;
        }

        private void fps_30(object sender, RoutedEventArgs e)
        {
            fps_60_box.IsChecked = false;
        }

        private void fps_60(object sender, RoutedEventArgs e)
        {
            fps_30_box.IsChecked = false;
        }
    }
}
