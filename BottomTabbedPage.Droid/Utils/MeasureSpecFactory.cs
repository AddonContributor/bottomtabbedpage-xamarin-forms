/*
* Complying with Apache Licence Version 2.0 that the original version of this 
* has been distributed I declare herewith that this file has been modified by
* me, Marc Lohrer.
* 
* I changed the namespace.
*/

using Android.Views;

namespace Naxam.Controls.Droid
{
    internal static class MeasureSpecFactory
    {
        public static int GetSize(int measureSpec)
        {
            const int modeMask = 0x3 << 30;
            return measureSpec & ~modeMask;
        }

        // Literally does the same thing as the android code, 1000x faster because no bridge cross
        // benchmarked by calling 1,000,000 times in a loop on actual device
        public static int MakeMeasureSpec(int size, MeasureSpecMode mode)
        {
            return size + (int)mode;
        }
    }
}