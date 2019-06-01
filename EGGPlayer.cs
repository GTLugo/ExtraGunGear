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
    public class EGGPlayer : ModPlayer
    {
        public bool hasMuzzle;
        public bool hasGrip;
        public bool hasStock;
        public bool hasAmp;

        public override void ResetEffects()
        {
            hasMuzzle = false;
            hasGrip = false;
            hasStock = false;
            hasAmp = false;
            base.ResetEffects();
        }

        public override bool PreItemCheck()
        {
            return base.PreItemCheck();
        }

        /*public override void PostItemCheck()
        {
            Player player = this.player;
            Item item = player.inventory[player.selectedItem];
            if (hasStock && !player.noItems && item.ranged)
            {
                player.releaseUseItem = true;
                if (player.itemAnimation == 1 && item.stack > 0)
                {
                    if (item.shoot > 0 && player.whoAmI != Main.myPlayer && player.controlUseItem && item.useStyle == 5)
                    {
                        player.itemAnimation = item.useAnimation;
                        player.itemAnimationMax = item.useAnimation;
                        player.reuseDelay = item.reuseDelay;
                        if (item.UseSound != null)
                        {
                            Main.PlaySound(item.UseSound, player.Center);
                        }
                    }
                    else
                    {
                        player.itemAnimation = 0;
                    }
                }
            }
            if (player.itemAnimation == 0 && player.reuseDelay > 0)
            {
                player.itemAnimation = player.reuseDelay;
                player.itemTime = player.reuseDelay;
                player.reuseDelay = 0;
            }
            if (player.itemAnimation == 0 && player.altFunctionUse == 2)
            {
                player.altFunctionUse = 0;
            }
            base.PostItemCheck();
        }*/
    }
}