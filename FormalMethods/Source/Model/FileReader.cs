using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Models
{
    class FileReader
    {
        private string alphabet;
        private string cleanedInput;
        private string line;
        private string[] lines;

        public FileReader()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "txt | *.txt";

            if(fd.ShowDialog() == DialogResult.OK)
            {
                string file = fd.FileName;

                try
                {
                    StreamReader sr = new StreamReader(file);
                    this.line = sr.ReadToEnd();                    
                }
                catch(Exception e)
                {
                    Console.WriteLine("file could not be read");
                    Console.WriteLine(e.Message);
                }

                this.lines = toCleanArray(this.line);
                
                this.cleanedInput = this.linesToString(this.lines);
                
                if (!checkAlphabet(this.alphabet))
                {
                    MessageBox.Show("This file doesn't contain an alphabet");
                }
            }            
        }

        public string getRawInput()
        {
            return this.line;
        }

        public string getAlphabet()
        {
            return this.alphabet;            
        }

        public string getInput()
        {
            return this.cleanedInput;
        }

        private string[] toCleanArray(string line)
        {            
            string[] inputLines = null;

            inputLines = line.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            inputLines = inputLines.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            this.alphabet = inputLines[0];
            inputLines = inputLines.Where(x => x != inputLines[0]).ToArray();

            return inputLines;
        }

        private string linesToString(string[] inputLines)
        {
            string newInput = "";

            for (int i = 0; i < inputLines.Length; i++)
            {
                newInput += inputLines[i] + Environment.NewLine;
            }
            return newInput;
        }       

        public bool checkAlphabet(string line)
        {
            if(line.Length > 1)
            {
                if(line.Contains(','))
                {
                    this.alphabet = line;
                    return true;                     
                }
                else
                {
                    return false;
                }
            }
            else
            {
                this.alphabet = line;
                return true;
            }            
        }

        public int getOption(string line)
        {
            int option = 0;

            if (this.lines.Length > 1)
            {
                option = 0;  //regGram
            }
            else if (this.lines.Length == 1)
            {
                option = 1; //regExp
            }

            return option;
        }

        public void loadDFA()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "txt | *.txt";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                string file = fd.FileName;

                try
                {
                    StreamReader sr = new StreamReader(file);
                    //line = sr.ReadToEnd();
                }
                catch (Exception e)
                {
                    Console.WriteLine("file could not be read");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
