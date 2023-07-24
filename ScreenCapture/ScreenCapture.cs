using System.Runtime.InteropServices;
using System;
using System.Drawing;

//Installed System.Drawing.Common! (7.0.0)
namespace SS
{
    public class ScreenCaptures
    {
        // Import the required functions from the user32.dll library using DllImport attribute.

        // Get handle to the foreground window (currently active window).
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        // Get handle to the desktop window (representing the entire screen).
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);
        // Define the Rect struct to store window position and size information.
        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        // Get the window's dimensions and capture the entire desktop.
        public static Bitmap CaptureDesktop()
        {
            return CaptureWindow(GetDesktopWindow());
        }

        // Get the window's dimensions and capture the currently active window.
        public static Bitmap CaptureActiveWindow()
        {
            return CaptureWindow(GetForegroundWindow());
        }

        // Capture the window specified by its handle (hWnd).
        public static Bitmap CaptureWindow(IntPtr handle)
        {
            // Create a Rect struct to store window position and size.
            var rect = new Rect();
            // Use the Windows API function GetWindowRect to retrieve the window's dimensions.
            GetWindowRect(handle, ref rect);
            // Create a Rectangle object using the retrieved dimensions.
            var bounds = new Rectangle(rect.Left, rect.Top, 1940,1200);
            // Create a new Bitmap object to store the captured screenshot.
            var result = new Bitmap(bounds.Width, bounds.Height);

            // Use the Graphics class to draw on the Bitmap object and capture the window contents.
            using (var graphics = Graphics.FromImage(result))
            {
                // Use CopyFromScreen to copy the contents of the specified window to the Bitmap.
                // Point.Empty represents the source point (0,0) on the screen.
                graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
            }

            // Return the captured screenshot as a Bitmap.
            return result;
        }
    }
}