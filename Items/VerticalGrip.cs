using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items
{
    public class VerticalGrip : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases ranged accuracy dramatically"
            + "\nDecreases ranged damage by 15%");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.value = 50000;
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.rangedDamage -= 0.10f;
            base.UpdateAccessory(player, hideVisual);
            player.GetModPlayer<EGGPlayer>(mod).hasGrip = true;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 18);
            recipe.anyIronBar = true;
            recipe.AddIngredient(ItemID.Wood, 12);
            recipe.anyWood = true;
            recipe.AddIngredient(ItemID.Leather, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}