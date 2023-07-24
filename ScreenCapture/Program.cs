using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using ReadPositionOfCoursor;
using SS;
using static ReadPositionOfCoursor.PositionCursor;

namespace ScreenCapture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nameOfPicture = "Screenshot";
            string fullDiskPath = "Full path ";   // Change before use. 
            POINT current_pos, prev_pos;
            List<POINT> coords = new List<POINT>();

            prev_pos.X = 0;
            prev_pos.Y = 0;

            do
            {
                if (GetCursorPos(out current_pos))
                {
                    System.Threading.Thread.Sleep(1000);
                    if ((current_pos.X != prev_pos.X) || (current_pos.Y != prev_pos.Y))
                    {
                        string combined = nameOfPicture + DateTime.Now;
                        combined = combined.Replace(".", "_");
                        combined = combined.Replace(" ", "_");
                        combined = combined.Replace(":", "_");
                        Bitmap btmp = ScreenCaptures.CaptureDesktop();
                        string fullPath = Path.Combine(fullDiskPath,combined + ".jpg");
                        btmp.Save(fullPath);
                        coords.Add(current_pos);
                    }

                    prev_pos.X = current_pos.X;
                    prev_pos.Y = current_pos.Y;
                }

            } while (!Console.KeyAvailable);
            Console.ReadKey();

            Console.WriteLine("Press any key to play the recorded mouse positions.");
        }
    }



   
}
