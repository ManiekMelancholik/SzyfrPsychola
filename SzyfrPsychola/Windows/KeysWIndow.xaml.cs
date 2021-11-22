using System;
using System.Collections.Generic;
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
    /// Interaction logic for KeysWIndow.xaml
    /// </summary>
    public partial class KeysWIndow : Window
    {
        public KeysWIndow(List<char> c, List<string> repps, int N)
        {
            //int i = 0;
            string tempstring;
            InitializeComponent();
            
            for(int j = 0; j < c.Count/N; j++)
            {
                WrapPanel wrapPanel = new WrapPanel();
               // foreach (char ch in c)
                for(int i = 0; i<N; i++)
                {

                    tempstring = ("[ " + c[(j * 23) + i] + " reps: " + repps[(j * 23) + i] + " ]");
                    //i++;
                    //tempstring=((j*23)+i).ToString();
                    Label l = new Label();
                    l.Content = tempstring;
                    wrapPanel.Children.Add(l);
                }
                this.mainContent.Children.Add(wrapPanel);
                
            }

        }
        
    }
}
