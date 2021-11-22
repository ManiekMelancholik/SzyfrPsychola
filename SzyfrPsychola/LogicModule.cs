using System;
using System.Collections.Generic;
using System.Text;

namespace SzyfrPsychola
{
    
    public class LogicModule
    {
        private interface ILogic
        {
            public abstract int Logic(int key, char c);
        }
        private class Logic1 : ILogic
        {
            public Logic1()
            {

            }
            public int Logic(int key, char c)
            {
                return (char)((int)c + key);
            }
        }
        private class Logic2 : ILogic
        {
            public Logic2()
            {

            }
            public int Logic(int key, char c)
            {
                return (char)((int)c -(2* key));
            }
        }
        private class Logic3 : ILogic
        {
            public Logic3()
            {

            }
            public int Logic(int key, char c)
            {
                return (char)((int)c - key);
            }
        }




        private static LogicModule instance;

        private String interpretatonTable;
        private String skipTable;
        private List<ILogic> logicList;
        private LogicModule(string s = null, string skilps = null)
        {
            if (s == null)
                s = "ABCDEFGHIJKLMNOPRSTUWYZ";
            if (skilps == null)
                skilps = ".<> ,;:-+=_!";
            this.interpretatonTable = s;
            this.skipTable = skilps;
            this.logicList = new List<ILogic>();
            this.logicList.Add(new Logic1());
            this.logicList.Add(new Logic2());
            this.logicList.Add(new Logic3());

        }

        public static ref LogicModule GetInstance(string s = null, string skip = null)
        {
            if(instance == null)
                instance = new LogicModule(s, skip);

            return ref instance;
        }

        public char interpretate(  int logicIndex, char c, int shift )
        {
            

            int x = this.logicList[logicIndex].Logic(CipherInfo.GetInstance().GetResultantSum((logicIndex * 2) % 5), c);



            return this.interpretatonTable[(x+shift) % interpretatonTable.Length];
        }

        public string TranslateText(string input, ref List<int> logicIndexes, bool way = true)
        {
            int shift = CipherInfo.GetInstance().GetResultantSumAll();
            string retString="";
            if (way)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (this.skipTable.Contains(input[i]))
                    {
                        retString += input[i];
                    }
                    else
                    {
                        retString += (char)interpretate(i % 3, input[i], shift*(i%3));
                    }
                }



            }
            

            return retString;

        }
        
        



    }
}
