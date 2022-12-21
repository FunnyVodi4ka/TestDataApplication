using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_demo_exam_04.ApplicationData
{
    public partial class FirstTable
    {
        public string CorrectImage
        {
            get
            {
                if(File.Exists(System.AppDomain.CurrentDomain.BaseDirectory+ "..\\..\\Resources\\UserImages\\" + ImageOfTable))
                {
                    return System.AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Resources\\UserImages\\" + ImageOfTable;
                }
                else
                {
                    return "..\\..\\Resources\\DefaultImage.png";
                }
            }
        }
    }
}
