using BepInEx;
using BepInEx.Configuration;
using EFT.InventoryLogic;
using HarmonyLib;
using System;
using System.Reflection;
using static ArmBandCore.Utilities.VersionChecker;

namespace ArmBandCore
{
    [BepInPlugin("com.jbs4bmx.ArmBandCore", "ArmBandCore", "311.2.1")]
    [BepInDependency("com.SPT.core", "3.11.2")]
    public class Core : BaseUnityPlugin
    {
        public const int TarkovVersion = 35392;
        internal static ConfigEntry<bool> DisableBT;

        private void Awake()
        {
            var harmony = new Harmony("com.jbs4bmx.ArmBandCore");
            const string sectionName = "ArmBandCore BT Remover";

            if (!CheckEftVersion(Logger, Info, Config))
            {
                throw new Exception("Invalid EFT Version");
            }

            DisableBT = Config.Bind(
                sectionName,
                "Disable blunt throughput damage.",
                true,
                new ConfigDescription
                (
                    "Disable damage from blunt-force trauma?",
                    null,
                    new ConfigurationManagerAttributes
                    {
                        Order = 1,
                    }
                )
            );

            AddArmBandArmorSlot();
            harmony.PatchAll();
        }

        public void AddArmBandArmorSlot()
        {
            

            var bindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public;
            var field = typeof(Inventory).GetField("ArmorSlots", bindingFlags);

            field.SetValue(null, new EquipmentSlot[]
            {
                EquipmentSlot.Headwear,
                EquipmentSlot.FaceCover,
                EquipmentSlot.Eyewear,
                EquipmentSlot.TacticalVest,
                EquipmentSlot.ArmorVest,
                EquipmentSlot.ArmBand
            });
        }
    }
}
