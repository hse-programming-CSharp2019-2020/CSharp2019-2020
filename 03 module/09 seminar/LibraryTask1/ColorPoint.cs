using System;

namespace LibraryTask1
{
    public class ColorPoint
    {
        public static string[] colors = { "Red", "Green", "DarkRed", "Magenta", "DarkSeaGreen",
            "Lime", "Purple", "DarkGreen", "DarkOrange", "Black", "BlueViolet", "Crimson",
            "Gray", "Brown", "CadetBlue" }; // так делать нельзя!!!
        public double x, y; // так делать нельзя!!!
        public string color; // так делать нельзя!!!
        public new string ToString()
        {
            string format = "{0:F3} {1:F3} {2}";
            return string.Format(format, x, y, color);
        }

        public static ColorPoint GetObj(string s)
        {
            ColorPoint colorPoint = new ColorPoint();

            string[] str = s.Split();

            colorPoint.x = double.Parse(str[0]);
            colorPoint.y = double.Parse(str[1]);
            colorPoint.color = str[2];

            return colorPoint;
        }
    }
}
