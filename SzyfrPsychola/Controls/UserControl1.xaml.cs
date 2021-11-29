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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SzyfrPsychola
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        private Hint hint;
        public UserControl1(ref Hint h)
        {
            InitializeComponent();
            this.hint = h;
            this.grid.Background = ColorControl.GetInstance().GetColor(0);
            DataContext = this.hint;
            this.button.Click += new RoutedEventHandler(Click);
        }
        public string save()
        {
            return hint.accessCode;
        }
        public void Click(object o, RoutedEventArgs e)
        {

            if (this.hint.Validate(this.inp.Text))
            //if (true)
            {

                int iterator = 0;
                foreach( Rectangle r in this.answer.Children)
                {

                    if (hint.chanellVals[iterator] == hint.colorChanel)
                        r.Fill = hint.color;

                    iterator++;
                }
            }
            else
            {
                MessageBox.Show("PODANY KOD JEST NIEPRAWIDŁOWY");
            }
        }
    }
}
