using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ReadPositionOfCoursor
{
    // Import necessary functions from the Windows user32.dll library.
    using System.Runtime.InteropServices;

    // Define an internal class to encapsulate cursor position manipulation.
    internal class PositionCursor
    {
        // Import the GetCursorPos function from user32.dll to get the current cursor position.

        // The [DllImport("user32.dll")] attribute tells the .NET runtime that this method
        // is implemented in the "user32.dll" library, which is a Windows system library
        // responsible for managing various user interface functions.

        // The method signature indicates that the function takes an "out" parameter, lpPoint,
        // of type POINT. The "out" keyword means that the parameter will be assigned a value
        // within the method and returned to the caller.
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        // Import the SetCursorPos function from user32.dll to set the cursor position.

        // The [DllImport("user32.dll")] attribute here indicates that this method is also
        // implemented in the "user32.dll" library.

        // The method signature shows that the function takes two integer parameters, X and Y,
        // which represent the new X and Y coordinates for the cursor's position.

        // The return type of the method is "bool," indicating whether the function call was
        // successful or not. If successful, it returns "true," and if there was an error,
        // it returns "false."
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);
    }

    // Define a struct to represent a point with X and Y coordinates.
    public struct POINT
    {
        public int X; // X coordinate of the point.
        public int Y; // Y coordinate of the point.
    }

    // Additional Information:

    // The "user32.dll" library contains various Windows API functions related to the user interface.
    // The GetCursorPos function is used to retrieve the current position of the cursor on the screen.
    // The SetCursorPos function is used to set the position of the cursor on the screen.

    // The POINT struct is used to represent a point with X and Y coordinates.
    // It is a simple data structure defined with two public integer fields, X and Y,
    // used to store the X and Y coordinates of a point.

    // The PositionCursor class acts as a wrapper for the GetCursorPos and SetCursorPos functions,
    // making it easier to use these functions in C# code.
    // By importing these functions from the "user32.dll" library, the C# code can directly call
    // these native Windows functions to interact with the cursor. This allows applications to perform
    // operations such as reading the cursor's position or programmatically moving the cursor on the screen.

    // Note: The class is marked as "internal," which means it is only accessible within the same assembly.
    // Therefore, it is typically intended for use within a specific project or module and not from external code.

}
