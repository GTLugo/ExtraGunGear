using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items {
    public class MayanCalendar : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Mayan Calendar");
            Tooltip.SetDefault("Summons the Sun God");
            ItemID.Sets.SortingPriorityBossSpawns[item.type] = 12; // This helps sort inventory know this is a boss summoning item.
        }

        public override bool CanUseItem(Player player) {
            return Main.hardMode && NPC.downedGolemBoss && !NPC.AnyNPCs(mod.NPCType("SunGod"));
        }

        public override bool UseItem(Player player) {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("SunGod"));
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }

        public override void SetDefaults() {
            item.maxStack = 1;
            item.width = 34;
            item.height = 34;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 8;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarTabletFragment, 4);
            recipe.AddIngredient(ItemID.Daybloom, 4);
            recipe.AddTile(TileID.LihzahrdAltar);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}