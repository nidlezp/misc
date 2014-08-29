using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            /*
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * */
            //ProcessTitle("D1 A2 D1 B4 A1 C6 B7 C8");
            ProcessTitle("1996 Ford Mustang GT Convertible, 5-Speed! Runs Great! Must See!! For Sale 1989 Mustang 5 speed 5.0 LX Convertible 1966 ford f100 straight body all new 5-speed Taurus SHO 1993 jeep wrangler READ AD PLEASE");
            //ProcessTitle("1989 Jeep Wrangler YJ 5 speed Jeep");
            string filePath = "C:\\Users\\pzeldin\\Documents\\Visual Studio 2010\\Projects\\WebApplication1\\WebApplication1\\CL\\index.htm";
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.OptionFixNestedTags = true;
            htmlDoc.Load(filePath);

            if (htmlDoc.ParseErrors != null && htmlDoc.ParseErrors.Count() > 0)
            {
                // Handle any parse errors as required
            }
            else
            {
                if (htmlDoc.DocumentNode != null)
                {
                    HtmlAgilityPack.HtmlNode bodyNode = htmlDoc.DocumentNode.SelectSingleNode("//body");
                    if (bodyNode != null)
                    {
                        // Do something with bodyNode
                    }
                }
            }
        }

        private void ProcessTitle(string title)
        {
            try
            {

                string[] stringSeparators = new string[] { " " };
                string[] words = title.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                Array.Sort(words, StringComparer.InvariantCultureIgnoreCase);

                Dictionary<string, int> map = new Dictionary< string, int>();
                foreach (string word in words)
                {
                    if (map.ContainsKey(word))
                    {
                        map[word]++;
                    }
                    else
                    {
                        map.Add(word, 1);
                    }
                    //Console.Write("hello");
                }
                foreach (KeyValuePair<string, int> entry in map.OrderByDescending(x => x.Value).ThenBy(x=>x.Key))
                {
                    Console.WriteLine(entry.Key + " " + entry.Value);
                }
                //map.OrderByDescending(o => o.Key);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }
    }
}
