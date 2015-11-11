using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject
{
    class MessageOfTheDay
    {
        string split = "-----";
        string str = "";
        string updateTxt = "";
        string filePath;

        public MessageOfTheDay(string path)
        {
            filePath = path;
        }

        public void setMessage(string msg)
        {
            int index = updateTxt.IndexOf(split);

            if (index > 0)
                updateTxt = updateTxt.Substring(0, index);

            str = msg + "\n" + split + "\n" + updateTxt;
            System.IO.File.WriteAllText(filePath, str);
            updateTxt = str;
            //Label1.Text = updateTxt;


        }
        public string getMessage()
        {
            string txt = "";

            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Equals("-----"))
                    {
                        break;
                    }
                    txt += line + "\n";
                }
                reader.Close();
            }
            return txt;

        }
    }
}
