using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Terraria;

namespace ExtraGunGear
{
	class ExtraGunGear : Mod
	{
		public ExtraGunGear()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Vertebrae, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.Leather);
            recipe.AddRecipe();
        }
        public override void AddRecipeGroups()
        {
            RecipeGroup group = new RecipeGroup(() => Lang.misc[37] + " Gold Bar", new int[]
            {
                    ItemID.GoldBar,
                    ItemID.PlatinumBar
            });
            RecipeGroup.RegisterGroup("ExtraGunGear:GoldBar", group);
        }
    }
}
