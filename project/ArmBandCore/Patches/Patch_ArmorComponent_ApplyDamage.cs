using ArmBandCore.Debug;
using ArmBandCore.Helpers;
using EFT;
using EFT.InventoryLogic;
using HarmonyLib;
using System.Collections.Generic;

namespace ArmBandCore.Patches
{
    [HarmonyPatch(typeof(ArmorComponent), nameof(ArmorComponent.ApplyDamage))]
    public static class Patch_ArmorComponent_ApplyDamage
    {
        public static void Postfix(
            ArmorComponent __instance,
            ref float __result,
            ref DamageInfoStruct damageInfo,
            EBodyPartColliderType colliderType,
            EArmorPlateCollider armorPlateCollider,
            bool damageInfoIsLocal,
            List<ArmorComponent> armorComponents,
            SkillManager.SkillBuffClass lightVestsDamageReduction,
            SkillManager.SkillBuffClass heavyVestsDamageReduction
        )
        {
            // Get the player who owns this armor
            var player = __instance.Item.Owner as Player;

            // Debug: hit tracing
            HitTraceDebugger.LogHit("After ApplyDamage", damageInfo, __instance);

            // Debug: armor inspector
            DebugArmorInspector.DumpArmorList("ArmorInspector", player);

            // Multi-armor logic
            MultiLayerArmorResolver.ApplySharedArmorDamage(
                __instance,
                damageInfo,
                player,
                armorComponents
            );
        }
    }
}
