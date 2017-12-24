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
    public class BlazingScope : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Ranged attacks set enemies on fire"
                + "\n15% increased ranged damage and critical strike chance"
                + "\nIncreases view range (Right click to zoom out)");
        }
        public override void SetDefaults()
        {

            item.width = 22;
            item.height = 30;
            item.value = 530000;
            item.rare = 8;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.rangedDamage += 0.15f;
            player.rangedCrit += 15;
            base.UpdateAccessory(player, hideVisual);
            player.scope = true;
            //player.GetModPlayer<EGGPlayer>(mod).hasMuzzle = true;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "InfernoMuzzle");
            recipe.AddIngredient(ItemID.SniperScope);
            recipe.AddIngredient(ItemID.Binoculars);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}