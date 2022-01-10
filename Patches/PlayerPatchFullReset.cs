
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using HDC.Extentions;

namespace DHC.Patches
{
    [Serializable]
    [HarmonyPatch(typeof(Player), "FullReset")]
    class PlayerPatchFullReset
    {
        private static void Prefix(Player __instance)
        {
            CustomEffects.DestroyAllEffects(__instance.gameObject);
        }
    }
}
