using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Attempt_3_Video_Player.Models
{
    public class Video
    {
        public Video() 
        {
            //get path
            //get framerate 
            //get resolution
        }

        public string Path;
        public TimeSpan Duration;
        public double frame_rate;
        public double proportion;
        public int num_ticks_per_frame;
        public int max_y;
        public int max_x;

        public void set_path(string new_path)
        {
            Path = new_path; 
        }

        public void set_proportion(double new_proportion)
        {
            proportion = new_proportion;   
        }

        public string get_path() { return Path; }

        public double get_proportion() { return proportion; }

        public int get_max_x() { return max_x; }
        public int get_max_y() { return max_y; }

    }
}
