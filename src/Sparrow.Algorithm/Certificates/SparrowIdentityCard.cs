using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparrow.Algorithm.Certificates
{
    /// <summary>
    /// 身份证
    /// </summary>
    public class SparrowIdentityCard
    {
        private static readonly int[] W = { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2, 1 };
        private static readonly string[] ModCheck = { "1", "0", "X", "9", "8", "7", "6", "5", "4", "3", "2" };
        private static readonly Dictionary<string, string> Address = new Dictionary<string, string>
        {
            { "11","11" },
            { "22","22" },
            { "35","35" },
            { "44","44" },
            { "53","53" },
            { "12","12" },
            { "23","23" },
            { "36","36" },
            { "45","45" },
            { "54","54" },
            { "13","13" },
            { "31","31" },
            { "37","37" },
            { "46","46" },
            { "61","61" },
            { "14","14" },
            { "32","32" },
            { "41","41" },
            { "50","50" },
            { "62","62" },
            { "15","15" },
            { "33","33" },
            { "42","42" },
            { "51","51" },
            { "63","63" },
            { "21","21" },
            { "34","34" },
            { "43","43" },
            { "52","52" },
            { "64","64" },
            { "65","65" },
            { "71","71" },
            { "81","81" },
            { "82","82" },
            { "91","91" }
        };
        /// <summary>
        /// 地区代码
        /// </summary>
        public string AreaCode { get; set; }
        /// <summary>
        /// 省代码
        /// </summary>
        public string ProvinceCode { get; set; }
        /// <summary>
        /// 市代码
        /// </summary>
        public string CityCode { get; set; }
        /// <summary>
        /// 县代码
        /// </summary>
        public string TownCode { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? BirthDate { get; set; }
        /// <summary>
        /// 性别（true：男；false：女）
        /// </summary>
        public bool? Sex { get; set; }
        /// <summary>
        /// 获取证件号信息
        /// </summary>
        /// <param name="number">证件号码</param>
        /// <remarks>支持15位和18位的证件号码</remarks>
        /// <returns></returns>
        public SparrowIdentityCard GetIdentityCardInfo(string number)
        {
            if (Verify(number))
            {
                var len = number.Length;
                var area = number.Substring(0, 6);
                var province = area.Substring(0, 2);
                var city = area.Substring(2, 2);
                var town = area.Substring(4, 2);
                DateTime? birth;
                switch (len)
                {
                    case 15:
                        birth = DateTime.Parse(number.Substring(6, 6).Insert(4, "-").Insert(2, "-"));
                        return new SparrowIdentityCard
                        {
                            AreaCode = area,
                            ProvinceCode = province,
                            CityCode = city,
                            TownCode = town,
                            BirthDate = birth,
                            Sex = int.Parse(number.Substring(14, 1)) % 2 != 0,
                        };
                    case 18:
                        birth = DateTime.Parse(number.Substring(6, 8).Insert(6, "-").Insert(4, "-"));
                        return new SparrowIdentityCard
                        {
                            AreaCode = area,
                            ProvinceCode = province,
                            CityCode = city,
                            TownCode = town,
                            BirthDate = birth,
                            Sex = int.Parse(number.Substring(16, 1)) % 2 != 0,
                        };
                }
            }
            return null;
        }

        /// <summary>
        /// 证件号码验证
        /// </summary>
        /// <param name="number">证件号码</param>
        /// <remarks>支持15位和18位的证件号码</remarks>
        /// <returns></returns>
        public static bool Verify(string number)
        {
            var len = number.Length;
            switch (len)
            {
                case 15:
                    return GB11643_1989(number);
                case 18:
                    return GB11643_1999(number);
            }
            return false;
        }

        /// <summary>
        /// 证件号码是否符合GB11643-1999
        /// </summary>
        /// <param name="number">证件号码</param>
        /// <returns></returns>
        public static bool GB11643_1999(string number)
        {
            if (!Address.ContainsKey(number.Remove(2)))
            {
                return false;//省份数字项检高不正确
            }
            string birth = number.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            if (DateTime.TryParse(birth, out _) == false)
            {
                return false;//生日项计算不正确
            }
            var a = new int[17];
            for (int i = 0; i < 17; i++)
            {
                a[i] = int.Parse(number.ElementAt(i).ToString());
            }
            var aw = new int[17];
            for (int i = 0; i < 17; i++)
            {
                aw[i] = a[i] * W[i];
            }
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += aw[i];
            }
            var mod = sum % 11;
            if (mod >= ModCheck.Length)
            {
                return false;//求出的模不正确
            }
            if (ModCheck[mod] != number.Last().ToString().ToUpperInvariant())
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 证件号码是否符合GB11643-1989
        /// </summary>
        /// <param name="number">证件号码</param>
        /// <returns></returns>
        public static bool GB11643_1989(string number)
        {
            if (!Address.ContainsKey(number.Remove(2)))
            {
                return false;//省份数字项检高不正确
            }
            string birth = number.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            if (DateTime.TryParse(birth, out _) == false)
            {
                return false;//生日项计算不正确
            }
            return true;//符合15位规范
        }
    }
}
