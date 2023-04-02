using MVVM_Attempt_3_Video_Player.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM_Attempt_3_Video_Player.ViewModels
{
    public class TwoVideosViewModel : ViewModelBase
    {
        int VIDEO_ONE = 1;
        int VIDEO_TWO = 2;

        private string _video_one_filename;
        public string video_one_filename
        {
            get => _video_one_filename;
            set
            {
                _video_one_filename = value;
                //MessageBox.Show(_video_one_filename);
                OnPropertyChanged(nameof(video_one_filename));
            }
        }
        
        private string _video_two_filename;
        public string video_two_filename
        {
            get => _video_two_filename;
            set
            {
                _video_two_filename = value;
                OnPropertyChanged(nameof(video_two_filename));
            }
        }

        private bool _is_muted_v1 = false;
        public bool is_muted_v1
        {
            get => _is_muted_v1;
            set
            {
                _is_muted_v1 = value;
                if (mute_button_text_v1.Equals("Mute"))
                {
                    mute_button_text_v1 = "Unmute";
                }
                else if (mute_button_text_v1.Equals("Unmute"))
                {
                    mute_button_text_v1 = "Mute";
                }
                OnPropertyChanged(nameof(is_muted_v1));
            }
        }

        private bool _is_muted_v2 = false;
        public bool is_muted_v2
        {
            get => _is_muted_v2;
            set
            {
                _is_muted_v2 = value;

                if (mute_button_text_v2.Equals("Mute"))
                {
                    mute_button_text_v2 = "Unmute";
                }
                else if (mute_button_text_v2.Equals("Unmute"))
                {
                    mute_button_text_v2 = "Mute";
                }
                OnPropertyChanged(nameof(is_muted_v2));
            }
        }

        private string _mute_button_text_v1 = "Mute";
        public string mute_button_text_v1
        {
            get => _mute_button_text_v1;
            set
            {
                _mute_button_text_v1 = value;
                OnPropertyChanged(nameof(mute_button_text_v1));
            }
        }

        private string _mute_button_text_v2 = "Mute";
        public string mute_button_text_v2
        {
            get => _mute_button_text_v2;
            set
            {
                _mute_button_text_v2 = value;
                OnPropertyChanged(nameof(mute_button_text_v2));
            }
        }

        private bool _is_playing_v1 = true;
        public bool is_playing_v1
        {
            get => _is_playing_v1;
            set
            {
                _is_playing_v1 = value;
                OnPropertyChanged(nameof(is_playing_v1));
            }
        }

        private bool _is_playing_v2 = true;
        public bool is_playing_v2
        {
            get => _is_playing_v2;
            set
            {
                _is_playing_v2 = value;
                OnPropertyChanged(nameof(is_playing_v2));
            }
        }

        private double _framerate_1;
        public double framerate_1
        {
            get => _framerate_1;
            set
            {
                _framerate_1 = value;
                OnPropertyChanged(nameof(framerate_1));
            }
        }

        private double _resolution_width_1;
        public double resolution_width_1
        {
            get => _resolution_width_1;
            set
            {
                _resolution_width_1 = value;
                OnPropertyChanged(nameof(resolution_width_1));
            }
        }

        private double _resolution_height_1;
        public double resolution_height_1
        {
            get => _resolution_height_1;
            set
            {
                _resolution_height_1 = value;
                OnPropertyChanged(nameof(resolution_height_1));
            }
        }
        private double _framerate_2;
        public double framerate_2
        {
            get => _framerate_2;
            set
            {
                _framerate_2 = value;
                OnPropertyChanged(nameof(framerate_2));
            }
        }

        private double _resolution_width_2;
        public double resolution_width_2
        {
            get => _resolution_width_2;
            set
            {
                _resolution_width_2 = value;
                OnPropertyChanged(nameof(resolution_width_2));
            }
        }

        private double _resolution_height_2;
        public double resolution_height_2
        {
            get => _resolution_height_2;
            set
            {
                _resolution_height_2 = value;
                OnPropertyChanged(nameof(resolution_height_2));
            }
        }
        public ICommand FileExplorer_1 { get; set; }
        public ICommand FileExplorer_2 { get; set; }

        public ICommand VideoControl_Mute_1 { get; set; }
        public ICommand VideoControl_Mute_2 { get; set; }


        public TwoVideosViewModel()
        {
            FileExplorer_1 = new FileExplorer(this, VIDEO_ONE);
            FileExplorer_2 = new FileExplorer(this, VIDEO_TWO);

            VideoControl_Mute_1 = new MuteButton(this, VIDEO_ONE);
            VideoControl_Mute_2 = new MuteButton(this, VIDEO_TWO);
        }
    }
}
