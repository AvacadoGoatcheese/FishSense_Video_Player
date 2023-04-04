using MVVM_Attempt_3_Video_Player.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MVVM_Attempt_3_Video_Player.ViewModels
{
    public class OneVideoViewModel : ViewModelBase
    {
        private string _video_one_filename;
        public string video_one_filename 
        { 
            get => _video_one_filename; 
            set
            {
                _video_one_filename = value;
                OnPropertyChanged(nameof(video_one_filename));
            }
        }

        private string _video_one_filename_no_dir;
        public string video_one_filename_no_dir
        {
            get => _video_one_filename_no_dir;
            set
            {
                _video_one_filename_no_dir = value;
                OnPropertyChanged(nameof(video_one_filename_no_dir));
            }
        }
        private double _framerate;
        public double framerate
        {
            get => _framerate;
            set
            {
                _framerate = value;
                OnPropertyChanged(nameof(framerate));
            }
        }

        private double _resolution_width;
        public double resolution_width
        {
            get => _resolution_width;
            set
            {
                _resolution_width = value;
                OnPropertyChanged(nameof(resolution_width));
            }
        }

        private double _resolution_height;
        public double resolution_height
        {
            get => _resolution_height;
            set
            {
                _resolution_height = value;
                OnPropertyChanged(nameof(resolution_height));
            }
        }

        private string _x_coord;
        public string x_coord 
        { 
            get => _x_coord;
            set
            {
                _x_coord = value;
                OnPropertyChanged(nameof(x_coord));
            }
        }


        private string _y_coord;
        public string y_coord 
        { 
            get => _y_coord;
            set
            {
                _y_coord = value;
                OnPropertyChanged(nameof(y_coord));
            }
        }
        private bool _is_playing = true;
        public bool is_playing
        {
            get => _is_playing; 
            set
            {
                _is_playing = value;
                OnPropertyChanged(nameof(is_playing));
            }
        }

        private bool _is_muted = true;
        public bool is_muted
        {
            get => _is_muted;
            set
            {
                _is_muted = value;
                OnPropertyChanged(nameof(is_muted));
            }
        }
        public ICommand FileExplorer { get; set; }
        public ICommand MuteButton { get; set; }

        public ICommand UpdatePixelValue { get; set; }

        private MediaElement _video_1;
        public MediaElement Video_1
        {
            get => _video_1;
            set
            {
                _video_1 = value;
                OnPropertyChanged(nameof(Video_1));
            }
        }
        public OneVideoViewModel()
        {
            _video_one_filename = "";
            _x_coord = "";
            _y_coord = "";

            FileExplorer = new FileExplorer(this);
            MuteButton = new MuteButton(this);
            UpdatePixelValue = new ChangePixel(this);
        }

    }
}
