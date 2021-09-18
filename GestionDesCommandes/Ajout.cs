using BAL;
using DAL;
using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace GestionDesCommandes
{


    public partial class Ajout : Form
    {

        BAL.BALLigCmd bl;
        DAL.LigCmd dl;
        DAL.Client cl1;
        BAL.BALCommande cl;
        DAL.Commande bc;
        BAL.BALClient c;
        int num;
        string Validate;
        string Save;


        public Ajout(string ch,string txt)
        {
            InitializeComponent();
            Save = ch;
            Validate = txt;
            txtReference.Text = ch;
            MyGlobal.variable = "";
            MyGlobal.Produit = "";

            if (txt== "mode modifier")
            {
                c = new BALClient();
                cl1 = new Client();
                cl = new BALCommande();
                bc = new Commande();
                dl = new LigCmd();
                bl = new BALLigCmd();

                ///init cmd
                cl.getCommandetbyRef(bc,txtReference.Text);
                date.Value = Convert.ToDateTime(bc.DateCmd);

                ///init client
                c.getClientbyName(cl1,c.getNameById(bc.NumClient.ToString()));
                txtClient.Text = cl1.NomClient;
                txtRue.Text = cl1.Rue;
                txtVille.Text = cl1.Ville;
                txtCodePostal.Text = cl1.CP.ToString();
                txtTel.Text = cl1.Tel.ToString();

                ///init ligcmd
                ///            gridLigne.Rows.Clear();
                OleDbConnection cn = new OleDbConnection();
                OleDbDataReader lect;
                cn = BAL.Global.seConnecter(BAL.Global.cs);
                lect = BAL.Global.ExecuterOleDBSelect(@"select CodeProduit,Qte,Prix from LigCmd where NumCmd="+ txtReference.Text, cn);
                while (lect.Read())
                {
                    dataGridLigneCmd.Rows.Add(lect.GetValue(0).ToString(), lect.GetValue(1), lect.GetValue(2));
                }
                BAL.Global.seDeconnecter(cn);
                lect.Close();


            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridLigneCmd.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selectionner la ligne entiere." + "\n" + "Cliquer sur le curseur à gauche du datagid", "Erreur de selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Voulez vous supprimer ce ligne de commande?", "Confirmation de la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                dataGridLigneCmd.Rows.RemoveAt(this.dataGridLigneCmd.SelectedRows[0].Index);
                MyGlobal.Produit = "";
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void btnAjouter_Click(object sender, EventArgs e)
        {
            AjoutLC f1 = new AjoutLC("mode ajout");
            f1.ShowDialog();
            if (MyGlobal.Produit != "")
            {
                dataGridLigneCmd.Rows.Add(MyGlobal.Produit, MyGlobal.quantite, MyGlobal.prix);
            }
        }

        private void txtClient_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                ClientAdd f1 = new ClientAdd();
                f1.ShowDialog();
                if (MyGlobal.variable != "")
                {
                    c = new BALClient();
                    cl1 = new Client();
                    c.getClientbyName(cl1, MyGlobal.variable);
                    txtClient.Text = MyGlobal.variable;
                    txtRue.Text = cl1.Rue;
                    txtVille.Text = cl1.Ville;
                    txtCodePostal.Text = cl1.CP.ToString();
                    txtTel.Text = cl1.Tel.ToString();

                }

            }
        }

        private void Ajout_Load(object sender, EventArgs e)
        {

        }

        private void txtReference_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            int res;

            bl = new BALLigCmd();
            dl = new LigCmd();
            cl = new BALCommande();
            bc = new Commande();
            c = new BALClient();


   
            bc.NumCmd = Int32.Parse(txtReference.Text);
            bc.DateCmd = date.Value.ToShortDateString();
            bc.NumClient = c.getIdByName(txtClient.Text);
            if (Validate == "mode modifier")
            {
                res = cl.ModifierCommande(bc,Save);
            }
            else
            {
                res = cl.AjouterCommande(bc);
            }

            if (res == 1)
            {
                for (int i = 0; i < dataGridLigneCmd.Rows.Count; i++)
                {
                    dl.CodeProduit = dataGridLigneCmd.Rows[i].Cells[0].Value.ToString();
                    dl.NumCmd = Int32.Parse(txtReference.Text);
                    dl.Qte = Int32.Parse(dataGridLigneCmd.Rows[i].Cells[1].Value.ToString());
                    dl.Prix = Int32.Parse(dataGridLigneCmd.Rows[i].Cells[2].Value.ToString());

                    if (Validate == "mode modifier")
                    {
                        res = bl.ModifierLigCmd(dl,Save);
                    }
                    else
                    { 
                        res = bl.AjouterLigCmd(dl);
                    }

                    if (res == 1)
                    {
                        num = num + res;
                    }
                    else
                    {
                        MessageBox.Show("Echec Ajout au niveau de ligne de commande.");
                        break;
                    }

                }
                MessageBox.Show("Succès Ajout des commandes a reuissi.");
                if (num == dataGridLigneCmd.Rows.Count)
                {
                    this.Dispose();
                }

            }
            else
            {
                MessageBox.Show("Echec Ajout au niveau du commande.");
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dataGridLigneCmd.SelectedRows.Count == 1)
            {
                MyGlobal.Produit= dataGridLigneCmd.SelectedRows[0].Cells[0].Value.ToString();
                MyGlobal.quantite= dataGridLigneCmd.SelectedRows[0].Cells[1].Value.ToString();
                MyGlobal.prix= dataGridLigneCmd.SelectedRows[0].Cells[2].Value.ToString();

                
                dataGridLigneCmd.Rows.RemoveAt(this.dataGridLigneCmd.SelectedRows[0].Index);

                AjoutLC f1 = new AjoutLC("mode modification");
                f1.ShowDialog();
               
                dataGridLigneCmd.Rows.Add(MyGlobal.Produit, MyGlobal.quantite, MyGlobal.prix);
       
            }
            else
            {
                MessageBox.Show("Selectionner une ligne entiere.");
                return;
            }
        }
    }
}
public static class MyGlobal
{
    public static string variable;
    public static string Produit;
    public static string quantite;
    public static string prix;

}