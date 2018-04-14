using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items
{
	public class BulletPouch : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Advanced Bullet Pouch");
            Tooltip.SetDefault("Mystical energy swarms around this pouch");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 34;
			item.maxStack = 30;
			item.value = 560000;
			item.rare = 5;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Leather, 8);
            recipe.AddIngredient(ItemID.SoulofLight, 6);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
