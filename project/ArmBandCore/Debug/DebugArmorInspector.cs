using ArmBandCore.Patches;
using EFT;
using EFT.InventoryLogic;
using System.Collections.Generic;

namespace ArmBandCore.Debug
{
    public static class DebugArmorInspector
    {
        public static void DumpArmorList(string context, Player player)
        {
            if (!ABCPlugin.DebugArmorInspectorEnabled.Value)
                return;

            if (player == null)
            {
                ABCPlugin.Log.LogInfo($"{context}: player is NULL.");
                return;
            }

            var equipment = player.Profile.Inventory.Equipment;
            if (equipment == null)
            {
                ABCPlugin.Log.LogInfo($"{context}: equipment is NULL.");
                return;
            }

            var armorList = new List<ArmorComponent>();

            foreach (var slotId in CustomArmorSlots.Slots)
            {
                var slot = equipment.GetSlot(slotId);
                var item = slot?.ContainedItem;
                var armor = item?.GetItemComponent<ArmorComponent>();
                if (armor != null)
                    armorList.Add(armor);
            }

            ABCPlugin.Log.LogInfo($"{context}: {armorList.Count} armor components detected.");

            foreach (var armor in armorList)
            {
                ABCPlugin.Log.LogInfo($"- {armor.Item.TemplateId} | {armor.Item.Name}");
            }
        }
    }
}
