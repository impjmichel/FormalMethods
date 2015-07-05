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
        public string getFileContent()
        {
            string line = null;
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "txt | *.txt";

            if(fd.ShowDialog() == DialogResult.OK)
            {
                string file = fd.FileName;

                try
                {
                    StreamReader sr = new StreamReader(file);
                    line = sr.ReadToEnd();                    
                }
                catch(Exception e)
                {
                    Console.WriteLine("file could not be read");
                    Console.WriteLine(e.Message);
                }
                return deleteEmpty(line);
            }
            else
            {
                return null;
            }
            
        }

        private string deleteEmpty(string line)
        {
            string newInput = "";
            string[] lines = line.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            lines = lines.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            for (int i = 0; i < lines.Length; i++)
            {
                newInput += lines[i] + Environment.NewLine;
            }

            return newInput;
        }

        public int getOption(string line)
        {
            int option = 0;
            string[] lines = line.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            if (lines.Length > 1)
            {
                option = 0;  //regGram
            }
            else if (lines.Length == 1)
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
