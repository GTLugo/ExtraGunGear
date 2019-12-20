
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Accessories {
    public class InfernoMuzzle : ModItem {
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("Accelerates bullets to the speed of light" +
                "\n12% increased ranged damage");
        }
        public override void SetDefaults() {
            item.width = 22;
            item.height = 30;
            item.value = 200000;
            item.rare = 4;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            EGGPlayer modPlayer = player.GetModPlayer<EGGPlayer>();
            player.rangedDamage += 0.12f;
            modPlayer.hasMuzzle = true;
            base.UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "MeteorMuzzle");
            recipe.AddIngredient(ItemID.RangerEmblem);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}