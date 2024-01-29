using NUnit.Framework;
using Sparrow.Database.SqlSugar.Models;
using System.Collections.Generic;

namespace Sparrow.Database.SqlSugar.Test
{
    internal class VersionCompareTest
    {
        [Test]
        public void CompareTest()
        {
            var list = new List<Migration>()
            {
                new Migration(0, 0, 0, 1),
                new Migration(0, 0, 1, 0),
                new Migration(0, 0, 1, 1),
                new Migration(0, 1, 0, 0),
                new Migration(0, 1, 0, 1),
                new Migration(0, 1, 1, 0),
                new Migration(0, 1, 1, 1),
                new Migration(1, 0, 0, 0),
                new Migration(1, 0, 0, 1),
                new Migration(1, 0, 1, 0),
                new Migration(1, 0, 1, 1),
                new Migration(1, 1, 0, 0),
                new Migration(1, 1, 0, 1),
                new Migration(1, 1, 1, 0),
                new Migration(1, 1, 1, 1),
                new Migration(2, 2, 2, 2),
                new Migration(2, 3, 2, 2),
                new Migration(2, 3, 2, 3),
            };
            for (int main = 0; main < list.Count; main++)
            {
                var mainVersion = list[main];
                for (int compare = 0; compare < list.Count; compare++)
                {
                    var compareVersion = list[compare];
                    var result = mainVersion.Compare(compareVersion);
                    if (main == compare)
                    {
                        Assert.That(result, Is.EqualTo(0));
                    }
                    else if (main > compare)
                    {
                        Assert.That(result, Is.EqualTo(1));
                    }
                    else if (main < compare)
                    {
                        Assert.That(result, Is.EqualTo(-1));
                    }
                }
            }
        }
    }
}
