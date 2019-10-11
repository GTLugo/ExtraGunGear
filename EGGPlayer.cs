using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ExtraGunGear
{
    public class EGGPlayer : ModPlayer
    {
        public bool hasMuzzle;
        public bool hasGrip;
        public bool hasStock;
        public bool hasAmp;
        public bool hasSeed;
        public bool hasMSeed;

        public const int maxSerums = 1;
        public int serums;

        public override void clientClone(ModPlayer clientClone)
        {
            // Here we would make a backup clone of values that are only correct on the local players Player instance.
            EGGPlayer clone = clientClone as EGGPlayer;
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = mod.GetPacket();
            packet.Write((byte)EGGModMessageType.EGGPlayerSyncPlayer);
            packet.Write((byte)player.whoAmI);
            packet.Write(serums);
            packet.Send(toWho, fromWho);
        }

        public override void SendClientChanges(ModPlayer clientPlayer)
        {
            // Here we would sync something like an RPG stat whenever the player changes it.
            EGGPlayer clone = clientPlayer as EGGPlayer;

        }

        public override TagCompound Save()
        {
            return new TagCompound {
                {"serums", serums},
            };
        }

        public override void Load(TagCompound tag)
        {
            serums = tag.GetInt("serums");
        }

        /*public override void ModifyDrawInfo(ref PlayerDrawInfo drawInfo)
        {
            Player player = drawInfo.drawPlayer;
            Item heldItem = player.inventory[player.selectedItem];
            if (heldItem.modItem != null)
            {
                if (heldItem.modItem.GetType() == mod.ItemType("VortexAR").GetType())
                {
                    Texture2D texture = mod.GetTexture("Items/Weapons/AssaultRifles/VortexAR_Glow");
                    Vector2 value2 = drawInfo.position + (player.itemLocation - player.position);
                    Vector2 vector10 = new Vector2((float)(Main.itemTexture[player.inventory[player.selectedItem].type].Width / 2), (float)(Main.itemTexture[player.inventory[player.selectedItem].type].Height / 2));
                    Vector2 vector11 = player.itemLocation;
                    int num107 = (int)vector11.X;

                    Vector2 origin5 = new Vector2((float)(-(float)num107), (float)(Main.itemTexture[player.inventory[player.selectedItem].type].Height / 2));

                    DrawData value = new DrawData(texture, new Vector2((float)((int)(value2.X - Main.screenPosition.X + vector10.X)), (float)((int)(value2.Y - Main.screenPosition.Y + vector10.Y))), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.itemTexture[player.inventory[player.selectedItem].type].Width, Main.itemTexture[player.inventory[player.selectedItem].type].Height)), new Microsoft.Xna.Framework.Color(250, 250, 250, player.inventory[player.selectedItem].alpha), player.itemRotation, origin5, player.inventory[player.selectedItem].scale, SpriteEffects.None, 0);
                    Main.playerDrawData.Add(value);
                }
            }
            base.ModifyDrawInfo(ref drawInfo);
        }*/

        public override void PostUpdateMiscEffects()
        {
            player.potionDelayTime = Item.potionDelay;
            player.restorationDelayTime = Item.restorationDelay;
            if (player.GetModPlayer<EGGPlayer>().hasAmp)
            {
                player.potionDelayTime = (int)((double)player.potionDelayTime * 0.5);
                player.restorationDelayTime = (int)((double)player.restorationDelayTime * 0.5);
            }

            base.PostUpdateMiscEffects();
        }

        public override void ResetEffects()
        {
            hasMuzzle = false;
            hasGrip = false;
            hasStock = false;
            hasAmp = false;
            hasSeed = false;
            hasMSeed = false;

            // Super Soldier Serum effects: //
            if (player.GetModPlayer<EGGPlayer>().serums > 0)
            {
                player.statLifeMax2 += serums * 100;
                player.moveSpeed += serums * 0.1f;
                player.jumpSpeedBoost += serums * 1.2f;
                player.lifeRegen += serums * 2;
                player.statDefense += serums * 4;
                player.meleeSpeed += serums * 0.1f;
                player.meleeDamage += serums * 0.1f;
                player.meleeCrit += serums * 2;
                player.rangedDamage += serums * 0.1f;
                player.rangedCrit += serums * 2;
                player.magicDamage += serums * 0.1f;
                player.magicCrit += serums * 2;
                player.pickSpeed -= serums * 0.15f;
                player.minionDamage += serums * 0.1f;
                player.minionKB += serums * 0.5f;
                player.thrownDamage += serums * 0.1f;
                player.thrownCrit += serums * 2;
            }

            base.ResetEffects();
        }

        public override bool Shoot(Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            //Main.NewText("Modified Shoot");
            if (item.ranged)
            {
                //Main.NewText("item is ranged");
                if (player.GetModPlayer<EGGPlayer>().hasMuzzle)
                {
                    //Main.NewText("player has muzzle");
                    if (type == ProjectileID.Bullet || type == ProjectileID.BulletHighVelocity)
                    {
                        //Main.NewText("bullet is hitscan");
                        //type = mod.ProjectileType("HitScan");
                    }
                    else if (type == ProjectileID.ChlorophyteBullet)
                    {
                        //Main.NewText("bullet is homing hitscan");
                        //type = mod.ProjectileType("HitScanHoming");
                    }
                }
            }
            return base.Shoot(item, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
    }
}