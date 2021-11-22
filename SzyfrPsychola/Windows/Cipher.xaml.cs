using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SzyfrPsychola.Windows
{
    /// <summary>
    /// Interaction logic for Cipher.xaml
    /// </summary>
    public partial class Cipher : Window
    {
        private static Cipher instance = null;



        private Cipher(ref List<List<Button>> buttons)
        {
            InitializeComponent();



            //  ADD TO VIEW
            foreach (List<Button> list in buttons)
            {
                foreach (Button b in list)
                {
                    this.mainGrid.Children.Add(b);
                }
            }
            this.Closed += PseudoClose;
        }

        public static ref Cipher GetInstance(ref List<List<Button>> buttons)
        {
            instance = new Cipher(ref buttons);

            return ref instance;
        }

        public static void PseudoClose(object o, EventArgs e)
        {
            instance.mainGrid.Children.Clear();
            MainWindow.UnlockCipher();
        }

        public void ResertCipher(object o, RoutedEventArgs e)
        {
            CipherInfo.GetInstance().Reset();
        }

        
        

      
       
    }
}
