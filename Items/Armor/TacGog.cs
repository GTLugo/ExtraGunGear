using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class TacGog : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Recon Visor");
            Tooltip.SetDefault("Allows the user to see enemies through walls" 
                + "\n'No one can hide from my sight'");
        }

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 2;
		}

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = true;
            base.DrawHair(ref drawHair, ref drawAltHair);
        }

        public override void UpdateEquip(Player player)
        {
            player.AddBuff(BuffID.Hunter, 60 * 1);
            base.UpdateEquip(player);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HunterPotion, 15);
            recipe.AddIngredient(ItemID.MeteoriteBar, 14);
            recipe.AddIngredient(ItemID.Goggles);
            recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}