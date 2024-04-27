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
    public partial class AdminHome : Form
    {
        

        public Historique Historique { get; }
       
        
        public AdminHome()
        {
            InitializeComponent();
            InitializeComponent();
            Historique = new Historique();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // Assurez-vous que la propriété Historique est initialisée
            if (Historique != null)
            {
                // Rendez le formulaire Historique subordonné au formulaire principal
                Historique.TopLevel = false;
                // Supprimez les bordures du formulaire Historique
                Historique.FormBorderStyle = FormBorderStyle.None;
                // Remplissez le formulaire Historique dans le Panel
                Historique.Dock = DockStyle.Fill;
                // Effacez le contenu précédent du Panel
                con.Controls.Clear();
                // Ajoutez le formulaire Historique au Panel
                con.Controls.Add(Historique);
                // Affichez le formulaire Historique
                Historique.Show();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
