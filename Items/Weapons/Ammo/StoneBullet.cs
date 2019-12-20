using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Weapons.Ammo {
    class StoneBullet : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Stone Bullet");
            Tooltip.SetDefault("'Simple, yet effective'");
        }

        public override void SetDefaults() {
            item.damage = 3;
            item.ranged = true;
            item.width = 8;
            item.height = 8;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 1.5f;
            item.value = 1;
            item.rare = -1;
            item.shoot = mod.ProjectileType("StoneBullet");
            item.shootSpeed = 8f;
            item.ammo = AmmoID.Bullet;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 1);
            recipe.SetResult(this, 25);
            recipe.AddRecipe();
        }
    }
}
