using Microsoft.Win32;
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
    public class FileExplorer : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        enum whichVM
        {
            NONE = -1,
            ONEVIDEO = 0,
            TWOVIDEOS_FIRST = 1,
            TWOVIDEOS_SECOND = 2,
        }
        whichVM current_video = whichVM.NONE;
        public OneVideoViewModel one_video_VM { get; set; }
        public TwoVideosViewModel two_video_VM { get; set; }
        public FileExplorer(OneVideoViewModel source)
        {
            current_video = whichVM.ONEVIDEO;
            one_video_VM = source;
        }
        public FileExplorer(TwoVideosViewModel source, int video_num)
        {
            if (video_num == 1) 
            {
                current_video = whichVM.TWOVIDEOS_FIRST;
            } 
            else if (video_num == 2)
            {
                current_video = whichVM.TWOVIDEOS_SECOND;
            }

            two_video_VM = source;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {   
                if (current_video == whichVM.ONEVIDEO)
                {
                    one_video_VM.video_one_filename = openFileDialog.FileName;
                    one_video_VM.video_one_filename_no_dir = openFileDialog.SafeFileName;
                    MessageBox.Show(one_video_VM.video_one_filename);
                }
                else if (current_video == whichVM.TWOVIDEOS_FIRST)
                {
                    two_video_VM.video_one_filename = openFileDialog.FileName;
                    two_video_VM.video_one_filename_no_dir = openFileDialog.SafeFileName;
                    MessageBox.Show(two_video_VM.video_one_filename);
                }
                else if (current_video == whichVM.TWOVIDEOS_SECOND)
                {
                    two_video_VM.video_two_filename = openFileDialog.FileName;
                    two_video_VM.video_two_filename_no_dir = openFileDialog.SafeFileName;
                    MessageBox.Show(two_video_VM.video_two_filename);
                }
            }
        }
    }
}
