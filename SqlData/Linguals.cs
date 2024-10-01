using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlData
{
    public static class Linguals
    {
        public const string NeutralCulture = "en-US";

        public static readonly string[] Languages =
                   { "English", "Tradition Chinese", "Simple Chinese" };

        public static readonly (string, string)[] Cultures =
                   new[] { ("English", "en-US"), ("Tradition Chinese", "zh-Hant"), ("Simple Chinese", "zh-Hans") };
    }
}
