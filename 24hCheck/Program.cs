using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace _24hCheck
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        private static System.Timers.Timer aTimer;
        private static int takeUpTime;
        public static NotifyIcon icon;
        public static NotifyIcon icon1;
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            NotifyIcon icon = new NotifyIcon();
            using (icon)
            //using (NotifyIcon icon = new NotifyIcon())
            {
                icon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
                icon.ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Show form", (s, e) => {new Form1().Show();}),
                new MenuItem("Exit", (s, e) => { Application.Exit(); }),
                });
                icon.Visible = true;
                //icon.BalloonTipText = czasInt.ToString();
                //icon.BalloonTipText = "Hejo";
                //icon.ShowBalloonTip(500);
                iconTipShow(icon);
                SetTimer();
                Application.Run();
                icon.Visible = false;
            }
        }

        public static void iconTipShow(NotifyIcon icon)
        {
            //NotifyIcon icon1 = new NotifyIcon();
            //icon1 = icon;
            //icon.BalloonTipText = "Hejos";
            //icon.ShowBalloonTip(500);
        }

    // Funkja pobierająca czas działania komputera
    private static void SetTimer()
        {
            // Create a timer
            aTimer = new System.Timers.Timer(6000);    // czas pojawienia się okna 10 minut - 600000 
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        // akcje w czasie działania programu, jeśli powyżej 24 h pojawia się okno
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Apps czas = new Apps();
            //Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
            //                  e.SignalTime);
            takeUpTime = (czas.CzasDzialania());

            FormCollection fc = Application.OpenForms;  // tworzona jest form Collection z listą otwartych okien
            Console.WriteLine("FC przed " + fc);
            // sprawdzanie colection
            //foreach (Form frm in fc) 
            //{
            //    if (takeUpTime > 1)
            //    {
            //        if (frm.Text != "Form1")
            //        {
            //            Console.WriteLine("Volvo jest elementem kolekcji");
            //            Console.WriteLine("Czas UpTime Program " + takeUpTime);
            //            new Form1().Show();
            //            Application.Run();
            //        }
            //    }
            //    //Console.WriteLine("FRM " + frm);
            //    //Console.WriteLine("FC  " + fc);
            //}
            if (fc.Count < 1) // sprawdzenie czy otwarte już jest okno
            {
                System.Console.WriteLine("Brak okna, a fc -  " + fc.Count);
                // ilość godzin po których ma się poajwiać okienko informacyjne
                if (takeUpTime > 3)
                {
                    iconTipShow(icon);
                    ShowForm1();
                    System.Console.WriteLine("Jestem baloon -  " + fc.Count);
                }
            }
            else
            {
                System.Console.WriteLine("Mamy okna, a fc -  " + fc.Count);
                // tutaj wpisz aktywację okna, jeśli zostało zminimalizowane lub przykryte
            }
        }
        // uaktywnianie okna
        public static void ShowForm1()
        {
            new Form1().Show();
            //icon.ShowBalloonTip(500);
            Application.Run();
        }
    }
}