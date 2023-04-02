using MVVM_Attempt_3_Video_Player.ViewModels;
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

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           //double proportion = 1.0 * Slider.Value / Slider.Maximum;
           //Video1.Pause();
           //
           //Video1.Position = Video1.NaturalDuration.TimeSpan * proportion;
           //Video1.Play();\
        }

        private void UserControl_KeyDown_One_Video(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right || e.Key == Key.Left )
            { 
                double framerate = ((OneVideoViewModel)(this.DataContext)).framerate;
                int ticks = (int)(1.0 / framerate * 10_000_000); // 10,000,000 ticks per second
                if (e.Key == Key.Right)
                {
                    Video1.Position += TimeSpan.FromTicks(ticks);
                    //MessageBox.Show("Moving forward " + ticks.ToString());
                }
                else
                {
                    Video1.Position -= TimeSpan.FromTicks(ticks);
                    //MessageBox.Show("Moving backwards " + ticks.ToString());
                }
                Video1.Play();
                Video1.Pause();
            }

                
                
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.KeyDown += new KeyEventHandler(UserControl_KeyDown_One_Video);
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
        }
    }
}
