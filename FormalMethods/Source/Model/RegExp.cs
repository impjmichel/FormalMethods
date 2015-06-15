using System;

namespace Models
{
    class RegExp
    {
        string exp;

        public RegExp(string input)
        {
            exp = input;
        }

        public string getExp()
        {
            return exp;
        }

        public void setExp(string input)
        {
            exp = input;
        }

        public void toNDFA()
        {
            int length = exp.Length;


            for(int i = 0; i < length; i++)
            {
                Console.WriteLine(exp[i]);
            }
        }
    }
        
}
