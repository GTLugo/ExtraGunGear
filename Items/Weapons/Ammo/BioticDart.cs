using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Weapons.Ammo {
    class BioticDart : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Biotic Dart" + "\n[UNIMPLEMENTED]");
            Tooltip.SetDefault("'pew'");
        }

        public override void SetDefaults() {
            item.width = 8;
            item.height = 8;
            item.ranged = true;
            item.consumable = true;
            item.maxStack = 999;
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
        //    recipe.AddIngredient(ItemID.EmptyBullet, 50);
        //    recipe.AddIngredient(ItemID.HolyWater);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(this, 50);
        //    recipe.AddRecipe();
        //}
    }
}
