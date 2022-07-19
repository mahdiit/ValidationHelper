using System;
using System.Text.RegularExpressions;

namespace ValidationHelper
{
    public static class Validations
    {
        public const string Date = "\\A(\\d{4})[\\\\/\\-](\\d{1,2})[\\\\/\\-](\\d{1,2})\\Z";
        public const string DateTime = "\\A(\\d{4})[\\\\/\\-](\\d{1,2})[\\\\/\\-](\\d{1,2})\\s(\\d{1,2}):(\\d{1,2}):(\\d{1,2})\\Z";
        public const string Time = "\\A(\\d{1,2}):(\\d{1,2}):(\\d{1,2})\\Z";
        public const string Email = "\\A\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*\\Z";
        public const string Url = "\\Ahttp(s)?://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&amp;=]*)?\\Z";
        public const string LatinCharAndNum = "\\A[\\sa-zA-Z0-9\\.]*\\Z";
        public const string Number = "\\A(?:-?(?:\\d+|\\d{1,3}(?:,\\d{3})+)(?:\\.\\d+)?)\\Z";
        public const string Digit = "\\A[\\d,٠١٢٣٤٥٦٧٨٩۰۱۲۳۴۵۶۷۸۹]*\\Z";
        public const string LatinChar = "\\A[\\sa-zA-Z]*\\Z";
        public const string FarsiChar = "\\A[\\sءآأؤئةكيگوکذىىلآدءٍفإجژچپشذزیثبلاهتنمئدخحضقسفعرصطغظ]*\\Z";
        public const string FarsiCharAndNum = "\\A[٠١٢٣٤٥٦٧٨٩۰۱۲۳۴۵۶۷۸۹كيا-یء-ی 0-9]+\\Z";
        public const string PostCode = @"\A\d{10}\Z";
        public const string Mobile = "\\A09[0-9]{9}\\Z";
        public const string Username = "\\A[a-z0-9]*\\Z";
        public const string Address = @"\A[\-كيا-یء-ی 0-9-,/.()a-zA-Z،]+\Z";
        public const string Tel = @"\A\d{8}\Z";
        public const string TelWithCode = @"\A0\d{10}\Z";
        public const string WebSite = @"(?i)^www([.]([a-z0-9]{1,})(([-]*)([a-z0-9]{1,}))*){1,}[.]([a-z]{1,})$";
        public const string PassportCode = "\\A[a-zA-Z0-9]*\\Z";
        public const string ResidenceCode = "\\A[0-9]{8}\\Z|\\A[0-9]{13}\\Z";
        public const string ForeignerPervasiveNo = @"\A\d{10,16}\Z";
        public static bool IsNationalCode(string nationalCode)
        {
            if (string.IsNullOrEmpty(nationalCode))
                return true;

            if (!Regex.IsMatch(nationalCode, @"^\d{10}$"))
                return false;

            //Check if all the numbers are same
            bool areAllNumbersSame = true;
            for (int i = 1; i < 10; i++)
            {
                areAllNumbersSame = nationalCode[0] == nationalCode[i];
                if (!areAllNumbersSame) break;
            }
            if (areAllNumbersSame) return false;

            int num3;
            int a = 0;
            int tempKey;
            for (int i = 2; i < 11; i++)
            {
                char ch = nationalCode[i - 2];
                if (int.TryParse(ch.ToString(), out tempKey))
                {
                    a += tempKey * (12 - i);
                }
            }

            Math.DivRem(a, 11, out num3);
            int num4 = 0;
            if (int.TryParse(nationalCode[9].ToString(), out tempKey))
            {
                num4 = tempKey;
            }

            return num3 == 0 && num4 == 0 || num3 == 1 && num4 == 1 || num4 == 11 - num3;
        }
    }
}