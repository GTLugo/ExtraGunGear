using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear
{
    public class EGGItem : GlobalItem
    {
        public override bool CanUseItem(Item item, Player player)
        {
            if (item.ranged && player.GetModPlayer<EGGPlayer>(mod).hasStock && player.altFunctionUse != 2)
            {
                item.autoReuse = true;
            }
            else if (item.ranged && !player.GetModPlayer<EGGPlayer>(mod).hasStock && player.altFunctionUse != 2)
            {
                byte prefix = item.prefix;
                bool fav = item.favorited;
                item.CloneDefaults(item.type);
                item.favorited = fav;
                item.prefix = prefix;
                if (item.modItem != null)
                {
                    item.modItem.CanUseItem(player);
                }

                //item.CloneWithModdedDataFrom(item).modItem.CanUseItem(player);
            }
            
            return base.CanUseItem(item, player);
        }
    }
}
