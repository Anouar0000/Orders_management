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
    public partial class ClientAdd : Form
    {
        BAL.BALClient bl;
        BAL.BALCommande bc;

        public ClientAdd()
        {
            InitializeComponent();
            remplirDatagrdview();
            comboBox1.Text = "AND";


        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (gridClient.SelectedRows.Count == 1)
            {
                MyGlobal.variable = gridClient.SelectedRows[0].Cells[0].Value.ToString();
                /* Ajout f1 = new Ajout(ch1,num);

                 f1.txtClient.Text = gridClient.SelectedRows[0].Cells[0].Value.ToString();
                 f1.txtRue.Text = gridClient.SelectedRows[0].Cells[1].Value.ToString();
                 f1.txtVille.Text = gridClient.SelectedRows[0].Cells[2].Value.ToString();
                 f1.txtCodePostal.Text = gridClient.SelectedRows[0].Cells[3].Value.ToString();
                 f1.txtTel.Text = gridClient.SelectedRows[0].Cells[4].Value.ToString();*/
                this.Dispose();
                //f1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selectionner le client souhaiter" + "\n" + "Selectionner la ligne entiere.", "Erreur de selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void remplirDatagrdview()
        {
            gridClient.Rows.Clear();
            OleDbConnection cn = new OleDbConnection();
            OleDbDataReader lect;
            cn = Global.seConnecter(Global.cs);
            lect = Global.ExecuterOleDBSelect(@"select * from Client;", cn);
            while (lect.Read())
            {
                gridClient.Rows.Add(lect.GetValue(1).ToString(), lect.GetValue(2).ToString(),
                    lect.GetValue(3).ToString(), lect.GetValue(4), lect.GetValue(5));
            }
            Global.seDeconnecter(cn);
            lect.Close();

        }

        private void ClientAdd_Load(object sender, EventArgs e)
        {
            remplirDatagrdview();

        }

        private void gridCommande_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtClient_TextChanged(object sender, EventArgs e)
        {
            string nom;
            nom = txtClient.Text;

            if (nom != "")
            {
                nom = "'" + nom + "%'";
                gridClient.Rows.Clear();
                OleDbConnection cn = new OleDbConnection();
                OleDbDataReader lect;
                cn = BAL.Global.seConnecter(BAL.Global.cs);
                lect = BAL.Global.ExecuterOleDBSelect(@"select * from Client where NomClient like "+nom, cn);
                while (lect.Read())
                {
                    gridClient.Rows.Add(lect.GetValue(1).ToString(), lect.GetValue(2).ToString(),
                    lect.GetValue(3).ToString(), lect.GetValue(4), lect.GetValue(5));
                }
                BAL.Global.seDeconnecter(cn);
                lect.Close();
            }
            else
            {
                remplirDatagrdview();
            }
        }

        private void txtRue_TextChanged(object sender, EventArgs e)
        {
            string rue;
            rue = txtRue.Text;

            if (rue != "")
            {
                rue = "'" + rue + "%'";
                gridClient.Rows.Clear();
                OleDbConnection cn = new OleDbConnection();
                OleDbDataReader lect;
                cn = BAL.Global.seConnecter(BAL.Global.cs);
                lect = BAL.Global.ExecuterOleDBSelect(@"select * from Client where Rue like " + rue, cn);
                while (lect.Read())
                {
                    gridClient.Rows.Add(lect.GetValue(1).ToString(), lect.GetValue(2).ToString(),
                    lect.GetValue(3).ToString(), lect.GetValue(4), lect.GetValue(5));
                }
                BAL.Global.seDeconnecter(cn);
                lect.Close();
            }
            else
            {
                remplirDatagrdview();
            }
        }

        private void txtVille_TextChanged(object sender, EventArgs e)
        {
            string Ville;
            Ville = txtVille.Text;

            if (Ville != "")
            {
                Ville = "'" + Ville + "%'";
                gridClient.Rows.Clear();
                OleDbConnection cn = new OleDbConnection();
                OleDbDataReader lect;
                cn = BAL.Global.seConnecter(BAL.Global.cs);
                lect = BAL.Global.ExecuterOleDBSelect(@"select * from Client where Ville like " + Ville, cn);
                while (lect.Read())
                {
                    gridClient.Rows.Add(lect.GetValue(1).ToString(), lect.GetValue(2).ToString(),
                    lect.GetValue(3).ToString(), lect.GetValue(4), lect.GetValue(5));
                }
                BAL.Global.seDeconnecter(cn);
                lect.Close();
            }
            else
            {
                remplirDatagrdview();
            }

        }

        private void txtCodePostal_TextChanged(object sender, EventArgs e)
        {
            string CP;
            CP = txtCodePostal.Text;

            if (CP != "")
            {
                CP = "'" + CP + "%'";
                gridClient.Rows.Clear();
                OleDbConnection cn = new OleDbConnection();
                OleDbDataReader lect;
                cn = BAL.Global.seConnecter(BAL.Global.cs);
                lect = BAL.Global.ExecuterOleDBSelect(@"select * from Client where CP like " + CP, cn);
                while (lect.Read())
                {
                    gridClient.Rows.Add(lect.GetValue(1).ToString(), lect.GetValue(2).ToString(),
                    lect.GetValue(3).ToString(), lect.GetValue(4), lect.GetValue(5));
                }
                BAL.Global.seDeconnecter(cn);
                lect.Close();
            }
            else
            {
                remplirDatagrdview();
            }
        }

        private void btnNewClient_Click(object sender, EventArgs e)
        {
            ClientAdd2 l = new ClientAdd2();
            l.ShowDialog();
            remplirDatagrdview();
        }

        private void ClientAdd_Load_1(object sender, EventArgs e)
        {

        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (gridClient.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selectionner la ligne entiere." + "\n" + "Cliquer sur le curseur à gauche du datagid", "Erreur de selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Voulez vous supprimer ce client?", "Confirmation de la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                bl = new BALClient();
                bc = new BALCommande();

                bc.deleteCommande(gridClient.SelectedRows[0].Cells[0].Value.ToString());
                bl.deleteClient(gridClient.SelectedRows[0].Cells[0].Value.ToString());
    
                remplirDatagrdview();
            }
        }


    }
}
