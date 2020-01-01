
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Accessories {
    public class AccessoryKit : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Illegal Accessory Kit");
            Tooltip.SetDefault("Increases ranged accuracy dramatically"
            //+ "\nDecreases ranged damage by 4%"
            + "\nBullets instantly hit their targets"
            + "\n(Visibility toggles bullet acceleration and accuracy)");
        }

        public override void SetDefaults() {
            item.width = 26;
            item.height = 22;
            item.value = 50000;
            item.rare = 8;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            EGGPlayer modPlayer = player.GetModPlayer<EGGPlayer>();
            //player.rangedDamage -= 0.04f;
            modPlayer.hasGrip = true;
            modPlayer.hasMuzzle = true;
            if (!hideVisual) {
                modPlayer.gripEnabled = true;
                modPlayer.muzzleEnabled = true;
            }
            base.UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "VerticalGrip");
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddIngredient(mod, "MeteorMuzzle");
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}