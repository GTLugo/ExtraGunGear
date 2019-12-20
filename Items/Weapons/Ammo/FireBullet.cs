using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Weapons.Ammo {
    public class FireBullet : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Incendiary Bullet");
            Tooltip.SetDefault("'You best head for the hills, I'm on fire'");
        }

        public override void SetDefaults() {
            item.damage = 8;
            item.ranged = true;
            item.width = 8;
            item.height = 8;
            item.maxStack = 999;
            item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
            item.knockBack = 2f;
            item.value = 2;
            item.rare = 1;
            item.shoot = mod.ProjectileType("FireBullet");   //The projectile shoot when your weapon using this ammo
            item.shootSpeed = 3.5f;                  //The speed of the projectile
            item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MusketBall, 25);
            recipe.AddIngredient(ItemID.Torch, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 25);
            recipe.AddRecipe();
        }
    }
}
