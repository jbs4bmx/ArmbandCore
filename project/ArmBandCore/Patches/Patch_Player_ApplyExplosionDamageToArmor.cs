using ArmBandCore.Helpers;
using EFT;
using EFT.InventoryLogic;
using HarmonyLib;
using System.Collections.Generic;

namespace ArmBandCore.Patches
{
    [HarmonyPatch(typeof(Player), nameof(Player.ApplyExplosionDamageToArmor))]
    public static class Patch_Player_ApplyExplosionDamageToArmor
    {
        public static bool Prefix(Player __instance, ref DamageInfoStruct damageInfo)
        {
            if (!ABCPlugin.ExplosiveArmorProtectionEnabled.Value)
                return true;

            if (damageInfo.DamageType != EDamageType.Explosion)
                return true;

            var equipment = __instance.Profile.Inventory.Equipment;
            if (equipment == null)
                return true;

            float totalDamage = damageInfo.Damage;

            // 1. If ONLY the armband should take explosive damage
            if (ABCPlugin.ExplosivesOnlyTargetArmbandArmor.Value)
            {
                var armbandArmor = ArmbandArmorHelper.GetArmbandArmor(equipment);

                if (armbandArmor != null)
                {
                    armbandArmor.ApplyDurabilityDamage(totalDamage, new List<ArmorComponent> { armbandArmor });

                    if (ABCPlugin.DebugHitTracingEnabled.Value)
                    {
                        ABCPlugin.Log.LogInfo(
                            $"[ExplosiveArmor] Applied {totalDamage} durability damage to ARMBAND {armbandArmor.Item.TemplateId}"
                        );
                    }

                    damageInfo.Damage = 0f;
                    return true;
                }

                // If toggle is on but no armband armor exists → do nothing
                return true;
            }

            // 2. Otherwise: redirect explosive damage ONLY to armband armor (not all armor)
            var armArmor = ArmbandArmorHelper.GetArmbandArmor(equipment);
            if (armArmor != null)
            {
                armArmor.ApplyDurabilityDamage(totalDamage, new List<ArmorComponent> { armArmor });

                if (ABCPlugin.DebugHitTracingEnabled.Value)
                {
                    ABCPlugin.Log.LogInfo(
                        $"[ExplosiveArmor] Applied {totalDamage} durability damage to ARMBAND {armArmor.Item.TemplateId}"
                    );
                }

                damageInfo.Damage = 0f;
            }

            return true;
        }
    }
}
