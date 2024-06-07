using NUnit.Framework;
using Sparrow.Database.SqlSugar.Migrations;
using System.Collections.Generic;

namespace Sparrow.Database.SqlSugar.Test
{
    internal class VersionCompareTest
    {
        [Test]
        public void CompareTest()
        {
            var list = new List<MigrationOptions>()
            {
                new MigrationOptions(0, 0, 0, 1),
                new MigrationOptions(0, 0, 1, 0),
                new MigrationOptions(0, 0, 1, 1),
                new MigrationOptions(0, 1, 0, 0),
                new MigrationOptions(0, 1, 0, 1),
                new MigrationOptions(0, 1, 1, 0),
                new MigrationOptions(0, 1, 1, 1),
                new MigrationOptions(1, 0, 0, 0),
                new MigrationOptions(1, 0, 0, 1),
                new MigrationOptions(1, 0, 1, 0),
                new MigrationOptions(1, 0, 1, 1),
                new MigrationOptions(1, 1, 0, 0),
                new MigrationOptions(1, 1, 0, 1),
                new MigrationOptions(1, 1, 1, 0),
                new MigrationOptions(1, 1, 1, 1),
                new MigrationOptions(2, 2, 2, 2),
                new MigrationOptions(2, 3, 2, 2),
                new MigrationOptions(2, 3, 2, 3),
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
