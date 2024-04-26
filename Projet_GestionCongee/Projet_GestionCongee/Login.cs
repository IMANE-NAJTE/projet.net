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
            String n =email.Text;
            String p = password.Text;

            using (gs_CongeeDataContext db = new gs_CongeeDataContext())
            {
                // Exécuter une requête LINQ pour récupérer des données
                var result = from c in db.personne
                             where c.email == n
                             select c;

                // Parcourir les résultats
                foreach (var item in result)
                {
                    Console.WriteLine($"Colonne1: {item.nom}, Colonne2: {item.role}");
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
