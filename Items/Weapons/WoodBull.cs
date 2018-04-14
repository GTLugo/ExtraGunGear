using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Weapons
{
    class WoodBull : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wooden Bullet");
            Tooltip.SetDefault("'Simple, yet effective'");
		}

		public override void SetDefaults()
		{
			item.damage = 4;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 1.5f;
			item.value = 1;
			item.rare = -1;
			item.shoot = mod.ProjectileType("WoodBull"); 
			item.shootSpeed = 8f;
			item.ammo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 2);
            recipe.anyWood = true;
            recipe.SetResult(this, 33);
			recipe.AddRecipe();
		}
	}
}
