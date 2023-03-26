using MVVM_Attempt_3_Video_Player.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM_Attempt_3_Video_Player.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel _viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter.ToString() == "ShowOneVideo")
            {
                _viewModel.SelectedViewModel = new OneVideoViewModel();
                _viewModel.ShowingTwoVideos = false;
                _viewModel.ShowingOneVideo = true;
                //MessageBox.Show("Show one video works!");
            } else if (parameter.ToString() == "ShowTwoVideos")
            {
                _viewModel.SelectedViewModel = new TwoVideosViewModel();
                _viewModel.ShowingTwoVideos = true;
                _viewModel.ShowingOneVideo = false;
                //MessageBox.Show("Show two video works!");
            }

            
        }
    }
}
