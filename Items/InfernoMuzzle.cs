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
    public class InfernoMuzzle : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Ranged attacks set enemies on fire" +
                "\n12% increased ranged damage");
        }
        public override void SetDefaults()
        {

            item.width = 22;
            item.height = 30;
            item.value = 200000;
            item.rare = 4;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.rangedDamage += 0.12f;
            base.UpdateAccessory(player, hideVisual);
            player.GetModPlayer<EGGPlayer>(mod).hasMuzzle = true;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "MeteorMuzzle");
            recipe.AddIngredient(ItemID.RangerEmblem);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}