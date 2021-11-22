using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace SzyfrPsychola
{
    public class ColorControl
    {
        private static ColorControl instance = null;
        private List<Brush> colors;
        private ColorControl(ref Brush colorA, ref Brush colorB, ref Brush colorC, ref Brush colorD) {

            colors = new List<Brush>();
            colors.Add(colorA);
            colors.Add(colorB);
            colors.Add(colorC);
            colors.Add(colorD);
        }
        public static ref ColorControl GetInstance(Brush colorA, Brush colorB, Brush colorC, Brush colorD)
        {
            if (instance == null)
                instance=new ColorControl(ref colorA, ref colorB, ref colorC, ref colorD);
            
            return ref instance;
        }
        public static ref ColorControl GetInstance()
        {
            return ref instance;
        }

        public Brush GetColor(int index)
        {
            return colors[index];
        }

    }
}
