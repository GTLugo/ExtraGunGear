using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Weapons.Ammo //Such namescape
{
    public class EndlessVenomBox : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Endless Venom Crate");
            Tooltip.SetDefault("'Enemy of the Endless Spider-man Crate'");
        }
        public override void SetDefaults() {
            item.damage = 14;
            item.ranged = true;
            item.width = 36;
            item.height = 32;
            item.maxStack = 1;
            item.knockBack = 4.1f;
            item.value = 76000;
            item.rare = 6;
            item.shoot = 283;
            item.shootSpeed = 5.3f;
            item.ammo = AmmoID.Bullet;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "BulletBox");
            recipe.AddIngredient(ItemID.VialofVenom, 85);
            recipe.AddIngredient(ItemID.SoulofNight, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}