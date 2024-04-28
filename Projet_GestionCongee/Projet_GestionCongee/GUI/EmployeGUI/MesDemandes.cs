using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_GestionCongee.GUI.EmployeGUI
{
    public partial class MesDemandes : Form
    {
        public MesDemandes()
        {
            InitializeComponent();
        }

      

     

        

        private void label5_Click(object sender, EventArgs e)
        {
            Home form2 = new Home();

            form2.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MesDemandes form2 = new MesDemandes();

            form2.Show();
            this.Hide();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            Login form2 = new Login();

            form2.Show();
            this.Hide();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            DemandePage form2 = new DemandePage();

            form2.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Compte form2 = new Compte();

            form2.Show();
            this.Hide();
        }
    }
}
