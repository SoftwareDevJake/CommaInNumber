using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string number = textBox1.Text.ToString();
            List<char> organized_number = new List<char>();
            List<char> result = new List<char>();
            string final_result = string.Empty;

            int count = 0;
            bool check = false;
            bool negative = false;
            bool pointOver = false;
            string pointOverNum = string.Empty;


            for(int i = 0; i < number.Length; i++)
            {
                if(number[i] == '-' && i == 0)
                {
                    negative = true;
                    continue;
                }
                else if(number[i] == '0' && !check)
                {
                    continue;
                }
                else if(number[i] == '.')
                {
                    pointOver = true;
                }
                else
                {
                    if(pointOver)
                    {
                        pointOverNum += number[i];
                    }
                    else
                    {
                        check = true;
                        organized_number.Add(number[i]);
                    }
                }
            }

            for(int i = organized_number.Count - 1; i >= 0; i--)
            {
                count++;
                if(count % 3 == 0 && i != 0)
                {
                    result.Add(organized_number[i]);
                    result.Add(',');
                    continue;
                }
                result.Add(organized_number[i]);
            }
            
            if(organized_number.Count == 0)
            {
                final_result = "0";
            }
            else
            {
                for (int i = result.Count - 1; i >= 0; i--)
                {
                    final_result += result[i];
                }
            }
            
            if(negative)
            {
                final_result = "-" + final_result;
            }
            if(pointOver)
            {
                final_result += "." + pointOverNum;
            }

            Console.WriteLine(final_result);
            Console.WriteLine(pointOverNum);

            textBox2.AppendText(final_result);
            textBox2.AppendText("\r\n\n");
        }
    }
}
