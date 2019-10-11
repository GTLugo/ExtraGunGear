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
    public class SunPowerSeed : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sunpower Seed");
            Tooltip.SetDefault("Dramatically reduces the cooldown of healing potions"
            //+ "\nDecreases ranged damage by 10%"
            );
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.value = 75000;
            item.rare = -12;
            item.expert = true;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //player.rangedDamage -= 0.10f;
            base.UpdateAccessory(player, hideVisual);
            player.GetModPlayer<EGGPlayer>().hasSeed = true;
        }
    }
}