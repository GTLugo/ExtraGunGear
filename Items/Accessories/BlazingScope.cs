
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Accessories {
    public class BlazingScope : ModItem {
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("Ranged attacks set enemies on fire"
                + "\n12% increased ranged damage and critical strike chance"
                + "\nIncreases view range for ranged weapons"
                + "\nwhen accessory is visible (Right click to zoom out)");
        }
        public override void SetDefaults() {
            item.width = 22;
            item.height = 30;
            item.value = 350000;
            item.rare = 8;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            EGGPlayer modPlayer = player.GetModPlayer<EGGPlayer>();
            player.rangedDamage += 0.12f;
            player.rangedCrit += 12;
            if (player.HeldItem.ranged && !hideVisual) {
                player.scope = true;
            }
            modPlayer.hasMuzzle = true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "InfernoMuzzle");
            recipe.AddIngredient(ItemID.SniperScope);
            recipe.AddIngredient(ItemID.Binoculars);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}