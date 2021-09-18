using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class BALLigCmd
    {
        public int AjouterLigCmd(DAL.LigCmd dal)
        {
            int res;
            OleDbConnection cn = new OleDbConnection();
            cn = Global.seConnecter(Global.cs);
            object[,] tabPMNames =
            {
                {"@CodeProduit",dal.CodeProduit },
                {"@NumCmd",dal.NumCmd },
                {"@Qte",dal.Qte },
                {"@Prix",dal.Prix }
            };
            res = Global.ExecuteroleDbActionNomsParams(@"insert into LigCmd (CodeProduit,NumCmd,Qte,Prix) values (@CodeProduit,@NumCmd,@Qte,@Prix)", cn, tabPMNames);
            Global.seDeconnecter(cn);
            return res;
        }

        public int ModifierLigCmd(DAL.LigCmd dal,string refer)
        {
            int res;
            OleDbConnection cn = new OleDbConnection();
            cn = Global.seConnecter(Global.cs);
            object[,] tabPMNames =
            {
                {"@CodeProduit",dal.CodeProduit },
                {"@NumCmd",dal.NumCmd },
                {"@Qte",dal.Qte },
                {"@Prix",dal.Prix }
            };
            res = Global.ExecuteroleDbActionNomsParams(@"update LigCmd set CodeProduit=@CodeProduit,NumCmd=@NumCmd,Qte=@Qte,Prix=@Prix where NumCmd="+refer, cn, tabPMNames);
            Global.seDeconnecter(cn);
            return res;
        }
    }
}
