using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projet_GestionCongee.Classe_Metier
{
    class Departement
    {
        // Attributs
        private int id;
        private string nom;

        // Constructeur
        public Departement(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }

        // Getters et Setters
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
    }
}
