using MVVM_Attempt_3_Video_Player.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_Attempt_3_Video_Player.ViewModels
{
    public class TwoVideosViewModel : ViewModelBase
    {
        int PLAY = 0;
        int PAUSE = 1;
        int STOP = 2;
        int MUTE = 3;

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

        private string _video_two_filename_no_dir;
        public string video_two_filename_no_dir
        {
            get => _video_two_filename_no_dir;
            set
            {
                _video_two_filename_no_dir = value;
                OnPropertyChanged(nameof(video_two_filename_no_dir));
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

        public ICommand FileExplorer_1 { get; set; }
        public ICommand FileExplorer_2 { get; set; }


        public ICommand VideoControl_Play_1 { get; set; }
        public ICommand VideoControl_Pause_1 { get; set; }
        public ICommand VideoControl_Stop_1 { get; set; }
        public ICommand VideoControl_Mute_1 { get; set; }


        public ICommand VideoControl_Play_2 { get; set; }
        public ICommand VideoControl_Pause_2 { get; set; }
        public ICommand VideoControl_Stop_2 { get; set; }
        public ICommand VideoControl_Mute_2 { get; set; }


        public TwoVideosViewModel()
        {
            FileExplorer_1 = new FileExplorer(this, 1);
            FileExplorer_2 = new FileExplorer(this, 2);

            VideoControl_Play_1 = new PlayButton(this, 1);
            VideoControl_Pause_1 = new PauseButton(this, 1);
            VideoControl_Stop_1 = new RestartButton(this, 1);
            VideoControl_Mute_1 = new MuteButton(this, 1);

            VideoControl_Play_2 = new PlayButton(this, 2);
            VideoControl_Pause_2 = new PauseButton(this, 2);
            VideoControl_Stop_2 = new RestartButton(this, 2);
            VideoControl_Mute_2 = new MuteButton(this, 2);

        }
    }
}
