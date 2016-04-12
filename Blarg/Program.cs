using SakuraBlue.Entities;
//using Megadrive;
using Omnicatz.AccessDenied;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Omnicatz.Helper;

namespace SakuraBlue {
    class Program {

        public const string GameTitle = "SakuraBlue";









    public  static GameState.GameStateBase currentState ;//= Singleton<GameState.Map>.GetInstance();

        public static char HexToChar(string hex)
        {
            return (char)ushort.Parse(hex, System.Globalization.NumberStyles.HexNumber);
        }
        static void Main(string[] args) {

       

            Console.Title = GameTitle;
            Console.OutputEncoding = UnicodeEncoding.UTF8;
         
            currentState = Singleton<GameState.Menu.TopMenu>.GetInstance();

    

            currentState.RunInitiate();

            makeBorderless();
            var width = Console.BufferWidth;//237
            var height = Console.BufferHeight;//67


            while (true) {
                currentState.RunRender();
                currentState.Update();
              
            }

         


        }

        #region window
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);

        [DllImport("USER32.DLL")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool DrawMenuBar(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        [DllImport("user32", ExactSpelling = true, SetLastError = true)]
        internal static extern int MapWindowPoints(IntPtr hWndFrom, IntPtr hWndTo, [In, Out] ref RECT rect, [MarshalAs(UnmanagedType.U4)] int cPoints);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetDesktopWindow();

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left, top, bottom, right;
        }

   
         private const int nIndex = -16;
         private const int dwNewLong = 0x00080000;
  

        static void makeBorderless()
        {
            IntPtr window = FindWindowByCaption(IntPtr.Zero, GameTitle);
            RECT rect;
            GetWindowRect(window, out rect);
            IntPtr hWndFrom = GetDesktopWindow();
            MapWindowPoints(hWndFrom, window, ref rect, 2);
            SetWindowLong(window, nIndex,dwNewLong);
            SetWindowPos(window, -2, 100, 75, rect.bottom, rect.right, 0x0040);
            DrawMenuBar(window);
            Process process = Process.GetCurrentProcess();
            Console.BufferHeight = Console.WindowHeight;
            ShowWindow(process.MainWindowHandle, 3);
            Console.CursorVisible = false;

        }
        #endregion
    }
}
