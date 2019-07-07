using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Accessories
{
    public class MeteorMuzzle : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Bullets are hit-scan" +
                "\nRanged attacks set enemies on fire");
        }
        public override void SetDefaults()
        {

            item.width = 22;
            item.height = 30;
            item.value = 50000;
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //player.bulletDamage *= 1.10f;
            player.GetModPlayer<EGGPlayer>(mod).hasMuzzle = true;
            base.UpdateAccessory(player, hideVisual);
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MeteoriteBar, 18);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}