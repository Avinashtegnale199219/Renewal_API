using System.Data;
using MF_FD_SA_AUTH_MANAGER.BussinessAccessLayer;
using System.Security.AccessControl;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WI_MF_FD_SA_RENEWAL_TRANS_BO;
using WI_MF_FD_SA_RENEWAL_TRANS_DAL;
using MF_FD_SA_AUTH_MANAGER.BussinessObject;
using Microsoft.AspNetCore.Http.Extensions;


namespace WI_MF_FD_SA_RENEWAL_TRANS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaveRenewalDetailsController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly SaveRenewal_DAL _SaveRenewal_DAL;
        public SaveRenewalDetailsController(IConfiguration configuration)
        {
            _config = configuration;
            _SaveRenewal_DAL = new SaveRenewal_DAL(_config);
        }

        [HttpPost]
        public async Task<IActionResult> POST([FromBody] FD_Save_Renewal_BO fD_Save_Renewal_BO)
        {
            List<Error1> errors = new List<Error1>();
            string req = UriHelper.GetDisplayUrl(Request.HttpContext.Request);
            string API_Version = _config["API_Version"];
            string json = JsonConvert.SerializeObject(fD_Save_Renewal_BO);
            int res1 = _SaveRenewal_DAL.Insert_Renewal_JSON_Log(fD_Save_Renewal_BO, json, req, API_Version);

            if (res1 != 0)
            {
                try
                {
                    string Response = "", App_valid = "";
                    //Check FDR maturity date 7 days condition 
                    DataTable dt_check_app_isvalid = _SaveRenewal_DAL.Check_Application_Isvalid(fD_Save_Renewal_BO);
                    if (dt_check_app_isvalid != null && dt_check_app_isvalid.Rows.Count > 0 && !string.IsNullOrEmpty(Convert.ToString(dt_check_app_isvalid.Rows[0]["msg"])))
                    {
                        Response = Convert.ToString(dt_check_app_isvalid.Rows[0]["status"]);
                        App_valid = Convert.ToString(dt_check_app_isvalid.Rows[0]["msg"]);
                    }

                    if (Response.ToUpper() == "SUCCESS")
                    {
                        //check SH,TH Applicable
                        string SH_Exist = "", TH_Exist = "";
                        DataTable dt_check_SH_TH = _SaveRenewal_DAL.Check_SH_TH(fD_Save_Renewal_BO);
                        for (int i = 0; i < dt_check_SH_TH.Rows.Count; i++)
                        {
                            if (i == 0)
                            {
                                SH_Exist = "Exists";
                            }
                            else if (i == 1)
                            {
                                TH_Exist = "Exists";
                            }
                        }



                        errors = await _SaveRenewal_DAL.isValidate(fD_Save_Renewal_BO, SH_Exist, TH_Exist);

                        if (errors.Count > 0)
                        {
                            return Ok(new { status = "error", code = 401, message = "fail", errors = errors, timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), path = "api/saverenewaldetails" });

                        }
                        else
                        {

                            string xml_2ndHolderDtls = "", xml_3rdHolderDtls = "";
                            //categorycode=PU [public], SR [SR CITIZEN], EM [EMPLOYEE]

                            switch (fD_Save_Renewal_BO.investmentdtls.categorydesc.ToUpper())
                            {
                                case "PUBLIC":
                                    fD_Save_Renewal_BO.investmentdtls.categorycode = "PU";
                                    break;
                                case "SR CITIZEN":
                                    fD_Save_Renewal_BO.investmentdtls.categorycode = "SR";
                                    break;
                                case "EM":
                                    fD_Save_Renewal_BO.investmentdtls.categorycode = "EM";
                                    break;
                                default:
                                    fD_Save_Renewal_BO.investmentdtls.categorycode = string.Empty;
                                    break;
                            }

                            if (fD_Save_Renewal_BO.investmentdtls.schemedesc == "CUMULATIVE" || fD_Save_Renewal_BO.investmentdtls.schemedesc == "MICRO DEPOSIT")
                            {
                                //fD_Save_Renewal_BO.investmentdtls.intfrqcode = "Y";
                                fD_Save_Renewal_BO.investmentdtls.intfreq = "COMP. ANNUALY";

                            }
                            else
                            {
                                fD_Save_Renewal_BO.investmentdtls.schemedesc = "NON-CUMULATIVE";

                                switch (fD_Save_Renewal_BO.investmentdtls.intfreq.ToUpper())
                                {
                                    case "HALF YEARLY":
                                        //fD_Save_Renewal_BO.investmentdtls.intfrqcode = "H";
                                        fD_Save_Renewal_BO.investmentdtls.intfreq = "HALF YEARLY";
                                        break;
                                    case "QUARTERLY":
                                        //fD_Save_Renewal_BO.investmentdtls.intfrqcode = "Q";
                                        fD_Save_Renewal_BO.investmentdtls.intfreq = "QUARTERLY";
                                        break;
                                    case "COMP. ANNUALY":
                                        //fD_Save_Renewal_BO.investmentdtls.intfrqcode = "Y";
                                        fD_Save_Renewal_BO.investmentdtls.intfreq = "COMP. ANNUALY";
                                        break;
                                    case "MONTHLY":
                                        //fD_Save_Renewal_BO.investmentdtls.intfrqcode = "M";
                                        fD_Save_Renewal_BO.investmentdtls.intfreq = "MONTHLY";
                                        break;
                                    default:
                                        //fD_Save_Renewal_BO.investmentdtls.intfrqcode = string.Empty;
                                        fD_Save_Renewal_BO.investmentdtls.intfreq = string.Empty;
                                        break;
                                }

                            }

                            #region Generate ApplicationNo
                            NewApplicationNoBO newApplicationNoBO = new NewApplicationNoBO();
                            newApplicationNoBO.bustype = "S";
                            newApplicationNoBO.source = "mSupApp";
                            newApplicationNoBO.createdip = (fD_Save_Renewal_BO.additionaldtls.serveripaddress == "" || fD_Save_Renewal_BO.additionaldtls.serveripaddress == null) ? "sys" : fD_Save_Renewal_BO.additionaldtls.serveripaddress;
                            newApplicationNoBO.createdbyname = "sys"; ;
                            newApplicationNoBO.dsource = "R";

                            #endregion

                            //XML Node for insert data in t_FD_RW_Holder_Verification_Dtl
                            if (fD_Save_Renewal_BO.holderverification != null && (!string.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.shpanno)) && (!string.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.shdob)))
                            {
                                xml_2ndHolderDtls = Bind_xml_Second_Holder_Details(fD_Save_Renewal_BO);
                            }
                            else
                            {
                                xml_2ndHolderDtls = "<root></root>";
                            }

                            if (fD_Save_Renewal_BO.holderverification != null && (!string.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.thpanno)) && (!string.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.shdob)))
                            {
                                xml_3rdHolderDtls = Bind_xml_Third_Holder_Details(fD_Save_Renewal_BO);
                            }
                            else
                            {
                                xml_3rdHolderDtls = "<root></root>";
                            }

                            DataTable dt = _SaveRenewal_DAL.Get_StateDistrictByPin(fD_Save_Renewal_BO.investmentdtls.guardianpin);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                fD_Save_Renewal_BO.investmentdtls.guardianstate = Convert.ToString(dt.Rows[0]["StateName"]);
                                fD_Save_Renewal_BO.investmentdtls.guardiandistrict = Convert.ToString(dt.Rows[0]["DistrictName"]);
                            }
                            else
                            {
                                fD_Save_Renewal_BO.investmentdtls.guardianstate = "";
                                fD_Save_Renewal_BO.investmentdtls.guardiandistrict = "";
                            }
                            string app = await _SaveRenewal_DAL.InsertTransactionDetails(fD_Save_Renewal_BO, newApplicationNoBO, xml_2ndHolderDtls, xml_3rdHolderDtls);

                            // FD_Renewal_SummaryBO renewalSummaryBo = new FD_Renewal_SummaryBO();
                            if (!string.IsNullOrEmpty(app))
                            {
                                //DataTable dataTable3 = new DataTable();
                                //DataTable fdSummaryDetails = _SaveRenewal_DAL.Get_Renewal_FD_Summary_Details(app);
                                //if (fdSummaryDetails.Rows.Count > 0)
                                //{
                                //    renewalSummaryBo.applno = app;
                                //    renewalSummaryBo.fdramt = Convert.ToString(fdSummaryDetails.Rows[0]["AMOUNT"]);
                                //    renewalSummaryBo.renewalfordec = Convert.ToString(fdSummaryDetails.Rows[0]["RENEWAL_OPTION"]);
                                //    renewalSummaryBo.tenure = Convert.ToString(fdSummaryDetails.Rows[0]["TENURE"]);
                                //    renewalSummaryBo.intfreq = Convert.ToString(fdSummaryDetails.Rows[0]["Int_Payout"]);
                                //    renewalSummaryBo.startdate = Convert.ToString(fdSummaryDetails.Rows[0]["Start_Dt"]);
                                //    renewalSummaryBo.matudate = Convert.ToString(fdSummaryDetails.Rows[0]["Maturity_Dt"]);
                                //    renewalSummaryBo.shholdername = Convert.ToString(fdSummaryDetails.Rows[0]["shholdername"]);
                                //    renewalSummaryBo.thholdername = Convert.ToString(fdSummaryDetails.Rows[0]["thholdername"]);
                                //    renewalSummaryBo.nomineename = Convert.ToString(fdSummaryDetails.Rows[0]["nomineename"]);
                                //    renewalSummaryBo.nomineedob = Convert.ToString(fdSummaryDetails.Rows[0]["nomineedob"]);
                                //    renewalSummaryBo.nomineerelation = Convert.ToString(fdSummaryDetails.Rows[0]["nomineerelation"]);
                                //    renewalSummaryBo.guardianname = Convert.ToString(fdSummaryDetails.Rows[0]["guardianname"]);
                                //    renewalSummaryBo.bankname = Convert.ToString(fdSummaryDetails.Rows[0]["BANK_NAME"]);
                                //    renewalSummaryBo.branchname = Convert.ToString(fdSummaryDetails.Rows[0]["BRANCH"]);
                                //    renewalSummaryBo.bankaccountno = Convert.ToString(fdSummaryDetails.Rows[0]["ACCOUNT_NUMBER"]);
                                //    renewalSummaryBo.neftcode = Convert.ToString(fdSummaryDetails.Rows[0]["IFSC"]);
                                //}

                                return Ok(new { status = "success", code = 200, message = "Task saved successfully", data = app, timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), path = "api/saverenewaldetails" });
                            }
                            else
                            {
                                return Ok(new { status = "fail", code = 400, message = "Application no not generated", data = "", timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), path = "api/saverenewaldetails" });

                            }
                        }
                    }
                    else
                    {
                        return Ok(new { status = "error", code = 401, message = "fail", errors = Response, timestamp = DateTime.Today.ToString(), path = "api/saverenewaldetails" });
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return Ok(new { status = "error", code = 400, message = "fail", error = errors, timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), path = "/api/saverenewaldetails" });
            }

        }

        private static string Bind_xml_Second_Holder_Details(FD_Save_Renewal_BO fD_Save_Renewal_BO)
        {
            string xml = "";
            if (!string.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.shpanno) && !string.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.shdob))
            {
                xml += "<root>";
                xml += "<HolderDetails>";
                xml += "<HolderName>" + fD_Save_Renewal_BO.holderverification.shholdername.ToString() + "</HolderName>";
                xml += "<FolioNo>" + fD_Save_Renewal_BO.investmentdtls.foliono.ToString() + "</FolioNo>";
                xml += "<FdrNo>" + fD_Save_Renewal_BO.investmentdtls.fdrno.ToString() + "</FdrNo>";
                xml += "<SH_hold_type>" + "2" + "</SH_hold_type>";
                xml += "</HolderDetails>";
                xml += "</root>";
            }
            return xml;
        }

        private static string Bind_xml_Third_Holder_Details(FD_Save_Renewal_BO fD_Save_Renewal_BO)
        {

            string xml = "";
            if (!string.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.thpanno) && !string.IsNullOrEmpty(fD_Save_Renewal_BO.holderverification.thdob))
            {
                xml += "<root>";
                xml += "<HolderDetails>";
                xml += "<HolderName>" + fD_Save_Renewal_BO.holderverification.thholdername.ToString() + "</HolderName>";
                xml += "<FolioNo>" + fD_Save_Renewal_BO.investmentdtls.foliono.ToString() + "</FolioNo>";
                xml += "<FdrNo>" + fD_Save_Renewal_BO.investmentdtls.fdrno.ToString() + "</FdrNo>";
                xml += "<TH_hold_type>" + "3" + "</TH_hold_type>";
                xml += "</HolderDetails>";
                xml += "</root>";
            }
            return xml;
        }


    }
}
