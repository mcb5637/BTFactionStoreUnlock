using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BTFactionStoreUnlock
{
    class BTFactionStoreUnlock_Init
    {
        public static void Init(string directory, string settingsJSON)
        {
            var harmony = HarmonyInstance.Create("com.github.mcb5637.BTFactionStoreUnlock");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
