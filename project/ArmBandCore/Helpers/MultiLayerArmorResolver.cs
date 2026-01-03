using ArmBandCore.Patches;
using EFT;
using EFT.InventoryLogic;
using System.Collections.Generic;

namespace ArmBandCore.Helpers
{
    public static class MultiLayerArmorResolver
    {
        public static void ApplySharedArmorDamage(
            ArmorComponent primaryArmor,
            DamageInfoStruct info,
            Player player,
            List<ArmorComponent> armorComponents
        )
        {
            if (!ABCPlugin.MultiLayerArmorEnabled.Value)
                return;

            if (player == null || primaryArmor == null)
                return;

            var equipment = player.Profile.Inventory.Equipment;
            if (equipment == null)
                return;

            var allArmor = new List<ArmorComponent>();

            foreach (var slotId in CustomArmorSlots.Slots)
            {
                var slot = equipment.GetSlot(slotId);
                var item = slot?.ContainedItem;
                var armor = item?.GetItemComponent<ArmorComponent>();
                if (armor != null)
                    allArmor.Add(armor);
            }

            // Remove the primary armor from the list
            allArmor.Remove(primaryArmor);

            if (allArmor.Count == 0)
                return;

            float sharedDamage = info.ArmorDamage * 0.5f / allArmor.Count;

            foreach (var extra in allArmor)
            {
                extra.ApplyDurabilityDamage(sharedDamage, armorComponents);

                if (ABCPlugin.DebugHitTracingEnabled.Value)
                {
                    ABCPlugin.Log.LogInfo(
                        $"[MultiArmor] Applied {sharedDamage} durability damage to {extra.Item.TemplateId}"
                    );
                }
            }
        }
    }
}
