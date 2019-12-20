using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Weapons.Ammo //Such namescape
{
    public class EndlessChloroBull : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Endless Chlorophyte Pouch");
            Tooltip.SetDefault("'I've got you in my sights!'");
        }

        public override void SetDefaults() {
            item.damage = 10;
            item.ranged = true;
            item.width = 26;
            item.height = 26;
            item.maxStack = 1;
            item.knockBack = 4.5f;
            item.value = 79500;
            item.rare = 7;
            item.shoot = 207; //Chlorophyte Bullet Projectile ID
            item.shootSpeed = 5f;
            item.ammo = AmmoID.Bullet;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "BulletPouch");
            recipe.AddIngredient(ItemID.ChlorophyteBar, 60);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}