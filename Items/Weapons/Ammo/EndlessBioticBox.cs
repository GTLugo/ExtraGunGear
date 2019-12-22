using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Weapons.Ammo //Such namescape
{
    public class EndlessBioticBox : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Endless Biotic Crate");
            Tooltip.SetDefault("'pew pew pew'" + "\n[UNIMPLEMENTED]");
        }

        public override void SetDefaults() {
            item.ranged = true;
            item.width = 36;
            item.height = 32;
            item.maxStack = 1;
            item.value = 76000;
            item.rare = 6;
            item.damage = 1;
            item.knockBack = 0f;
            item.shoot = mod.ProjectileType("BioticDart");
            item.shootSpeed = 8f;
            item.ammo = AmmoID.Bullet;
        }

        //public override void AddRecipes() {
        //    ModRecipe recipe = new ModRecipe(mod);
        //    recipe.AddIngredient(mod, "BulletBox");
        //    recipe.AddIngredient(ItemID.HolyWater, 85);
        //    recipe.AddIngredient(ItemID.SoulofLight, 5);
        //    recipe.AddIngredient(ItemID.SoulofSight, 5);
        //    recipe.AddTile(TileID.CrystalBall);
        //    recipe.SetResult(this);
        //    recipe.AddRecipe();
        //}
    }
}