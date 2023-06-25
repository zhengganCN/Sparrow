using NUnit.Framework;
using System.Collections.Generic;

namespace Sparrow.Database.Migration.Test
{
    public class Tests
    {

        [Test]
        public void VersionCompareTest()
        {
            var list = new List<SparrowVersion>()
            {
                new SparrowVersion(0, 0, 0, 1),
                new SparrowVersion(0, 0, 1, 0),
                new SparrowVersion(0, 0, 1, 1),
                new SparrowVersion(0, 1, 0, 0),
                new SparrowVersion(0, 1, 0, 1),
                new SparrowVersion(0, 1, 1, 0),
                new SparrowVersion(0, 1, 1, 1),
                new SparrowVersion(1, 0, 0, 0),
                new SparrowVersion(1, 0, 0, 1),
                new SparrowVersion(1, 0, 1, 0),
                new SparrowVersion(1, 0, 1, 1),
                new SparrowVersion(1, 1, 0, 0),
                new SparrowVersion(1, 1, 0, 1),
                new SparrowVersion(1, 1, 1, 0),
                new SparrowVersion(1, 1, 1, 1),
                new SparrowVersion(2, 2, 2, 2),
                new SparrowVersion(2, 3, 2, 2),
                new SparrowVersion(2, 3, 2, 3),
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