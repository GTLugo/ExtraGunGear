/*using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items
{
	public class LargeTorch : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Giant Torch");
            Tooltip.SetDefault("'Unlimited torch power! Itty bitty inventory space.'");
		}

        public override bool ConsumeAmmo(Player p)
        {
            int rand = Main.rand.Next(4);
            if (p.itemAnimation < p.inventory[p.selectedItem].useAnimation - 30) //Consumes ammo near the end of the item's animation
            {
                if (rand == 0) //33 percent chance to make player consume no ammo 
                {
                    return false; //No ammo is consumed
                }
                else
                {
                    return true; //Ammo is consumed
                }
            }
            else
            {
                return false; //Ammo is not consumed before animation is finished
            }

        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-7, 0);
        }

        public override void SetDefaults()
		{
			item.width = 36;
			item.height = 32;
            item.useStyle = 1;
            item.noMelee = true;
            item.useAnimation = 15;
            item.autoReuse = true;
            item.useTime = 15;
            item.reuseDelay = 1;
            item.value = 560000;
			item.rare = 5;
            item.useTurn = true;
            item.noWet = true;
            item.createTile = TileID.Torches;
            item.placeStyle = 1;
            item.useAmmo = AmmoID.Gel;
        }
        


        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 200);
            recipe.AddIngredient(ItemID.Gel, 300);
            recipe.AddIngredient(ItemID.SoulofLight, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
*/