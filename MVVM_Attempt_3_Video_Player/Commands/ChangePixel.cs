using MVVM_Attempt_3_Video_Player.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace MVVM_Attempt_3_Video_Player.Commands
{
    public class ChangePixel : ICommand
    {
        private OneVideoViewModel oneVideoViewModel;

        public ChangePixel(OneVideoViewModel oneVideoViewModel)
        {
            this.oneVideoViewModel = oneVideoViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            if (oneVideoViewModel != null)
            {
                string x_coord = Mouse.GetPosition(parameter as MediaElement).X.ToString();
                string y_coord = Mouse.GetPosition(parameter as MediaElement).X.ToString();
                MessageBox.Show(x_coord + " " + y_coord);
            }
        }

    }
}
