using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Weapons.Ammo //Such namescape
{
    public class EndlessLuminiteBox : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Endless Luminite Crate");
            Tooltip.SetDefault("'Taken straight from Apollo 11'");
        }
        public override void SetDefaults() {
            item.damage = 22;
            item.ranged = true;
            item.width = 36;
            item.height = 32;
            item.maxStack = 1;
            item.knockBack = 3f;
            item.value = 76000;
            item.rare = 6;
            item.shoot = 638;
            item.shootSpeed = 20f;
            item.ammo = AmmoID.Bullet;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "BulletBox");
            recipe.AddIngredient(ItemID.LunarBar, 6);
            recipe.AddIngredient(ItemID.SoulofSight, 8);
            recipe.AddIngredient(ItemID.FragmentVortex, 6);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}