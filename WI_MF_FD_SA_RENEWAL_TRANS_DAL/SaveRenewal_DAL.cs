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
using System.Xml.Linq;
using System.Text.RegularExpressions;
using static WI_MF_FD_SA_RENEWAL_TRANS_BO.SaveValidation;

namespace WI_MF_FD_SA_RENEWAL_TRANS_DAL
{
    public class SaveRenewal_DAL
    {
        private readonly string _conn = string.Empty;
        public SaveRenewal_DAL(IConfiguration config)
        {
            _conn = config["ConnectionStrings:CONN_FD"];
        }

        //public string Get_NewApplicationNo(NewApplicationNoBO objBo)
        //{
        //    SqlParameter[] param = new SqlParameter[7];
        //    param[0] = new SqlParameter("@BusType", objBo.bustype);
        //    param[1] = new SqlParameter("@Source", objBo.source);
        //    param[2] = new SqlParameter("@CreatedIP", objBo.createdip);
        //    param[3] = new SqlParameter("@CreatedUserId", objBo.createdby);
        //    param[4] = new SqlParameter("@CreatedUserName", objBo.createdbyname);
        //    param[5] = new SqlParameter("@SessionId", objBo.sessionid);
        //    param[6] = new SqlParameter("@DSource", objBo.dsource);

        //    return SqlHelper.ExecuteScalar(_conn, CommandType.StoredProcedure, "USP_FD_SA_GetApplicationNo", param).ToString();
        //}

        //public DataTable Save_Renewal_Configuration(FD_Save_Renewal_BO objBO, string secondholderdtlxml, string thirdholderdtlxml, string renewalhdrsequence, string applno)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[27];
        //        param[0] = new SqlParameter("@fdrno", objBO.fdrno);
        //        param[1] = new SqlParameter("@foliono", objBO.foliono);
        //        param[2] = new SqlParameter("@applno", applno);
        //        param[3] = new SqlParameter("@categorycode", objBO.investmentdtls.categorycode);
        //        param[4] = new SqlParameter("@categorydec", objBO.fdrenewalconfig.categorydec);
        //        param[5] = new SqlParameter("@schemecode", objBO.fdrenewalconfig.schemecode);
        //        param[6] = new SqlParameter("@schemedec", objBO.fdrenewalconfig.schemedec);
        //        param[7] = new SqlParameter("@intfrqcode", objBO.fdrenewalconfig.intfrqcode);
        //        param[8] = new SqlParameter("@intfrqdec", objBO.fdrenewalconfig.intfrqdec);
        //        param[9] = new SqlParameter("@tenurecode", objBO.fdrenewalconfig.tenurecode);
        //        param[10] = new SqlParameter("@intrate", objBO.fdrenewalconfig.intrate);
        //        param[11] = new SqlParameter("@fdramt", objBO.fdrenewalconfig.fdramt);
        //        param[12] = new SqlParameter("@renewalfordec", objBO.fdrenewalconfig.renewalfordec);
        //        param[13] = new SqlParameter("@existingfdrno", objBO.fdrno);
        //        param[14] = new SqlParameter("@secondholderdtlid", objBO.secondholderdtlid);
        //        param[15] = new SqlParameter("@thirdholderdtlid", objBO.thirdholderdtlid);
        //        param[16] = new SqlParameter("@secondholderdtlxml", secondholderdtlxml);
        //        param[17] = new SqlParameter("@thirdholderdtlxml", thirdholderdtlxml);
        //        param[18] = new SqlParameter("@nomineedtlid", objBO.nominee.nomineedtlid);
        //        param[19] = new SqlParameter("@createdby", objBO.createdby);
        //        param[20] = new SqlParameter("@createdbyname", objBO.createdbyname);
        //        param[21] = new SqlParameter("@createdip", "");
        //        param[22] = new SqlParameter("@sessionid", objBO.sessionid);
        //        param[23] = new SqlParameter("@nomname", objBO.nominee.name);
        //        param[24] = new SqlParameter("@nomrelation", objBO.nominee.relation);
        //        param[25] = new SqlParameter("@renewalhdrsequence", renewalhdrsequence);
        //        param[26] = new SqlParameter("@provisionalbankdtlid", objBO.provisionalbankdtlid);

        //        dt = SqlHelper.ExecuteDataTable(_conn, CommandType.StoredProcedure, "USP_FD_SA_Renewal_Configration_Dtl", param);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    return dt;
        //}


        //public DataTable Save_Renewal_Holder_Verification(FD_Save_Renewal_BO fD_Save_Renewal_BO,string applno)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[14];
        //        param[0] = new SqlParameter("@applno", applno);
        //        param[1] = new SqlParameter("@shsequence", fD_Save_Renewal_BO.holderverification.shholdseq);
        //        param[2] = new SqlParameter("@thsequence", fD_Save_Renewal_BO.holderverification.thholdseq);
        //        param[3] = new SqlParameter("@foliono", fD_Save_Renewal_BO.foliono);
        //        param[4] = new SqlParameter("@fdrno", fD_Save_Renewal_BO.fdrno);
        //        param[5] = new SqlParameter("@createdby", fD_Save_Renewal_BO.createdby);
        //        param[6] = new SqlParameter("@createdbyname", fD_Save_Renewal_BO.createdbyname);
        //        param[7] = new SqlParameter("@createdip", fD_Save_Renewal_BO.createdip);
        //        param[8] = new SqlParameter("@sessionid", fD_Save_Renewal_BO.sessionid);
        //        param[9] = new SqlParameter("@shname", fD_Save_Renewal_BO.holderverification.shholdername);
        //        param[10] = new SqlParameter("@shtype", fD_Save_Renewal_BO.holderverification.shholdtype);
        //        param[11] = new SqlParameter("@thname", fD_Save_Renewal_BO.holderverification.thholdername);
        //        param[12] = new SqlParameter("@thtype", fD_Save_Renewal_BO.holderverification.thholdtype);
        //        param[13] = new SqlParameter("@renewalhdrsequence", fD_Save_Renewal_BO.renewalhdrsequence);

        //        dt = SqlHelper.ExecuteDataTable(_conn, CommandType.StoredProcedure, "USP_FD_SA_Renewal_Save_Holder_Verification", param);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    return dt;
        //}

        //public DataTable Save_Renewal_Bank_Details(FD_Save_Renewal_BO fD_Save_Renewal_BO, string applno)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[11];
        //        param[0] = new SqlParameter("@applno", applno);
        //        param[1] = new SqlParameter("@micrcode", fD_Save_Renewal_BO.bankdetails.micrcode);
        //        param[2] = new SqlParameter("@neftcode", fD_Save_Renewal_BO.bankdetails.neftcode);
        //        param[3] = new SqlParameter("@bankname", fD_Save_Renewal_BO.bankdetails.bankname);
        //        param[4] = new SqlParameter("@branchname", fD_Save_Renewal_BO.bankdetails.branchname);
        //        param[5] = new SqlParameter("@bankaccno", fD_Save_Renewal_BO.bankdetails.bankaccno);
        //        param[6] = new SqlParameter("@createdby", fD_Save_Renewal_BO.createdby);
        //        param[7] = new SqlParameter("@createdbyname", fD_Save_Renewal_BO.createdbyname);
        //        param[8] = new SqlParameter("@sessionid", fD_Save_Renewal_BO.sessionid);
        //        param[9] = new SqlParameter("@createdip", fD_Save_Renewal_BO.createdip);
        //        param[10] = new SqlParameter("@provisionalbankdtlid", fD_Save_Renewal_BO.provisionalbankdtlid);

        //        dt = SqlHelper.ExecuteDataTable(_conn, CommandType.StoredProcedure, "USP_FD_SA_Save_Bankdetails", param);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    return dt;
        //}

        //public DataTable Save_Renewal_Holder_Details(FD_Save_Renewal_BO fD_Save_Renewal_BO, string applno)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[6];
        //        param[0] = new SqlParameter("@applno", applno);
        //        param[1] = new SqlParameter("@createdby", fD_Save_Renewal_BO.createdby);
        //        param[2] = new SqlParameter("@createdbyname", fD_Save_Renewal_BO.createdbyname);
        //        param[3] = new SqlParameter("@createdip", fD_Save_Renewal_BO.createdip);
        //        param[4] = new SqlParameter("@sessionid", fD_Save_Renewal_BO.sessionid);
        //        param[5] = new SqlParameter("@formcode", "FD_RW_Ent_V5");

        //        dt = SqlHelper.ExecuteDataTable(_conn, CommandType.StoredProcedure, "USP_FD_SA_Renewal_Save_Holder_Dtls", param);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    return dt;
        //}

        //public DataTable Save_Renewal_Nominee(FD_Save_Renewal_BO fD_Save_Renewal_BO, string applno)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[4];
        //        param[0] = new SqlParameter("@applno", applno);
        //        param[1] = new SqlParameter("@createdby", fD_Save_Renewal_BO.createdby);
        //        param[2] = new SqlParameter("@createdbyname", fD_Save_Renewal_BO.createdbyname);
        //        param[3] = new SqlParameter("@sessionid", fD_Save_Renewal_BO.sessionid);

        //        dt = SqlHelper.ExecuteDataTable(_conn, CommandType.StoredProcedure, "USP_FD_SA_Save_Nominee_Dtls", param);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    return dt;
        //}

        //public DataTable Save_Renewal_Dtls(FD_Save_Renewal_BO fD_Save_Renewal_BO, string applno)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[3];
        //        param[0] = new SqlParameter("@applno", applno);
        //        param[1] = new SqlParameter("@foliono", fD_Save_Renewal_BO.foliono);
        //        param[2] = new SqlParameter("@createdby", fD_Save_Renewal_BO.createdby);

        //        dt = SqlHelper.ExecuteDataTable(_conn, CommandType.StoredProcedure, "USP_FD_SA_Renewal_SaveRenewal_Dtls", param);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    return dt;
        //}


        public int Insert_Renewal_JSON_Log(FD_Save_Renewal_BO fD_Save_Renewal_BO, string json, string req, string API_Version)
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
                sqlparam[13] = new SqlParameter("@transrefno", fD_Save_Renewal_BO.investmentdtls.transrefno);
                res = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "usp_FD_SA_Renewal_Save_JSON_Log", sqlparam);
                return res;
            }
            catch (Exception ex)
            {
                string exce = ex.Message;
                throw;
            }
        }

        public DataTable Check_Application_Isvalid(FD_Save_Renewal_BO fD_Save_Renewal_BO)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@foliono", fD_Save_Renewal_BO.investmentdtls.foliono);
                param[1] = new SqlParameter("@fdrno", fD_Save_Renewal_BO.investmentdtls.fdrno);

                dt = SqlHelper.ExecuteDataTable(_conn, CommandType.StoredProcedure, "USP_FD_SA_Renewal_Isvalid_AppNo", param);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return dt;
        }

        public DataTable Check_SH_TH(FD_Save_Renewal_BO fD_Save_Renewal_BO)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@foliono", fD_Save_Renewal_BO.investmentdtls.foliono);
                param[1] = new SqlParameter("@fdrno", fD_Save_Renewal_BO.investmentdtls.fdrno);

                dt = SqlHelper.ExecuteDataTable(_conn, CommandType.StoredProcedure, "USP_FD_SA_Renewal_Check_SH_TH", param);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return dt;
        }

        public async Task<string> InsertTransactionDetails(FD_Save_Renewal_BO fD_Save_Renewal_BO, NewApplicationNoBO newApplicationNoBO, string secondholderdtlxml, string thirdholderdtlxml)
        {
            string App_No = "";

            SqlTransaction sqlTrans = null;
            SqlCommand sqlCmd = new SqlCommand();
            SqlCommand sqlCmd1 = new SqlCommand();
            SqlCommand sqlCmd2 = new SqlCommand();
            SqlCommand sqlCmd3 = new SqlCommand();
            SqlCommand sqlCmd4 = new SqlCommand();
            SqlCommand sqlCmd5 = new SqlCommand();
            SqlCommand sqlCmd6 = new SqlCommand();
            SqlCommand sqlCmd7 = new SqlCommand();

            SqlConnection sqlConn = new SqlConnection(_conn);
            sqlConn.Open();
            sqlCmd = sqlConn.CreateCommand();
            sqlCmd1 = sqlConn.CreateCommand();
            sqlCmd2 = sqlConn.CreateCommand();
            sqlCmd3 = sqlConn.CreateCommand();
            sqlCmd4 = sqlConn.CreateCommand();
            sqlCmd5 = sqlConn.CreateCommand();
            sqlCmd6 = sqlConn.CreateCommand();
            sqlCmd7 = sqlConn.CreateCommand();

            sqlTrans = sqlConn.BeginTransaction();
            try
            {
                int j = 0;
                sqlCmd = sqlConn.CreateCommand();
                sqlCmd.Transaction = sqlTrans;
                SqlParameter[] sqlparam = new SqlParameter[11];
                sqlparam[0] = new SqlParameter("@IPAddress", fD_Save_Renewal_BO.additionaldtls.clientipaddress);
                sqlparam[1] = new SqlParameter("@ServerIP", fD_Save_Renewal_BO.additionaldtls.serveripaddress);
                sqlparam[2] = new SqlParameter("@BrowserType", fD_Save_Renewal_BO.additionaldtls.browsertype);
                sqlparam[3] = new SqlParameter("@BrowserVersion", fD_Save_Renewal_BO.additionaldtls.browserversion);
                sqlparam[4] = new SqlParameter("@BrowserMajorVersion", fD_Save_Renewal_BO.additionaldtls.browsermajorversion);
                sqlparam[5] = new SqlParameter("@BrowserMinorVersion", fD_Save_Renewal_BO.additionaldtls.browserminorversion);
                sqlparam[6] = new SqlParameter("@UserAgent", fD_Save_Renewal_BO.additionaldtls.useragent);
                sqlparam[7] = new SqlParameter("@ismobile", string.IsNullOrEmpty(fD_Save_Renewal_BO.additionaldtls.ismobiledevice) ? false : (fD_Save_Renewal_BO.additionaldtls.ismobiledevice.ToUpper().ToString() == "Y" ? true : false));
                sqlparam[8] = new SqlParameter("@Sp_Cp_Trans_Ref_No", string.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.transrefno) ? DBNull.Value : fD_Save_Renewal_BO.investmentdtls.transrefno.Trim());
                sqlparam[9] = new SqlParameter("@SESSION_ID", "");
                sqlparam[10] = new SqlParameter("@SYS_REF_NO", "");
                sqlparam[9].Direction = ParameterDirection.Output;
                sqlparam[9].Size = 200;
                sqlparam[10].Direction = ParameterDirection.Output;
                sqlparam[10].Size = 200;
                sqlCmd.Parameters.AddRange(sqlparam);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "usp_FD_SA_Renewal_InsertSession";
                int hdr = sqlCmd.ExecuteNonQuery();

                fD_Save_Renewal_BO.additionaldtls.sessionid = sqlparam[9].Value.ToString();
                fD_Save_Renewal_BO.additionaldtls.sysrefno = sqlparam[10].Value.ToString();

                if (hdr > 0 && !string.IsNullOrEmpty(fD_Save_Renewal_BO.additionaldtls.sessionid) && !string.IsNullOrEmpty(fD_Save_Renewal_BO.additionaldtls.sysrefno))
                {
                    sqlCmd1 = sqlConn.CreateCommand();
                    sqlCmd1.Transaction = sqlTrans;

                    SqlParameter[] sqlparam1 = new SqlParameter[10];
                    sqlparam1[0] = new SqlParameter("@BusType", newApplicationNoBO.bustype);
                    sqlparam1[1] = new SqlParameter("@Source", newApplicationNoBO.source);
                    sqlparam1[2] = new SqlParameter("@CreatedIP", fD_Save_Renewal_BO.additionaldtls.serveripaddress);
                    sqlparam1[3] = new SqlParameter("@CreatedUserId", fD_Save_Renewal_BO.additionaldtls.sysrefno);
                    sqlparam1[4] = new SqlParameter("@CreatedUserName", newApplicationNoBO.createdbyname);
                    sqlparam1[5] = new SqlParameter("@SessionId", fD_Save_Renewal_BO.additionaldtls.sessionid);
                    sqlparam1[6] = new SqlParameter("@DSource", newApplicationNoBO.dsource);
                    sqlparam1[7] = new SqlParameter("@Sys_Ref_No", fD_Save_Renewal_BO.additionaldtls.sysrefno);
                    sqlparam1[8] = new SqlParameter("@FormCode", "mSupApp");
                    sqlparam1[9] = new SqlParameter("@App_No", "");
                    sqlparam1[9].Direction = ParameterDirection.Output;
                    sqlparam1[9].Size = 200;

                    sqlCmd1.Parameters.AddRange(sqlparam1);
                    sqlCmd1.CommandType = CommandType.StoredProcedure;
                    sqlCmd1.CommandText = "USP_FD_SA_GetApplicationNo";
                    int hdr1 = sqlCmd1.ExecuteNonQuery();

                    if (hdr1 != null)
                    {
                        App_No = sqlparam1[9].Value.ToString();
                    }
                    else
                    {
                        sqlTrans.Rollback();
                        return null;
                    }
                    if (!string.IsNullOrEmpty(App_No))
                    {
                        int fnl = 0;
                        sqlCmd2 = sqlConn.CreateCommand();
                        sqlCmd2.Transaction = sqlTrans;
                        SqlParameter[] sqlparam2 = new SqlParameter[27];
                        sqlparam2[0] = new SqlParameter("@fdrno", fD_Save_Renewal_BO.investmentdtls.fdrno);
                        sqlparam2[1] = new SqlParameter("@foliono", fD_Save_Renewal_BO.investmentdtls.foliono);
                        sqlparam2[2] = new SqlParameter("@applno", App_No);
                        sqlparam2[3] = new SqlParameter("@categorycode", fD_Save_Renewal_BO.investmentdtls.categorycode);
                        sqlparam2[4] = new SqlParameter("@categorydec", fD_Save_Renewal_BO.investmentdtls.categorydesc);
                        sqlparam2[5] = new SqlParameter("@schemecode", fD_Save_Renewal_BO.investmentdtls.schemecode);
                        sqlparam2[6] = new SqlParameter("@schemedec", fD_Save_Renewal_BO.investmentdtls.schemedesc);
                        sqlparam2[7] = new SqlParameter("@intfrqcode", "");
                        sqlparam2[8] = new SqlParameter("@intfrqdec", fD_Save_Renewal_BO.investmentdtls.intfreq);
                        sqlparam2[9] = new SqlParameter("@tenurecode", fD_Save_Renewal_BO.investmentdtls.tenure);
                        sqlparam2[10] = new SqlParameter("@intrate", fD_Save_Renewal_BO.investmentdtls.intrate);
                        sqlparam2[11] = new SqlParameter("@fdramt", fD_Save_Renewal_BO.investmentdtls.fdramt);
                        sqlparam2[12] = new SqlParameter("@renewalfordec", fD_Save_Renewal_BO.investmentdtls.renewalfordec);
                        sqlparam2[13] = new SqlParameter("@existingfdrno", fD_Save_Renewal_BO.investmentdtls.fdrno);
                        sqlparam2[14] = new SqlParameter("@secondholderdtlxml", secondholderdtlxml);
                        sqlparam2[15] = new SqlParameter("@thirdholderdtlxml", thirdholderdtlxml);
                        sqlparam2[16] = new SqlParameter("@nomineedtlid", fD_Save_Renewal_BO.investmentdtls.nomineeseq);
                        sqlparam2[17] = new SqlParameter("@createdby", fD_Save_Renewal_BO.investmentdtls.transrefno);
                        sqlparam2[18] = new SqlParameter("@createdbyname", newApplicationNoBO.createdbyname);
                        sqlparam2[19] = new SqlParameter("@createdip", newApplicationNoBO.createdip);
                        sqlparam2[20] = new SqlParameter("@sessionid", fD_Save_Renewal_BO.additionaldtls.sessionid);
                        sqlparam2[21] = new SqlParameter("@nomname", fD_Save_Renewal_BO.investmentdtls.nomineename);
                        sqlparam2[22] = new SqlParameter("@nomrelation", fD_Save_Renewal_BO.investmentdtls.nomineerelation);

                        sqlparam2[23] = new SqlParameter("@shpanno", fD_Save_Renewal_BO.holderverification.shpanno);
                        sqlparam2[24] = new SqlParameter("@shdob", string.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.shdob) ? DBNull.Value : DateTime.ParseExact(fD_Save_Renewal_BO.holderverification.shdob, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                        sqlparam2[25] = new SqlParameter("@thpanno", fD_Save_Renewal_BO.holderverification.thpanno);
                        sqlparam2[26] = new SqlParameter("@thdob", string.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.thdob) ? DBNull.Value : DateTime.ParseExact(fD_Save_Renewal_BO.holderverification.thdob, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));


                        sqlCmd2.Parameters.AddRange(sqlparam2);
                        sqlCmd2.CommandType = CommandType.StoredProcedure;
                        sqlCmd2.CommandText = "USP_FD_SA_Renewal_Configration_Dtl";
                        fnl = sqlCmd2.ExecuteNonQuery();
                        if (fnl <= 0)
                        {
                            sqlTrans.Rollback();
                            return null;
                        }
                        else if(!string.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.shholdername))
                        {
                            #region Save in Holder verification dtl
                            int fnl1 = 0;
                            sqlCmd3 = sqlConn.CreateCommand();
                            sqlCmd3.Transaction = sqlTrans;
                            SqlParameter[] sqlparam3 = new SqlParameter[26];
                            sqlparam3[0] = new SqlParameter("@applno", App_No);
                            sqlparam3[1] = new SqlParameter("@foliono", fD_Save_Renewal_BO.investmentdtls.foliono);
                            sqlparam3[2] = new SqlParameter("@fdrno", fD_Save_Renewal_BO.investmentdtls.fdrno);
                            sqlparam3[3] = new SqlParameter("@createdby", fD_Save_Renewal_BO.investmentdtls.transrefno);
                            sqlparam3[4] = new SqlParameter("@createdbyname", newApplicationNoBO.createdbyname);
                            sqlparam3[5] = new SqlParameter("@createdip", newApplicationNoBO.createdip);
                            sqlparam3[6] = new SqlParameter("@sessionid", fD_Save_Renewal_BO.additionaldtls.sessionid);
                            sqlparam3[7] = new SqlParameter("@formcode", "mSupApp");

                            sqlparam3[8] = new SqlParameter("@shpanno", fD_Save_Renewal_BO.holderverification.shpanno);
                            sqlparam3[9] = new SqlParameter("@shdob", string.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.shdob) ? DBNull.Value : DateTime.ParseExact(fD_Save_Renewal_BO.holderverification.shdob, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                            sqlparam3[10] = new SqlParameter("@shname", fD_Save_Renewal_BO.holderverification.shholdername);
                            sqlparam3[11] = new SqlParameter("@shverificationtype", fD_Save_Renewal_BO.holderverification.shverificationtype);
                            sqlparam3[12] = new SqlParameter("@shverificationby", fD_Save_Renewal_BO.holderverification.shverificationby);
                            sqlparam3[13] = new SqlParameter("@shverificationstatus", fD_Save_Renewal_BO.holderverification.shverificationstatus);
                            sqlparam3[14] = new SqlParameter("@shotpverified", fD_Save_Renewal_BO.holderverification.shotpverified);
                            sqlparam3[15] = new SqlParameter("@shseq", fD_Save_Renewal_BO.holderverification.shseq);


                            sqlparam3[16] = new SqlParameter("@thpanno", fD_Save_Renewal_BO.holderverification.thpanno);
                            sqlparam3[17] = new SqlParameter("@thdob", string.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.thdob) ? DBNull.Value : DateTime.ParseExact(fD_Save_Renewal_BO.holderverification.thdob, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                            sqlparam3[18] = new SqlParameter("@thname", fD_Save_Renewal_BO.holderverification.thholdername);
                            sqlparam3[19] = new SqlParameter("@thverificationtype", fD_Save_Renewal_BO.holderverification.thverificationtype);
                            sqlparam3[20] = new SqlParameter("@thverificationby", fD_Save_Renewal_BO.holderverification.thverificationby);
                            sqlparam3[21] = new SqlParameter("@thverificationstatus", fD_Save_Renewal_BO.holderverification.thverificationstatus);
                            sqlparam3[22] = new SqlParameter("@thotpverified", fD_Save_Renewal_BO.holderverification.thotpverified);
                            sqlparam3[23] = new SqlParameter("@thseq", fD_Save_Renewal_BO.holderverification.thseq);
                            sqlparam3[24] = new SqlParameter("@sysrefno", fD_Save_Renewal_BO.additionaldtls.sysrefno);
                            //sqlparam3[25] = new SqlParameter("@source", "mSupApp");
                            sqlparam3[25] = new SqlParameter("@source", "RW_mSupApp");


                            sqlCmd3.Parameters.AddRange(sqlparam3);
                            sqlCmd3.CommandType = CommandType.StoredProcedure;
                            sqlCmd3.CommandText = "USP_FD_SA_Renewal_Save_Holder_Verification";
                            fnl1 = sqlCmd3.ExecuteNonQuery();

                            #endregion
                        }

                           
                        #region save in bank dtls
                            int fnl2 = 0;
                            sqlCmd4 = sqlConn.CreateCommand();
                            sqlCmd4.Transaction = sqlTrans;
                            SqlParameter[] sqlparam4 = new SqlParameter[12];
                            sqlparam4[0] = new SqlParameter("@applno", App_No);
                            sqlparam4[1] = new SqlParameter("@micrcode", fD_Save_Renewal_BO.investmentdtls.micrcode);
                            sqlparam4[2] = new SqlParameter("@neftcode", fD_Save_Renewal_BO.investmentdtls.neftcode);
                            sqlparam4[3] = new SqlParameter("@bankname", fD_Save_Renewal_BO.investmentdtls.bankname);
                            sqlparam4[4] = new SqlParameter("@branchname", fD_Save_Renewal_BO.investmentdtls.branchname);
                            sqlparam4[5] = new SqlParameter("@bankaccno", fD_Save_Renewal_BO.investmentdtls.bankaccountno);
                            sqlparam4[6] = new SqlParameter("@createdby", fD_Save_Renewal_BO.investmentdtls.transrefno);
                            sqlparam4[7] = new SqlParameter("@createdbyname", newApplicationNoBO.createdbyname);
                            sqlparam4[8] = new SqlParameter("@sessionid", fD_Save_Renewal_BO.additionaldtls.sessionid);
                            sqlparam4[9] = new SqlParameter("@createdip", newApplicationNoBO.createdip);
                            sqlparam4[10] = new SqlParameter("@sysrefno", fD_Save_Renewal_BO.additionaldtls.sysrefno);
                            sqlparam4[11] = new SqlParameter("@formcode", "mSupApp");
                            sqlCmd4.Parameters.AddRange(sqlparam4);
                            sqlCmd4.CommandType = CommandType.StoredProcedure;
                            sqlCmd4.CommandText = "USP_FD_SA_Save_Bankdetails";
                            fnl2 = sqlCmd4.ExecuteNonQuery();
                            #endregion
                        if (fnl2 <= 0)
                        {
                            sqlTrans.Rollback();
                            return null;
                        }
                        else if(!string.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.nomineename))
                        {
                                #region save in nominee
                                int fnl3 = 0;
                                sqlCmd5 = sqlConn.CreateCommand();
                                sqlCmd5.Transaction = sqlTrans;
                                SqlParameter[] sqlparam5 = new SqlParameter[18];
                                sqlparam5[0] = new SqlParameter("@applno", App_No);
                                sqlparam5[1] = new SqlParameter("@createdby", fD_Save_Renewal_BO.investmentdtls.transrefno);
                                sqlparam5[2] = new SqlParameter("@createdbyname", newApplicationNoBO.createdbyname);
                                sqlparam5[3] = new SqlParameter("@sessionid", fD_Save_Renewal_BO.additionaldtls.sessionid);
                                sqlparam5[4] = new SqlParameter("@sysrefno", fD_Save_Renewal_BO.additionaldtls.sysrefno);
                                sqlparam5[5] = new SqlParameter("@name", fD_Save_Renewal_BO.investmentdtls.nomineename);
                                sqlparam5[6] = new SqlParameter("@relation", fD_Save_Renewal_BO.investmentdtls.nomineerelation);
                                sqlparam5[7] = new SqlParameter("@dob", string.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.nomineedob) ? DBNull.Value : DateTime.ParseExact(fD_Save_Renewal_BO.investmentdtls.nomineedob, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                                sqlparam5[8] = new SqlParameter("@guardianname", fD_Save_Renewal_BO.investmentdtls.guardianname);
                                sqlparam5[9] = new SqlParameter("@guardianadd1", fD_Save_Renewal_BO.investmentdtls.guardianadd1);
                                sqlparam5[10] = new SqlParameter("@guardianadd2", fD_Save_Renewal_BO.investmentdtls.guardianadd2==""?"":fD_Save_Renewal_BO.investmentdtls.guardianadd2);
                                sqlparam5[11] = new SqlParameter("@guardianadd3", fD_Save_Renewal_BO.investmentdtls.guardianadd3==""?"":fD_Save_Renewal_BO.investmentdtls.guardianadd3);
                                sqlparam5[12] = new SqlParameter("@guardiancity", fD_Save_Renewal_BO.investmentdtls.guardiancity==""?"":fD_Save_Renewal_BO.investmentdtls.guardiancity);
                                sqlparam5[13] = new SqlParameter("@guardianpin", fD_Save_Renewal_BO.investmentdtls.guardianpin);
                                sqlparam5[14] = new SqlParameter("@guardiancountry", fD_Save_Renewal_BO.investmentdtls.guardiancountry);
                                sqlparam5[15] = new SqlParameter("@guardianstate", fD_Save_Renewal_BO.investmentdtls.guardianstate);
                                sqlparam5[16] = new SqlParameter("@guardiandistrict", fD_Save_Renewal_BO.investmentdtls.guardiandistrict);
                                sqlparam5[17] = new SqlParameter("@source", "RW_mSupApp");


                            sqlCmd5.Parameters.AddRange(sqlparam5);
                                sqlCmd5.CommandType = CommandType.StoredProcedure;
                                sqlCmd5.CommandText = "USP_FD_SA_Save_Nominee_Dtls";
                                fnl3 = sqlCmd5.ExecuteNonQuery();
                                #endregion
                        }

                        if (fnl2 <= 0)
                        {
                            sqlTrans.Rollback();
                            return null;
                        }
                        else
                        {
                            #region save in renewal dtls
                            int fnl4 = 0;
                            sqlCmd6 = sqlConn.CreateCommand();
                            sqlCmd6.Transaction = sqlTrans;
                            SqlParameter[] sqlparam6 = new SqlParameter[3];
                            sqlparam6[0] = new SqlParameter("@applno", App_No);
                            sqlparam6[1] = new SqlParameter("@foliono", fD_Save_Renewal_BO.investmentdtls.foliono);
                            sqlparam6[2] = new SqlParameter("@createdby", fD_Save_Renewal_BO.investmentdtls.transrefno);
                            sqlCmd6.Parameters.AddRange(sqlparam6);
                            sqlCmd6.CommandType = CommandType.StoredProcedure;
                            sqlCmd6.CommandText = "USP_FD_SA_Renewal_SaveRenewal_Dtls";
                            fnl4 = sqlCmd6.ExecuteNonQuery();
                            #endregion
                        

                            if (fnl4 <= 0)
                            {
                                sqlTrans.Rollback();
                                return null;
                            }
                            else
                            {
                                #region save holder dtls
                                int fnl5 = 0;
                                sqlCmd7 = sqlConn.CreateCommand();
                                sqlCmd7.Transaction = sqlTrans;
                                SqlParameter[] sqlparam7 = new SqlParameter[7];
                                sqlparam7[0] = new SqlParameter("@applno", App_No);
                                sqlparam7[1] = new SqlParameter("@createdby", fD_Save_Renewal_BO.investmentdtls.transrefno);
                                sqlparam7[2] = new SqlParameter("@createdbyname", newApplicationNoBO.createdbyname);
                                sqlparam7[3] = new SqlParameter("@createdip", newApplicationNoBO.createdip);
                                sqlparam7[4] = new SqlParameter("@sessionid", fD_Save_Renewal_BO.additionaldtls.sessionid);
                                sqlparam7[5] = new SqlParameter("@formcode", "mSupApp");
                                sqlparam7[6] = new SqlParameter("sysrefno", fD_Save_Renewal_BO.additionaldtls.sysrefno);
                                sqlCmd7.Parameters.AddRange(sqlparam7);
                                sqlCmd7.CommandType = CommandType.StoredProcedure;
                                sqlCmd7.CommandText = "USP_FD_SA_Renewal_Save_Holder_Dtls";
                                fnl5 = sqlCmd7.ExecuteNonQuery();
                                #endregion
                                if (fnl5 <= 0)
                                {
                                    sqlTrans.Rollback();
                                    return null;
                                }
                                else
                                {
                                    sqlTrans.Commit();
                                    return App_No;
                                }
                            }
                        }
                    }
                }
                else
                {
                    sqlTrans.Rollback();
                    return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                sqlTrans.Rollback();
                //if (Convert.ToString(ex.Message).Contains("MFFDCP-API-E-VAL"))
                //    return ex.Message.ToString().Replace("@", System.Environment.NewLine);
                //else
                //{
                //    throw ex;
                //}
                throw ex;
                //return null;
            }
            finally
            {
                sqlConn.Close();
                sqlCmd = null;
                sqlCmd1 = null;
                sqlCmd2 = null;
                sqlCmd3 = null;
                sqlCmd4 = null;
                sqlCmd5 = null;
                sqlCmd6 = null;
                sqlCmd7 = null;
                sqlTrans.Dispose();
            }
        }


        public async Task<List<Error1>> isValidate(FD_Save_Renewal_BO fD_Save_Renewal_BO, string SH_Exist,string TH_Exist)
        {
            SaveValidation validation = new SaveValidation();
            List<Error1> ER = new List<Error1>();
            Error1 sb = new Error1();
            try
            {
                List<UDTValidation> objVBO = new List<UDTValidation>();
                ValidationBO objBo = new ValidationBO();
                bool IsValid = true;
                var regexAmount = @"^[0-9]\d*(\.\d+)?$";
                var regexName = @"^[A-Za-z'\-\p{L}\p{Zs}\p{Lu}\p{Ll}\']+$";
                var regexAdd = @"^[\sA-Za-z0-9'\-\p{L}\p{Zs}\p{Lu}\p{Ll}\']+$";

                var regexNumeric = @"^[0-9]*$";
                var regexPIN = @"^[1-9][0-9]{5}$";
                var regexMobile = @"^[6-9]\d{9}$";

                var regexEmail =
                  @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                  @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
                int PANLength = 10, AmountLength = 15, NameLength = 30, FullNameLength = 100, f_Inv_Add_Address_Length = 39;

                string[] autorenewaltype = { "P", "F" };
                string[] booltype = { "Y", "N" };


                if (fD_Save_Renewal_BO.investmentdtls == null && fD_Save_Renewal_BO.investmentdtls == null && fD_Save_Renewal_BO.investmentdtls == null && fD_Save_Renewal_BO.holderverification == null)
                {
                    sb = new Error1();
                    sb.field = String.Empty;
                    sb.code = "MFFDSUP-TRANS-E-VAL";
                    sb.message = "Please provide all mandatory parameters";
                }


                //Direct model property
                if (String.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.fdrno))
                {
                    sb = new Error1();
                    IsValid = false;
                    sb.field = "fdrno";
                    sb.code = SaveErrorMsg.ErrorMsgs["fdrno"].Key;
                    sb.message = SaveErrorMsg.ErrorMsgs["fdrno"].Value;
                    ER.Add(sb);
                }
                if (String.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.foliono))
                {
                    sb = new Error1();
                    IsValid = false;
                    sb.field = "foliono";
                    sb.code = SaveErrorMsg.ErrorMsgs["foliono"].Key;
                    sb.message = SaveErrorMsg.ErrorMsgs["foliono"].Value;
                    ER.Add(sb);
                }
                if (String.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.transrefno))
                {
                    sb = new Error1();
                    IsValid = false;
                    sb.field = "transrefno";
                    sb.code = SaveErrorMsg.ErrorMsgs["transrefno"].Key;
                    sb.message = SaveErrorMsg.ErrorMsgs["transrefno"].Value;
                    ER.Add(sb);
                }


                #region FD Config Details

                if (String.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.categorycode))
                {
                    sb = new Error1();
                    IsValid = false;
                    sb.field = "categorycode";
                    sb.code = SaveErrorMsg.ErrorMsgs["categorycode"].Key;
                    sb.message = SaveErrorMsg.ErrorMsgs["categorycode"].Value;
                    ER.Add(sb);
                }
                if (String.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.categorydesc))
                {
                    sb = new Error1();
                    IsValid = false;
                    sb.field = "categorydec";
                    sb.code = SaveErrorMsg.ErrorMsgs["categorydec"].Key;
                    sb.message = SaveErrorMsg.ErrorMsgs["categorydec"].Value;
                    ER.Add(sb);
                }
                if (String.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.schemecode))
                {
                    sb = new Error1();
                    IsValid = false;
                    sb.field = "schemecode";
                    sb.code = SaveErrorMsg.ErrorMsgs["schemecode"].Key;
                    sb.message = SaveErrorMsg.ErrorMsgs["schemecode"].Value;
                    ER.Add(sb);
                }
                if (String.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.schemedesc))
                {
                    sb = new Error1();
                    IsValid = false;
                    sb.field = "schemedec";
                    sb.code = SaveErrorMsg.ErrorMsgs["schemedec"].Key;
                    sb.message = SaveErrorMsg.ErrorMsgs["schemedec"].Value;
                    ER.Add(sb);
                }
                if (String.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.intfreq))
                {
                    sb = new Error1();
                    IsValid = false;
                    sb.field = "intfrqcode";
                    sb.code = SaveErrorMsg.ErrorMsgs["intfrqcode"].Key;
                    sb.message = SaveErrorMsg.ErrorMsgs["intfrqcode"].Value;
                    ER.Add(sb);
                }
                if (String.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.intfreq))
                {
                    sb = new Error1();
                    IsValid = false;
                    sb.field = "intfrqdec";
                    sb.code = SaveErrorMsg.ErrorMsgs["intfrqdec"].Key;
                    sb.message = SaveErrorMsg.ErrorMsgs["intfrqdec"].Value;
                    ER.Add(sb);
                }

                if (!String.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.tenure))
                {
                    bool isNumeric = Regex.IsMatch(fD_Save_Renewal_BO.investmentdtls.tenure, regexNumeric);
                    if (!isNumeric)
                    {
                        IsValid = false;
                        sb = new Error1();
                        sb.field = "tenureNumeric";
                        sb.code = SaveErrorMsg.ErrorMsgs["tenureNumeric"].Key;
                        sb.message = SaveErrorMsg.ErrorMsgs["tenureNumeric"].Value;
                        ER.Add(sb);
                    }
                }
                else
                {
                    sb = new Error1();
                    IsValid = false;
                    sb.field = "tenurecode";
                    sb.code = SaveErrorMsg.ErrorMsgs["tenurecode"].Key;
                    sb.message = SaveErrorMsg.ErrorMsgs["tenurecode"].Value;
                    ER.Add(sb);
                }
                if (!String.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.intrate))
                {
                    bool isIntRateValid = Regex.IsMatch(fD_Save_Renewal_BO.investmentdtls.intrate.ToString(), regexAmount);
                    if (!isIntRateValid)
                    {
                        IsValid = false;
                        sb = new Error1();
                        sb.field = "AmtNumeric";
                        sb.code = SaveErrorMsg.ErrorMsgs["AmtNumeric"].Key;
                        sb.message = SaveErrorMsg.ErrorMsgs["AmtNumeric"].Value;
                        ER.Add(sb);
                    }
                }
                else
                {
                    sb = new Error1();
                    IsValid = false;
                    sb.field = "intrate";
                    sb.code = SaveErrorMsg.ErrorMsgs["intrate"].Key;
                    sb.message = SaveErrorMsg.ErrorMsgs["intrate"].Value;
                    ER.Add(sb);
                }
                if (!String.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.fdramt))
                {
                    bool isAmountValid = Regex.IsMatch(fD_Save_Renewal_BO.investmentdtls.fdramt, regexAmount);
                    if (!isAmountValid)
                    {
                        IsValid = false;
                        sb = new Error1();
                        sb.field = "AmtNumeric";
                        sb.code = SaveErrorMsg.ErrorMsgs["AmtNumeric"].Key;
                        sb.message = SaveErrorMsg.ErrorMsgs["AmtNumeric"].Value;
                        ER.Add(sb);
                    }
                }
                else
                {
                    sb = new Error1();
                    IsValid = false;
                    sb.field = "fdramt";
                    sb.code = SaveErrorMsg.ErrorMsgs["fdramt"].Key;
                    sb.message = SaveErrorMsg.ErrorMsgs["fdramt"].Value;
                    ER.Add(sb);
                }
                if (String.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.renewalfordec))
                {
                    sb = new Error1();
                    IsValid = false;
                    sb.field = "renewalfordec";
                    sb.code = SaveErrorMsg.ErrorMsgs["renewalfordec"].Key;
                    sb.message = SaveErrorMsg.ErrorMsgs["renewalfordec"].Value;
                    ER.Add(sb);
                }

                #endregion

                #region Bank details
                if (String.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.micrcode))
                {
                    IsValid = false;
                    sb = new Error1();
                    sb.field = "micrcode";
                    sb.code = SaveErrorMsg.ErrorMsgs["micrcode"].Key;
                    sb.message = SaveErrorMsg.ErrorMsgs["micrcode"].Value;
                    ER.Add(sb);
                }
                if (String.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.neftcode))
                {
                    IsValid = false;
                    sb = new Error1();
                    sb.field = "neftcode";
                    sb.code = SaveErrorMsg.ErrorMsgs["neftcode"].Key;
                    sb.message = SaveErrorMsg.ErrorMsgs["neftcode"].Value;
                    ER.Add(sb);
                }
                if (String.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.bankname))
                {
                    IsValid = false;
                    sb = new Error1();
                    sb.field = "bankname";
                    sb.code = SaveErrorMsg.ErrorMsgs["bankname"].Key;
                    sb.message = SaveErrorMsg.ErrorMsgs["bankname"].Value;
                    ER.Add(sb);
                }
                if (String.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.branchname))
                {
                    IsValid = false;
                    sb = new Error1();
                    sb.field = "branchname";
                    sb.code = SaveErrorMsg.ErrorMsgs["branchname"].Key;
                    sb.message = SaveErrorMsg.ErrorMsgs["branchname"].Value;
                    ER.Add(sb);
                }
                if (String.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.bankaccountno))
                {
                    IsValid = false;
                    sb = new Error1();
                    sb.field = "bankaccno";
                    sb.code = SaveErrorMsg.ErrorMsgs["bankaccno"].Key;
                    sb.message = SaveErrorMsg.ErrorMsgs["bankaccno"].Value;
                    ER.Add(sb);
                }
                #endregion

                #region Nominee details

                // if (String.IsNullOrEmpty(fD_Save_Renewal_BO.nominee.name))
                // {
                //     IsValid = false;
                //     sb = new Error1();
                //     sb.field = "name";
                //     sb.code = SaveErrorMsg.ErrorMsgs["name"].Key;
                //     sb.message = SaveErrorMsg.ErrorMsgs["name"].Value;
                //     ER.Add(sb);
                // }

                // if (!String.IsNullOrEmpty(fD_Save_Renewal_BO.nominee.dob))
                // {
                //     if (validation.IsValidDateFormat(fD_Save_Renewal_BO.nominee.dob))
                //     {
                //         DateTime result;
                //         if (DateTime.TryParse(fD_Save_Renewal_BO.nominee.dob, out result))
                //         {
                //             string.Format("{0:DD-MM-YYYY hh:mm:ss}", result);
                //             if (result > DateTime.Now)
                //             {
                //                 sb = new Error1();
                //                 IsValid = false;
                //                 sb.field = "dob";
                //                 sb.code = SaveErrorMsg.ErrorMsgs["dtFutureNom"].Key;
                //                 sb.message = SaveErrorMsg.ErrorMsgs["dtFutureNom"].Value;
                //                 ER.Add(sb);
                //             }
                //         }
                //     }
                //     else
                //     {
                //         sb = new Error1();
                //         IsValid = false;
                //         sb.field = "dob";
                //         sb.code = SaveErrorMsg.ErrorMsgs["dtFormatNom"].Key;
                //         sb.message = SaveErrorMsg.ErrorMsgs["dtFormatNom"].Value;
                //         ER.Add(sb);

                //     }

                // }
                // else
                // {
                //     sb = new Error1();
                //     IsValid = false;
                //     sb.field = "dob";
                //     sb.code = SaveErrorMsg.ErrorMsgs["dob"].Key;
                //     sb.message = SaveErrorMsg.ErrorMsgs["dob"].Value;
                //     ER.Add(sb);
                // }

                // if (String.IsNullOrEmpty(fD_Save_Renewal_BO.nominee.relation))
                // {
                //     IsValid = false;
                //     sb = new Error1();
                //     sb.field = "nomrelation";
                //     sb.code = SaveErrorMsg.ErrorMsgs["nomrelation"].Key;
                //     sb.message = SaveErrorMsg.ErrorMsgs["nomrelation"].Value;
                //     ER.Add(sb);
                // }

                bool isNomGuardian = false;
                if (!string.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.nomineedob) && isMinor(fD_Save_Renewal_BO.investmentdtls.nomineedob) < 18M)
                {
                    isNomGuardian = true;
                }

                if (isNomGuardian)
                {
                    var regExpPostalCode = @"^[0-9]{6}$";
                    var regExprAddress = @"^[a-zA-Z0-9.,\-\/ ]+$";
                     var regExpcharactersOnly = @"^[A-Za-z ]+$";

                    if(String.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.guardianname)){      
                        IsValid = false;
                        sb = new Error1();
                        sb.field = "guardianname";
                        sb.code = SaveErrorMsg.ErrorMsgs["guardianname"].Key;
                        sb.message = SaveErrorMsg.ErrorMsgs["guardianname"].Value;
                        ER.Add(sb);
                    }

                    if(String.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.guardianadd1)){      
                        IsValid = false;
                        sb = new Error1();
                        sb.field = "guardianadd1";
                        sb.code = SaveErrorMsg.ErrorMsgs["guardianaddblnk"].Key;
                        sb.message = SaveErrorMsg.ErrorMsgs["guardianaddblnk"].Value;
                        ER.Add(sb);
                    }
                    else
                    {
                        bool isAddrValid = Regex.IsMatch(fD_Save_Renewal_BO.investmentdtls.guardianadd1, regExprAddress, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                        if (!isAddrValid)
                        {
                            IsValid = false;
                            sb = new Error1();
                            sb.field = "guardianadd1";
                            sb.code = SaveErrorMsg.ErrorMsgs["guardianadd_invalid"].Key;
                            sb.message = SaveErrorMsg.ErrorMsgs["guardianadd_invalid"].Value;
                            ER.Add(sb);
                        }
                    }

                    if(String.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.guardiancity)){      
                        IsValid = false;
                        sb = new Error1();
                        sb.field = "guardiancity";
                        sb.code = SaveErrorMsg.ErrorMsgs["guardiancityblnk"].Key;
                        sb.message = SaveErrorMsg.ErrorMsgs["guardiancityblnk"].Value;
                        ER.Add(sb);
                    }
                    else
                    {
                        bool isStateValid = Regex.IsMatch(fD_Save_Renewal_BO.investmentdtls.guardiancity, regExpcharactersOnly, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                        if (!isStateValid)
                        {
                            IsValid = false;
                            sb = new Error1();
                            sb.field = "guardiancity";
                            sb.code = SaveErrorMsg.ErrorMsgs["guardiancity_invalid"].Key;
                            sb.message = SaveErrorMsg.ErrorMsgs["guardiancity_invalid"].Value;
                            ER.Add(sb);
                        }
                    }

                    if (string.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.guardianpin))
                    {
                         IsValid = false;
                         sb = new Error1();
                        sb.field = "guardianpin";
                        sb.code = SaveErrorMsg.ErrorMsgs["guardianpinblnk"].Key;
                        sb.message = SaveErrorMsg.ErrorMsgs["guardianpinblnk"].Value;
                        ER.Add(sb);
                    }
                    else
                    {
                        bool isPincodeValid = Regex.IsMatch(fD_Save_Renewal_BO.investmentdtls.guardianpin, regExpPostalCode, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                        if (!isPincodeValid)
                        {
                            IsValid = false;
                              sb = new Error1();
                            sb.field = "guardianpin";
                            sb.code = SaveErrorMsg.ErrorMsgs["guardianpin_invalid"].Key;
                            sb.message = SaveErrorMsg.ErrorMsgs["guardianpin_invalid"].Value;
                            ER.Add(sb);
                        }
                    }

                    if(String.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.guardianstate)){      
                        IsValid = false;
                        sb = new Error1();
                        sb.field = "guardianstate";
                        sb.code = SaveErrorMsg.ErrorMsgs["guardianstateblnk"].Key;
                        sb.message = SaveErrorMsg.ErrorMsgs["guardianstateblnk"].Value;
                        ER.Add(sb);
                    }
                    else
                    {
                        bool isStateValid = Regex.IsMatch(fD_Save_Renewal_BO.investmentdtls.guardianstate, regExpcharactersOnly, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                        if (!isStateValid)
                        {
                            IsValid = false;
                            sb = new Error1();
                            sb.field = "guardianstate";
                            sb.code = SaveErrorMsg.ErrorMsgs["guardianstate_invalid"].Key;
                            sb.message = SaveErrorMsg.ErrorMsgs["guardianstate_invalid"].Value;
                            ER.Add(sb);
                        }
                    }


                    if(String.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.guardiandistrict)){      
                        IsValid = false;
                        sb = new Error1();
                        sb.field = "guardiandistrict";
                        sb.code = SaveErrorMsg.ErrorMsgs["guardiandistrictblnk"].Key;
                        sb.message = SaveErrorMsg.ErrorMsgs["guardiandistrictblnk"].Value;
                        ER.Add(sb);
                    }
                    else
                    {
                        bool isDistrictValid = Regex.IsMatch(fD_Save_Renewal_BO.investmentdtls.guardiandistrict, regExpcharactersOnly, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                        if (!isDistrictValid)
                        {
                            IsValid = false;
                            sb = new Error1();
                            sb.field = "district";
                            sb.code = SaveErrorMsg.ErrorMsgs["guardiandistrict_invalid"].Key;
                            sb.message = SaveErrorMsg.ErrorMsgs["guardiandistrict_invalid"].Value;
                            ER.Add(sb);
                        }
                    }                                          
                }

                #endregion

                #region Holder Verification details

                if (SH_Exist == "Exists")
                {
                    bool isPANValid_SH = false;
                    if (!String.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.shpanno))
                    {
                        if (fD_Save_Renewal_BO.holderverification.shpanno.Length <= PANLength)
                        {
                            isPANValid_SH = validation.IsValidPANFormat(fD_Save_Renewal_BO.holderverification.shpanno);
                            if (!isPANValid_SH)
                            {
                                IsValid = false;
                                sb = new Error1();
                                sb.field = "shpanno";
                                sb.code = SaveErrorMsg.ErrorMsgs["PANInvalidSH"].Key;
                                sb.message = SaveErrorMsg.ErrorMsgs["PANInvalidSH"].Value;
                                ER.Add(sb);
                            }
                        }
                        else
                        {
                            IsValid = false;
                            sb = new Error1();
                            sb.field = "shpanno";
                            sb.code = SaveErrorMsg.ErrorMsgs["PANLengthSH"].Key;
                            sb.message = SaveErrorMsg.ErrorMsgs["PANLengthSH"].Value;
                            ER.Add(sb);
                        }
                    }
                    else
                    {
                        IsValid = false;
                        sb = new Error1();
                        sb.field = "shpanno";
                        sb.code = SaveErrorMsg.ErrorMsgs["shpanno"].Key;
                        sb.message = SaveErrorMsg.ErrorMsgs["shpanno"].Value;
                        ER.Add(sb);
                    }

                    if (!String.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.shdob))
                    {
                        if (validation.IsValidDateFormat(fD_Save_Renewal_BO.holderverification.shdob))
                        {
                            DateTime result;
                            if (DateTime.TryParse(fD_Save_Renewal_BO.holderverification.shdob, out result))
                            {
                                string.Format("{0:DD-MM-YYYY hh:mm:ss}", result);
                                if (result > DateTime.Now)
                                {
                                    sb = new Error1();
                                    IsValid = false;
                                    sb.field = "shdob";
                                    sb.code = SaveErrorMsg.ErrorMsgs["dtFutureSH"].Key;
                                    sb.message = SaveErrorMsg.ErrorMsgs["dtFutureSH"].Value;
                                    ER.Add(sb);

                                }
                            }
                        }
                        else
                        {
                            sb = new Error1();
                            IsValid = false;
                            sb.field = "shdob";
                            sb.code = SaveErrorMsg.ErrorMsgs["dtFormatSH"].Key;
                            sb.message = SaveErrorMsg.ErrorMsgs["dtFormatSH"].Value;
                            ER.Add(sb);

                        }

                    }
                    else
                    {
                        sb = new Error1();
                        IsValid = false;
                        sb.field = "shdob";
                        sb.code = SaveErrorMsg.ErrorMsgs["shdob"].Key;
                        sb.message = SaveErrorMsg.ErrorMsgs["shdob"].Value;
                        ER.Add(sb);
                    }

                    if (String.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.shholdername))
                    {
                        IsValid = false;
                        sb = new Error1();
                        sb.field = "shholdername";
                        sb.code = SaveErrorMsg.ErrorMsgs["shholdername"].Key;
                        sb.message = SaveErrorMsg.ErrorMsgs["shholdername"].Value;
                        ER.Add(sb);
                    }

                    if (String.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.shverificationtype))
                    {
                        IsValid = false;
                        sb = new Error1();
                        sb.field = "shverificationtype";
                        sb.code = SaveErrorMsg.ErrorMsgs["shverificationtype"].Key;
                        sb.message = SaveErrorMsg.ErrorMsgs["shverificationtype"].Value;
                        ER.Add(sb);
                    }

                    if (!String.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.shverificationby))
                    {
                        bool isMobileValid = Regex.IsMatch(fD_Save_Renewal_BO.holderverification.shverificationby, regexMobile);
                        if (!isMobileValid)
                        {
                            sb = new Error1();
                            IsValid = false;
                            sb.field = "shverificationby";
                            sb.code = SaveErrorMsg.ErrorMsgs["MobFormatSH"].Key;
                            sb.message = SaveErrorMsg.ErrorMsgs["MobFormatSH"].Value;
                            ER.Add(sb);
                        }
                    }
                    else
                    {
                        sb = new Error1();
                        IsValid = false;
                        sb.field = "shverificationby";
                        sb.code = SaveErrorMsg.ErrorMsgs["shverificationby"].Key;
                        sb.message = SaveErrorMsg.ErrorMsgs["shverificationby"].Value;
                        ER.Add(sb);
                    }

                    if (String.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.shverificationstatus))
                    {
                        IsValid = false;
                        sb = new Error1();
                        sb.field = "shverificationstatus";
                        sb.code = SaveErrorMsg.ErrorMsgs["shverificationstatus"].Key;
                        sb.message = SaveErrorMsg.ErrorMsgs["shverificationstatus"].Value;
                        ER.Add(sb);
                    }

                    if (string.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.shotpverified))
                    {
                        sb = new Error1();
                        IsValid = false;
                        sb.field = "shotpverified";
                        sb.code = SaveErrorMsg.ErrorMsgs["shotpverifiedblnk"].Key;
                        sb.message = SaveErrorMsg.ErrorMsgs["shotpverifiedblnk"].Value;
                        ER.Add(sb);
                    }
                    else
                    {

                        if (Array.Exists(booltype, E => (E == fD_Save_Renewal_BO.holderverification.shotpverified.ToUpper().ToString())))
                        {
                            if (!(IsConvertBoolean(fD_Save_Renewal_BO.holderverification.shotpverified)))
                            {
                                sb = new Error1();
                                IsValid = false;
                                sb.field = "shotpverified";
                                sb.code = SaveErrorMsg.ErrorMsgs["shotpverifiedtrue"].Key;
                                sb.message = SaveErrorMsg.ErrorMsgs["shotpverifiedtrue"].Value;
                                ER.Add(sb);

                            }
                        }
                        else
                        {
                            sb = new Error1();
                            IsValid = false;
                            sb.field = "isshverified";
                            sb.code = SaveErrorMsg.ErrorMsgs["isshverifiedyorn"].Key;
                            sb.message = SaveErrorMsg.ErrorMsgs["isshverifiedyorn"].Value;
                            ER.Add(sb);
                        }
                    }

                    if (String.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.shseq))
                    {
                        IsValid = false;
                        sb = new Error1();
                        sb.field = "shseq";
                        sb.code = SaveErrorMsg.ErrorMsgs["shseq"].Key;
                        sb.message = SaveErrorMsg.ErrorMsgs["shseq"].Value;
                        ER.Add(sb);
                    }



                }


                if (TH_Exist == "Exists")
                {
                    bool isPANValid_TH = false;
                    if (!String.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.thpanno))
                    {
                        if (fD_Save_Renewal_BO.holderverification.thpanno.Length <= PANLength)
                        {
                            isPANValid_TH = validation.IsValidPANFormat(fD_Save_Renewal_BO.holderverification.thpanno);
                            if (!isPANValid_TH)
                            {
                                IsValid = false;
                                sb = new Error1();
                                sb.field = "thpanno";
                                sb.code = SaveErrorMsg.ErrorMsgs["PANInvalidTH"].Key;
                                sb.message = SaveErrorMsg.ErrorMsgs["PANInvalidTH"].Value;
                                ER.Add(sb);
                            }
                        }
                        else
                        {
                            IsValid = false;
                            sb = new Error1();
                            sb.field = "thpanno";
                            sb.code = SaveErrorMsg.ErrorMsgs["PANLengthTH"].Key;
                            sb.message = SaveErrorMsg.ErrorMsgs["PANLengthTH"].Value;
                            ER.Add(sb);
                        }
                    }
                    else
                    {
                        IsValid = false;
                        sb = new Error1();
                        sb.field = "thpanno";
                        sb.code = SaveErrorMsg.ErrorMsgs["thpanno"].Key;
                        sb.message = SaveErrorMsg.ErrorMsgs["thpanno"].Value;
                        ER.Add(sb);
                    }

                    if (!String.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.thdob))
                    {
                        if (validation.IsValidDateFormat(fD_Save_Renewal_BO.holderverification.thdob))
                        {
                            DateTime result;
                            if (DateTime.TryParse(fD_Save_Renewal_BO.holderverification.thdob, out result))
                            {
                                string.Format("{0:DD-MM-YYYY hh:mm:ss}", result);
                                if (result > DateTime.Now)
                                {
                                    sb = new Error1();
                                    IsValid = false;
                                    sb.field = "thdob";
                                    sb.code = SaveErrorMsg.ErrorMsgs["dtFutureTH"].Key;
                                    sb.message = SaveErrorMsg.ErrorMsgs["dtFutureTH"].Value;
                                    ER.Add(sb);

                                }
                            }
                        }
                        else
                        {
                            sb = new Error1();
                            IsValid = false;
                            sb.field = "thdob";
                            sb.code = SaveErrorMsg.ErrorMsgs["dtFormatTH"].Key;
                            sb.message = SaveErrorMsg.ErrorMsgs["dtFormatTH"].Value;
                            ER.Add(sb);

                        }

                    }
                    else
                    {
                        sb = new Error1();
                        IsValid = false;
                        sb.field = "thdob";
                        sb.code = SaveErrorMsg.ErrorMsgs["thdob"].Key;
                        sb.message = SaveErrorMsg.ErrorMsgs["thdob"].Value;
                        ER.Add(sb);
                    }


                    if (String.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.thholdername))
                    {
                        IsValid = false;
                        sb = new Error1();
                        sb.field = "thholdername";
                        sb.code = SaveErrorMsg.ErrorMsgs["thholdername"].Key;
                        sb.message = SaveErrorMsg.ErrorMsgs["thholdername"].Value;
                        ER.Add(sb);
                    }

                    if (String.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.thverificationtype))
                    {
                        IsValid = false;
                        sb = new Error1();
                        sb.field = "thverificationtype";
                        sb.code = SaveErrorMsg.ErrorMsgs["thverificationtype"].Key;
                        sb.message = SaveErrorMsg.ErrorMsgs["thverificationtype"].Value;
                        ER.Add(sb);
                    }

                    if (!String.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.thverificationby))
                    {
                        bool isMobileValid = Regex.IsMatch(fD_Save_Renewal_BO.holderverification.thverificationby, regexMobile);
                        if (!isMobileValid)
                        {
                            sb = new Error1();
                            IsValid = false;
                            sb.field = "thverificationby";
                            sb.code = SaveErrorMsg.ErrorMsgs["MobFormatTH"].Key;
                            sb.message = SaveErrorMsg.ErrorMsgs["MobFormatTH"].Value;
                            ER.Add(sb);
                        }
                    }
                    else
                    {
                        sb = new Error1();
                        IsValid = false;
                        sb.field = "thverificationby";
                        sb.code = SaveErrorMsg.ErrorMsgs["thverificationby"].Key;
                        sb.message = SaveErrorMsg.ErrorMsgs["thverificationby"].Value;
                        ER.Add(sb);
                    }

                    if (String.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.thverificationstatus))
                    {
                        IsValid = false;
                        sb = new Error1();
                        sb.field = "thverificationstatus";
                        sb.code = SaveErrorMsg.ErrorMsgs["thverificationstatus"].Key;
                        sb.message = SaveErrorMsg.ErrorMsgs["thverificationstatus"].Value;
                        ER.Add(sb);
                    }


                    if (string.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.thotpverified))
                    {
                        sb = new Error1();
                        IsValid = false;
                        sb.field = "thotpverified";
                        sb.code = SaveErrorMsg.ErrorMsgs["thotpverifiedblnk"].Key;
                        sb.message = SaveErrorMsg.ErrorMsgs["thotpverifiedblnk"].Value;
                        ER.Add(sb);
                    }
                    else
                    {

                        if (Array.Exists(booltype, E => (E == fD_Save_Renewal_BO.holderverification.thotpverified.ToUpper().ToString())))
                        {
                            // objVBO.Add(new UDTValidation() { RootElement = "RequestBO", Element = "RequestBO", Attribute = "isshverified", Evalue = ObjBo.pmwreqdtls.isshverified, ErrorMessage = "Success" });
                            if (!(IsConvertBoolean(fD_Save_Renewal_BO.holderverification.thotpverified)))
                            {
                                sb = new Error1();
                                IsValid = false;
                                sb.field = "thotpverified";
                                sb.code = SaveErrorMsg.ErrorMsgs["thotpverifiedtrue"].Key;
                                sb.message = SaveErrorMsg.ErrorMsgs["thotpverifiedtrue"].Value;
                                ER.Add(sb);

                            }
                            //else
                            //{
                            //    objVBO.Add(new UDTValidation() { RootElement = "RequestBO", Element = "RequestBO", Attribute = "", Evalue = "", ErrorMessage = "Success" });
                            //}
                        }
                        else
                        {
                            sb = new Error1();
                            IsValid = false;
                            sb.field = "isthverified";
                            sb.code = SaveErrorMsg.ErrorMsgs["isthverifiedyorn"].Key;
                            sb.message = SaveErrorMsg.ErrorMsgs["isthverifiedyorn"].Value;
                            ER.Add(sb);
                        }
                    }
                }


                #endregion

                #region Confirm checkbox flag
                if (string.IsNullOrEmpty(fD_Save_Renewal_BO.investmentdtls.istncaccepted))
                {
                    sb = new Error1();
                    IsValid = false;
                    sb.field = "istncaccepted";
                    sb.code = SaveErrorMsg.ErrorMsgs["istncacceptedblnk"].Key;
                    sb.message = SaveErrorMsg.ErrorMsgs["istncacceptedblnk"].Value;
                    ER.Add(sb);
                }
                else
                {
                    if (Array.Exists(booltype, E => (E == fD_Save_Renewal_BO.investmentdtls.istncaccepted.ToUpper().ToString())))
                    {
                        if (!(IsConvertBoolean(fD_Save_Renewal_BO.investmentdtls.istncaccepted)))
                        {
                            sb = new Error1();
                            IsValid = false;
                            sb.field = "istncaccepted";
                            sb.code = SaveErrorMsg.ErrorMsgs["istncacceptedtrue"].Key;
                            sb.message = SaveErrorMsg.ErrorMsgs["istncacceptedtrue"].Value;
                            ER.Add(sb);

                        }
                    }
                    else
                    {
                        sb = new Error1();
                        IsValid = false;
                        sb.field = "istncaccepted";
                        sb.code = SaveErrorMsg.ErrorMsgs["istncacceptedyorn"].Key;
                        sb.message = SaveErrorMsg.ErrorMsgs["istncacceptedyorn"].Value;
                        ER.Add(sb);
                    }
                }
                #endregion

                return ER;
            }
            catch (Exception ex)
            {
                sb = new Error1();
                sb.field = String.Empty;
                sb.code = String.Empty;
                sb.message = ex.Message;
                ER.Add(sb);
                return ER;

            }
        }

        public decimal isMinor(string dDate)
        {
            decimal age = 0;
            DataSet ds = new DataSet();
            try
            {
                // DateTime toDt = DateTime.Parse(dDate);

                SqlConnection con = new SqlConnection(_conn);
                SqlParameter[] sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@DOB", string.IsNullOrEmpty(dDate) ? DBNull.Value : DateTime.ParseExact(dDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));

                ds = SqlHelper.ExecuteDataSet(con, CommandType.StoredProcedure, "Usp_FD_SA_Renewal_Get_InvestorAge", sqlparam);
                age = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                String str = ex.Message;
            }
            return age;
        }


        bool IsConvertBoolean(string stringValue)
        {
            if (stringValue.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (stringValue.Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            else
            {
                // Handle unrecognized values here
                return false; // Or throw an exception if appropriate
            }
        }

        public DataTable Get_StateDistrictByPin(string PostalCode)
        {
                SqlParameter[] sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@PinCode", PostalCode);
                DataSet ds = SqlHelper.ExecuteDataSet(_conn, CommandType.StoredProcedure, "USP_FD_SA_Renewal_Prov_Nominee_GetDtlsBy_PinCode", sqlparam);
                if (ds != null && ds.Tables.Count == 1)
                {
                    return ds.Tables[0];
                }
                else
                {
                    throw new Exception("No Data Found.");
                }
            
        }
        public DataTable Get_Renewal_FD_Summary_Details(string app)
        {
            //DataTable dataTable = SqlHelper.ExecuteDataTable(this._conn, CommandType.StoredProcedure, "USP_FD_SA_Renewal_Summary_Dtls", new SqlParameter[1]
            //{
            //   new SqlParameter("@appno", (object) app)
            //});
            //return dataTable != null && dataTable.Rows.Count > 0 ? dataTable : (DataTable)null;



            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@appno", app);
            DataTable dt = SqlHelper.ExecuteDataTable(_conn, CommandType.StoredProcedure, "USP_FD_SA_Renewal_Summary_Dtls", sqlparam);
            if (dt != null && dt.Rows.Count>0)
            {
                return dt;
            }
            else
            {
                throw new Exception("No Data Found.");
            }
        }

    }
}
