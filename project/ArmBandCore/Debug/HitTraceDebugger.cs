using EFT.InventoryLogic;

namespace ArmBandCore.Debug
{
    public static class HitTraceDebugger
    {
        public static void LogHit(string context, DamageInfoStruct info, ArmorComponent armor)
        {
            if (!ABCPlugin.DebugHitTracingEnabled.Value)
            {
                return;
            }
            else
            {
                ABCPlugin.Log.LogInfo($"{context}:");
                ABCPlugin.Log.LogInfo($"DamageType: {info.DamageType}");
                ABCPlugin.Log.LogInfo($"Damage: {info.Damage}");
                ABCPlugin.Log.LogInfo($"PenetrationPower: {info.PenetrationPower}");
                ABCPlugin.Log.LogInfo($"ArmorDamage: {info.ArmorDamage}");
                ABCPlugin.Log.LogInfo($"HeavyBleedingDelta: {info.HeavyBleedingDelta}");
                ABCPlugin.Log.LogInfo($"LightBleedingDelta: {info.LightBleedingDelta}");
                ABCPlugin.Log.LogInfo($"IsForwardHit: {info.IsForwardHit}");
                ABCPlugin.Log.LogInfo($"SourceId (Ammo): {info.SourceId}");
                ABCPlugin.Log.LogInfo($"BodyPartColliderType: {info.BodyPartColliderType}");

                // Armor info
                var armorTemplate = armor?.Template;
                ABCPlugin.Log.LogInfo($"Armor Template: {armor?.Item?.TemplateId}");
                ABCPlugin.Log.LogInfo($"Armor Material: {armorTemplate?.Material}");
                ABCPlugin.Log.LogInfo($"Armor Class: {armorTemplate?.ArmorClass}");
            }
        }
    }
}
