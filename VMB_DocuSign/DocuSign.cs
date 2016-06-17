using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class DocuSign : Form
    {
        private bool hot = false;
        public bool cold = false;
        private bool footwear = false;
        private bool headwear = false;
        private bool socks = false;
        private bool shirt = false;
        private bool jacket = false;
        private bool pants = false;
        private bool isitfirst = true;

        public DocuSign()
        {
            InitializeComponent();
        }

        private bool control (int act)
        {
            // Pajamas must be taken off before anything else can be put on
            if (isitfirst && act != 8)
                return false;
            isitfirst = false;

            // Only 1 piece of each type of clothing may be put on
            if ((footwear && act == 1) || (headwear && act == 2) || (socks && act == 3) || (shirt && act == 4)
              || (jacket && act == 5) || (pants && act == 6))
                return false;

            // You cannot put on socks when it is hot
            // You cannot put on a jacket when it is hot
            if (hot && (act == 3 || act == 5))
                return false;

            // Socks must be put on before shoes
            if (act == 1 && !socks)
                return false;

            // Pants must be put on before shoes
            if (act == 1 && !pants)
                return false;

            // The shirt must be put on before the headwear or jacket
            if ((act == 2 || act == 5) && !shirt)
                return false;

            // You cannot leave the house until all items of clothing are on (except socks and a jacket when it’s hot)
            if (act == 7 && cold && (!footwear || !headwear || !socks || !shirt || !jacket || !pants))
                return false;
            if (act == 7 && hot && (!footwear || !headwear || !shirt || !pants))
                return false;

            return true;
        }

        private void fail()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            radioButton2.Enabled = false;
            radioButton1.Enabled = false;
            if(isitfirst)
                textBox1.Text += "fail";
            else
                textBox1.Text += ", fail";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!hot && !cold)
                return;
            
            if (control(1))
            {
                if(hot)
                    textBox1.Text += ", sandals";
                else
                    textBox1.Text += ", boots";
            }
            else
                fail();
            footwear = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!hot && !cold)
                return;

            if (control(2))
            {
                if (hot)
                    textBox1.Text += ", sun visor";
                else
                    textBox1.Text += ", hat";
            }
            else
                fail();
            headwear = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!hot && !cold)
                return;

            if (control(3))
            {
                textBox1.Text += ", socks";
            }
            else
                fail();
            socks = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!hot && !cold)
                return;

            if (control(4))
            {
                if (hot)
                    textBox1.Text += ", t-shirt";
                else
                    textBox1.Text += ", shirt";
            }
            else
                fail();
            shirt = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!hot && !cold)
                return;

            if (control(5))
            {
                textBox1.Text += ", jacket";
            }
            else
                fail();
            jacket = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!hot && !cold)
                return;

            if (control(6))
            {
                if (hot)
                    textBox1.Text += ", shorts";
                else
                    textBox1.Text += ", pants";
            }
            else
                fail();
            pants = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!hot && !cold)
                return;

            if (control(7))
            {
                textBox1.Text += ", leaving house";
            }
            else
                fail();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!hot && !cold)
                return;

            if (control(8))
                textBox1.Text += "Removing PJs";
            else
                fail();
        }
        private void button9_Click_1(object sender, EventArgs e)
        {
            //Reset everything
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;

            

            radioButton2.Enabled = true;
            radioButton2.Checked = false;

            radioButton1.Enabled = true;
            radioButton1.Checked = false;

            footwear = false;
            headwear = false;
            socks = false;
            shirt = false;
            jacket = false;
            pants = false;
            textBox1.Text = "";
            isitfirst = true;

            //to be sure it has restarted above code is not necessary
            Application.Restart();
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            radioButton2.Enabled = false;
            hot = true;
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            radioButton1.Enabled = false;
            cold = true;
        }
    }
}
