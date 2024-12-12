using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WI_MF_FD_SA_RENEWAL_TRANS_BO
{
    public static class SaveErrorMsg
    {
        public static readonly ReadOnlyDictionary<string, KeyValuePair<string, string>> ErrorMsgs = new ReadOnlyDictionary<string, KeyValuePair<string, string>>(
     new Dictionary<string, KeyValuePair<string, string>>(){

             {"dtFormatSH",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0001","Second holder date is not in correct format(DD-MM-YYYY)") },
             {"dtFutureSH",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0002","Second holder date can not be Future date") },

             {"dtFormatTH",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0003","Third holder date is not in correct format(DD-MM-YYYY)") },
             {"dtFutureTH",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0004","Third holder date can not be Future date") },

             {"dtFormatNom",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0005","Nominee date is not in correct format(DD-MM-YYYY)") },
             {"dtFutureNom",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0006","Nominee date can not be Future date") },

             {"fdrno",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0007","Fdr number can not be null or blank")},
             {"foliono",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0008","Folio number can not be null or blank")},
             {"transrefno",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0009","Trans ref number can not be null or blank")},


             //FDR Config 
             {"categorycode",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0010","Category code can not be null or blank")},
             {"categorydec",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0011","Category dec can not be null or blank")},
             {"schemecode",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0012","Scheme code can not be null or blank")},
             {"schemedec",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0013","Scheme dec can not be null or blank")},
             {"intfrqcode",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0014","Interest frquency code can not be null or blank")},
             {"intfrqdec",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0015","Interest frquency dec can not be null or blank")},
             {"tenurecode",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0016","Tenure code can not be null or blank")},
             {"tenureNumeric",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0017","Tenure must be Numeric")},
             {"intrate",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0018","Interest rate can not be null or blank")},
             {"fdramt",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0019","Fdr amount can not be null or blank")},
             {"AmtNumeric",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0020","Amount must be Numeric") },
             {"renewalfordec",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0021","Renewal for dec can not be null or blank")},


            //Bank details
             {"micrcode",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0022","MICR code can not be null or blank")},
             {"neftcode",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0023","NEFT code can not be null or blank")},
             {"bankname",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0024","Bank name can not be null or blank")},
             {"branchname",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0025","Branch name can not be null or blank")},
             {"bankaccno",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0026","Bank account no can not be null or blank")},


             //Nominee details
            //  {"name",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0027","Nominee name can not be null or blank")},
            //  {"dob",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0028","Nominee dob can not be null or blank")},
            //  {"nomrelation",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0029","Nominee relation can not be null or blank")},
             {"guardianname",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0030","Guardian name can not be null or blank if Nominee is minor.")},
             {"guardianaddblnk",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0030","Guardian address can not be null or blank if Nominee is minor.")},
             {"guardianadd_invalid",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0030","Guardian address is invalid")},
             
             {"guardiancityblnk",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0030","Guardian city can not be null or blank if Nominee is minor.")},
             {"guardiancity_invalid",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0030","Guardian city is invalid")},

             {"guardianpinblnk",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0030","Guardian pincode can not be null or blank if Nominee is minor.")},
             {"guardianpin_invalid",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0045","Guardian pincode is invalid.")},
           
             {"guardianstateblnk",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0030","Guardian state can not be null or blank if Nominee is minor.")},
             {"guardianstate_invalid",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0030","Guardian state is invalid")},
             
             {"guardiandistrictblnk",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0030","Guardian district can not be null or blank if Nominee is minor.")},
             {"guardiandistrict_invalid",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0030","Guardian district is invalid")},


        
             //Holder verification details
             {"shpanno",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0031","Second holder PAN can not be null or blank")},
             {"PANInvalidSH",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0032","Second holder PAN Number is not valid")},
             {"PANLengthSH",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0033","Second holder Invalid length of PAN")},
             {"shdob",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0034","Second holder DOB can not be null or blank")},
             {"shholdername",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0035","Second holder name can not be null or blank")},
             {"shverificationtype",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0036","Second holder verification type can not be null or blank")},
             {"shverificationby",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0037","Second holder verification by can not be null or blank")},
             {"MobFormatSH",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0038","Please enter correct Mobile Format of Second holder")},
             {"shverificationstatus",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0039","Second holder verification status can not be null or blank")},
             {"shotpverifiedblnk",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0040","Second holder otp verified can not be null or blank")},
             {"isshverifiedyorn",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0041","Second holder otp verified should be Y or N")},
             {"shotpverifiedtrue",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0042","Second holder otp verified should be Y")},
             {"shseq",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0042","Second holder sequence no can not be blank or null")},


             {"thpanno",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0043","Third holder PAN can not be null or blank")},
             {"PANInvalidTH",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0044","Third holder PAN Number is not valid")},
             {"PANLengthTH",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0045","Third holder Invalid length of PAN")},
             {"thdob",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0046","Third holder DOB can not be null or blank")},
             {"thholdername",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0047","Third holder name can not be null or blank")},
             {"thverificationtype",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0048","Third holder verification type can not be null or blank")},
             {"thverificationby",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0049","Third holder verification by can not be null or blank")},
             {"MobFormatTH",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0050","Please enter correct MobFormat of Third holder")},
             {"thverificationstatus",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0051","Third holder verification status can not be null or blank")},
             {"thotpverifiedblnk",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0052","Third holder otp verified can not be null or blank")},
             {"isthverifiedyorn",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0053","Third holder otp verified should be Y or N")},
             {"thotpverifiedtrue",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0054","Third holder otp verified should be Y")},
             {"thseq",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0042","Third holder sequence no can not be blank or null")},

             {"istncacceptedblnk",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0055","istncacceptedblnk can not be null or blank")},
             {"istncacceptedyorn",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0056","Istncaccepted should be Y or N")},
             {"istncacceptedtrue",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0057","Istncaccepted should be Y")},
     });
    }
}
