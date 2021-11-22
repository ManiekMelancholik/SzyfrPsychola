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

        public void Click(object o, RoutedEventArgs e)
        {

            if (this.hint.Validate(this.inp.Text))
            {
                this.textBlock.Text = hint.messeage;
                this.textBlock.Foreground = hint.color;
            }
            else
            {
                this.textBlock.Text = hint.output;
                this.textBlock.Foreground = Brushes.DarkOrange;
            }
        }
    }
}
