using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24hCheck
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32")]
        extern static UInt64 GetTickCount64();
        int timeUpPublic = 0;
        

        public Form1()
        {
            InitializeComponent();
            string timeMili = " ";
            ulong timeUp = (GetUpTimeMili() / (3600000));
            String czasLabel = " ";
            czasLabel = timeUp.ToString();
            int czasInt = System.Convert.ToInt32(czasLabel);
            timeUpPublic = czasInt;
            label2.Text = czasLabel;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //string timeMili = " ";
            ulong timeUp = (GetUpTimeMili() / (3600000)); // 1 godzina 3600000 - nie zmieniać, bo przelicznik
            String czasLabel = " ";
            czasLabel = timeUp.ToString();
            int czasInt = System.Convert.ToInt32(czasLabel);
            label2.Text = czasLabel;
            //czas po którym ma się pojawić komunikat o restarcie - wstaw 23 na dobę
            if(timeUp > 4) 
            {
                label3.Text = "Zrestartuj komputer, jeśli to możliwe";
            }
            Apps.starter();
            if(czasInt > 0)
            {
                //Form1().Visible(false);
                //Console.WriteLine("UpTime  " + czasInt);
            }
        }

        public static TimeSpan GetUpTime()
        {
            return TimeSpan.FromMilliseconds(GetTickCount64());
        }

        public static ulong GetUpTimeMili()
        {
            return GetTickCount64();
        }

        public static void timeChecker()
        {
            //Console.WriteLine("UpTime  " + GetUpTime());
            //Console.WriteLine("UpTime Hours " + (GetUpTimeMili() / 3600000));
        }

        public int upTimeActually()
        {
            return timeUpPublic;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("shutdown.exe", "-r -t 600");
            Form2 restartForm = new Form2();   // Create a new instance of the Form2 class
            // Show the settings form
            restartForm.Show();
        }
    }
}