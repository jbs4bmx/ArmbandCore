using Comfort.Common;
using EFT;
using EFT.InventoryLogic;
using HarmonyLib;
using System.Collections.Generic;

namespace ArmBandCore.Utilities
{
    [HarmonyPatch(typeof(ArmorComponent), "BluntThroughput", MethodType.Getter)]
    internal class BTDisable
    {
        static void Postfix(ref float __result, ArmorComponent __instance)
        {
            Player player = Singleton<GameWorld>.Instance?.MainPlayer;

            if (player != null && player.IsYourPlayer)
            {
                if (!Core.DisableBT.Value)
                {
                    return;
                }

                List<ArmorComponent> armorComponents = new List<ArmorComponent>(20);
                player.Inventory.GetPutOnArmorsNonAlloc(armorComponents);

                foreach (ArmorComponent armor in armorComponents)
                {
                    if (armor.Item.TemplateId == "66087622e26587d9430a1cfb")
                    {
                        __result = 0f;
                        return;
                    }
                }
            }
        }
    }
}
