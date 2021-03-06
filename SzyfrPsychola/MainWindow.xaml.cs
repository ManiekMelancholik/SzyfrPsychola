using System;
using System.Collections.Generic;
using System.IO;
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
using SzyfrPsychola.Tests;
using SzyfrPsychola.Windows;

namespace SzyfrPsychola
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool logedIn;
        private List<Hint> hints;
        private List<UserControl1> controls;
        private CipherInfo cipher;
        private ColorControl colorCtrl;
        private static bool lockCipher = false;
        public MainWindow()
        {
            InitializeComponent();
            this.logedIn = false;
            this.colorCtrl = ColorControl.GetInstance(Brushes.Gray, Brushes.Red, Brushes.Cyan, Brushes.LimeGreen);
            this.hints = new List<Hint>();
            this.controls = new List<UserControl1>();

            this.SetCipher.Click += new RoutedEventHandler(ShowCipher);
            this.decipher.Click += new RoutedEventHandler(Decipher);
            //this.ShowKeys.Click+= new RoutedEventHandler(GetKeys);
            this.LogiIn.Click += new RoutedEventHandler(LOGIN);
            this.LogOut.Click += new RoutedEventHandler(LOGOUT);
            this.Save.Click += new RoutedEventHandler(SAVE);
            List<string> UCPasswords=new List<string>();
            using (StreamReader sr = new StreamReader("appInfo.xml"))
            {
                string line=sr.ReadLine();
                while (line != null)
                {
                    UCPasswords.Add(line);
                    line = sr.ReadLine();
                }


            }
            if(UCPasswords.Count>=3)
            for(int i =0; i<3; i++)
            {
                    if (UCPasswords[i] == "")
                    {
                        UCPasswords[i] = "---EMPTY---";
                    }
            }

            List<int> vals = new List<int>();
            for (int i = 3; i < UCPasswords.Count; i++)
            {
                vals.Add(int.Parse(UCPasswords[i]));
            }
            
            

            Hint hint1 = new Hint(UCPasswords[0], " [Q||X->V] \n [Q||V->X] \n [X||V->Q]", colorCtrl.GetColor(1),1,vals);
            Hint hint2 = new Hint(UCPasswords[1], " [Q||X->Q] \n [X||V->X] \n [V||Q->V]", colorCtrl.GetColor(2),2,vals);
            Hint hint3 = new Hint(UCPasswords[2], " [X||Q->Q] \n [Q||V->V] \n [X||X->X]", colorCtrl.GetColor(3),3,vals);

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
            if (this.logedIn)
            {
                if (this.decipherInput.Text.Length > 0)
                {
                    FindKeys fk = new FindKeys();
                    FindCounterKeys CK = fk.FIndAndDIsplay(false);
                    //inputBox.Text = CK.CipherInfo(decipherInput.Text);
                    outputBox.Text = CK.CipherInfo(decipherInput.Text);
                    
                }
            }
            else
            {
                if (inputBox.Text != "")
                {
                    outputBox.Text = LogicModule.GetInstance().TranslateText(inputBox.Text);
                }
            }
            
        }
        public void GetKeys(bool b=false)
        {
            FindKeys fk = new FindKeys();
            fk.FIndAndDIsplay(b);
        }
        public void LOGIN(object o, RoutedEventArgs e)
        {
            if (!this.logedIn)
            {
                if(this.login.Text == "ADMIN_RB")
                {
                    if (this.password.Text == "2137")
                    {
                        this.logedIn = true;
                        this.Save.Visibility = Visibility.Visible;
                        this.hidenInput.Visibility = Visibility.Visible;
                       //this.GetKeys(true);
                    }
                }
            }
        }
        public void LOGOUT(object o, RoutedEventArgs e)
        {
            if (this.logedIn)
            {
                this.logedIn = false;
                this.Save.Visibility = Visibility.Hidden;
                this.hidenInput.Visibility = Visibility.Hidden;
                this.login.Text = "";
                this.password.Text = "";
            }
        }
        public void SAVE(object o, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("appInfo.xml"))
            {
               
                List<string> list = new List<string>();
                foreach (UserControl1 uc in controls) {
                    if (uc.inp.Text.Length > 0)
                    {
                        list.Add(uc.inp.Text);
                    }
                    else
                    {
                        list.Add(uc.save());
                    }
                }
                foreach(string s in list)
                {
                    sw.WriteLine(s);
                }
                foreach (int i in cipher.GetKeyMatrix())
                {
                    sw.WriteLine(i);
                }
                
            }
            using (StreamWriter sw = new StreamWriter("TEXT.txt"))
            {
                if (this.outputBox.Text.Length > 0)
                    sw.WriteLine(this.outputBox.Text);
            }
        }

        
    }
}
