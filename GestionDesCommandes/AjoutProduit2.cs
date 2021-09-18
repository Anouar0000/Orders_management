using BAL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionDesCommandes
{
    public partial class AjoutProduit2 : Form
    {
        BAL.BALProduit bl;
        DAL.Produit dl;
        BAL.BALTProduit cl;

        public AjoutProduit2()
        {
            InitializeComponent();
        }

        private void txtAnnuler_Click(object sender, EventArgs e)
        {

            this.Dispose();

        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (txtCodeProduit.Text!="" && txtDesignation.Text!="" && TPBox.Text!="") 
            { 
                int res;
                bl = new BALProduit();
                dl = new Produit();
                cl = new BALTProduit();
            
                dl.CodeProduit = txtCodeProduit.Text;
                dl.Designation = txtDesignation.Text;
                dl.CodeTProduit = cl.getCodeTProduit(TPBox.Text);
                res = bl.AjouterProduit(dl);
                if (res == 1)
                {
                    MessageBox.Show("Succès Ajout de nouveau Produit.");
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Echec Ajout de nouveau Produit.");
                }
            }
            else
            {
                MessageBox.Show("Veuiller remplir le formulaire.");
            }
        }
    }
}
