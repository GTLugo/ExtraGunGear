
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Accessories {
    public class MeteorMuzzle : ModItem {
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("Bullets instantly hit their targets" +
                "\nBullets burn struck enemies" +
                "\n(Visibility toggles bullet acceleration)" +
                "\n'Zoom!'");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 30;
            item.value = 50000;
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            //player.bulletDamage *= 1.10f;
            EGGPlayer modPlayer = player.GetModPlayer<EGGPlayer>();
            modPlayer.hasMuzzle = true;
            if (!hideVisual) {
                modPlayer.muzzleEnabled = true;
            }
            base.UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MeteoriteBar, 18);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}