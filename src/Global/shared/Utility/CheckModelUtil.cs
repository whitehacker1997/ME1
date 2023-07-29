using System.Text.RegularExpressions;

namespace Global.Utility
{
    public static class CheckModelUtil
    {
        public static bool CheckINNAlgorithm(string inn)
        {
            if (inn.Length != 9)
                return false;
            if (!IsNumber(inn))
                return false;

            char[] inndigits = inn.ToArray();
            decimal checksum = (decimal)(Convert.ToInt32(inndigits[0].ToString()) * 37 +
                Convert.ToInt32(inndigits[1].ToString()) * 29 +
                Convert.ToInt32(inndigits[2].ToString()) * 23 +
                Convert.ToInt32(inndigits[3].ToString()) * 19 +
                Convert.ToInt32(inndigits[4].ToString()) * 17 +
                Convert.ToInt32(inndigits[5].ToString()) * 13 +
                Convert.ToInt32(inndigits[6].ToString()) * 7 +
                Convert.ToInt32(inndigits[7].ToString()) * 3) / ((decimal)11);
            checksum = NumberUtility.RoundDown((9 - (checksum - NumberUtility.RoundDown(checksum, 0)) * 9), 0);

            if (Convert.ToInt32(checksum) != Convert.ToInt32(inndigits[8].ToString()))
                return false;
            else
                return true;
        }
        public static bool CheckSettlementCode(string SettlementCode, string BankCode)
        {

            if (SettlementCode.Length != 20)
                return false;
            if (!IsNumber(SettlementCode))
                return false;

            string code = BankCode + SettlementCode.Substring(0, 8) + SettlementCode.Substring(9) + "9";
            int sum = 0;
            char[] accdigits = code.ToArray();
            for (int i = 0; i < 24; i++)
            {
                sum += Convert.ToInt32(accdigits[i].ToString()) * Convert.ToInt32(accdigits[i + 1].ToString());
            }

            sum = sum % 11;
            string key = "";
            if (sum == 0)
                key = "9";
            else if (sum == 1)
                key = "0";
            else
                key = (11 - sum).ToString();

            if (key != SettlementCode.Substring(8, 1))
                return false;
            else
                return true;
        }
        public static bool IsNumber(string inputvalue)
        {
            Regex isnumber = new Regex("[^0-9]");
            return !isnumber.IsMatch(inputvalue);
        }


    }
}
