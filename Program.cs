using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualDesktop;

namespace BetterVirtualDesktops
{
    internal class Program
    {

        public static void Main(string[] args) 
        {
            HotKeyManager.RegisterHotKey(Keys.Up, KeyModifiers.Control | KeyModifiers.Windows);
            //HotKeyManager.RegisterHotKey(Keys.Down, KeyModifiers.Control | KeyModifiers.Windows);

            HotKeyManager.HotKeyPressed += (obj, args) =>
            { 
                switch (args.Key) 
                {
                    case Keys.Up: 
                    {
                        SwapDesktop();
                        break;
                    }
                    case Keys.Down:
                    {
                        
                        break;
                    }
                }
            };

            Thread.Sleep(-1);
        }


        public static void SwapDesktop()
        {
            try
            {
                //DesktopHelper.SetLockForWindowsOnMonitor(@"\\.\DISPLAY3");
                var desktop = GetNextDesktop();
                
                if ((Control.MouseButtons & MouseButtons.Left) != 0)
                    desktop.MoveActiveWindow();
                
                desktop.MakeVisible();
            }
            catch (Exception e)
            { 
                Console.WriteLine(e);
            }
        }
        
        public static Desktop CurrentDesktop => Desktop.FromIndex(Desktop.FromDesktop(Desktop.Current));
        
        public static Desktop GetNextDesktop()
        {
            int desktopCount = Desktop.Count;
            int visibleDesktop = Desktop.FromDesktop(VirtualDesktop.Desktop.Current);

            // round robin desktops
            int target = (visibleDesktop + 1) % desktopCount; 
            
            return VirtualDesktop.Desktop.FromIndex(target);
        }
    }
}