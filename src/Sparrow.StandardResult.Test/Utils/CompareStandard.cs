using Newtonsoft.Json;
using Sparrow.Extension;
using System.Linq;

namespace Sparrow.StandardResult.Test.Utils
{
    public class CompareStandard
    {
        public static bool Compare(object obj1, object obj2)
        {

            var s1 = JsonConvert.SerializeObject(obj1);
            var s2 = JsonConvert.SerializeObject(obj2);
            return s1.OrderBy(e => e).ToString(' ') == s2.OrderBy(e => e).ToString(' ');
        }
    }
}
