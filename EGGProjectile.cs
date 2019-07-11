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
        public override void SetDefaults(Projectile projectile)
        {
            Player owner = Main.player[projectile.owner];
            if (projectile.ranged && projectile.friendly && !projectile.npcProj && projectile.owner == Main.myPlayer)
            {
                if (owner.GetModPlayer<EGGPlayer>(mod).hasMuzzle) //Test for muzzle and ranged projectile
                {
                    projectile.width = 4;
                    projectile.height = 4;
                    projectile.aiStyle = -1;
                    projectile.tileCollide = true;
                    projectile.ignoreWater = true;
                    projectile.extraUpdates = 100;
                    projectile.timeLeft = 600;
                    projectile.hostile = false;
                }
            }
            base.SetDefaults(projectile);
        }
        
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
                    
                    Color dustColor;
                    switch (owner.team)
                    {
                        case 0:
                            dustColor = Color.White;
                            break;
                        case 1:
                            dustColor = Color.Red;
                            break;
                        case 2:
                            dustColor = Color.LawnGreen;
                            break;
                        case 3:
                            dustColor = Color.Cyan;
                            break;
                        case 4:
                            dustColor = Color.PaleGoldenrod;
                            break;
                        case 5:
                            dustColor = Color.Magenta;
                            break;
                        default:
                            dustColor = Color.White;
                            break;
                    }
                    if (projectile.type == ProjectileID.Bullet || projectile.type == ProjectileID.BulletHighVelocity)
                    {
                        //Main.NewText("bullet is hitscan");
                        projectile.localAI[0] += 1f;
                        if (projectile.localAI[0] > 3f)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                Vector2 projectilePosition = projectile.position;
                                projectilePosition -= projectile.velocity * ((float)i * 0.25f);
                                projectile.alpha = 255;
                                projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
                                projectile.spriteDirection = projectile.direction;
                                int trail = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y - projectile.height / 4), 1, 1, 199, 0f, 0f, 0, dustColor, 1f);
                                Main.dust[trail].position = projectilePosition;
                                Main.dust[trail].scale = (float)Main.rand.Next(70, 110) * 0.013f;
                                Main.dust[trail].velocity *= 0.2f;
                                Main.dust[trail].noGravity = true;
                            }
                            return;
                        }
                        return;
                    }
                    else if (projectile.type == ProjectileID.ChlorophyteBullet)
                    {
                        //Main.NewText("bullet is homing hitscan");
                        projectile.localAI[0] += 1f;
                        if (projectile.localAI[0] > 2f)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                Vector2 projectilePosition = projectile.position;
                                projectilePosition -= projectile.velocity * ((float)i * 0.25f);
                                projectile.alpha = 255;
                                projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
                                projectile.spriteDirection = projectile.direction;
                                int trail = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y - projectile.height / 4), 1, 1, 75, 0f, 0f, 0, default(Color), 1f);
                                Main.dust[trail].position = projectilePosition;
                                Main.dust[trail].scale = (float)Main.rand.Next(70, 110) * 0.013f;
                                Main.dust[trail].velocity *= 0.2f;
                                Main.dust[trail].noGravity = true;
                            }
                            return;
                        }
                        return;
                    }
                    
                }
            }
            base.AI(projectile);
        }
        
        public override void ModifyDamageHitbox(Projectile projectile, ref Rectangle hitbox)
        {
            Player owner = Main.player[projectile.owner];
            if (projectile.ranged && projectile.friendly && !projectile.npcProj && projectile.owner == Main.myPlayer)
            {
                if (owner.GetModPlayer<EGGPlayer>(mod).hasMuzzle) //Test for muzzle and ranged projectile
                {
                    hitbox.Inflate(10, 10);
                }
            }
            base.ModifyDamageHitbox(projectile, ref hitbox);
        }
        
    }
}