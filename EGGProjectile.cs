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
    public class EGGProjectile : GlobalProjectile
    {

        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            if (projectile.friendly && projectile.owner == Main.myPlayer && !projectile.npcProj)
            {
                Player owner = Main.player[projectile.owner];
                //Test for bullet types
                //(projectile.type == ProjectileID.Bullet) || (projectile.type == ProjectileID.BulletHighVelocity) || (projectile.type == ProjectileID.ChlorophyteBullet) || (projectile.type == ProjectileID.CrystalBullet) || (projectile.type == ProjectileID.CursedBullet) || (projectile.type == ProjectileID.ExplosiveBullet) || (projectile.type == ProjectileID.GoldenBullet) || (projectile.type == ProjectileID.IchorBullet) || (projectile.type == ProjectileID.MoonlordBullet) || (projectile.type == ProjectileID.NanoBullet) || (projectile.type == ProjectileID.PartyBullet) || (projectile.type == ProjectileID.VenomBullet))
                if (projectile.ranged && owner.GetModPlayer<EGGPlayer>(mod).hasMuzzle) //Test for muzzle and ranged projectile
                {
                    target.AddBuff(BuffID.OnFire, 60 * 8);
                    base.OnHitNPC(projectile, target, damage, knockback, crit);
                }
            }
        }

        public override void AI(Projectile projectile)
        {
            Player owner = Main.player[projectile.owner];
            if (projectile.ranged && projectile.friendly && !projectile.npcProj && projectile.owner == Main.myPlayer)
            {
                if (owner.GetModPlayer<EGGPlayer>(mod).hasGrip  && (projectile.timeLeft == 600)) //Test for grip and test that the bullet just spawned
                {
                    Vector2 cursor = (Main.MouseWorld - owner.Center).SafeNormalize(Vector2.UnitX);
                    Vector2 perturbedSpeed = (cursor * projectile.velocity.Length()).RotatedByRandom(MathHelper.ToRadians(1f));
                    projectile.velocity.X = perturbedSpeed.X;
                    projectile.velocity.Y = perturbedSpeed.Y;
                }
                if (owner.GetModPlayer<EGGPlayer>(mod).hasMuzzle) //Test for muzzle and ranged projectile
                {
                    Lighting.AddLight(projectile.position, 1f, 0.40f, 0f);
                    if (Main.rand.Next(2) == 0)
                    {
                        Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire);
                    }
                }
            }
            base.AI(projectile);
        }
    }
}