using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_GestionCongee.GUI.AdminGUI
{
    public partial class HomeAdmin : Form
    {
        Classe_Metier.Demande d = new Classe_Metier.Demande();
        Classe_Metier.Personne p = new Classe_Metier.Personne();
        Classe_Metier.Departement b = new Classe_Metier.Departement();
        public HomeAdmin()
        {
            InitializeComponent();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void historique_Click(object sender, EventArgs e)
        {
            Historique F = new Historique();
            F.Show();
            this.Hide();

        }

        private void label16_Click(object sender, EventArgs e)
        {
            HomeAdmin F = new HomeAdmin();
            F.Show();
            this.Hide();
        }

        private void HomeAdmin_Load(object sender, EventArgs e)
        {
            
            total_p.Text = p.GetPersonnesFromDatabase().Count().ToString();
            labelrefuser.Text = d.GetDemandesByCondition("refuser").Count().ToString();
            label_encours.Text = d.GetDemandesByCondition("en attente").Count().ToString();
            label_accepter.Text = d.GetDemandesByCondition("accepter").Count().ToString();
            l_vente.Text = d.GetDemandesBureauById(5).Count().ToString();
            l_pr.Text = d.GetDemandesBureauById(6).Count().ToString();
            l_rh.Text = d.GetDemandesBureauById(7).Count().ToString();
            l_s.Text = d.GetDemandesBureauById(8).Count().ToString();
            l_f.Text = d.GetDemandesBureauById(9).Count().ToString();
            l_inf.Text = d.GetDemandesBureauById(10).Count().ToString();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Historique F = new Historique();
            F.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Historique F = new Historique();
            F.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Historique F = new Historique();
            F.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Historique.etatGlobale = "en cours";
            Historique F = new Historique();
            F.Show();
            this.Hide();
        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
