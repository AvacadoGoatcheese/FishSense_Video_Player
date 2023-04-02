using Microsoft.Win32;
using MVVM_Attempt_3_Video_Player.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
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

                    var resolution = return_resolution(openFileDialog.FileName);
                    double framerate = return_framerate(openFileDialog.FileName);
                    //MessageBox.Show("Resolution is: " + resolution[0].ToString() + " " + resolution[1].ToString() + " Framerate: " + framerate.ToString());
                    one_video_VM.framerate = framerate;
                    one_video_VM.resolution_width = resolution[0];
                    one_video_VM.resolution_height= resolution[1];
                }
                else if (current_video == whichVM.TWOVIDEOS_FIRST)
                {
                    two_video_VM.video_one_filename = openFileDialog.FileName;

                    var resolution = return_resolution(openFileDialog.FileName);
                    double framerate = return_framerate(openFileDialog.FileName);

                    //MessageBox.Show("Resolution is: " + resolution[0].ToString() + " " + resolution[1].ToString() + " Framerate: " + framerate.ToString());
                    two_video_VM.framerate_1 = framerate;
                    two_video_VM.resolution_height_1 = resolution[0];
                    two_video_VM.resolution_width_1 = resolution[1];
                }
                else if (current_video == whichVM.TWOVIDEOS_SECOND)
                {
                    two_video_VM.video_two_filename = openFileDialog.FileName;
                   
                    var resolution = return_resolution(openFileDialog.FileName);
                    double framerate = return_framerate(openFileDialog.FileName);

                    //MessageBox.Show("Resolution is: " + resolution[0].ToString() + " " + resolution[1].ToString() + " Framerate: " + framerate.ToString());
                    two_video_VM.framerate_2 = framerate;
                    two_video_VM.resolution_height_2 = resolution[0];
                    two_video_VM.resolution_width_2 = resolution[1];
                }
            }
        }

        public double return_framerate(string file_path)
        {
            double framerate = 0.0;
            // https://trac.ffmpeg.org/wiki/FFprobeTips#FrameRate gave the command to return frame rate
            string cmd_framerate = "/c ffprobe -v error -select_streams v:0 -show_entries stream=avg_frame_rate -of default=noprint_wrappers=1:nokey=1 " + file_path;
            
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = cmd_framerate;
            string cmd_framerate_output = "!";
            string cmd_resolution_output = "!";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            process.Start();

            while (!process.StandardOutput.EndOfStream)
            {
                cmd_framerate_output = process.StandardOutput.ReadLine();
                //MessageBox.Show(cmd_framerate_output);
            }
            process.Close();
    
            string framerate_numerator = "";
            string framerate_denominator = "";
            if (cmd_framerate_output != "!" && cmd_framerate_output != null)
            {
                int i = 0;
                for (i = 0; i < cmd_framerate_output.Length; i++)
                {
                    if (cmd_framerate_output[i] != '/')
                    {
                        framerate_numerator += cmd_framerate_output[i];
                    }
                    else
                    {
                        break;
                    }
                }

                for (int j = i + 1; j < cmd_framerate_output.Length; j++)
                {
                    framerate_denominator += cmd_framerate_output[j];
                }

                framerate = Convert.ToDouble(framerate_numerator) / Convert.ToDouble(framerate_denominator);
            }
            else
            {
                //MessageBox.Show("There was an issue calculating your framerate for the video. Please confirm you have ffprobe/ffmpeg installed. If the problem still persists, please contact a8ghosh@ucsd.edu.");
            }
            return framerate;
        }

        public List<Int32> return_resolution(string file_path)
        {
            var resolution = new List<Int32>();
            string cmd_resolution = "/c ffprobe -v error -select_streams v:0 -show_entries stream=height,width -of csv=s=x:p=0 " + file_path;
            string cmd_resolution_output = "!";


            Process process = new Process();

            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.Arguments = cmd_resolution;

            process.Start();

            while (!process.StandardOutput.EndOfStream)
            {
                cmd_resolution_output = process.StandardOutput.ReadLine();
                //MessageBox.Show(cmd_resolution_output);
            }

            //processing resolution from string format widthxheight 
            if (cmd_resolution_output != "!" && cmd_resolution_output != null)
            {
                int i = 0;
                string storing_res_width = "";

                for (i = 0; i < cmd_resolution_output.Length; i++)
                {
                    if (cmd_resolution_output[i] != 'x')
                    {
                        storing_res_width += cmd_resolution_output[i];
                    }
                    else
                    {
                        break;
                    }
                }
                int j = i;
                string storing_res_height = "";
                for (j = i + 1; j < cmd_resolution_output.Length; j++)
                {
                    storing_res_height += cmd_resolution_output[j];
                }

                resolution.Add(Convert.ToInt32(storing_res_width));
                resolution.Add(Convert.ToInt32(storing_res_height));
            }
            process.Close();

            return resolution;
        }
    }
}
