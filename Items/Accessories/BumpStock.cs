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
    public class BumpStock : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Converts all ranged weapons to auto-fire"
            //+ "\nDecreases ranged damage by 10%"
            );
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.value = 75000;
            item.rare = 7;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //player.rangedDamage -= 0.10f;
            base.UpdateAccessory(player, hideVisual);
            player.GetModPlayer<EGGPlayer>(mod).hasStock = true;
        }
    }
}