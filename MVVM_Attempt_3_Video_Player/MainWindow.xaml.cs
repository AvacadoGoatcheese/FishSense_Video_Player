using MVVM_Attempt_3_Video_Player.ViewModels;
using MVVM_Attempt_3_Video_Player.Views;
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

namespace MVVM_Attempt_3_Video_Player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

     //   private void Window_Loaded(object sender, RoutedEventArgs e)
     //   {
     //       this.KeyDown += new KeyEventHandler(UserControl_KeyDown_One_Video);
     //   }


     //   private void UserControl_KeyDown_One_Video(object sender, KeyEventArgs e)
     //   {
     //       if (e.Key == Key.Right || e.Key == Key.Left)
     //       {
     //           if (((MainViewModel)(this.DataContext)).ShowingOneVideo)
     //           {
     //               
     //           } else if (((MainViewModel)(this.DataContext)).ShowingTwoVideos)
     //           {
     //
     //           }
     //       }
     //   }
    }
}
