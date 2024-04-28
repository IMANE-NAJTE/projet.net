using Projet_GestionCongee.Classe_Metier;
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
    public partial class DemandePage : Form
    {

        private Personne GetPersonne(int id)
        {
            using (gs_CongeeDataContext db = new gs_CongeeDataContext())
            {
                var result = (from c in db.personne where c.id == id select c).FirstOrDefault();

                // Vérifier si une entité a été trouvée
                if (result != null)
                {
                    // Retourner l'entité sous forme de Personne
                    return new Personne
                    {
                        Nom = result.nom,
                        Prenom = result.prenom,
                        Email = result.email,
                        Password = result.password,
                        Grade = result.grade,

                        // Autres propriétés...
                    };
                }
                else
                {
                    // Aucune entité trouvée avec l'ID spécifié, retourner null ou une valeur par défaut selon vos besoins
                    return null;
                }
            }
        }


        public DemandePage()
        {
            InitializeComponent();

            int id = Personne.getId();
            Console.WriteLine("hhhhhh" + id);

            // Utilisation de l'id pour récupérer les détails de la personne
            var personne = GetPersonne(id);
            if (personne != null)
            {
                NomU.Text = personne.Nom + " " + personne.Prenom;
                Console.Write(personne.Nom + " " + personne.Prenom);
                NomU.Visible = true;
            }

        }

   

        private void label2_Click(object sender, EventArgs e)
        {

            DemandePage form2 = new DemandePage();

            form2.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

            MesDemandes form2 = new MesDemandes();

            form2.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

            Compte form2 = new Compte();

            form2.Show();
            this.Hide();
        }


        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

            Login form2 = new Login();

            form2.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

           Home form2 = new Home();

            form2.Show();
            this.Hide();
        }
    }
}

