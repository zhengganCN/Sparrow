using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparrow.Extension.Utils
{
    internal static class ChineseNumberUtil
    {
        public static string GetChinese(string nums, ChineseCategory category)
        {
            var minus = false;
            if (nums.StartsWith("-"))
            {
                minus = true;
                nums = nums.Substring(1);
            }
            var splits = nums.Split('.');
            var integer = splits[0];
            string fraction = default;
            if (splits.Length == 2)
            {
                fraction = splits[1];
            }
            var result = GetInteger(integer, category, minus);

            GetFraction(fraction, category, result);
            return result.ToString();
        }

        private static void GetFraction(string fraction, ChineseCategory category, StringBuilder integer)
        {
            if (string.IsNullOrWhiteSpace(fraction))
            {
                return;
            }
            if (integer.Length == 0)
            {
                integer.Append(SimpleChineseNumber.N_0);
            }
            integer.Append("点");
            var chars = fraction.ToCharArray();
            foreach (var value in chars)
            {
                switch (category)
                {
                    case ChineseCategory.Traditional:
                        integer.Append(GetTraditional(Convert.ToInt16(value.ToString())));
                        break;
                    case ChineseCategory.Simple:
                        integer.Append(GetSimple(Convert.ToInt16(value.ToString())));
                        break;
                }
            }
        }

        private static StringBuilder GetInteger(string nums, ChineseCategory category, bool minus)
        {
            var chars = nums.ToList();
            chars.Reverse();
            var floor = Math.Ceiling((double)chars.Count / 4);
            if (floor - 1 > SimpleChineseNumber.Units.Length)
            {
                throw new ArgumentException();
            }
            var sb = new StringBuilder();
            for (int i = 0; i < floor; i++)
            {
                if (i != 0)
                {
                    sb.Append(GetUnit(category, i + 2));
                }
                var temp = chars.Skip(i * 4).Take(4);
                Combine(category, sb, temp);
            }
            if (minus)
            {
                sb.Append("负");
            }
            var result = new StringBuilder();
            for (int i = sb.Length - 1; i >= 0; i--)
            {
                result.Append(sb[i]);
            }

            return result;
        }

        private static void Combine(ChineseCategory category, StringBuilder sb, IEnumerable<char> temp)
        {
            for (int j = 0; j < temp.Count(); j++)
            {
                var value = temp.ElementAt(j).ToString();
                if (value != "0")
                {
                    switch (j)
                    {
                        case 1:
                            sb.Append(GetUnit(category, 0));
                            break;
                        case 2:
                            sb.Append(GetUnit(category, 1));
                            break;
                        case 3:
                            sb.Append(GetUnit(category, 2));
                            break;
                    }
                }
                if (j == 0 && value == "0")
                {
                    continue;
                }
                if (j != 0 && value == "0" && sb.Length - 1 < 0)
                {
                    continue;
                }
                if (j != 0 && value == "0" && sb[sb.Length - 1] == SimpleChineseNumber.N_0)
                {
                    continue;
                }
                switch (category)
                {
                    case ChineseCategory.Traditional:
                        sb.Append(GetTraditional(Convert.ToInt16(value)));
                        break;
                    case ChineseCategory.Simple:
                        sb.Append(GetSimple(Convert.ToInt16(value)));
                        break;
                }
                if (sb.Length >= 2)
                {
                    if (sb[sb.Length - 1] == SimpleChineseNumber.N_0 &&
                        (SimpleChineseNumber.Units.Contains(sb[sb.Length - 2]) ||
                        TraditionalChineseNumber.Units.Contains(sb[sb.Length - 2])))
                    {
                        sb.Remove(sb.Length - 2, 2);
                    }
                }
            }
        }

        private static char GetUnit(ChineseCategory chinese, int index)
        {
            switch (chinese)
            {
                case ChineseCategory.Traditional:
                    return TraditionalChineseNumber.Units[index];
                case ChineseCategory.Simple:
                    return SimpleChineseNumber.Units[index];
            }
            return default;
        }

        private static char GetSimple(short num)
        {
            switch (num)
            {
                case 0:
                    return SimpleChineseNumber.N_0;
                case 1:
                    return SimpleChineseNumber.N_1;
                case 2:
                    return SimpleChineseNumber.N_2;
                case 3:
                    return SimpleChineseNumber.N_3;
                case 4:
                    return SimpleChineseNumber.N_4;
                case 5:
                    return SimpleChineseNumber.N_5;
                case 6:
                    return SimpleChineseNumber.N_6;
                case 7:
                    return SimpleChineseNumber.N_7;
                case 8:
                    return SimpleChineseNumber.N_8;
                case 9:
                    return SimpleChineseNumber.N_9;
            }
            throw new ArgumentException();
        }
        private static char GetTraditional(short num)
        {
            switch (num)
            {
                case 0:
                    return TraditionalChineseNumber.N_0;
                case 1:
                    return TraditionalChineseNumber.N_1;
                case 2:
                    return TraditionalChineseNumber.N_2;
                case 3:
                    return TraditionalChineseNumber.N_3;
                case 4:
                    return TraditionalChineseNumber.N_4;
                case 5:
                    return TraditionalChineseNumber.N_5;
                case 6:
                    return TraditionalChineseNumber.N_6;
                case 7:
                    return TraditionalChineseNumber.N_7;
                case 8:
                    return TraditionalChineseNumber.N_8;
                case 9:
                    return TraditionalChineseNumber.N_9;
            }
            throw new ArgumentException();
        }
    }
}
