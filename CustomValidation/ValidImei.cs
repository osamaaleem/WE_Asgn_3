using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WE_Asgn_3.CustomValidation
{
    public class ValidImei : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string imei = value.ToString();
            Regex regex = new Regex("^[0-9]{2}-[0-9]{6}-[0-9]{6}-[0-9]{1}$");
            return regex.IsMatch(imei);
        }
    }
}