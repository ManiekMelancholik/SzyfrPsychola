using System;
using System.Collections.Generic;
using System.Text;
using SzyfrPsychola.Windows;

namespace SzyfrPsychola.Tests
{
    public class FindCounterKeys : TestClass
    {
        
        public class CounterKey
        {
            public char counterKey;
            public int chanel;
            public string keys;

            public CounterKey(char ck, string k, int chanel)
            {
                this.counterKey = ck;
                this.keys = k;
                this.chanel = chanel;
            }

        }
        Random random;
        protected List<CounterKey> counterKeys;

        public FindCounterKeys() : base()
        {
            this.counterKeys = new List<CounterKey>();
            this.random = new Random();
        }
        public override bool Test(char c)
        {
            return false;
        }

        private void FIND(ref List<char> keys, ref List<string> repps, ref string range)
        {
            //int iterator = 0;
            //i - chanel
            List<int> temp = new List<int>();
            string tempString = "";
            for (int chanell= 0; chanell < LogicModule.GetInstance().LogicSize(); chanell++)
            {
                foreach(char ct in range)
                {
                    temp=this.Search(ref repps, ct, chanell);
                    foreach(int index in temp)
                    {
                        tempString += keys[index];
                    }
                    this.counterKeys.Add(new CounterKey(ct, tempString, chanell));
                    tempString = "";
                    

                }
            }
        }
        private List<int> Search(ref List<string> repps, char counterKey, int channel)
        {
            List<int> tempList = new List<int>();
            for(int i = 0; i<repps.Count; i++)
            {
                if(repps[i][channel] == counterKey)
                {
                    tempList.Add(i);
                }
            }
            return tempList;
        }

        public void FIndAndDIsplay(ref List<char> keys, ref List<string> reppss, ref string range, bool display)
        {
            this.FIND(ref keys,ref reppss, ref range);

            List<char> kii = new List<char>();
            List<string> repps = new List<string>();
            foreach (CounterKey key in this.counterKeys)
            {
                kii.Add(key.counterKey);
                repps.Add(key.keys);

            }
            if (display)
            {
                KeysWIndow kw = new KeysWIndow(kii, repps, 23);
                kw.Show();
            }

        }
        public ref List<CounterKey> GetCK()
        {
            return ref this.counterKeys;
        }
        private char Cipher(char c, int ch)
        {
            char ret = '0';
            string skips = LogicModule.GetInstance().GetSkipTab();
            for(int i = 0; i < this.counterKeys.Count; i++)
            {
                if (skips.Contains(c))
                {
                    return ' ';
                }
                if(this.counterKeys[i].counterKey == c)
                {
                    if (counterKeys[i].chanel == ch)
                    {
                        if (counterKeys[i].keys.Length > 1)
                        {
                            ret = counterKeys[i].keys[(this.random.Next())%(counterKeys[i].keys.Length)];
                        }
                    }
                }
            }
            return ret;
        }
        public string CipherInfo(string s)
        {
            string tempStr = "";
            s = s.ToUpper();
            for(int i = 0; i< s.Length; i++)
            {
                tempStr += this.Cipher(s[i], i % LogicModule.GetInstance().LogicSize());
            }

            return tempStr;
        }
    }
}
