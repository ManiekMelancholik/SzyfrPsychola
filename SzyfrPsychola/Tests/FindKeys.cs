using System;
using System.Collections.Generic;
using System.Text;
using SzyfrPsychola.Windows;

namespace SzyfrPsychola.Tests
{
    public class FindKeys : TestClass
    {

        protected class Key
        {
            public char key;
            public string reprezentations;

            public Key(char k, string rep)
            {
                this.key = k;
                this.reprezentations = rep;
            }
        }
        private List<FindKeys.Key> keys;
        private FindCounterKeys FCK;
        public FindKeys() : base()
        {
            this.keys = new List<Key>();

        }

        private string tempField;
        private void FIND()
        {
            string TestStringA = "ABCDEFGHIJKLMNOPRSTUWYZ";
            string TestStringB = "abcdefghijklmnoprstuwyz";
            foreach (char c in TestStringA)
            {
                this.Test(c);
                this.keys.Add(new FindKeys.Key(c, tempField));
            }
            foreach (char c in TestStringB)
            {
                this.Test(c);
                this.keys.Add(new FindKeys.Key(c, tempField));
            }

        }
       
        public override bool Test(char c)
        {
            string tempString = "";
            for(int i = 0; i < LogicModule.GetInstance().LogicSize(); i++)
            {
                tempString += c;

            }

            tempField = LogicModule.GetInstance().TranslateText(tempString);

            return true;
        }
        public FindCounterKeys FIndAndDIsplay(bool display)
        {
            string TestStringA = "ABCDEFGHIJKLMNOPRSTUWYZ";
            this.FIND();

            List<char> kii = new List<char>();
            List<string> repps = new List<string>();
            foreach(Key key in this.keys)
            {
                kii.Add(key.key);
                repps.Add(key.reprezentations);

            }

            if (display)
            {
                KeysWIndow kw = new KeysWIndow(kii, repps, TestStringA.Length);
                kw.Show();
            }


            this.FCK= new FindCounterKeys();
            kii.Clear();
            repps.Clear();
            foreach (Key key in this.keys)
            {
                kii.Add(key.key);
                repps.Add(key.reprezentations);

            }


            FCK.FIndAndDIsplay(ref kii, ref repps, ref TestStringA, display);

            return this.FCK;
        }
    }
}
