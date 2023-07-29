﻿using System.Text.RegularExpressions;

namespace Global.Utility
{
    public static class NumberUtility
    {
        public static CheckAlgorithmResult CheckINNAlgorithm(string INN,bool iscontractor=true)
        {
            CheckAlgorithmResult checkAlgorithmResult = new CheckAlgorithmResult();
            if (string.IsNullOrWhiteSpace(INN)||INN.Length != 9)
            {
                checkAlgorithmResult.Error = "Длина ИНН не 9 символов";
                return checkAlgorithmResult;
            }
            if (!IsNumber(INN))
            {
                checkAlgorithmResult.Error = "В ИНН содержит не цифровые символ";
                return checkAlgorithmResult;
            }
            if(!iscontractor)
            {
                if (!INN.StartsWith("4") && !INN.StartsWith("5") && !INN.StartsWith("6"))
                {
                    checkAlgorithmResult.Error = "ИНН не физическая лицо.";
                    return checkAlgorithmResult;
                }
            }
            else
            {
                if (!INN.StartsWith("2") && !INN.StartsWith("3"))
                {
                    checkAlgorithmResult.Error = "ИНН не юридическая лицо.";
                    return checkAlgorithmResult;
                }
            }
            char[] inndigits = INN.ToArray();
            decimal checksum = (decimal)(Convert.ToInt32(inndigits[0].ToString()) * 37 +
                Convert.ToInt32(inndigits[1].ToString()) * 29 +
                Convert.ToInt32(inndigits[2].ToString()) * 23 +
                Convert.ToInt32(inndigits[3].ToString()) * 19 +
                Convert.ToInt32(inndigits[4].ToString()) * 17 +
                Convert.ToInt32(inndigits[5].ToString()) * 13 +
                Convert.ToInt32(inndigits[6].ToString()) * 7 +
                Convert.ToInt32(inndigits[7].ToString()) * 3) / ((decimal)11);
            checksum = Global.Utility.NumberUtility.RoundDown((9 - (checksum - Global.Utility.NumberUtility.RoundDown(checksum, 0)) * 9), 0);

            if (Convert.ToInt32(checksum) != Convert.ToInt32(inndigits[8].ToString()))
            {
                checkAlgorithmResult.Error = "Ошибка в ИНН:" + INN;
                return checkAlgorithmResult;
            }
            checkAlgorithmResult.Error = null;
            checkAlgorithmResult.Success = true;
            return checkAlgorithmResult;
        }
        public static CheckAlgorithmResult CheckSettlementCode(string SettlementCode, string BankCode)
        {
            CheckAlgorithmResult checkAlgorithmResult = new CheckAlgorithmResult();

            if (string.IsNullOrWhiteSpace(SettlementCode) || SettlementCode.Length != 20)
            {
                checkAlgorithmResult.Error = "Длина Р/С не 20 символов";
                return checkAlgorithmResult;
            }
            if (!IsNumber(SettlementCode))
            {
                checkAlgorithmResult.Error = "В Р/С содержит не цифровые символ";
                return checkAlgorithmResult;
            }

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
            {
                checkAlgorithmResult.Error = "Ошибка в Р/С:" + SettlementCode;
                return checkAlgorithmResult;
            }
            checkAlgorithmResult.Success = true;
            return checkAlgorithmResult;
        }

        public static bool IsNumber(string inputvalue)
        {
            Regex isnumber = new Regex("[^0-9]");
            return !isnumber.IsMatch(inputvalue);
        }

        public class CheckAlgorithmResult
        {
            public bool Success { get; set; } = false;
            public string Error { get; set; }
        }
        public static CheckAlgorithmResult CheckPINFL(string PINFL, int GenderID, DateTime DateOfBirth)
        {
            CheckAlgorithmResult checkAlgorithmResult = new CheckAlgorithmResult();
            if (PINFL.Length != 14)
            {
                checkAlgorithmResult.Error = "Длина ПИНФЛ не 14 символов";
                return checkAlgorithmResult;
            }
            bool FirstLetter = false;

            if (new string[] { "D", "C", "I" }.Contains(PINFL.Substring(0, 1).ToUpper()))
                FirstLetter = true;

            if (!FirstLetter)
            {
                if ((DateOfBirth.Year < 2000 && PINFL.Substring(0, 1) != "3" && GenderID == 1) || (DateOfBirth.Year >= 2000 && PINFL.Substring(0, 1) != "5" && GenderID == 1))
                {
                    checkAlgorithmResult.Error = "ПИНФЛ рақами унинг туғилган санаси ёки жинси билан мос келмаяпти\n\rНомер ПИНФЛ не совпадает с датой рождения и/или полом. ПИНФЛ = " + PINFL;
                    return checkAlgorithmResult;
                }
            }
            if (!FirstLetter)
            {
                if ((DateOfBirth.Year < 2000 && PINFL.Substring(0, 1) != "4" && GenderID == 2) || (DateOfBirth.Year >= 2000 && PINFL.Substring(0, 1) != "6" && GenderID == 2))
                {
                    checkAlgorithmResult.Error = "ПИНФЛ рақами унинг туғилган санаси ёки жинси билан мос келмаяпти\n\rНомер ПИНФЛ не совпадает с датой рождения и/или полом. ПИНФЛ = " + PINFL;
                    return checkAlgorithmResult;
                }
            }
            if (PINFL.Substring(1, 4) != "0000")
            {
                if (PINFL.Substring(1, 2) != DateOfBirth.Day.ToString("00"))
                {
                    checkAlgorithmResult.Error = "ПИНФЛ рақами унинг туғилган санаси ёки жинси билан мос келмаяпти\n\rНомер ПИНФЛ не совпадает с датой рождения и/или полом. ПИНФЛ = " + PINFL;
                    return checkAlgorithmResult;
                }
                if (PINFL.Substring(3, 2) != DateOfBirth.Month.ToString("00"))
                {
                    checkAlgorithmResult.Error = "ПИНФЛ рақами унинг туғилган санаси ёки жинси билан мос келмаяпти\n\rНомер ПИНФЛ не совпадает с датой рождения и/или полом. ПИНФЛ = " + PINFL;
                    return checkAlgorithmResult;
                }
            }

            if (PINFL.Substring(5, 2) != DateOfBirth.Year.ToString().Substring(2))
            {
                checkAlgorithmResult.Error = "ПИНФЛ рақами унинг туғилган санаси ёки жинси билан мос келмаяпти\n\rНомер ПИНФЛ не совпадает с датой рождения и/или полом. ПИНФЛ = " + PINFL;
                return checkAlgorithmResult;
            }
            checkAlgorithmResult.Error = null;
            checkAlgorithmResult.Success = true;
            return checkAlgorithmResult;
        }
        public static int? SetNullIfZero(this int? value)
        {
            return value == 0 ? (int?)null : value;
        }
        public static decimal Round(decimal d, int decimals)
        {
            decimal degree = (decimal)Math.Pow(10, decimals);
            decimal temp = RoundDown(d, decimals);
            if ((d - temp) * degree >= 0.5m)
                return temp + 1 / degree;
            else
                return temp;
        }

        public static decimal RoundDown(decimal d, int decimals)
        {
            decimal degree = (decimal)Math.Pow(10, decimals);
            return (decimal)(Math.Floor((double)(d * degree)) / (double)degree);
        }

        public static decimal RoundDown(decimal d, decimal degree)
        {
            return (decimal)(Math.Floor((double)(d * degree)) / (double)degree);
        }
        public static decimal ObjecttoDecimal(object val, bool showError = false, System.Globalization.CultureInfo cultureInfo=null)
        {
            decimal d = 0.0m;
            if (val == null || val == DBNull.Value)
                d = 0.0m;
            else
            {
                if (cultureInfo == null)
                    cultureInfo = System.Globalization.CultureInfo.CurrentCulture;
                val = val.ToString().Replace("/", ",").Replace(@"\", ",").Replace(".", ",");
                var res=decimal.TryParse(val.ToString(), System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign, cultureInfo, out d);
                if (showError&& !res)
                    throw new Exception($"Cannot convert to decimal {val}");
            }
            return d;

        }
        public static decimal ToDecimal(this object val,bool showError=false, System.Globalization.CultureInfo cultureInfo = null)
        {
            return ObjecttoDecimal(val, showError, cultureInfo);

        }
        static public string SumInWordsCapital(decimal Amount, bool IsUZB = false)
        {
            object returnValue;
            short temp_short = 1;
            string temp_string = (IsUZB ? "сўм" : "сум");
            string temp_string2 = (IsUZB ? "сўм" : "сум");
            string temp_string3 = (IsUZB ? "сўм" : "сум");
            returnValue = AmountInWords(Amount, ref temp_short, ref temp_string, ref temp_string2, ref temp_string3, 2, "тийин", "тийин", "тийин", IsUZB);
            return returnValue.ToString().Substring(0, 1).ToUpper() + returnValue.ToString().Substring(1);

        }
        static public object AmountInWords(object Amount, ref short Gender1, ref string Dollar1, ref string Dollar2, ref string Dollar5, short Gender2, string Cent1, string Cent2, string Cent5, bool IsUZB)
        {
            object returnValue;
            string Image;
            if (Amount == null)
            {
                returnValue = System.DBNull.Value;
            }
            else
            {
                Image = ((decimal)Amount).ToString("0.00");
                object temp_object = Gender1;
                short temp_short = (short)temp_object;
                object temp_object2 = Dollar1;
                string temp_string = (string)temp_object2;
                object temp_object3 = Dollar2;
                string temp_string2 = (string)temp_object3;
                object temp_object4 = Dollar5;
                string temp_string3 = (string)temp_object4;
                returnValue = ((Image.Substring(0, 1) == "-") ? "минус " : "") + NumberInWords(System.Math.Abs(System.Convert.ToDouble(Image.Substring(0, Image.Length - 3))), ref temp_short, ref temp_string, ref temp_string2, ref temp_string3, IsUZB) + "  " + Image.Substring(Image.Length - 2, 2) + " " + Cent5;
            }
            return returnValue;
        }
        static public object NumberInWords(object Number, ref short Gender, ref string Unit1, ref string Unit2, ref string Unit5, bool IsUZB)
        {
            object returnValue;
            string Image;
            string Modulus;
            if (Number == DBNull.Value)
            {
                returnValue = System.DBNull.Value;
            }
            else
            {
                double tempnumber = 0;
                double.TryParse(Number.ToString(), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.CurrentCulture, out tempnumber);
                Image = System.Math.Abs(tempnumber).ToString(new string('0', 15));
                if (System.Convert.ToDouble(Image) == 0)
                {
                    returnValue = (IsUZB ? "нол " : "ноль ") + Unit5.Trim();
                }
                else
                {
                    if (Image.Length > 15)
                    {
                        Modulus = " <много> " + Unit5;
                    }
                    else
                    {
                        Modulus = TriadInWords(Image.Substring(0, 3), 1, (IsUZB ? "триллион" : "триллион"), (IsUZB ? "триллион" : "триллионa"), (IsUZB ? "триллион" : "триллионов"), IsUZB) + TriadInWords(Image.Substring(3, 3), 1, (IsUZB ? "миллиард" : "миллиард"), (IsUZB ? "миллиард" : "миллиарда"), (IsUZB ? "миллиард" : "миллиардов"), IsUZB) + TriadInWords(Image.Substring(6, 3), 1, (IsUZB ? "миллион" : "миллион"), (IsUZB ? "миллион" : "миллиона"), (IsUZB ? "миллион" : "миллионов"), IsUZB) + TriadInWords(Image.Substring(9, 3), 2, (IsUZB ? "минг" : "тысяча"), (IsUZB ? "минг" : "тысячи"), (IsUZB ? "минг" : "тысяч"), IsUZB) + ((Image.Substring(12, 3) == "000") ? " " + Unit5 : (TriadInWords(Image.Substring(12, 3), Gender, Unit1, Unit2, Unit5, IsUZB)));
                    }
                    returnValue = ((System.Convert.ToDouble(Number) < 0 ? "минус" : "") + Modulus).Trim();
                }
            }
            return returnValue;
        }
        static public string TriadInWords(string Triad, short Gender, string Unit1, string Unit2, string Unit5, bool IsUZB)
        {
            string returnValue;
            string Result;
            if (Triad == "000")
            {
                returnValue = "";
            }
            else
            {
                Result = new string[] { "", " сто", " двести", " триста", " четыреста", " пятьсот", " шестьсот", " семьсот", " восемьсот", " девятьсот" }[System.Convert.ToInt32(Triad.Substring(0, 1)) + 1 - 1];
                if (IsUZB)
                    Result = new string[] { "", " бир юз", " икки юз", " уч юз", " тўрт юз", " беш юз", " олти юз", " етти юз", " саккиз юз", " тўққиз юз" }[System.Convert.ToInt32(Triad.Substring(0, 1)) + 1 - 1];

                if (System.Convert.ToDouble(Triad.Substring(1, 1)) == 1)
                {
                    if (IsUZB)
                        Result = Result + " " + new string[] { "ўн", "ўн бир", "ўн икки", "ўн уч", "ўн тўрт", "ўн беш", "ўн олти", "ўн етти", "ўн саккиз", "ўн тўккиз" }[System.Convert.ToInt32(Triad.Substring(2, 1)) + 1 - 1] + " " + Unit5;
                    else
                        Result = Result + " " + new string[] { "десять", "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" }[System.Convert.ToInt32(Triad.Substring(2, 1)) + 1 - 1] + " " + Unit5;
                }
                else
                {
                    if (IsUZB)
                        Result = Result + new string[] { "", "", " йигирма", " ўттиз", " қирқ", " эллик", " олтмиш", " етмиш", " саксон", " тўқсон" }[System.Convert.ToInt32(Triad.Substring(1, 1)) + 1 - 1];
                    else
                        Result = Result + new string[] { "", "", " двадцать", " тридцать", " сорок", " пятьдесят", " шестьдесят", " семьдесят", " восемьдесят", " девяносто" }[System.Convert.ToInt32(Triad.Substring(1, 1)) + 1 - 1];
                    switch (Triad.Substring(2, 1))
                    {
                        default:
                            if (Triad.Substring(2, 1) == 4.ToString())
                            {

                                if (IsUZB)
                                    Result = Result + " тўрт " + Unit2;
                                else
                                    Result = Result + " четыре " + Unit2;
                                break;
                            }
                            if (Triad.Substring(2, 1) == 3.ToString())
                            {

                                if (IsUZB)
                                    Result = Result + " уч " + Unit2;
                                else
                                    Result = Result + " три " + Unit2;
                                break;
                            }
                            if (Triad.Substring(2, 1) == 2.ToString())
                            {

                                if (IsUZB)
                                    Result = Result + " икки " + Unit2;
                                else
                                    Result = Result + new string[] { " два ", " две ", " два " }[Gender - 1] + Unit2;
                                break;
                            }
                            if (Triad.Substring(2, 1) == 1.ToString())
                            {

                                if (IsUZB)
                                    Result = Result + " бир " + Unit1;
                                else
                                    Result = Result + new string[] { " один ", " одна ", " одно " }[Gender - 1] + Unit1;
                                break;
                            }

                            if (IsUZB)
                                Result = Result + new string[] { "", "", "", "", "", " беш", " олти", " етти", " саккиз", " тўққиз" }[System.Convert.ToInt32(Triad.Substring(2, 1)) + 1 - 1] + " " + Unit5;
                            else
                                Result = Result + new string[] { "", "", "", "", "", " пять", " шесть", " семь", " восемь", " девять" }[System.Convert.ToInt32(Triad.Substring(2, 1)) + 1 - 1] + " " + Unit5;
                            break;
                    }
                }
                returnValue = Result;
            }
            return returnValue;
        }

    }
}
