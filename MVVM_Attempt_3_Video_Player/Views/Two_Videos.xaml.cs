﻿using MVVM_Attempt_3_Video_Player.ViewModels;
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
            //MessageBox.Show(Video1.Source.ToString());
        }
        public void pause_button1(object sender, RoutedEventArgs e)
        {
            Video1.Pause();
            //MessageBox.Show("test");
        }
        public void restart_button1(object sender, RoutedEventArgs e)
        {
            Video1.Stop();
            Video1.Play();
            //MessageBox.Show("test");
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

        private void UserControl_KeyDown_First_Video(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right || e.Key == Key.Left)
            {
                double framerate = ((TwoVideosViewModel)(this.DataContext)).framerate_1;

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
        private void UserControl_KeyDown_Second_Video(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right || e.Key == Key.Left)
            {
                double framerate = ((TwoVideosViewModel)(this.DataContext)).framerate_2;

                int ticks = (int)(1.0 / framerate * 10_000_000); // 10,000,000 ticks per second
                if (e.Key == Key.Right)
                {
                    Video2.Position += TimeSpan.FromTicks(ticks);
                    //MessageBox.Show("Moving forward " + ticks.ToString());
                }
                else
                {
                    Video2.Position -= TimeSpan.FromTicks(ticks);
                    //MessageBox.Show("Moving backwards " + ticks.ToString());
                }
                Video2.Play();
                Video2.Pause();
            }
        }
       private void UserControl_KeyDown_Two_Videos(object sender, KeyEventArgs e)
       {
           if (e.Key == Key.Right || e.Key == Key.Left)
           {
               double framerate_1 = ((TwoVideosViewModel)(this.DataContext)).framerate_1;
               double framerate_2 = ((TwoVideosViewModel)(this.DataContext)).framerate_2;
       
               double framerate = 0.0;
               if (framerate_1 < framerate_2)
               {
                   framerate = framerate_1;
               }
               else
               {
                   framerate = framerate_2;
               }
               int ticks = (int)(1.0 / framerate * 10_000_000); // 10,000,000 ticks per second
               if (e.Key == Key.Right)
               {
                   Video1.Position += TimeSpan.FromTicks(ticks);
                   Video2.Position += TimeSpan.FromTicks(ticks);
                   //MessageBox.Show("Moving forward " + ticks.ToString());
               }
               else
               {
                   Video1.Position -= TimeSpan.FromTicks(ticks);
                   Video2.Position -= TimeSpan.FromTicks(ticks);
                   //MessageBox.Show("Moving backwards " + ticks.ToString());
               }
               Video1.Play();
               Video2.Play();
               Video1.Pause();
               Video2.Pause();
           }
       
       
       
       }
       
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.KeyDown += new KeyEventHandler(UserControl_KeyDown_Two_Videos);
        }

        private void Mutual_Play(object sender, RoutedEventArgs e)
        {
            Video1.Play();
            Video2.Play();
        }

        private void Mutual_Pause(object sender, RoutedEventArgs e)
        {
            Video1.Pause();
            Video2.Pause();
        }

        private void Mutual_Reset(object sender, RoutedEventArgs e)
        {
            Video1.Stop();
            Video2.Stop();
        }

 
    }
}
