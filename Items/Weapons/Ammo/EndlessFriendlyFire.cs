using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Weapons.Ammo {
    class EndlessFriendlyFire : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Endless Friendly Fire Rounds");
            Tooltip.SetDefault("Harms townspeople and yourself" +
                "\n'Pure evil...'");
        }

        public override void SetDefaults() {
            item.damage = 4;
            item.ranged = true;
            item.width = 8;
            item.height = 8;
            item.maxStack = 1;
            item.consumable = false;
            item.knockBack = 1.5f;
            item.value = 1;
            item.rare = -1;
            item.shoot = mod.ProjectileType("FriendlyFire");
            item.shootSpeed = 8f;
            item.ammo = AmmoID.Bullet;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "FriendlyFire", 3996);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
