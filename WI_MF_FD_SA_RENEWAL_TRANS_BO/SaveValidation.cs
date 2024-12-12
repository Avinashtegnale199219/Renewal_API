using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WI_MF_FD_SA_RENEWAL_TRANS_BO
{
    public class SaveValidation
    {
        private readonly IConfiguration _config;

        public bool IsValidDateFormat(string Dt)
        {
            CultureInfo invariantCulture = CultureInfo.InvariantCulture;
            string format = "dd-MM-yyyy";
            try
            {
                DateTime.ParseExact(Dt, format, (IFormatProvider)invariantCulture);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IsValidPANFormat(string pan)
        {
            bool IsValid = false;
            var regexPAN = @"[A-Z]{5}\d{4}[A-Z]{1}";
            IsValid = Regex.IsMatch(pan, regexPAN);
            return IsValid;
        }
        public class ValidationBO
        {
            public string strKey { get; set; }
            public string strValue { get; set; }
            public string strRemarks { get; set; }
            public string Appl_No { get; set; }
            public string CP_Code { get; set; }
            public string Scp_Code { get; set; }
            public string CP_Name { get; set; }
            public string Cp_Api_User_Name { get; set; }
            public string App_Code { get; set; }
            public string CP_Trans_Ref_No { get; set; }
            public string MF_Sys_Ref_no { get; set; }
            public string Cp_Location_Code { get; set; }
            public string API_Called { get; set; }
            public string API_Version { get; set; }
            public string CreatedIP { get; set; }
            public string Ref_Type { get; set; }
            public string JSON_Text { get; set; }
            public string Ref_Othr_Code { get; set; }
            public string Ref_Rm_Code { get; set; }
            public string Ref_Cust_Code { get; set; }

        }

        public class UDTValidation
        {
            public string RootElement { get; set; }
            public string Element { get; set; }

            public string Attribute { get; set; }

            public string Evalue { get; set; }

            public string ErrorMessage { get; set; }

        }
    }
}
