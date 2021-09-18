using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class BALCommande
    {
        public int AjouterCommande(DAL.Commande dal)
        {
            int res;
            OleDbConnection cn = new OleDbConnection();
            cn = Global.seConnecter(Global.cs);
            object[,] tabPMNames =
            {
                {"@NumCmd",dal.NumCmd },
                {"@DateCmd",dal.DateCmd },
                {"@NumClient",dal.NumClient }
            };
            res = Global.ExecuteroleDbActionNomsParams(@"insert into Commande (NumCmd,DateCmd,NumClient) values (@NumCmd,@DateCmd,@NumClient)", cn, tabPMNames);
            Global.seDeconnecter(cn);
            return res;
        }

        public int getMaxRef()
        {
            OleDbConnection ocn = new OleDbConnection();
            ocn = BAL.Global.seConnecter(BAL.Global.cs);
            Object o1 = BAL.Global.ExecuterOleDBScalaire(@"select Max(NumCmd) from Commande;" , ocn);
            int i = Int32.Parse(o1.ToString());
            BAL.Global.seDeconnecter(ocn);
            return i;
        }

        public void deleteCommande(string ch)
        {
            ch = "'" + ch + "'";
            OleDbConnection cn = new OleDbConnection();
            cn = BAL.Global.seConnecter(BAL.Global.cs);
            Object o = BAL.Global.ExecuterOleDBScalaire(@"select NumClient from Client where NomClient =" + ch, cn);
            BAL.Global.ExecuterOleDbAction(@"delete from commande where NumClient = " + o.ToString(), cn);
            BAL.Global.seDeconnecter(cn);
        }
        public string getNumClientByRef(string refer)
        {
            OleDbConnection ocn = new OleDbConnection();
            ocn = BAL.Global.seConnecter(BAL.Global.cs);
            Object o1 = BAL.Global.ExecuterOleDBScalaire(@"select NumClient from Commande where CodeCmd="+refer, ocn);
            string i = o1.ToString();
            BAL.Global.seDeconnecter(ocn);
            return i;
        }

        public void getCommandetbyRef(DAL.Commande dl, string refer)
        {

            OleDbConnection cn = new OleDbConnection();
            OleDbDataReader lect;
            cn = BAL.Global.seConnecter(BAL.Global.cs);
            lect = BAL.Global.ExecuterOleDBSelect(@"select * from Commande where NumCmd=" + refer, cn);
            while (lect.Read())
            {
                dl.NumCmd  = Int32.Parse(lect.GetValue(0).ToString());
                dl.DateCmd = lect.GetValue(1).ToString();
                dl.NumClient = Int32.Parse(lect.GetValue(2).ToString());
            }

            BAL.Global.seDeconnecter(cn);
            lect.Close();

        }
        public int ModifierCommande(DAL.Commande dal,string refer)
        {
            int res;
            OleDbConnection cn = new OleDbConnection();
            cn = Global.seConnecter(Global.cs);
            object[,] tabPMNames =
            {
                {"@NumCmd",dal.NumCmd },
                {"@DateCmd",dal.DateCmd },
                {"@NumClient",dal.NumClient }
            };
            res = Global.ExecuteroleDbActionNomsParams(@"update commande set NumCmd=@NumCmd,DateCmd=@DateCmd,NumClient=@NumClient where NumCmd="+refer, cn, tabPMNames);
            Global.seDeconnecter(cn);
            return res;
        }

    }
}
