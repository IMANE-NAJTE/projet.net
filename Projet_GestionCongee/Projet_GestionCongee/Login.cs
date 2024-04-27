using Projet_GestionCongee.GUI.AdminGUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Projet_GestionCongee
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

      private void button1_Click(object sender, EventArgs e)
{
    String n = email.Text;
    String p = password.Text;

    using (gs_CongeeDataContext db = new gs_CongeeDataContext())
    {
        if (string.IsNullOrEmpty(n) || string.IsNullOrEmpty(p))
        {
            message.Text = "Il faut remplir tous les champs";
            message.Visible = true;
        }
        else
        {
            var result = (from c in db.personne where c.email == n && c.password == p select c).FirstOrDefault();

            if (result != null)
            {
                message.Visible = false;

                // Tu peux accéder aux propriétés de "result" ici
                int id = result.id;
                string role = result.role;

                if (role == "admin")
                {
                            AdminHome F =new  AdminHome();
                            F.Show();
                            this.Hide();
                        }
                else
                {
                            DemandePage form2 = new DemandePage();

                            form2.Show();
                            this.Hide();
                }

                
                
            }
            else
            {
                MessageBox.Show("Email ou mot de passe invalide");
            }
        }
    }
}

      








        // Parcourir les résultats


    }
        }


