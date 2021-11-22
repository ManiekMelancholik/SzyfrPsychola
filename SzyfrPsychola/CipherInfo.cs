using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using SzyfrPsychola.Windows;

namespace SzyfrPsychola
{
    internal class CipherInfo
    {
        private static CipherInfo instance = null;


        private List<List<Button>> buttons;
        private int size;


        private CipherInfo()
        {
            size = 5;
            buttons = new List<List<Button>>();
            for (int i = 0; i < size; i++)
            {
                List<Button> list = new List<Button>();
                for (int j = 0; j < size; j++)
                {
                    Button b = new Button();
                    Grid.SetColumn(b, j);
                    Grid.SetRow(b, i);
                    b.Tag = 0;

                    b.Click += new RoutedEventHandler(BCLICK);
                    b.Background = Brushes.DarkGray;
                    list.Add(b);


                }
                buttons.Add(list);
            }
        }

        public static ref CipherInfo GetInstance()
        {
            if(instance == null)
                instance = new CipherInfo();
            return ref instance;
        }
        public int GetResultantSum(int index)
        {
            int retVal = 0;
            foreach (Button b in buttons[index])
            {
                retVal += (int)b.Tag;
            }
            return retVal;
        }
        public int GetResultantSumAll()
        {
            int retVal = 0;
            int index = 0;
            foreach (List<Button> list in buttons)
            {
                foreach (Button b in buttons[index])
                {
                    retVal += (int)b.Tag;
                }
                index++;
            }
            return retVal;
        }

        public void Show()
        {
            Cipher.GetInstance(ref buttons).Show();
        }

        public void Reset()
        {
            foreach (List<Button> list in buttons)
            {
                foreach (Button b in list)
                {
                    b.Tag=0;
                    b.Background=ColorControl.GetInstance().GetColor((int)b.Tag);
                }
            }
        }
        //  EVENTS
        public void BCLICK(object o, RoutedEventArgs e)
        {
            Button b = (Button)o;
            if ((int)b.Tag == 3)
            {
                b.Tag = 0;
            }
            else
            {
                int z = (int)b.Tag;
                z++;
                b.Tag = z;
            }
            b.Background = ColorControl.GetInstance().GetColor((int)b.Tag);

        }
    }
}
