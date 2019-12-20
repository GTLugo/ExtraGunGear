using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Weapons.Ammo //Such namescape
{
    public class EndlessHighVBox : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Endless High Velocity Crate");
            Tooltip.SetDefault("'For those who want to be MLG PR0 3L1T3'");
        }
        public override void SetDefaults() {
            item.damage = 10;
            item.ranged = true;
            item.width = 36;
            item.height = 32;
            item.maxStack = 1;
            item.knockBack = 4f;
            item.value = 76000;
            item.rare = 6;
            item.shoot = 242;
            item.shootSpeed = 28f;
            item.ammo = AmmoID.Bullet;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "BulletBox");
            recipe.AddIngredient(ItemID.Cog, 90);
            recipe.AddIngredient(ItemID.SoulofNight, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}