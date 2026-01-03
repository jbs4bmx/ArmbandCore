using ArmBandCore.Helpers;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using EFT.InventoryLogic;
using HarmonyLib;
using System;
using System.Linq;
using System.Reflection;

namespace ArmBandCore
{
    [BepInPlugin("com.jbs4bmx.ArmBandCore", "ArmBandCore", "4.0.1")]
    [BepInDependency("com.SPT.core", "4.0.0")]

    public class ABCPlugin : BaseUnityPlugin
    {
        public const int TarkovVersion = 40087;
        internal static ABCPlugin Instance { get; set; }
        internal static ManualLogSource Log { get; set; } = null;
        internal static ConfigEntry<bool> DebugArmorInspectorEnabled;
        internal static ConfigEntry<bool> DebugHitTracingEnabled;
        internal static ConfigEntry<bool> MultiLayerArmorEnabled;
        internal static ConfigEntry<bool> ExplosiveArmorProtectionEnabled;
        internal static ConfigEntry<bool> ExplosivesOnlyTargetArmbandArmor;
        internal static ConfigEntry<bool> DisableThroughputDamage;
        internal static ConfigEntry<bool> DisableBluntDamage;
        internal static ConfigEntry<bool> DisableFragmentationDamage;

        public void Awake()
        {
            ABCPlugin.Log = base.Logger;
            var harmony = new Harmony("com.jbs4bmx.ArmBandCore");

            if (!VersionChecker.CheckEftVersion(Logger, Info, Config))
            {
                throw new Exception("Invalid EFT Version");
            }

            ABCPlugin.Log.LogInfo("Starting mod...");

            DebugArmorInspectorEnabled = Config.Bind<bool>(
                "DEBUG OPTIONS",
                "Enable Armor Inspector (WIP)",
                false,
                "Enable detailed armor inspection logging. (This may not function at the moment.)"
            );

            DebugHitTracingEnabled = Config.Bind<bool>(
                "DEBUG OPTIONS",
                "Enable Hit Tracing (WIP)",
                false,
                "Enable detailed hit tracing for ballistic impacts. (This may not function at the moment.)"
            );

            MultiLayerArmorEnabled = Config.Bind<bool>(
                "EXPERIMENTAL OPTIONS (ALL ARMOR)",
                "Enable Multi-Layer Armor Damage Resolution",
                false,
                "Enable multi-layer armor damage resolution. This should distribute ballistics damage between the armband and all other armors. (split 50/50)"
            );

            ExplosiveArmorProtectionEnabled = Config.Bind<bool>(
                "EXPERIMENTAL OPTIONS (ARMBAND ARMOR)",
                "Enable Protection From Explosives",
                false,
                "Redirect explosive damage to armor instead of the player."
            );

            ExplosivesOnlyTargetArmbandArmor = Config.Bind<bool>(
                "EXPERIMENTAL OPTIONS (ARMBAND ARMOR)",
                "Redirect All Explosive Damage to Armband Armor",
                false,
                "Explosive damage specifically targets only armband armor. Must set 'Enable Protection From Explosives' to 'True' for this option to work."
            );

            DisableThroughputDamage = Config.Bind<bool>(
                "EXPERIMENTAL OPTIONS (ARMBAND ARMOR)",
                "Disable Throughput Damage",
                false,
                "If true, prevents any armor throughput damage from reaching the player. All damage is redirected to the armor on the player instead."
            );

            DisableBluntDamage = Config.Bind<bool>(
                "EXPERIMENTAL OPTIONS (ARMBAND ARMOR)",
                "Disable Blunt Damage",
                false,
                "If true, blocks all blunt damage from armor impacts. All damage is redirected to the armor on the player instead."
            );

            DisableFragmentationDamage = Config.Bind<bool>(
                "EXPERIMENTAL OPTIONS (ARMBAND ARMOR)",
                "Disable Fragmentation Damage",
                false,
                "If true, blocks all fragmentation damage from reaching the player. All damage is redirected to the armor on the player instead."
            );

            ABCPlugin.Log.LogInfo("Applying ArmorSlots patch...");
            PatchArmorSlots();

            harmony.PatchAll();
            ABCPlugin.Log.LogInfo("Harmony patched.");

            ABCPlugin.Log.LogInfo("Mod fully loaded.");
        }

        private void PatchArmorSlots()
        {
            var flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public;
            var armorSlotsField = typeof(Inventory).GetField("ArmorSlots", flags);

            if (armorSlotsField == null)
            {
                ABCPlugin.Log.LogError("ArmorSlots field NOT FOUND on Inventory.");
                return;
            }

            var existing = (EquipmentSlot[])armorSlotsField.GetValue(null);

            if (!existing.Contains(EquipmentSlot.ArmBand))
            {
                var updated = existing.Concat(new[] { EquipmentSlot.ArmBand }).ToArray();
                armorSlotsField.SetValue(null, updated);
            }

            ABCPlugin.Log.LogInfo("ArmorSlots patch APPLIED.");
        }
    }
}
