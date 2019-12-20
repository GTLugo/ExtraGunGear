using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Weapons.Ammo //Such namescape
{
    public class EndlessCrystalBull : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Endless Crystal Pouch");
            Tooltip.SetDefault("'Simple Geometry'");
        }

        public override void SetDefaults() {
            item.damage = 9;
            item.ranged = true;
            item.width = 26;
            item.height = 26;
            item.maxStack = 1;
            item.knockBack = 1f;
            item.value = 76000;
            item.rare = 6;
            item.shoot = 89;
            item.shootSpeed = 5f;
            item.ammo = AmmoID.Bullet;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "BulletPouch");
            recipe.AddIngredient(ItemID.CrystalShard, 65);
            recipe.AddIngredient(ItemID.SoulofLight, 6);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}