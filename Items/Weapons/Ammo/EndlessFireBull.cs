using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Weapons.Ammo //Such namescape
{
    public class EndlessFireBull : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Endless Incendiary Pouch");
            Tooltip.SetDefault("'A firebender's favorite'");
        }

        public override void SetDefaults() {
            item.damage = 8;
            item.ranged = true;
            item.width = 26;
            item.height = 26;
            item.maxStack = 1;
            item.consumable = false;
            item.knockBack = 2f;
            item.value = 76000;
            item.rare = 6;
            item.shoot = mod.ProjectileType("FireBullet");
            item.shootSpeed = 3.5f;
            item.ammo = AmmoID.Bullet;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "BulletPouch");
            recipe.AddIngredient(ItemID.Torch, 400);
            recipe.AddIngredient(ItemID.SoulofLight, 6);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}