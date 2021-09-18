using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class Global
    {
        static public String cs = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|MaBD.accdb;";

        static public OleDbConnection seConnecter(String strCN)
        {
            //on va créer un objet de connexion objCN
            OleDbConnection objCN = new OleDbConnection();
            try
            {
                // Définir la chaîne de connexion
                objCN.ConnectionString = strCN;
                // si la connexion est fermée, on l'ouvre avec la méthode open
                if (objCN.State == System.Data.ConnectionState.Closed)
                    objCN.Open();

            }
            catch (Exception)
            {

                throw;
            }
            return objCN;
        }

        static public void seDeconnecter(OleDbConnection objCN)
        {
            try
            {
                if (objCN.State == System.Data.ConnectionState.Open)
                    objCN.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        ///executer un sql ""
        static public Object ExecuterOleDBScalaire(String strSQL, OleDbConnection objCN)
        {
            Object obj = new object();
            OleDbCommand objCom = new OleDbCommand(strSQL, objCN);
            try
            {
                obj = objCom.ExecuteScalar();
            }
            catch (Exception)
            {

                throw;
            }
            return obj;
        }

        static public OleDbDataReader ExecuterOleDBSelect(string strSQL, OleDbConnection objCN)
        {
            OleDbDataReader objDR = null;
            OleDbCommand objCOM = new OleDbCommand(strSQL, objCN);
            try
            {
                objDR = objCOM.ExecuteReader();
            }
            catch (Exception)
            {

                throw;
            }
            return objDR;
        }

        public static int ExecuterOleDbAction(string strSQL, OleDbConnection objCN, params object[] objPM)
        {
            int nb = -1;
            OleDbCommand objCOM = new OleDbCommand(strSQL, objCN);
            try
            {
                foreach (Object obj in objPM)
                {
                    OleDbParameter param = new OleDbParameter();
                    param.Value = obj;
                    objCOM.Parameters.Add(param);
                }
                nb = objCOM.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            return nb;
        }
        static public int ExecuteroleDbActionNomsParams(string strSQL, OleDbConnection objCN, Object[,] objPM)
        {
            int nb = -1;
            OleDbCommand objCom = new OleDbCommand(strSQL, objCN);
            try
            {
                for (int i = 0; i < objPM.GetLength(0); i++)
                {
                    objCom.Parameters.AddWithValue((String)objPM[i, 0], objPM[i, 1]);
                }
                nb = objCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //  return -1;
                throw;
            }
            return nb;
        }
    }
}
