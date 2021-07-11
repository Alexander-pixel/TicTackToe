using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tick_Tack_Toe
{
    public partial class Form1 : Form
    {
        string _lastText = String.Empty;
        int _counter = 0;

        public Form1()
        {
            InitializeComponent();

            button2.Click += new System.EventHandler(this.button1_Click);
            button3.Click += new System.EventHandler(this.button1_Click);
            button4.Click += new System.EventHandler(this.button1_Click);
            button5.Click += new System.EventHandler(this.button1_Click);
            button6.Click += new System.EventHandler(this.button1_Click);
            button7.Click += new System.EventHandler(this.button1_Click);
            button8.Click += new System.EventHandler(this.button1_Click);
            button9.Click += new System.EventHandler(this.button1_Click);

            this.Controls.Add(button1);
            this.Controls.Add(button2);
            this.Controls.Add(button3);
            this.Controls.Add(button4);
            this.Controls.Add(button5);
            this.Controls.Add(button6);
            this.Controls.Add(button7);
            this.Controls.Add(button8);
            this.Controls.Add(button9);
            this.Controls.Add(button10);
            this.Controls.Add(label1);

            label1.Visible = false;
            button10.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";

            label1.Text = "";
            label1.Visible = false;
            button10.Visible = false;
            _lastText = "";

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
        }

        private string GetText()
        {
            if (_lastText == "")
            {
                return "X";
            }
            else if (_lastText == "X")
            {
                return "0";
            }
            return "X";
        }

        public bool GetWinner()
        {
            try
            {
                // horizonal
                for (int i = 0; i < Controls.Count - 2; i += 3)
                {
                    if ((Controls[i].Text == Controls[i + 1].Text)
                        && (Controls[i + 2].Text == Controls[i].Text) && Controls[i].Text != "" && Controls[i+1].Text != "" && Controls[i+2].Text != "")
                    {
                        Console.WriteLine("horizontal");
                        return true;
                    }
                }

                // vertical 
                for (int i = 0; i < Controls.Count - 6; i++)
                {
                    if ((Controls[i].Text == Controls[i + 3].Text)
                        && (Controls[i].Text == Controls[i + 6].Text)
                        && ((Controls[i + 3].Text == Controls[i + 6].Text)) && Controls[i].Text != "" && Controls[i + 3].Text != "" && Controls[i + 6].Text != "")
                    {
                        Console.WriteLine("vertical");
                        return true;
                    }
                }

                if ((Controls[0].Text == Controls[4].Text)
                    && (Controls[4].Text == Controls[8].Text) && Controls[0].Text != "" && Controls[4].Text != "" && Controls[8].Text != "")
                {
                    Console.WriteLine("left");
                    return true;
                }

                if ((Controls[2].Text == Controls[4].Text)
                    && (Controls[4].Text == Controls[6].Text) && Controls[2].Text != "" && Controls[4].Text != "" && Controls[6].Text != "")
                {
                    Console.WriteLine("right");
                    return true;
                }

                return false;
            }
            catch(ArgumentOutOfRangeException exc)
            {
                MessageBox.Show(exc.Message);
            }

            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "")
            {
                ((Button)sender).Text = GetText();
                _lastText = GetText();

                _counter++;
            }

            if (_counter >= 5)
            {
                bool res = GetWinner();
                if (res)
                {
                    if (_lastText == "X")
                    {
                        label1.Text = "X is the winner.";
                        label1.Visible = true;
                        button10.Visible = true;

                    }
                    if (_lastText == "0")
                    {
                        label1.Text = "0 is the winner.";
                        label1.Visible = true;
                        button10.Visible = true;
                    }

                    _counter = 0;
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    button8.Enabled = false;
                    button9.Enabled = false;
                }
                else if (_counter > 8 && res == false)
                {
                    label1.Text = "Draw.";
                    
                    label1.Visible = true;
                    button10.Visible = true;

                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    button8.Enabled = false;
                    button9.Enabled = false;
                }
            }
        }
    }
}
