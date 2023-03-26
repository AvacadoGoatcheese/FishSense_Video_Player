using MVVM_Attempt_3_Video_Player.ViewModels;
using MVVM_Attempt_3_Video_Player.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM_Attempt_3_Video_Player.Commands
{
    public class VideoControl : ICommand
    {
        enum Task
        {
            NONE=-1, PLAY=0, PAUSE=1, STOP=2, MUTE=3,
        }
        public int video_num;
        private Task task = Task.NONE;
        private TwoVideosViewModel? view_model_2_videos;
        private OneVideoViewModel? view_model_1_video;

        private bool one_video_vm;
        public VideoControl(TwoVideosViewModel source, int video_num, int task) 
        {
            this.video_num = video_num;
            if (task == 0)
            {
                this.task= Task.PLAY;
            } 
            else if (task == 1)
            {
                this.task = Task.PAUSE;
            } 
            else if (task == 2)
            {
                this.task = Task.STOP;
            } 
            else if (task == 3)
            {
                this.task = Task.MUTE;
            } 
            else
            {
                MessageBox.Show("Button failed to initialize in VideoControl.cs file.");
            }

            view_model_2_videos = source;
            one_video_vm = false;
        }
        public VideoControl(OneVideoViewModel source, int video_num, int task)
        {
            this.video_num = video_num;
            if (task == 0)
            {
                this.task = Task.PLAY;
            }
            else if (task == 1)
            {
                this.task = Task.PAUSE;
            }
            else if (task == 2)
            {
                this.task = Task.STOP;
            }
            else if (task == 3)
            {
                this.task = Task.MUTE;
            }
            else
            {
                MessageBox.Show("Button failed to initialize in VideoControl.cs file.");
            }

            view_model_1_video = source;
            one_video_vm = true;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (task == Task.MUTE)
            {
                if (video_num == 1)
                {
                    if (view_model_1_video != null)
                    if (view_model_2_videos.is_muted_v1 == true)
                    {
                        view_model_2_videos.is_muted_v1 = false;
                    }
                    else if (view_model_2_videos.is_muted_v1 == false)
                    {
                        view_model_2_videos.is_muted_v1 = true;
                    }
                } 
                else if (video_num == 2)
                {
                    if (view_model_2_videos.is_muted_v2 == true)
                    {
                        view_model_2_videos.is_muted_v2 = false;
                    }
                    else if (view_model_2_videos.is_muted_v2 == false)
                    {
                        view_model_2_videos.is_muted_v2 = true;
                    }
                }
            } else if (task == Task.PAUSE)
            {
                if (video_num == 1)
                {
                    if (one_video_vm == true && view_model_1_video != null)
                    {
                        view_model_1_video.is_playing = false;
                    }
                    else if (one_video_vm == false && view_model_2_videos != null)
                    {
                        view_model_2_videos.is_playing_v1 = false;
                    }
                    
                } 
                else if (video_num == 2 && view_model_2_videos != null)
                {
                    view_model_2_videos.is_playing_v2 = false;
                }
            }
        }
    }
}
