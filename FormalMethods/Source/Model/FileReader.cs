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
            }
            return line;
        }

        
    }
}
