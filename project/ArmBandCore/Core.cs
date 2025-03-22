using ABCore.Utilities;
using BepInEx;
using EFT.InventoryLogic;
using System;
using System.Reflection;

namespace ABCore
{
    [BepInPlugin("com.jbs4bmx.ArmBandCore", "ArmBandCore", "311.1.1")]
    [BepInDependency("com.SPT.core", "3.11.1")]
    public class Core : BaseUnityPlugin
    {
        public const int TarkovVersion = 35392;

        private void Main()
        {
            if (!VersionChecker.CheckEftVersion(Logger, Info, Config))
            {
                throw new Exception("Invalid EFT Version");
            }
            AddArmBandArmorSlot();
        }

        public void AddArmBandArmorSlot()
        {
            var bindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public;
            var field = typeof(Inventory).GetField("ArmorSlots", bindingFlags);

            field.SetValue(null, new EquipmentSlot[]
            {
                EquipmentSlot.TacticalVest,
                EquipmentSlot.ArmorVest,
                EquipmentSlot.Headwear,
                EquipmentSlot.FaceCover,
                EquipmentSlot.Eyewear,
                EquipmentSlot.ArmBand
            });
        }
    }
}
