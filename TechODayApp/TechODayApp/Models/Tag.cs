using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace TechODayApp.Models
{
    public class Tag
    {
        public Tag(string name) { Name = name; Color = GetRandomColor(); }

        public string Name { get; set; }

        public Color Color { get; set; }

        private Color GetRandomColor()
        {
            var random = new Random();

            int r, g, b;
            int tries = 25;

            do
            {
                r = random.Next(1, 256);
                g = random.Next(1, 256);
                b = random.Next(1, 256);
                tries -= 1;
            } while (IsAlmostBlack(r / 255, g / 255, g / 255) && tries > 0);
            

            return Color.FromArgb(r, g, b);
        }

        private static bool IsAlmostBlack(int red, int green ,int blue)
        {
            return red < 50 && green < 50 && blue < 50;
        }
    }
}
