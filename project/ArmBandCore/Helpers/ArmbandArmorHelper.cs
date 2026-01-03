using EFT.InventoryLogic;

namespace ArmBandCore.Helpers
{
    public static class ArmbandArmorHelper
    {
        public static ArmorComponent GetArmbandArmor(InventoryEquipment equipment)
        {
            if (equipment == null)
                return null;

            var slot = equipment.GetSlot(EquipmentSlot.ArmBand);
            var item = slot?.ContainedItem;
            return item?.GetItemComponent<ArmorComponent>();
        }
    }
}
