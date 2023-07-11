using NUnit.Framework;

namespace Sparrow.Extension.System.Test.ConvertTest
{
    internal class SparrowConvertChineseNumberTest
    {
        [Test]
        [TestCase(-1.34432f, "负一点三四四三二", "负壹点叁肆肆叁贰")]
        [TestCase(0.6f, "零点六", "零点陆")]
        [TestCase(1.6f, "一点六", "壹点陆")]
        [TestCase(1.64432f, "一点六四四三二", "壹点陆肆肆叁贰")]
        public void ConvertChineseNumberTest(float dec, string simple, string traditional)
        {
            Assert.Multiple(() =>
            {
                Assert.That(SparrowConvert.ToChineseNumber(dec, ChineseCategory.Simple), Is.EqualTo(simple));
                Assert.That(SparrowConvert.ToChineseNumber(dec, ChineseCategory.Traditional), Is.EqualTo(traditional));
            });
        }

        [Test]
        [TestCase(-1, "负一", "负壹")]
        [TestCase(1, "一", "壹")]
        [TestCase(10, "一十", "壹拾")]
        [TestCase(20, "二十", "贰拾")]
        [TestCase(31, "三十一", "叁拾壹")]
        [TestCase(300, "三百", "叁佰")]
        [TestCase(402, "四百零二", "肆佰零贰")]
        [TestCase(420, "四百二十", "肆佰贰拾")]
        [TestCase(452, "四百五十二", "肆佰伍拾贰")]
        [TestCase(5000, "五千", "伍仟")]
        [TestCase(5003, "五千零三", "伍仟零叁")]
        [TestCase(5023, "五千零二十三", "伍仟零贰拾叁")]
        [TestCase(5050, "五千零五十", "伍仟零伍拾")]
        [TestCase(5300, "五千三百", "伍仟叁佰")]
        [TestCase(5301, "五千三百零一", "伍仟叁佰零壹")]
        [TestCase(5321, "五千三百二十一", "伍仟叁佰贰拾壹")]
        public void ConvertChineseNumberTest(short dec, string simple, string traditional)
        {
            Assert.Multiple(() =>
            {
                Assert.That(SparrowConvert.ToChineseNumber(dec, ChineseCategory.Simple), Is.EqualTo(simple));
                Assert.That(SparrowConvert.ToChineseNumber(dec, ChineseCategory.Traditional), Is.EqualTo(traditional));
            });
        }
        [Test]
        [TestCase(60000, "六万", "陆萬")]
        [TestCase(60001, "六万零一", "陆萬零壹")]
        [TestCase(60040, "六万零四十", "陆萬零肆拾")]
        [TestCase(60041, "六万零四十一", "陆萬零肆拾壹")]
        [TestCase(60100, "六万零一百", "陆萬零壹佰")]
        [TestCase(60103, "六万零一百零三", "陆萬零壹佰零叁")]
        [TestCase(60123, "六万零一百二十三", "陆萬零壹佰贰拾叁")]
        [TestCase(60150, "六万零一百五十", "陆萬零壹佰伍拾")]
        [TestCase(600000, "六十万", "陆拾萬")]
        [TestCase(600001, "六十万零一", "陆拾萬零壹")]
        [TestCase(600010, "六十万零一十", "陆拾萬零壹拾")]
        [TestCase(600011, "六十万零一十一", "陆拾萬零壹拾壹")]
        [TestCase(600100, "六十万零一百", "陆拾萬零壹佰")]
        [TestCase(600110, "六十万零一百一十", "陆拾萬零壹佰壹拾")]
        [TestCase(600111, "六十万零一百一十一", "陆拾萬零壹佰壹拾壹")]
        [TestCase(601000, "六十万一千", "陆拾萬壹仟")]
        [TestCase(601001, "六十万一千零一", "陆拾萬壹仟零壹")]
        [TestCase(601010, "六十万一千零一十", "陆拾萬壹仟零壹拾")]
        [TestCase(601011, "六十万一千零一十一", "陆拾萬壹仟零壹拾壹")]
        [TestCase(601100, "六十万一千一百", "陆拾萬壹仟壹佰")]
        [TestCase(601101, "六十万一千一百零一", "陆拾萬壹仟壹佰零壹")]
        [TestCase(601110, "六十万一千一百一十", "陆拾萬壹仟壹佰壹拾")]
        [TestCase(601111, "六十万一千一百一十一", "陆拾萬壹仟壹佰壹拾壹")]
        [TestCase(610000, "六十一万", "陆拾壹萬")]
        [TestCase(610001, "六十一万零一", "陆拾壹萬零壹")]
        [TestCase(610010, "六十一万零一十", "陆拾壹萬零壹拾")]
        [TestCase(610011, "六十一万零一十一", "陆拾壹萬零壹拾壹")]
        [TestCase(610100, "六十一万零一百", "陆拾壹萬零壹佰")]
        [TestCase(610101, "六十一万零一百零一", "陆拾壹萬零壹佰零壹")]
        [TestCase(610110, "六十一万零一百一十", "陆拾壹萬零壹佰壹拾")]
        [TestCase(610111, "六十一万零一百一十一", "陆拾壹萬零壹佰壹拾壹")]
        [TestCase(611000, "六十一万一千", "陆拾壹萬壹仟")]
        [TestCase(611001, "六十一万一千零一", "陆拾壹萬壹仟零壹")]
        [TestCase(611010, "六十一万一千零一十", "陆拾壹萬壹仟零壹拾")]
        [TestCase(611011, "六十一万一千零一十一", "陆拾壹萬壹仟零壹拾壹")]
        [TestCase(611100, "六十一万一千一百", "陆拾壹萬壹仟壹佰")]
        [TestCase(611101, "六十一万一千一百零一", "陆拾壹萬壹仟壹佰零壹")]
        [TestCase(611110, "六十一万一千一百一十", "陆拾壹萬壹仟壹佰壹拾")]
        [TestCase(611111, "六十一万一千一百一十一", "陆拾壹萬壹仟壹佰壹拾壹")]
        [TestCase(765432, "七十六万五千四百三十二", "柒拾陆萬伍仟肆佰叁拾贰")]
        [TestCase(7654321, "七百六十五万四千三百二十一", "柒佰陆拾伍萬肆仟叁佰贰拾壹")]
        [TestCase(7654321, "七百六十五万四千三百二十一", "柒佰陆拾伍萬肆仟叁佰贰拾壹")]
        [TestCase(87654321, "八千七百六十五万四千三百二十一", "捌仟柒佰陆拾伍萬肆仟叁佰贰拾壹")]
        [TestCase(600000000, "六亿", "陆亿")]
        [TestCase(187654321, "一亿八千七百六十五万四千三百二十一", "壹亿捌仟柒佰陆拾伍萬肆仟叁佰贰拾壹")]
        [TestCase(1987654321, "一十九亿八千七百六十五万四千三百二十一", "壹拾玖亿捌仟柒佰陆拾伍萬肆仟叁佰贰拾壹")]
        public void ConvertChineseNumberTest(int dec, string simple, string traditional)
        {
            Assert.Multiple(() =>
            {
                Assert.That(SparrowConvert.ToChineseNumber(dec, ChineseCategory.Simple), Is.EqualTo(simple));
                Assert.That(SparrowConvert.ToChineseNumber(dec, ChineseCategory.Traditional), Is.EqualTo(traditional));
            });
        }

        [TestCase(11987654321, "一百一十九亿八千七百六十五万四千三百二十一", "壹佰壹拾玖亿捌仟柒佰陆拾伍萬肆仟叁佰贰拾壹")]
        [TestCase(111987654321, "一千一百一十九亿八千七百六十五万四千三百二十一", "壹仟壹佰壹拾玖亿捌仟柒佰陆拾伍萬肆仟叁佰贰拾壹")]
        [TestCase(1111987654321, "一兆一千一百一十九亿八千七百六十五万四千三百二十一", "壹兆壹仟壹佰壹拾玖亿捌仟柒佰陆拾伍萬肆仟叁佰贰拾壹")]
        public void ConvertChineseNumberTest(long dec, string simple, string traditional)
        {
            Assert.Multiple(() =>
            {
                Assert.That(SparrowConvert.ToChineseNumber(dec, ChineseCategory.Simple), Is.EqualTo(simple));
                Assert.That(SparrowConvert.ToChineseNumber(dec, ChineseCategory.Traditional), Is.EqualTo(traditional));
            });
        }

        [TestCase("11987654321", "一百一十九亿八千七百六十五万四千三百二十一", "壹佰壹拾玖亿捌仟柒佰陆拾伍萬肆仟叁佰贰拾壹")]
        [TestCase("111987654321", "一千一百一十九亿八千七百六十五万四千三百二十一", "壹仟壹佰壹拾玖亿捌仟柒佰陆拾伍萬肆仟叁佰贰拾壹")]
        [TestCase("1111987654321", "一兆一千一百一十九亿八千七百六十五万四千三百二十一", "壹兆壹仟壹佰壹拾玖亿捌仟柒佰陆拾伍萬肆仟叁佰贰拾壹")]
        public void ConvertChineseNumberTest(string dec, string simple, string traditional)
        {
            Assert.Multiple(() =>
            {
                Assert.That(SparrowConvert.ToChineseNumber(dec, ChineseCategory.Simple), Is.EqualTo(simple));
                Assert.That(SparrowConvert.ToChineseNumber(dec, ChineseCategory.Traditional), Is.EqualTo(traditional));
            });
        }
    }
}
