using BAL;
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
    public partial class AjoutProduit : Form
    {
        BAL.BALProduit bl;

        public AjoutProduit()
        {
            InitializeComponent();
            remplirDatagrdview();
        }

        private void remplirDatagrdview()
        {
            gridProduit.Rows.Clear();
            OleDbConnection cn = new OleDbConnection();
            OleDbDataReader lect;
            cn = BAL.Global.seConnecter(BAL.Global.cs);
            lect = BAL.Global.ExecuterOleDBSelect(@"select Produit.CodeProduit,Produit.Designation,TProduit.Designation from Produit ,TProduit where Produit.CodeTProduit=TProduit.CodeTProduit", cn);
            while (lect.Read())
            {
                gridProduit.Rows.Add(lect.GetValue(0).ToString(), lect.GetValue(1), lect.GetValue(2));
            }
            BAL.Global.seDeconnecter(cn);
            lect.Close();

        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtDesignation_TextChanged(object sender, EventArgs e)
        {
            string nom;
            nom = txtDesignation.Text;

            if (nom != "")
            {
                nom = "'" + nom + "%'";
                gridProduit.Rows.Clear();
                OleDbConnection cn = new OleDbConnection();
                OleDbDataReader lect;
                cn = BAL.Global.seConnecter(BAL.Global.cs);
                lect = BAL.Global.ExecuterOleDBSelect(@"select Produit.CodeProduit,Produit.Designation,TProduit.Designation from Produit ,TProduit where Produit.CodeTProduit=TProduit.CodeTProduit and TProduit.Designation like " + nom, cn);
                while (lect.Read())
                {
                    gridProduit.Rows.Add(lect.GetValue(0).ToString(), lect.GetValue(1), lect.GetValue(2));
                }
                BAL.Global.seDeconnecter(cn);
                lect.Close();
            }
            else
            {
                remplirDatagrdview();
            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (gridProduit.SelectedRows.Count == 1)
            {

                MyGlobal1.Produit= gridProduit.SelectedRows[0].Cells[0].Value.ToString();
                MyGlobal1.type = gridProduit.SelectedRows[0].Cells[1].Value.ToString();
                MyGlobal1.designation = gridProduit.SelectedRows[0].Cells[2].Value.ToString();


                this.Dispose();

            }
            else
            {
                MessageBox.Show("Selectionner le produit souhaiter" + "\n" + "Selectionner la ligne entiere.", "Erreur de selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (gridProduit.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selectionner la ligne entiere." + "\n" + "Cliquer sur le curseur à gauche du datagid", "Erreur de selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Voulez vous supprimer ce commande?", "Confirmation de la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                bl = new BALProduit();
                bl.deleteProduit(gridProduit.SelectedRows[0].Cells[0].Value.ToString());
                remplirDatagrdview();
            }
        }

        private void btnNewClient_Click(object sender, EventArgs e)
        {
            AjoutProduit2 f1 = new AjoutProduit2();
            f1.ShowDialog();
            remplirDatagrdview();
        }

        private void gridProduit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
