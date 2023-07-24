using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using ReadPositionOfCoursor; // This is a reference to an external library.
using SS; // This is a reference to another external library.
using static ReadPositionOfCoursor.PositionCursor; // Importing a specific member from an external library.

namespace ScreenCapture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nameOfPicture = "Screenshot"; // Name for the screenshot files.
            string fullDiskPath = "//"; // Change this to the full disk path where the screenshots will be saved. 

            POINT current_pos, prev_pos; // Variables to store the current and previous cursor positions.
            List<POINT> coords = new List<POINT>(); // A list to store the cursor positions.

            prev_pos.X = 0;
            prev_pos.Y = 0;
            Console.WriteLine("Recording started");
            do
            {
               
                // Get the current cursor position using the external library function 'GetCursorPos'.
                if (GetCursorPos(out current_pos))
                {
                    System.Threading.Thread.Sleep(1000); // Pause the execution for 1000 milliseconds (1 second).

                    // Check if the cursor has moved since the last check.
                    if ((current_pos.X != prev_pos.X) || (current_pos.Y != prev_pos.Y))
                    {
                       
                        // Generate a unique file name for the screenshot based on the current timestamp.
                        string combined = nameOfPicture + DateTime.Now;
                        combined = combined.Replace(".", "_");
                        combined = combined.Replace(" ", "_");
                        combined = combined.Replace(":", "_");

                        // Capture the desktop screen and store it in a Bitmap object using the 'CaptureDesktop' method from the 'ScreenCaptures' class.
                        Bitmap btmp = ScreenCaptures.CaptureDesktop();

                        // Combine the full disk path and the generated filename to get the full path of the screenshot file.
                        string fullPath = Path.Combine(fullDiskPath, combined + ".jpg");

                        // Save the screenshot to the specified file path.
                        btmp.Save(fullPath,System.Drawing.Imaging.ImageFormat.Jpeg);

                        // Store the current cursor position in the 'coords' list.
                        coords.Add(current_pos);
                        Console.WriteLine("Snap saved");
                    }

                    // Update the previous cursor position to the current cursor position for the next iteration.
                    prev_pos.X = current_pos.X;
                    prev_pos.Y = current_pos.Y;
                }

            } while (!Console.KeyAvailable); // Continue capturing the cursor position until any key is pressed.

            Console.ReadKey(); // Wait for a key press before the program exits.

            Console.WriteLine("Press any key to play the recorded mouse positions.");
        }
    }
}