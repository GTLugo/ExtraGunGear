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
    public class AccessoryKit : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Illegal Accessory Kit");
            Tooltip.SetDefault("Increases ranged accuracy dramatically"
            //+ "\nDecreases ranged damage by 4%"
            + "\nRanged attacks set enemies on fire");
        }
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 22;
            item.value = 50000;
            item.rare = 3;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //player.rangedDamage -= 0.04f;
            base.UpdateAccessory(player, hideVisual);
            player.GetModPlayer<EGGPlayer>(mod).hasGrip = true;
            player.GetModPlayer<EGGPlayer>(mod).hasMuzzle = true;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "VerticalGrip");
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddIngredient(mod, "MeteorMuzzle");
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}