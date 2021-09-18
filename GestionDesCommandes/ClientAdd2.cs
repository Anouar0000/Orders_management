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
    public partial class ClientAdd2 : Form
    {
        BALClient bl;
        Client dl;

        public ClientAdd2()
        {
            InitializeComponent();

        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Voulez vous annuler l'ajout?", "Annulation de l'ajout", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Dispose();

            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (txtClient.Text !="" && txtRue.Text !="" && txtVille.Text !="" && txtCP.Text !="" && txtTel.Text !="") {

                Boolean k = false;
                for (int i = 0; i < txtCP.Text.Length; i++)
                {
                    if (Int32.Parse(txtCP.Text[i].ToString()) <= 9 && Int32.Parse(txtCP.Text[i].ToString()) >= 0)
                    {
                        k = true;
                    }
                }

                for (int j = 0; j < txtCP.Text.Length; j++)
                {
                        if (!(Int32.Parse(txtCP.Text[j].ToString()) <= 9 && Int32.Parse(txtCP.Text[j].ToString()) >= 0))
                        {
                            k = false;
                        }
                }

                if (k)
                {
                    int res;
                    bl = new BALClient();
                    dl = new Client();
                    dl.NumClient = bl.getMaxId() + 1;
                    dl.NomClient = txtClient.Text;
                    dl.Rue = txtRue.Text;
                    dl.Ville = txtVille.Text;
                    dl.CP = Int32.Parse(txtCP.Text);
                    dl.Tel = Int32.Parse(txtTel.Text);
                    res = bl.AjouterClient(dl);
                    if (res == 1)
                    {
                        MessageBox.Show("Succès Ajout de nouveau client.");
                        this.Dispose();
                    }
                    else
                    {
                       MessageBox.Show("Echec Ajout de nouveau client.");
                    }
                }
                else
                {
                    MessageBox.Show("Veuiller enter des valeur valides.");
                }
            }
            else
            {
                MessageBox.Show("Veuiller remplir le formulaire.");
            }
        }
    }
}
