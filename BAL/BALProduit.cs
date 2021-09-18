using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class BALProduit
    {
        public int AjouterProduit(DAL.Produit dal)
        {
            int res;
            OleDbConnection cn = new OleDbConnection();
            cn = Global.seConnecter(Global.cs);
            object[,] tabPMNames =
            {
                {"@CodeProduit",dal.CodeProduit },
                {"@Designation",dal.Designation },
                {"@CodeTProduit",dal.CodeTProduit }
            };
            res = Global.ExecuteroleDbActionNomsParams(@"insert into Produit (CodeProduit,Designation,CodeTProduit) values (@CodeProduit,@Designation,@CodeTProduit)", cn, tabPMNames);
            Global.seDeconnecter(cn);
            return res;
        }

        public void deleteProduit(string ch)
        {
            ch = "'" + ch + "'";
            OleDbConnection cn = new OleDbConnection();
            cn = BAL.Global.seConnecter(BAL.Global.cs);
            BAL.Global.ExecuterOleDbAction(@"delete from Produit where CodeProduit = " + ch, cn);
            BAL.Global.seDeconnecter(cn);
        }

        public string getDesignationbyName(string name)
        {
            name = "'" + name + "'";
            OleDbConnection ocn = new OleDbConnection();
            ocn = BAL.Global.seConnecter(BAL.Global.cs);
            Object o1 = BAL.Global.ExecuterOleDBScalaire(@"select Designation from Produit where CodeProduit ="+name, ocn);
            string i = o1.ToString();
            BAL.Global.seDeconnecter(ocn);
            return i;
        }

        public string getCodeTPrduitbyName(string name)
        {
            name = "'" + name + "'";
            OleDbConnection ocn = new OleDbConnection();
            ocn = BAL.Global.seConnecter(BAL.Global.cs);
            Object o1 = BAL.Global.ExecuterOleDBScalaire(@"select CodeTProduit from Produit where CodeProduit =" + name, ocn);
            string i = o1.ToString();
            BAL.Global.seDeconnecter(ocn);
            return i;
        }
    }
}
