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
    public partial class Historique : Form
    {

        gs_CongeeDataContext db;
        Classe_Metier.Demande d = new Classe_Metier.Demande();
        Classe_Metier.Personne p = new Classe_Metier.Personne();
        Classe_Metier.Departement b = new Classe_Metier.Departement();
        static int bureauId = -1;
        public Historique()
        {
            InitializeComponent();
            db = new gs_CongeeDataContext();
            tabledata.DataBindingComplete += tabledata_DataBindingComplete;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chercher_Click(object sender, EventArgs e)
        {
            // Récupérez le nom du bureau sélectionné
            string nomBureau = comBox.SelectedItem.ToString();
            if (nomBureau == "Tout")
            {
                bureauId = -1;
            }
            else
            {
                bureauId = b.GetIdByNom(nomBureau);
            }


            DataTable dataTable = GetDataFromDatabase();
            tabledata.DataSource = dataTable;

        }

        private void RemplirComboBoxBureaux()
        {
            // Récupérez les noms des bureaux à partir du modèle de données LINQ
            var Bureaux = b.GetBureauFromDatabase();

            comBox.Items.Add("Tout");
            // Ajoutez les noms des bureaux à la ComboBox
            foreach (var nomBureau in Bureaux)
            {
                comBox.Items.Add(nomBureau.nomB);
            }

            // Sélectionnez le premier élément par défaut si la ComboBox n'est pas vide
            if (comBox.Items.Count > 0)
            {
                comBox.SelectedIndex = 0;
            }
        }

        private void tabledata_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Vérifiez si la première ligne est la ligne d'en-tête
            if (tabledata.Rows.Count > 0 && tabledata.Rows[0].IsNewRow == false)
            {
                // Appliquer le style à chaque cellule de la ligne d'en-tête
                foreach (DataGridViewCell cell in tabledata.Rows[0].Cells)
                {
                    cell.Style.BackColor = Color.Green; // Fond vert
                    cell.Style.ForeColor = Color.White; // Texte blanc
                }
            }


        }

        public DataTable GetDataFromDatabase()
        {
            int nb_d = 0;
            List<demande> demandes;
            if (bureauId < 0)
            {
                // Effectuez une requête LINQ pour récupérer les données de la table Demande avec les noms de personne
                demandes = d.GetAllDemandes();
            }
            else
            {
                demandes = d.GetDemandesBureauById(bureauId);
            }
            DataTable table = new DataTable();
            table.Columns.Add("id", typeof(int)); // Colonne pour l'ID
            table.Columns.Add("date_d", typeof(DateTime)); // Colonne pour la date de début
            table.Columns.Add("date_f", typeof(DateTime)); // Colonne pour la date de fin
            table.Columns.Add("etat", typeof(string)); // Colonne pour l'état
            table.Columns.Add("certificat", typeof(string)); // Colonne pour le certificat
            table.Columns.Add("Le demandeur", typeof(string)); // Colonne pour le nom et le prénom de la personne
            table.Columns.Add("commentaire", typeof(string)); // Colonne pour le commentaire
            table.Columns.Add("date_demande", typeof(DateTime)); // Colonne pour la date de demande

            personne p_id;
            // Parcourez les résultats de la requête et ajoutez-les au DataTable
            foreach (var demande in demandes)
            {
                nb_d++;
                p_id = p.GetPersonneById(demande.id_pers);
                // Concaténez le nom et le prénom de la personne dans une seule chaîne
                string nom_prenom_personne = $"{p_id.nom} {p_id.prenom}";
                table.Rows.Add(demande.id, demande.date_d, demande.date_f, demande.etat, demande.certificat, nom_prenom_personne, demande.commentaire, demande.date_demande);
            }

            total.Text = nb_d.ToString();
            return table;

        }

        private void Historique_Load(object sender, EventArgs e)
        {
            RemplirComboBoxBureaux();
            DataTable dataTable = GetDataFromDatabase();
            tabledata.DataSource = dataTable;
        }
    }
}
