using ArmBandCore.Helpers;
using EFT;
using HarmonyLib;

namespace ArmBandCore.Patches
{
    [HarmonyPatch(typeof(Player), nameof(Player.ApplyDamageInfo))]
    public static class Patch_Player_ApplyDamageInfo
    {
        public static bool Prefix(Player __instance, ref DamageInfoStruct damageInfo)
        {
            float originalDamage = damageInfo.Damage;
            if (originalDamage <= 0f)
                return true;

            var equipment = __instance.Profile.Inventory.Equipment;
            var armbandArmor = ArmbandArmorHelper.GetArmbandArmor(equipment);

            // If no armband armor is worn, NONE of the ARMBAND options apply
            if (armbandArmor == null)
                return true;

            // 1. Disable throughput (ballistic + explosive)
            if (ABCPlugin.DisableThroughputDamage.Value)
            {
                if (damageInfo.DamageType == EDamageType.Bullet ||
                    damageInfo.DamageType == EDamageType.Explosion)
                {
                    damageInfo.Damage = 0f;

                    if (ABCPlugin.DebugHitTracingEnabled.Value)
                        ABCPlugin.Log.LogInfo($"[ThroughputBlock] Blocked {originalDamage} throughput damage (ARMBAND ONLY).");
                }
            }

            // 2. Disable blunt damage
            if (ABCPlugin.DisableBluntDamage.Value)
            {
                if (damageInfo.DamageType == EDamageType.Blunt)
                {
                    damageInfo.Damage = 0f;

                    if (ABCPlugin.DebugHitTracingEnabled.Value)
                        ABCPlugin.Log.LogInfo($"[BluntBlock] Blocked {originalDamage} blunt damage (ARMBAND ONLY).");
                }
            }

            // 3. Disable fragmentation damage
            if (ABCPlugin.DisableFragmentationDamage.Value)
            {
                if (damageInfo.DamageType == EDamageType.GrenadeFragment)
                {
                    damageInfo.Damage = 0f;

                    if (ABCPlugin.DebugHitTracingEnabled.Value)
                        ABCPlugin.Log.LogInfo($"[FragmentBlock] Blocked {originalDamage} fragmentation damage (ARMBAND ONLY).");
                }
            }

            return true;
        }
    }
}
