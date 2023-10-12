using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMR_calc_Tarasov
{
    public partial class Form1 : Form
    {
        float bmr;
        int index_ = 1;
        bool isMale = true;
        public Form1()
        {

            InitializeComponent();
            label12.Text = label14.Text = label16.Text = label18.Text = label20.Text = "0";
            textBox1.Text = textBox2.Text = textBox3.Text = "0";

        }
        private float ValidateTexbox(string text)
        {
            float num;

            if (float.TryParse(text, out num))
            {
                //valid
                return num;
            }
            else
            {
                //invalid
                MessageBox.Show("Для ввода доступны только цифры");
                return 0;
            }
        }

        private void sum_btn_Click(object sender, EventArgs e)
        {

            float rost = ValidateTexbox(textBox1.Text);
            float ves = ValidateTexbox(textBox2.Text);
            float age = ValidateTexbox(textBox3.Text);

            

            if (isMale)
            {
                bmr = 66.0F + (13.7F * ves) + (5.0F * rost) - (6.8F * age);
                bmr /= 1000;
            }
            else
            {
                bmr = 655.0F + (9.6F * ves) + (1.8F * rost) - (4.7F * age);
                bmr /= 1000;
            }
            num_bmr.Text = Math.Round(bmr, 3).ToString();

            label12.Text = Math.Round(bmr*1.2, 3).ToString();
            label14.Text = Math.Round(bmr*1.375, 3).ToString();
            label16.Text = Math.Round(bmr*1.55, 3).ToString();
            label18.Text = Math.Round(bmr*1.725, 3).ToString();
            label20.Text = Math.Round(bmr*1.9, 3).ToString();
            
        }

        private void pictureBox_Info_Click(object sender, EventArgs e)
        {
            Level_act l = new Level_act();
            l.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            isMale = true;
            panel_male.BackColor = Color.White;
            panel_fem.BackColor = Color.Gray;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            isMale = false;
            panel_male.BackColor = Color.Gray;
            panel_fem.BackColor = Color.White;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            label12.Text = label14.Text = label16.Text = label18.Text = label20.Text  = "0";
            textBox1.Text = textBox2.Text = textBox3.Text = "0";
            num_bmr.Text = "0";
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            MessageBox.Show("Обратитесь в поддержку Microsoft по номеру: 8-800-555-3535", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Form1 f = new Form1();
            f.ShowDialog();
        }
    }
}
