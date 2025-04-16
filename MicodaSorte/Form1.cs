using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicodaSorte
{
    public partial class Form1 : Form
    {
        int[] roleta;
        int[] ciclos;
        Label[] tela;
        Random r;
        public Form1()
        {
            InitializeComponent();
            roleta = new int[3];
            ciclos = new int[3];
            tela = new Label[] { label1, label2, label3 };
            r = new Random();
            for (int i = 0; i < roleta.Length; i++)
            {
                roleta[i] = r.Next(0, 10);
                Update(i);
            }
        }

        void Update(int i)
        {
            tela[i].Text = roleta[i].ToString();


        }

        private void btSpin_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ciclos.Length; i++)
            {
                ciclos[i] = r.Next(1, 21);
                tela[i].ForeColor = Color.Black;
            }
            btSpin.Enabled = false;
            tmrSpin.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tmrSpin_Tick(object sender, EventArgs e)
        {
            bool stop = true;
            for (int i = 0; i < ciclos.Length; i++)
            {
                if (ciclos[i] > 0)
                {
                    ciclos[i]--;
                    roleta[i]++;
                    if (ciclos[i] == 0)
                    {
                        tela[i].ForeColor = Color.Red;
                    }

                    if (roleta[i] == 10)
                    {
                        roleta[i] = 0;
                    }
                    Update(i);
                    stop &= false;
                }
                else
                {
                    stop &= true;
                }
            }
            if (stop)
            {
                tmrSpin.Enabled = false;
                btSpin.Enabled = true;
            }
            if (roleta[0] == roleta[1] && roleta[0] == roleta[2])
            {
                label1.ForeColor = Color.Green;
                label2.ForeColor = Color.Green;
                label3.ForeColor = Color.Green;
                txtBox.Text = "Você Venceu";
            }
            else
            {
                label1.ForeColor = Color.Red;
                label2.ForeColor = Color.Red;
                label3.ForeColor = Color.Red;
                txtBox.Text = "Você Perdeu";
            }
            if (!chbWins.Checked || (roleta[0] == roleta[1] && roleta[1] == roleta[2])) { 
                lbxLast.Items.Add($"{roleta[0]} - {roleta[1]} - {roleta[2]}");
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbxLast_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        List<string> jogadas;

        private void chbWins_CheckedChanged(object sender, EventArgs e)
        {
            if (chbWins.Checked)
            {
                jogadas = new List<string>();
                foreach (string item in lbxLast.Items)
                {
                    jogadas.Add(item);
                }
                lbxLast.Items.Clear();
                foreach (string item in jogadas)
                {
                    string[] nums = item.Split('-');
                    if (nums[0] == nums[1] && nums[1] == nums[2])
                        lbxLast.Items.Add(item);
                }

            }
            else
            {
                lbxLast.Items.Clear();
                foreach (string item in jogadas)
                {
                    lbxLast.Items.Add(item);
                }
            }
        }
    }
}


