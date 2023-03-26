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
    public class RestartButton : ICommand
    {
        public OneVideoViewModel? view_model_one_video;
        public TwoVideosViewModel? view_model_two_videos;
        public int video_num = -1;
        public RestartButton(OneVideoViewModel source)
        {
            view_model_one_video = source;
            video_num = 1;
        }

        public RestartButton(TwoVideosViewModel source, int video_num)
        {
            view_model_two_videos = source;
            this.video_num = video_num;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (video_num == 1)
            {
                if (view_model_two_videos != null)
                {
                    //MessageBox.Show("Restarting video 1 of two videos");
                }
                else if (view_model_one_video != null)
                {
                    //MessageBox.Show("Restarting video 1 of one video");
                }
            }
            else if (video_num == 2)
            {
                if (view_model_two_videos != null)
                {
                    //MessageBox.Show("Restarting video 2 of two videos");
                }
            }
        }
    }
}
