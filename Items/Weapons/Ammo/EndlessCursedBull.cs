using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Weapons.Ammo //Such namescape
{
    public class EndlessCursedBull : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Endless Cursed Pouch");
            Tooltip.SetDefault("'I curse the man who made these...'");
        }

        public override void SetDefaults() {
            item.damage = 12;
            item.ranged = true;
            item.width = 26;
            item.height = 26;
            item.maxStack = 1;
            item.knockBack = 4f;
            item.value = 76000;
            item.rare = 6;
            item.shoot = 104;
            item.shootSpeed = 5f;
            item.ammo = AmmoID.Bullet;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "BulletPouch");
            recipe.AddIngredient(ItemID.CursedFlame, 60);
            recipe.AddIngredient(ItemID.SoulofNight, 4);
            recipe.AddIngredient(ItemID.SoulofSight, 2);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}