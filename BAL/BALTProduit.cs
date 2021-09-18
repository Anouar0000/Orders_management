using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class BALTProduit
    {
        public int AjouterTProduit(DAL.TProduit dal)
        {
            int res;
            OleDbConnection cn = new OleDbConnection();
            cn = Global.seConnecter(Global.cs);
            object[,] tabPMNames =
            {
                {"@CodeTProduit",dal.CodeTProduit },
                {"@Designation",dal.Designation }
            };
            res = Global.ExecuteroleDbActionNomsParams(@"insert into clients (CodeTProduit,Designation) values (@CodeTProduit,@Designation)", cn, tabPMNames);
            Global.seDeconnecter(cn);
            return res;
        }

        public int getCodeTProduit(string ch)
        {
            ch = "'" + ch + "'";
            OleDbConnection ocn = new OleDbConnection();
            ocn = BAL.Global.seConnecter(BAL.Global.cs);
            Object o1 = BAL.Global.ExecuterOleDBScalaire(@"select CodeTProduit from TProduit where Designation ="+ch, ocn);
            int i = Int32.Parse(o1.ToString());
            BAL.Global.seDeconnecter(ocn);
            return i;
        }
        public string getDesignationbyTProduit(string name)
        {
            OleDbConnection ocn = new OleDbConnection();
            ocn = BAL.Global.seConnecter(BAL.Global.cs);
            Object o1 = BAL.Global.ExecuterOleDBScalaire(@"select Designation from TProduit where CodeTProduit =" + name, ocn);
            string i = o1.ToString();
            BAL.Global.seDeconnecter(ocn);
            return i;
        }
    }
}
