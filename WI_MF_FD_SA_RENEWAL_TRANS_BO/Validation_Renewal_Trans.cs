using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WI_MF_FD_SA_RENEWAL_TRANS_BO
{
    public class Validation_Renewal_Trans
    {
        public async Task<List<Error>> isValidate(RenewalBO renewalBO)
        {

            List<Error> ER = new List<Error>();
            Error sb = new Error();
            try
            {
                if (renewalBO != null)
                {
                    List<UDTValidation_Renewal_Trans> objVBO = new List<UDTValidation_Renewal_Trans>();
                    bool IsValid = true;

                    // if (string.IsNullOrEmpty(renewalBO.foliono.Trim()))
                    // {
                    //     sb = new Error();
                    //     IsValid = false;
                    //     objVBO.Add(new UDTValidation_Renewal_Trans() { RootElement = "Renewal_Trans", Element = "Renewal_Trans", Attribute = "foliono", Evalue = renewalBO.foliono, ErrorMessage = ErrorMsg_Renewal_Trans.ErrorMsgs["foliono"].Value });
                    //     sb.field = "foliono";
                    //     sb.code = ErrorMsg_Renewal_Trans.ErrorMsgs["foliono"].Key;
                    //     sb.message = ErrorMsg_Renewal_Trans.ErrorMsgs["foliono"].Value;
                    //     ER.Add(sb);
                    // }
                    // else
                    // {
                    //     objVBO.Add(new UDTValidation_Renewal_Trans() { RootElement = "Renewal_Trans", Element = "Renewal_Trans", Attribute = "foliono", Evalue = renewalBO.foliono, ErrorMessage = "Success" });
                    // }

                    if (string.IsNullOrEmpty(renewalBO.fdrno.Trim()))
                    {
                        sb = new Error();
                        IsValid = false;
                        objVBO.Add(new UDTValidation_Renewal_Trans() { RootElement = "Gen_Doc", Element = "Gen_Doc", Attribute = "fdrno", Evalue = renewalBO.fdrno, ErrorMessage = ErrorMsg_Renewal_Trans.ErrorMsgs["fdrno"].Value });
                        sb.field = "fdrno";
                        sb.code = ErrorMsg_Renewal_Trans.ErrorMsgs["fdrno"].Key;
                        sb.message = ErrorMsg_Renewal_Trans.ErrorMsgs["fdrno"].Value;
                        ER.Add(sb);
                    }
                    else
                    {
                        objVBO.Add(new UDTValidation_Renewal_Trans() { RootElement = "Gen_Doc", Element = "Gen_Doc", Attribute = "fdrno", Evalue = renewalBO.fdrno, ErrorMessage = "Success" });
                    }

                   
                    return ER;
                }
                else
                    return ER;
            }
            catch (Exception ex)
            {
                return ER;

            }
        }

        public class UDTValidation_Renewal_Trans
        {
            public string RootElement { get; set; }
            public string Element { get; set; }

            public string Attribute { get; set; }

            public string Evalue { get; set; }

            public string ErrorMessage { get; set; }



        }
    }
}
