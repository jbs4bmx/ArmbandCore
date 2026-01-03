using System.Collections.Generic;
using EFT.InventoryLogic;

namespace ArmBandCore.Patches
{
    public static class CustomArmorSlots
    {
        // List of all custom armor slots you want to support
        public static readonly List<EquipmentSlot> Slots = new List<EquipmentSlot>
        {
            EquipmentSlot.ArmBand
            // Add more custom slots here later?? (maybe pockets??)
        };
    }
}