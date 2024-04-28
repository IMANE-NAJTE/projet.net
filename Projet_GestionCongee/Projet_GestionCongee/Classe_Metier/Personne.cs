using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_GestionCongee.Classe_Metier
{
    public class Personne
    {
        // Attributs
        private string nom;
        private string prenom;
        static private int id;
        private string role;
        private string email;
        private string password;
        private DateTime date_debut;
        private string grade;

        private gs_CongeeDataContext db;

        public Personne()
        {
            db = new gs_CongeeDataContext();
        }

        // Constructeur
        public Personne(string nom, string prenom, int id, string role, string email, string password, DateTime date_debut, string grade)
        {
            this.nom = nom;
            this.prenom = prenom;
            Personne.id = id;
            this.role = role;
            this.email = email;
            this.password = password;
            this.date_debut = date_debut;
            this.grade = grade;
        }

        // Getters et Setters
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        static public int getId()
        {
            return id;
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public DateTime DateDebut
        {
            get { return date_debut; }
            set { date_debut = value; }
        }

        public string Grade
        {
            get { return grade; }
            set { grade = value; }
        }


        public List<personne> GetPersonnesFromDatabase()
        {
            return (from p in db.personne select p).ToList();
        }

        public List<personne> GetPersonnesByRole(string role)
        {
            return (from p in db.personne where p.role == role select p).ToList();
        }

        public personne GetPersonneById(int id)
        {
            return (from c in db.personne where c.id == id select c).FirstOrDefault();

            
        }



        public personne GetPersonneByEmail(string email)
        {
            return (from p in db.personne where p.email == email select p).FirstOrDefault();
        }

        public personne GetPersonneByNomPrenom(string nom, string prenom)
        {
            return (from p in db.personne where p.nom == nom && p.prenom == prenom select p).FirstOrDefault();
        }
        public void UpdatePersonne(int id,string email,string pass)
        {
               
                    var utilisateur = db.personne.FirstOrDefault(p => p.id == id);

                    if (utilisateur != null)
                    {
                        utilisateur.email = email;
                        utilisateur.password = pass;

                        db.SubmitChanges();
                    }
                    else
                    {
                        Console.WriteLine("Utilisateur introuvable avec l'ID : " + id);
                    }
             

        }


    }


}

