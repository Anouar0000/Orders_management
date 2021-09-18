using BAL;
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
    public partial class AjoutLC : Form
    {
        BAL.BALProduit bl;
        BALTProduit pl;
        string val;
        public AjoutLC(string ch)
        {
            val = ch;
            InitializeComponent();
            if (ch == "mode modification")
            {
                bl = new BALProduit();
                pl = new BALTProduit();


                txtProduit.Text = MyGlobal.Produit;
                txtType.Text =bl.getDesignationbyName(MyGlobal.Produit);
                txtDesignation.Text = pl.getDesignationbyTProduit(bl.getCodeTPrduitbyName(MyGlobal.Produit));
                txtQte.Text = MyGlobal.quantite;
                txtPrix.Text = MyGlobal.prix;
            }
        }


        private void EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AjoutProduit f1 = new AjoutProduit();
                f1.ShowDialog();
                txtProduit.Text = MyGlobal1.Produit;
                txtType.Text = MyGlobal1.type;
                txtDesignation.Text = MyGlobal1.designation;
            }
        }


        private void btnValider_Click(object sender, EventArgs e)
        {

            if(txtProduit.Text!="" && txtQte.Text!="" && txtPrix.Text!="" && txtType.Text!="" && txtDesignation.Text!="")
                {
                Boolean k = false;
                for (int i = 0; i < txtQte.Text.Length; i++)
                {
                    if (int.Parse(txtQte.Text[i].ToString()) <= 9 && txtQte.Text[i] > '0')
                    {
                        k = true;
                    }

                }
                if (k) 
                {
                    MyGlobal.Produit = txtProduit.Text;
                    MyGlobal.quantite = txtQte.Text;
                    MyGlobal.prix = txtPrix.Text;
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Veuiller donner des valeurs correctes.");
                }
            }
            else
            {
                MessageBox.Show("Veuiller remplir le formulaire.");
            }

        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtProduit_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

public static class MyGlobal1
{
    public static string Produit;
    public static string type;
    public static string designation;

}