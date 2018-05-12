using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NickGenerator.Properties;

namespace NickGenerator
{
    public partial class WorsForm : Form
    {
        public WorsForm()
        {
            InitializeComponent();
            getDictnionery();
        }

        List<string> combo1 = new List<string>();
        List<string> combo2 = new List<string>();

        private void textInPut_TextChanged(object sender, EventArgs e)
        {

        }

        private void textInPut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar == (int)Keys.Enter)
                Solution.Text = spell(textInPut.Text.Split(' '), ref combo1);
            
        }

        private void textInPut2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
                Solution2.Text = spell(textInPut2.Text.Split(' '), ref combo2);
            
        }

        private string spell(string[] słowa, ref List<string> combo)
        {
            string allT = "";
            foreach (string s in słowa)
            {
                List<string> sylaby = FindSylaby.AllSyllable(s);
                combo = sylaby;
                allT = listOfSylabyToATekstForm(sylaby);
            }
            return allT;
        }


        private string listOfSylabyToATekstForm(List<string> sylaby)
        {
            string tekst = "";
            string allT = "";
            foreach (string item in sylaby)
            {
                if (tekst == "")
                    tekst = $"{tekst}{item}";
                else
                    tekst = $"{tekst}-{item}";
            }
            if (allT == "")
                allT = allT + tekst;
            else
                allT = $"{allT} {tekst}";
            return allT;
        }

        private void WorsForm_Resize(object sender, EventArgs e)
        {
            if (this.Size.Height < 380)
            {
                if (this.Size.Width < 480)
                {
                    this.Size = new Size(480, 380);
                }
                else
                    this.Size = new Size(this.Size.Width, 380);
            }
            if (this.Size.Width < 480)
            {
                if (this.Size.Height < 380)
                    this.Size = new Size(480, 380);
                else
                    this.Size = new Size(480, this.Size.Width);
            }
        }

        private void ForceCheck_Click(object sender, EventArgs e)
        {
            if(this.ech)
            {
                getDictnionery();
            }
            if (this.combo1 == null || this.combo1.Count() == 0 )
            {
                Solution.Text = spell(textInPut.Text.Split(' '), ref this.combo1);   
            }
            if ( this.combo2 == null || this.combo2.Count() == 0)
            {
                Solution2.Text = spell(textInPut2.Text.Split(' '), ref this.combo2);
            }
            string tekst = string.Empty;
            List<string> l1 = new List<string>();
            List<string> toDictonaryBox = new List<string>();
  

            if (combo1 != null && combo2 != null)
            {
                if(combo1.Any() && combo2.Any())
                {
                    l1 = getAllNickName(combo1, combo2);
                    //l1.Add("\n");
                    l1.AddRange(getAllNickName(combo2, combo1));
                    int i = 1;
                    foreach (string item in l1)
                    {
                        if (checkWithD(item))
                        {
                            toDictonaryBox.Add(item);
                        }
                        
                        tekst += $"{item},";
                        if(tekst.Length > 60 *i)
                        {
                            tekst += "\n";
                            i++;
                        }
                    }

                }
            }

            //this.MixNick.Text = tekst;
            this.MixNick.DataSource = l1;
            this.Dictonery.DataSource = toDictonaryBox;
        
            
        }

        private List<KeyValuePair<char, string[]>> dc;
        bool ech = false;
        private void getDictnionery ()
        {
            string[] dic =  NickGenerator.Properties.Resources.odm.Split(new char[] {' ', ',', '\r', '\n'}).Where(e=> e != string.Empty).ToArray();
            if(dic.Count() <2)
            {
                ech = true;

            }
            this.dc = new List<KeyValuePair<char, string[]>>();
            foreach (var item in NickGenerator.Alfabet.Consonants)
            {
                try
                {
                    KeyValuePair<char, string[]> it = new KeyValuePair<char, string[]>(item, dic.Where(e => e[0] == item).Select(e => e.ToLower()).ToArray());
                    dc.Add(it);
                }
                catch
                {

                }
            }

            foreach (var item in NickGenerator.Alfabet.Vowel)
            {
                try
                {
                    KeyValuePair<char, string[]> it = new KeyValuePair<char, string[]>(item, dic.Where(e => e[0] == item).Select(e => e.ToLower()).ToArray());
                    dc.Add(it);
                }
                catch
                {

                }
            }

            



        }

        private bool checkWithD(string item)
        {
            if (dc.Exists(e => e.Key == item[0] && (e.Value.Contains(item))))
            {
                return true;
            }
            else
                return false;
        }
        private List<String> getAllNickName(List<String> cs1, List<String>cs2)
        {
            List<String> list = new List<string>();
            list.AddRange(cs1);
            list.RemoveAt(0);
            list.AddRange(cs2);

            List<String> end = new List<string>();

            int lenght;
            if (cs1.Count() > cs2.Count())
                lenght = cs1.Count();
            else
                lenght = cs2.Count();

            if (lenght > 1)
                for (int k = 2; k <= lenght; k++)
                {
                    var result = NickGenerator.MathFunc.GetPermutations(list, k - 1);
                    foreach (var item in result)
                    {
                        string line = cs1[0];
                        foreach (var item2 in item)
                        {
                            line = $"{line}{item2}";
                        }
                        end.Add(line);
                    }
                }
            //end.Add("koniec");
            return end;
        }
    }
}
