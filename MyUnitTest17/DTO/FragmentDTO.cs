using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnitTest17.DTO
{
    public class FragmentDTO
    {

        public String Text { get; set; }
        public enum VisibleField { All, Best, No };
        public enum MoodField { M_3, M_2, M_1, M_0, M1, M2, M3 };

        public VisibleField Visible { get; set; }
        public MoodField Mood { get; set; }
    }
}
