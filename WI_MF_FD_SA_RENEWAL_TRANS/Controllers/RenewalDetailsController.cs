using System.Configuration;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PQScan.BarcodeCreator;
using WI_MF_FD_SA_RENEWAL_TRANS_DAL;
using WI_MF_FD_SA_RENEWAL_TRANS_BO;
using Microsoft.AspNetCore.Http.Extensions;

namespace WI_MF_FD_SA_RENEWAL_TRANS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RenewalDetailsController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly Renewal_DAL _Renewal_DAL;
        public RenewalDetailsController(IConfiguration configuration)
        {
            _config = configuration;
            _Renewal_DAL = new Renewal_DAL(_config);
        }

        [HttpPost]
        public async Task<IActionResult> POST([FromBody] RenewalBO renewalBO)
        {
            string pwd = string.Empty;
            List<Error> errors = new List<Error>();
            try
            {
                string req = UriHelper.GetDisplayUrl(Request.HttpContext.Request);
                string API_Version = _config["API_Version"];
                string json = JsonConvert.SerializeObject(renewalBO);
                int res1 = _Renewal_DAL.Insert_Renewal_JSON_Log(renewalBO, json, req, API_Version);
                if (res1 != 0)
                {
                    Validation_Renewal_Trans _validation = new Validation_Renewal_Trans();
                    errors = await _validation.isValidate(renewalBO);

                    if (errors.Count > 0)
                    {
                        return Ok(new { status = "error", code = 400, message = "Validation failed for the submitted data.", error = errors, timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), path = "/api/renewalfddtls" });
                    }
                    else
                    {
                        FD_RenewalBO _fdrrenewal = new FD_RenewalBO();
                        DataSet ds = new DataSet();
                        ds = _Renewal_DAL.Get_Renewal_FDDetails(renewalBO);
                        if (ds != null && ds.Tables.Count > 0)
                        {

                            _fdrrenewal.investmentdtls = new FDR_DetailsBO();
                            FDR_DetailsBO fDR_DetailsBO = new FDR_DetailsBO();

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                _fdrrenewal.investmentdtls.fdrno = Convert.ToString(ds.Tables[0].Rows[0]["fdrno"]) == "" ? "" : Convert.ToString(ds.Tables[0].Rows[0]["fdrno"]);
                                _fdrrenewal.investmentdtls.fdrdate = Convert.ToString(ds.Tables[0].Rows[0]["fdrdate"]) == "" ? "" : Convert.ToString(ds.Tables[0].Rows[0]["fdrdate"]);
                                _fdrrenewal.investmentdtls.matudate = Convert.ToString(ds.Tables[0].Rows[0]["matdate"]) == "" ? "" : Convert.ToString(ds.Tables[0].Rows[0]["matdate"]);
                                _fdrrenewal.investmentdtls.fdramt = Convert.ToString(ds.Tables[0].Rows[0]["fdramt"]) == "" ? "" : Convert.ToString(ds.Tables[0].Rows[0]["fdramt"]);
                                _fdrrenewal.investmentdtls.matuamt = Convert.ToString(ds.Tables[0].Rows[0]["matamt"]) == "" ? "" : Convert.ToString(ds.Tables[0].Rows[0]["matamt"]);
                                _fdrrenewal.investmentdtls.categorycode = Convert.ToString(ds.Tables[0].Rows[0]["categorycode"]) == "" ? "" : Convert.ToString(ds.Tables[0].Rows[0]["categorycode"]);
                                _fdrrenewal.investmentdtls.categorydesc = Convert.ToString(ds.Tables[0].Rows[0]["categorydec"]) == "" ? "" : Convert.ToString(ds.Tables[0].Rows[0]["categorydec"]);
                                _fdrrenewal.investmentdtls.schemecode = Convert.ToString(ds.Tables[0].Rows[0]["schemecode"]) == "" ? "" : Convert.ToString(ds.Tables[0].Rows[0]["schemecode"]);
                                _fdrrenewal.investmentdtls.schemedesc = Convert.ToString(ds.Tables[0].Rows[0]["schemedec"]) == "" ? "" : Convert.ToString(ds.Tables[0].Rows[0]["schemedec"]);
                                _fdrrenewal.investmentdtls.intfreq = Convert.ToString(ds.Tables[0].Rows[0]["intfrqdec"]) == "" ? "" : Convert.ToString(ds.Tables[0].Rows[0]["intfrqdec"]);
                                _fdrrenewal.investmentdtls.tenure = Convert.ToString(ds.Tables[0].Rows[0]["tenurecode"]) == "" ? "" : Convert.ToString(ds.Tables[0].Rows[0]["tenurecode"]);
                                _fdrrenewal.investmentdtls.intrate = Convert.ToString(ds.Tables[0].Rows[0]["intrate"]) == "" ? "" : Convert.ToString(ds.Tables[0].Rows[0]["intrate"]);

                                if (ds.Tables[1].Rows.Count > 0)
                                {
                                    _fdrrenewal.investmentdtls.nomineename = Convert.ToString(ds.Tables[1].Rows[0]["name"]) == "" ? "" : Convert.ToString(ds.Tables[1].Rows[0]["name"]);
                                    _fdrrenewal.investmentdtls.nomineedob = Convert.ToString(ds.Tables[1].Rows[0]["Nominee_DOB"]) == "" ? "" : Convert.ToString(ds.Tables[1].Rows[0]["Nominee_DOB"]);
                                    _fdrrenewal.investmentdtls.nomineerelation = Convert.ToString(ds.Tables[1].Rows[0]["Nominee_Relation"]) == "" ? "" : Convert.ToString(ds.Tables[1].Rows[0]["Nominee_Relation"]);
                                    _fdrrenewal.investmentdtls.guardianname = Convert.ToString(ds.Tables[1].Rows[0]["NOM_GUARDIAN"]) == "" ? "" : Convert.ToString(ds.Tables[1].Rows[0]["NOM_GUARDIAN"]);
                                    _fdrrenewal.investmentdtls.guardianadd1 = Convert.ToString(ds.Tables[1].Rows[0]["Nom_Guardian_Add1"]) == "" ? "" : Convert.ToString(ds.Tables[1].Rows[0]["Nom_Guardian_Add1"]);
                                    _fdrrenewal.investmentdtls.guardianadd2 = Convert.ToString(ds.Tables[1].Rows[0]["Nom_Guardian_Add2"]) == "" ? "" : Convert.ToString(ds.Tables[1].Rows[0]["Nom_Guardian_Add2"]);
                                    _fdrrenewal.investmentdtls.guardianadd3 = Convert.ToString(ds.Tables[1].Rows[0]["Nom_Guardian_Add3"]) == "" ? "" : Convert.ToString(ds.Tables[1].Rows[0]["Nom_Guardian_Add3"]);
                                    _fdrrenewal.investmentdtls.guardiancity = Convert.ToString(ds.Tables[1].Rows[0]["Nom_Guardian_City"]) == "" ? "" : Convert.ToString(ds.Tables[1].Rows[0]["Nom_Guardian_City"]);
                                    _fdrrenewal.investmentdtls.guardianpincode = Convert.ToString(ds.Tables[1].Rows[0]["Nom_Guardian_Pin"]) == "" ? "" : Convert.ToString(ds.Tables[1].Rows[0]["Nom_Guardian_Pin"]);
                                    _fdrrenewal.investmentdtls.guardiancountry = Convert.ToString(ds.Tables[1].Rows[0]["Nom_Guardian_Country"]) == "" ? "" : Convert.ToString(ds.Tables[1].Rows[0]["Nom_Guardian_Country"]);
                                    _fdrrenewal.investmentdtls.guardianstate = Convert.ToString(ds.Tables[1].Rows[0]["Nom_Guardian_State"]) == "" ? "" : Convert.ToString(ds.Tables[1].Rows[0]["Nom_Guardian_State"]);
                                    _fdrrenewal.investmentdtls.guardiandistrict = Convert.ToString(ds.Tables[1].Rows[0]["Nom_Guardian_District"]) == "" ? "" : Convert.ToString(ds.Tables[1].Rows[0]["Nom_Guardian_District"]);
                                    _fdrrenewal.investmentdtls.nomineeseq = Convert.ToString(ds.Tables[1].Rows[0]["ProvNomineeDtl_Sequence"]) == "" ? "" : Convert.ToString(ds.Tables[1].Rows[0]["ProvNomineeDtl_Sequence"]);

                                    _fdrrenewal.investmentdtls.renewaltype = Convert.ToString(ds.Tables[1].Rows[0]["renewaltype"]) == "" ? "" : Convert.ToString(ds.Tables[1].Rows[0]["renewaltype"]);
                                    //_fdrrenewal.investmentdtls.autorenewal = Convert.ToString(ds.Tables[1].Rows[0]["Auto_Renewal"]) == "" ? "" : Convert.ToString(ds.Tables[1].Rows[0]["Auto_Renewal"]);

                                    if (Convert.ToString(ds.Tables[1].Rows[0]["Auto_Renewal"])=="1")
                                    {
                                        _fdrrenewal.investmentdtls.autorenewal = "Y";
                                    }
                                    else
                                    {
                                        _fdrrenewal.investmentdtls.autorenewal = "N";
                                    }
                                }
                                else
                                {
                                    _fdrrenewal.investmentdtls.nomineename = "";
                                    _fdrrenewal.investmentdtls.nomineedob = "";
                                    _fdrrenewal.investmentdtls.nomineerelation = "";
                                    _fdrrenewal.investmentdtls.guardianname = "";
                                    _fdrrenewal.investmentdtls.guardianadd1 = "";
                                    _fdrrenewal.investmentdtls.guardianadd2 = "";
                                    _fdrrenewal.investmentdtls.guardianadd3 = "";
                                    _fdrrenewal.investmentdtls.guardiancity = "";
                                    _fdrrenewal.investmentdtls.guardianpincode = "";
                                    _fdrrenewal.investmentdtls.guardiancountry = "";
                                    _fdrrenewal.investmentdtls.guardianstate = "";
                                    _fdrrenewal.investmentdtls.guardiandistrict = "";
                                    _fdrrenewal.investmentdtls.nomineeseq = "";
                                    _fdrrenewal.investmentdtls.renewaltype = "";
                                    _fdrrenewal.investmentdtls.autorenewal = "";
                                }

                                if (ds.Tables[4].Rows.Count > 0)
                                {
                                    _fdrrenewal.investmentdtls.micrcode = Convert.ToString(ds.Tables[4].Rows[0]["micrcode"]) == "" ? "" : Convert.ToString(ds.Tables[4].Rows[0]["micrcode"]);
                                    _fdrrenewal.investmentdtls.neftcode = Convert.ToString(ds.Tables[4].Rows[0]["neftcode"]) == "" ? "" : Convert.ToString(ds.Tables[4].Rows[0]["neftcode"]);
                                    _fdrrenewal.investmentdtls.bankname = Convert.ToString(ds.Tables[4].Rows[0]["bankname"]) == "" ? "" : Convert.ToString(ds.Tables[4].Rows[0]["bankname"]);
                                    _fdrrenewal.investmentdtls.branchname = Convert.ToString(ds.Tables[4].Rows[0]["branchname"]) == "" ? "" : Convert.ToString(ds.Tables[4].Rows[0]["branchname"]);
                                    _fdrrenewal.investmentdtls.bankaccountno = Convert.ToString(ds.Tables[4].Rows[0]["bankaccno"]) == "" ? "" : Convert.ToString(ds.Tables[4].Rows[0]["bankaccno"]);
                                }

                                _fdrrenewal.jointholdersdtls = new HoldersBO();
                                if (ds.Tables[2].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                                    {
                                        HoldersBO holdersBO = new HoldersBO();
                                        if (i == 0)
                                        {
                                            _fdrrenewal.jointholdersdtls.shname = Convert.ToString(ds.Tables[2].Rows[i]["JH_NAME"]) == "" ? "" : Convert.ToString(ds.Tables[2].Rows[i]["JH_NAME"]);
                                            _fdrrenewal.jointholdersdtls.shmob = Convert.ToString(ds.Tables[2].Rows[i]["JH_MOBILE"]) == "" ? "" : Convert.ToString(ds.Tables[2].Rows[i]["JH_MOBILE"]);
                                            _fdrrenewal.jointholdersdtls.shseq = Convert.ToString(ds.Tables[2].Rows[i]["JH_SEQ"]) == "" ? "" : Convert.ToString(ds.Tables[2].Rows[i]["JH_SEQ"]);
                                            _fdrrenewal.jointholdersdtls.shpan = Convert.ToString(ds.Tables[2].Rows[i]["panno"]) == "" ? "" : Convert.ToString(ds.Tables[2].Rows[i]["panno"]);
                                            _fdrrenewal.jointholdersdtls.shdob = Convert.ToString(ds.Tables[2].Rows[i]["dob"]) == "" ? "" : Convert.ToString(ds.Tables[2].Rows[i]["dob"]);

                                            _fdrrenewal.jointholdersdtls.thname = "";
                                            _fdrrenewal.jointholdersdtls.thmob = "";
                                            _fdrrenewal.jointholdersdtls.thseq = "";
                                            _fdrrenewal.jointholdersdtls.thpan = "";
                                            _fdrrenewal.jointholdersdtls.thdob = "";
                                        }

                                        if (i == 1)
                                        {
                                            _fdrrenewal.jointholdersdtls.thname = Convert.ToString(ds.Tables[2].Rows[i]["JH_NAME"]) == "" ? "" : Convert.ToString(ds.Tables[2].Rows[i]["JH_NAME"]);
                                            _fdrrenewal.jointholdersdtls.thmob = Convert.ToString(ds.Tables[2].Rows[i]["JH_MOBILE"]) == "" ? "" : Convert.ToString(ds.Tables[2].Rows[i]["JH_MOBILE"]);
                                            _fdrrenewal.jointholdersdtls.thseq = Convert.ToString(ds.Tables[2].Rows[i]["JH_SEQ"]) == "" ? "" : Convert.ToString(ds.Tables[2].Rows[i]["JH_SEQ"]);
                                            _fdrrenewal.jointholdersdtls.thpan = Convert.ToString(ds.Tables[2].Rows[i]["panno"]) == "" ? "" : Convert.ToString(ds.Tables[2].Rows[i]["panno"]);
                                            _fdrrenewal.jointholdersdtls.thdob = Convert.ToString(ds.Tables[2].Rows[i]["dob"]) == "" ? "" : Convert.ToString(ds.Tables[2].Rows[i]["dob"]);

                                        }
                                    }
                                }
                                else
                                {
                                    _fdrrenewal.jointholdersdtls.shname = "";
                                    _fdrrenewal.jointholdersdtls.shmob = "";
                                    _fdrrenewal.jointholdersdtls.shseq = "";
                                    _fdrrenewal.jointholdersdtls.shpan = "";
                                    _fdrrenewal.jointholdersdtls.shdob = "";

                                    _fdrrenewal.jointholdersdtls.thname = "";
                                    _fdrrenewal.jointholdersdtls.thmob = "";
                                    _fdrrenewal.jointholdersdtls.thseq = "";
                                    _fdrrenewal.jointholdersdtls.thpan = "";
                                    _fdrrenewal.jointholdersdtls.thdob = "";
                                }

                                _fdrrenewal.folionominee = new List<ProvisionalNomineeBO>();
                                if (ds.Tables[3].Rows.Count > 0)
                                {
                                    for (int j = 0; j < ds.Tables[3].Rows.Count; j++)
                                    {
                                        ProvisionalNomineeBO provisionalNomineeBO = new ProvisionalNomineeBO();
                                        provisionalNomineeBO.nomineeseq = Convert.ToString(ds.Tables[3].Rows[j]["code"]) == "" ? "" : Convert.ToString(ds.Tables[3].Rows[j]["code"]);
                                        provisionalNomineeBO.nomineename = Convert.ToString(ds.Tables[3].Rows[j]["nomineename"]) == "" ? "" : Convert.ToString(ds.Tables[3].Rows[j]["nomineename"]);
                                        provisionalNomineeBO.nomineedob = Convert.ToString(ds.Tables[3].Rows[j]["nomineedob"]) == "" ? "" : Convert.ToString(ds.Tables[3].Rows[j]["nomineedob"]);
                                        provisionalNomineeBO.nomineerelation = Convert.ToString(ds.Tables[3].Rows[j]["nomineerelation"]) == "" ? "" : Convert.ToString(ds.Tables[3].Rows[j]["nomineerelation"]);
                                        provisionalNomineeBO.guardianname = Convert.ToString(ds.Tables[3].Rows[j]["guardianname"]) == "" ? "" : Convert.ToString(ds.Tables[3].Rows[j]["guardianname"]);
                                        provisionalNomineeBO.guardianadd1 = Convert.ToString(ds.Tables[3].Rows[j]["Nom_Guardian_Add1"]) == "" ? "" : Convert.ToString(ds.Tables[3].Rows[j]["Nom_Guardian_Add1"]);
                                        provisionalNomineeBO.guardianadd2 = Convert.ToString(ds.Tables[3].Rows[j]["Nom_Guardian_Add2"]) == "" ? "" : Convert.ToString(ds.Tables[3].Rows[j]["Nom_Guardian_Add2"]);
                                        provisionalNomineeBO.guardianadd3 = Convert.ToString(ds.Tables[3].Rows[j]["Nom_Guardian_Add3"]) == "" ? "" : Convert.ToString(ds.Tables[3].Rows[j]["Nom_Guardian_Add3"]);
                                        provisionalNomineeBO.guardiancity = Convert.ToString(ds.Tables[3].Rows[j]["Nom_Guardian_City"]) == "" ? "" : Convert.ToString(ds.Tables[3].Rows[j]["Nom_Guardian_City"]);
                                        provisionalNomineeBO.guardianpincode = Convert.ToString(ds.Tables[3].Rows[j]["Nom_Guardian_Pin"]) == "" ? "" : Convert.ToString(ds.Tables[3].Rows[j]["Nom_Guardian_Pin"]);
                                        provisionalNomineeBO.guardiancountry = Convert.ToString(ds.Tables[3].Rows[j]["Nom_Guardian_Country"]) == "" ? "" : Convert.ToString(ds.Tables[3].Rows[j]["Nom_Guardian_Country"]);
                                        provisionalNomineeBO.guardianstate = Convert.ToString(ds.Tables[3].Rows[j]["Nom_Guardian_State"]) == "" ? "" : Convert.ToString(ds.Tables[3].Rows[j]["Nom_Guardian_State"]);
                                        provisionalNomineeBO.guardiandistrict = Convert.ToString(ds.Tables[3].Rows[j]["Nom_Guardian_District"]) == "" ? "" : Convert.ToString(ds.Tables[3].Rows[j]["Nom_Guardian_District"]);


                                        _fdrrenewal.folionominee.Add(provisionalNomineeBO);
                                    }
                                }



                                if (ds.Tables[4].Rows.Count > 0)
                                {
                                    _fdrrenewal.jointholdersdtls.fhisckyccompliant = Convert.ToString(ds.Tables[5].Rows[0]["IsFHCKYC"]) == "" ? "" : Convert.ToString(ds.Tables[5].Rows[0]["IsFHCKYC"]);
                                    _fdrrenewal.jointholdersdtls.fhisamlcompliant = Convert.ToString(ds.Tables[5].Rows[0]["IsFHAML"]) == "" ? "" : Convert.ToString(ds.Tables[5].Rows[0]["IsFHAML"]);
                                    _fdrrenewal.jointholdersdtls.shisckyccompliant = Convert.ToString(ds.Tables[5].Rows[0]["IsSHCKYC"]) == "" ? "" : Convert.ToString(ds.Tables[5].Rows[0]["IsSHCKYC"]); ;
                                    _fdrrenewal.jointholdersdtls.shisamlcompliant = Convert.ToString(ds.Tables[5].Rows[0]["IsSHAML"]) == "" ? "" : Convert.ToString(ds.Tables[5].Rows[0]["IsSHAML"]);
                                    _fdrrenewal.jointholdersdtls.thisckyccompliant = Convert.ToString(ds.Tables[5].Rows[0]["IsTHCKYC"]) == "" ? "" : Convert.ToString(ds.Tables[5].Rows[0]["IsTHCKYC"]); ;
                                    _fdrrenewal.jointholdersdtls.thisamlcompliant = Convert.ToString(ds.Tables[5].Rows[0]["IsTHAML"]) == "" ? "" : Convert.ToString(ds.Tables[5].Rows[0]["IsTHAML"]); ;
                                }
                                else
                                {
                                    _fdrrenewal.jointholdersdtls.fhisckyccompliant = "";
                                    _fdrrenewal.jointholdersdtls.fhisamlcompliant = "";
                                    _fdrrenewal.jointholdersdtls.shisckyccompliant = "";
                                    _fdrrenewal.jointholdersdtls.shisamlcompliant = "";
                                    _fdrrenewal.jointholdersdtls.thisckyccompliant = "";
                                    _fdrrenewal.jointholdersdtls.thisamlcompliant = "";
                                }

                                return Ok(new { status = 1, msg = "SUCCESS", data = _fdrrenewal });
                            }
                            else
                            {
                                return Ok(new { status = 0, msg = "FAIL", data = "FD details not found." });
                            }
                        }
                        else
                        {
                            return Ok(new { status = 0, msg = "FAIL", data = "FD details not found." });
                        }

                    }
                }
                else
                {
                    return Ok(new { status = "error", code = 400, message = "fail", error = errors, timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), path = "/api/renewalfddtls" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { status = "error", code = 500, message = ex.Message, error = errors, timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), path = "api/renewalfddtls" });
                throw;
            }
        }
    }
}
