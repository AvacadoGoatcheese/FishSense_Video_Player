using MVVM_Attempt_3_Video_Player.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_Attempt_3_Video_Player.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _selectedViewModel = new OneVideoViewModel();

        private bool _showingTwoVideos = false;
        public bool ShowingTwoVideos { 
            get => _showingTwoVideos; 
            set
            {
                _showingTwoVideos = value;
                OnPropertyChanged(nameof(ShowingTwoVideos));
            } 
        }
        private bool _showingOneVideo = true;
        public bool ShowingOneVideo
        {
            get => _showingOneVideo;
            set
            {
                _showingOneVideo = value;
                OnPropertyChanged(nameof(ShowingOneVideo));
            }
        }

        public ViewModelBase SelectedViewModel
        {
            get { return _selectedViewModel; }
            set { _selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }

        }
        public ICommand UpdateViewCommand { get; set; }

        public MainViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
        }
    }
}
