using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SzyfrPsychola.Windows;

namespace SzyfrPsychola
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Hint> hints;
        private List<UserControl1> controls;
        private CipherInfo cipher;
        private ColorControl colorCtrl;
        private static bool lockCipher = false;
        public MainWindow()
        {
            InitializeComponent();
            this.colorCtrl = ColorControl.GetInstance(Brushes.Gray, Brushes.Red, Brushes.Cyan, Brushes.LimeGreen);
            this.hints = new List<Hint>();
            this.controls = new List<UserControl1>();
            
            this.SetCipher.Click += new RoutedEventHandler(ShowCipher);
            this.decipher.Click+= new RoutedEventHandler(Decipher);
            Hint hint1 =new Hint("10101", " [Q||X->V] \n [Q||V->X] \n [X||V->Q]", colorCtrl.GetColor(1));
            Hint hint2 = new Hint("11002", " [Q||X->Q] \n [X||V->X] \n [V||Q->V]", colorCtrl.GetColor(2));
            Hint hint3 = new Hint("23005", " [X||Q->Q] \n [Q||V->V] \n [X||X->X]", colorCtrl.GetColor(3));
            
            UserControl1 UC1 = new UserControl1(ref hint1);
            UserControl1 UC2 = new UserControl1(ref hint2);
            UserControl1 UC3 = new UserControl1(ref hint3);


            controls.Add(UC1);
            controls.Add(UC2);
            controls.Add(UC3);

            Grid.SetRow(UC1, 0);
            Grid.SetRow(UC2, 1);
            Grid.SetRow(UC3, 2);
            //foreach(UserControl1 uc1 in controls)
            //{
            //    this.mainGrid.Children.Add(uc1);
            //}

            this.mainGrid.Children.Add(controls[0]);
            this.mainGrid.Children.Add(controls[1]);
            this.mainGrid.Children.Add(controls[2]);
            this.cipher = CipherInfo.GetInstance();
            
        }
        public void ShowCipher(object o, RoutedEventArgs e)
        {
            if (!lockCipher)
                CipherInfo.GetInstance().Show();
            lockCipher = true;

        }
        public static void UnlockCipher()
        {
            lockCipher = false;
        }

        public void Decipher(object o, RoutedEventArgs e)
        {
            if (inputBox.Text != "")
            {
                List<int> vs = new List<int>();
                for (int i =0; i<inputBox.Text.Length; i++)
                {
                    vs.Add(i % 3);
                }
                outputBox.Text = LogicModule.GetInstance().TranslateText(inputBox.Text, ref vs);
            }
        }
    }
}
