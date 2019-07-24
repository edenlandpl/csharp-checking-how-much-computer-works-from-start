using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _24hCheck
{
    class Apps
    {
        [DllImport("kernel32")]
        extern static UInt64 GetTickCount64();

        public static void starter()
        {
            //Console.WriteLine("UpTime suchelec ");
        }
        public int CzasDzialania()
        {
            string timeMili = " ";
            ulong timeUp = (GetUpTimeMili() / (3600000));
            String czasLabel = " ";
            czasLabel = timeUp.ToString();
            int czasInt = System.Convert.ToInt32(czasLabel);
            return czasInt;
        }

        public static ulong GetUpTimeMili()
        {
            return GetTickCount64();
        }
    }
}
