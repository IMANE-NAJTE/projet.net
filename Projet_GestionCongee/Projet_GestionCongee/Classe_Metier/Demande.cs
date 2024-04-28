using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_GestionCongee.Classe_Metier
{
    class Demande
    {
        // Attributs
        private int id;
        private DateTime date_debut;
        private DateTime date_fin;
        private DateTime date_demande;
        private string etat;
        private string certificat;
        gs_CongeeDataContext db;

        public Demande()
        {
            db = new gs_CongeeDataContext();
        }

        // Constructeur
        public Demande(int id, DateTime date_debut, DateTime date_fin, DateTime date_demande, string etat, string certificat)
        {
            this.id = id;
            this.date_debut = date_debut;
            this.date_fin = date_fin;
            this.date_demande = date_demande;
            this.etat = etat;
            this.certificat = certificat;

        }

        // Getters et Setters
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime DateDebut
        {
            get { return date_debut; }
            set { date_debut = value; }
        }

        public DateTime DateFin
        {
            get { return date_fin; }
            set { date_fin = value; }
        }

        public DateTime DateDemande
        {
            get { return date_demande; }
            set { date_demande = value; }
        }

        public string Etat
        {
            get { return etat; }
            set { etat = value; }
        }

        public string Certificat
        {
            get { return certificat; }
            set { certificat = value; }
        }

        public List<demande> GetAllDemandes()
        {
            return db.demande.ToList();
        }

        public demande GetDemandeById(int id)
        {
            return db.demande.FirstOrDefault(d => d.id == id);
        }


        public List<demande> GetDemandesByCondition(string etat)
        {
            return db.demande.Where(d => d.etat == etat).ToList();
        }

        public List<demande> GetDemandesBetweenDates(DateTime dateDebut, DateTime dateFin)
        {
            return db.demande.Where(d => d.date_d >= dateDebut && d.date_f <= dateFin).ToList();
        }

        public List<demande> GetDemandesBureauById(int bureauId)
        {
            // Effectuer une requête LINQ pour sélectionner les demandes appartenant au bureau spécifique
            var demandes = (from demande in db.demande
                            join personne in db.personne on demande.id_pers equals personne.id
                            where personne.id_B == bureauId
                            select demande).Take(1000).ToList();
            return demandes;
        }

    }
}
