using BAL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionDesCommandes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DateTime dt1 = new DateTime(2000 , 01 , 01);
            DateTime dt2 = new DateTime(2030, 12, 30);
            dateDebut.Value=dt1;
            dateFin.Value = dt2;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateDebut.Value < dateFin.Value)
            {
                gridList.Rows.Clear();
                gridLigne.Rows.Clear();
                OleDbConnection cn = new OleDbConnection();
                OleDbDataReader lect;
                OleDbDataReader lect1;

                cn = BAL.Global.seConnecter(BAL.Global.cs);

                lect = BAL.Global.ExecuterOleDBSelect(@"select Commande.NumCmd,Commande.DateCmd,Client.NomClient from Client,Commande where Client.NumClient=Commande.NumClient and Commande.DateCmd between #"+ dateDebut.Value.ToShortDateString() + "# and #"+ dateFin.Value.ToShortDateString()+ "#", cn);
                while (lect.Read())
                {

                    gridList.Rows.Add(lect.GetValue(0).ToString(), lect.GetValue(1).ToString(),
                    lect.GetValue(2).ToString());
                    lect1 = BAL.Global.ExecuterOleDBSelect(@"select Produit.Designation,LigCmd.Qte,LigCmd.Prix from Produit,LigCmd where Produit.CodeProduit=LigCmd.CodeProduit and LigCmd.NumCmd = " + lect.GetValue(0).ToString(), cn);
                    while (lect1.Read())
                    {

                        gridLigne.Rows.Add(lect1.GetValue(0).ToString(), lect1.GetValue(1).ToString(),
                        lect1.GetValue(2).ToString());

                    }
                }

            }

        }

        private void gridList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (gridList.SelectedCells.Count == 1 && gridList.SelectedCells[0].ColumnIndex==2)
            {
                /**string name;
                name="'"+gridList.SelectedRows[0].Cells[2].Value.ToString()+"'";

                OleDbConnection cn = new OleDbConnection();
                OleDbDataReader lect;
                cn = BAL.Global.seConnecter(BAL.Global.cs);
                lect = BAL.Global.ExecuterOleDBSelect(@"select * from Client where NomClient="+name, cn);
                while (lect.Read())
                {
                    txtClient.Text =lect.GetValue(1).ToString();
                    txtAdresse.Text = lect.GetValue(2).ToString();
                    txtVille.Text = lect.GetValue(3).ToString();
                    txtCP.Text = lect.GetValue(4).ToString();
                    txtTel.Text = lect.GetValue(5).ToString();
                }
                BAL.Global.seDeconnecter(cn);
                lect.Close();


                return;**/
                string name;
                name = gridList.SelectedCells[0].Value.ToString();
                DAL.Client dl;
                BAL.BALClient bl;
                dl = new Client();
                bl = new BALClient();
                bl.getClientbyName(dl, name);

                txtClient.Text = dl.NomClient;
                txtAdresse.Text = dl.Rue;
                txtVille.Text = dl.Ville;
                txtCP.Text = dl.CP.ToString();
                txtTel.Text = dl.Tel.ToString();
            }
            else
                {
                txtClient.Text = "";
                txtAdresse.Text = "";
                txtVille.Text = "";
                txtCP.Text = "";
                txtTel.Text = "";
            }

        }
        private void remplirDatagrdview()
        {
            gridList.Rows.Clear();
            OleDbConnection cn = new OleDbConnection();
            OleDbDataReader lect;
            cn = BAL.Global.seConnecter(BAL.Global.cs);
            lect = BAL.Global.ExecuterOleDBSelect(@"select Commande.NumCmd,Commande.DateCmd,Client.NomClient from Commande ,Client where Commande.NumClient=Client.NumClient", cn);
            while (lect.Read())
            {
                gridList.Rows.Add(lect.GetValue(0), lect.GetValue(1),lect.GetValue(2).ToString());
            }
            BAL.Global.seDeconnecter(cn);
            lect.Close();

        }

        private void remplirDatagrdview1()
        {
            gridLigne.Rows.Clear();
            OleDbConnection cn = new OleDbConnection();
            OleDbDataReader lect;
            cn = BAL.Global.seConnecter(BAL.Global.cs);
            lect = BAL.Global.ExecuterOleDBSelect(@"select Produit.Designation,LigCmd.Qte,LigCmd.Prix from Produit ,LigCmd where Produit.CodeProduit=LigCmd.CodeProduit", cn);
            while (lect.Read())
            {
                gridLigne.Rows.Add(lect.GetValue(0).ToString(), lect.GetValue(1), lect.GetValue(2));
            }
            BAL.Global.seDeconnecter(cn);
            lect.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            remplirDatagrdview();
            remplirDatagrdview1();

        }

        private void txtRef_TextChanged(object sender, EventArgs e)
        {
            string id = txtRef.Text;
            Boolean k = false;
            for (int i=0; i<id.Length;i++)
            {
                if ( id[i] < '9' && id[i] > '0' )
                {
                    k = true;
                }
                
            }

            if (id !="" && k)
            {

                id = "'" + id + "%'";
                gridList.Rows.Clear();
                gridLigne.Rows.Clear();
                OleDbConnection cn = new OleDbConnection();
                OleDbDataReader lect;
                OleDbDataReader lect1;

                cn = BAL.Global.seConnecter(BAL.Global.cs);

                    lect = BAL.Global.ExecuterOleDBSelect(@"select Commande.NumCmd,Commande.DateCmd,Client.NomClient from Client,Commande where Client.NumClient=Commande.NumClient and Commande.NumCmd like " + id, cn);
                    while (lect.Read())
                    {

                        gridList.Rows.Add(lect.GetValue(0).ToString(), lect.GetValue(1).ToString(),
                        lect.GetValue(2).ToString());
                        lect1 = BAL.Global.ExecuterOleDBSelect(@"select Produit.Designation,LigCmd.Qte,LigCmd.Prix from Produit,LigCmd where Produit.CodeProduit=LigCmd.CodeProduit and LigCmd.NumCmd = " + lect.GetValue(0).ToString(), cn);
                        while (lect1.Read())
                        {

                            gridLigne.Rows.Add(lect1.GetValue(0).ToString(), lect1.GetValue(1).ToString(),
                            lect1.GetValue(2).ToString());

                        }
                    }

                
                BAL.Global.seDeconnecter(cn);
                lect.Close();
            }
            else 
                {
                    remplirDatagrdview();
                    remplirDatagrdview1();
                }
        }

        private void txtClient1_TextChanged(object sender, EventArgs e)
        {
            string nom1 = txtClient1.Text;
            string nom = txtClient1.Text;


            ////recherche dans grid 1
            if (nom != "")
            {
                nom = "'" + nom + "%'";
                gridList.Rows.Clear();
                gridLigne.Rows.Clear();
                OleDbConnection cn = new OleDbConnection();
                OleDbDataReader lect;
                OleDbDataReader lect1;
                OleDbDataReader lect2;

                cn = BAL.Global.seConnecter(BAL.Global.cs);
                lect = BAL.Global.ExecuterOleDBSelect(@"select * from Client where NomClient like " + nom, cn);
                while (lect.Read())
                {
                    lect1 = BAL.Global.ExecuterOleDBSelect(@"select * from Commande where NumClient = " + lect.GetValue(0).ToString(), cn);
                    while (lect1.Read())
                    {

                        gridList.Rows.Add(lect1.GetValue(0).ToString(), lect1.GetValue(1).ToString(),
                        lect.GetValue(1).ToString());
                        lect2 = BAL.Global.ExecuterOleDBSelect(@"select Produit.Designation,LigCmd.Qte,LigCmd.Prix from Produit,LigCmd where Produit.CodeProduit=LigCmd.CodeProduit and LigCmd.NumCmd = " + lect1.GetValue(0).ToString(), cn);
                        while (lect2.Read())
                        {

                            gridLigne.Rows.Add(lect2.GetValue(0).ToString(), lect2.GetValue(1).ToString(),
                            lect2.GetValue(2).ToString());
 
                        }
                    }

                }
                BAL.Global.seDeconnecter(cn);
                lect.Close();

            }
            else
            {
                remplirDatagrdview();
                remplirDatagrdview1();
            }

        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (gridList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selectionner la ligne entiere." + "\n" + "Cliquer sur le curseur à gauche du datagid", "Erreur de selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Voulez vous supprimer ce commande?", "Confirmation de la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                OleDbConnection cn = new OleDbConnection();
                cn = BAL.Global.seConnecter(BAL.Global.cs);
                BAL.Global.ExecuterOleDbAction(@"delete from Commande where NumCmd = " + gridList.SelectedRows[0].Cells[0].Value.ToString(), cn);
                BAL.Global.ExecuterOleDbAction(@"delete from LigCmd where NumCmd = " + gridList.SelectedRows[0].Cells[0].Value.ToString(), cn);
                BAL.Global.seDeconnecter(cn);
                remplirDatagrdview();
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (gridList.SelectedRows.Count == 1)
            {
                string referance;
                BAL.BALCommande bl;
                bl = new BALCommande();


                referance = gridList.SelectedRows[0].Cells[0].Value.ToString();
                Ajout f1 = new Ajout(referance,"mode modifier");
                f1.ShowDialog();
                remplirDatagrdview();
                remplirDatagrdview1();
            }
            else
            {
                MessageBox.Show("Selectionner une ligne entiere pour modifier.");
                return;
            }
            
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            string referance;
            BAL.BALCommande bl;
            bl = new BALCommande();

            
            referance= (bl.getMaxRef()+1).ToString();
            Ajout f1 = new Ajout(referance,"mode ajouter");
            f1.ShowDialog();
            remplirDatagrdview();
            remplirDatagrdview1();
        }

        private void dateFin_ValueChanged(object sender, EventArgs e)
        {
            if (dateDebut.Value < dateFin.Value)
            {
                gridList.Rows.Clear();
                gridLigne.Rows.Clear();
                OleDbConnection cn = new OleDbConnection();
                OleDbDataReader lect;
                OleDbDataReader lect1;

                cn = BAL.Global.seConnecter(BAL.Global.cs);

                lect = BAL.Global.ExecuterOleDBSelect(@"select Commande.NumCmd,Commande.DateCmd,Client.NomClient from Client,Commande where Client.NumClient=Commande.NumClient and Commande.DateCmd between #" + dateDebut.Value.ToShortDateString() + "# and #" + dateFin.Value.ToShortDateString()+ "#", cn);
                while (lect.Read())
                {

                    gridList.Rows.Add(lect.GetValue(0).ToString(), lect.GetValue(1).ToString(),
                    lect.GetValue(2).ToString());
                    lect1 = BAL.Global.ExecuterOleDBSelect(@"select Produit.Designation,LigCmd.Qte,LigCmd.Prix from Produit,LigCmd where Produit.CodeProduit=LigCmd.CodeProduit and LigCmd.NumCmd = " + lect.GetValue(0).ToString(), cn);
                    while (lect1.Read())
                    {

                        gridLigne.Rows.Add(lect1.GetValue(0).ToString(), lect1.GetValue(1).ToString(),
                        lect1.GetValue(2).ToString());

                    }
                }

            }
        }
    }
}
