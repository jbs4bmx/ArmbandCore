using BepInEx;
using BepInEx.Configuration;
using System;
using UnityEngine;
using EFT.InventoryLogic;
using System.Reflection;
using ArmBandCore.Utilities;
using static ArmBandCore.Utilities.VersionChecker;

namespace ABCore
{
    [BepInPlugin("com.jbs4bmx.ArmBandCore", "ArmBandCore", "310.0.1")]
    public class Core : BaseUnityPlugin
    {
        public const int TarkovVersion = 33420;

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
