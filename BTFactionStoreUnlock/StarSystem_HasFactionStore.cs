using BattleTech;
using BattleTech.UI;
using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BTFactionStoreUnlock
{
    [HarmonyPatch(typeof(StarSystem), "CanUseFactionStore")]
    class StarSystem_HasFactionStore
    {
        public static bool Prefix(StarSystem __instance, ref bool __result)
        {
            if (!__instance.HasFactionStore())
                return true;
            __result = true;
            return false;
        }
    }

    [HarmonyPatch(typeof(SGNavigationScreen), "GetSystemSpecialIndicator")]
    class SGNavigationScreen_GetSystemSpecialIndicator
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> ins)
        {
            foreach (CodeInstruction c in ins)
            {
                if (c.opcode == OpCodes.Callvirt && c.operand.ToString().Contains("IsFactionAlly"))
                    c.operand = AccessTools.DeclaredMethod(typeof(SGNavigationScreen_GetSystemSpecialIndicator), "RetTrue");
                yield return c;
            }
        }
        public static bool RetTrue(SimGameState s, FactionValue v, List<string> o)
        {
            return true;
        }
    }
}
