using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHelper;
using Microsoft.Extensions.Configuration;
using WI_MF_FD_SA_RENEWAL_TRANS_BO;

namespace WI_MF_FD_SA_RENEWAL_TRANS_DAL
{
    public class Renewal_DAL
    {
        private readonly string _conn = string.Empty;
        public Renewal_DAL(IConfiguration config)
        {
            _conn = config["ConnectionStrings:CONN_FD"];
        }


        public int Insert_Renewal_JSON_Log(RenewalBO renewalBO, string json, string req, string API_Version)
        {
            int res = 0;
            try
            {
                SqlConnection con = new SqlConnection(_conn);
                SqlParameter[] sqlparam = new SqlParameter[14];

                sqlparam[0] = new SqlParameter("@Appl_No", "");
                sqlparam[1] = new SqlParameter("@App_Code", DBNull.Value);
                sqlparam[2] = new SqlParameter("@Ref_Cust_Code", DBNull.Value);
                sqlparam[3] = new SqlParameter("@Ref_Rm_Code", DBNull.Value);
                sqlparam[4] = new SqlParameter("@Ref_Othr_Code", DBNull.Value);
                sqlparam[5] = new SqlParameter("@Ref_Type", DBNull.Value);
                sqlparam[6] = new SqlParameter("@Sp_Cp_Trans_Ref_No", DBNull.Value);
                sqlparam[7] = new SqlParameter("@API_Called", req);
                sqlparam[8] = new SqlParameter("@API_Version", API_Version);
                sqlparam[9] = new SqlParameter("@JSON_Text", json);
                sqlparam[10] = new SqlParameter("@Active", "1");
                sqlparam[11] = new SqlParameter("@Dummy", 0);
                sqlparam[12] = new SqlParameter("@applno", "");
                sqlparam[13] = new SqlParameter("@transrefno", "");
                res = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "usp_FD_SA_Renewal_Save_JSON_Log", sqlparam);
                return res;
            }
            catch (Exception ex)
            {
                string exce = ex.Message;
                throw;
            }
        }

        public DataSet Get_Renewal_FDDetails(RenewalBO renewalBO)
        {
            SqlParameter[] param = new SqlParameter[1];
            //param[0] = new SqlParameter("@foliono", renewalBO.foliono);
            param[0] = new SqlParameter("@fdrno", renewalBO.fdrno);
            DataSet ds = SqlHelper.ExecuteDataSet(_conn, CommandType.StoredProcedure, "USP_FD_SA_Renewal_Get_FD_Dtls", param);
            if (ds != null
                 && ds.Tables.Count>0
            )
            {
                return ds;
            }
            else
            {
                return null;
            }
        }
    }
}
