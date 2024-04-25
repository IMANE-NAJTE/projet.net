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
            // Récupérer le texte saisi dans les zones de texte
            string emailText = email.Text;
            string passwordText = password.Text;

            // Utiliser les valeurs récupérées (vous pouvez faire ce que vous voulez avec ces valeurs)
            Console.Write("Email: " + emailText);
            Console.WriteLine("Password: " + passwordText);
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
