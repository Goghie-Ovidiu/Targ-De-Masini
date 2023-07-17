using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using Masini;
using Fisier;

namespace Interfata
{
    public partial class Form1 : Form
    {
        AdministrareFisier adminMasini = new AdministrareFisier("Masini.txt");
        

        private TextBox txtNume_Vanzator;
        private TextBox txtNume_Cumparator;
        private TextBox txtFirma;


        private int ID;
       


        public Form1()
        {
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
            adminMasini = new AdministrareFisier(caleCompletaFisier);
            InitializeComponent();
            this.Text = "Targ de Masini";

        }
        private void OnButtonClicked(object sender, EventArgs e)
        {


            TargMasini masina = new TargMasini(ID, txtNume_Vanzator.Text, txtNume_Cumparator.Text, txtFirma.Text, txtFirma.Text, txtNume_Vanzator.Text, txtNume_Vanzator.Text, txtNume_Vanzator.Text, txtNume_Vanzator.Text, txtNume_Vanzator.Text);
            
            adminMasini.AddMasina(masina);
            ID = ID + 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Vanzator f2 = new Vanzator();
            int nrMasini;
            adminMasini.GetMasini(out nrMasini);
            if (nrMasini >= 150)
                MessageBox.Show("S-a atins numarul maxim de masini.");
            else
                f2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cumparator f3 = new Cumparator();
            f3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Admin_Click(object sender, EventArgs e)
        {
            Administrator f4=new Administrator();
            f4.ShowDialog();
        }
    }
}
