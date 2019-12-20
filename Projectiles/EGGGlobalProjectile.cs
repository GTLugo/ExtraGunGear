using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear {
    public class EGGGlobalProjectile : GlobalProjectile {
        public static List<int> bulletTypes = new List<int>(){
                        ProjectileID.Bullet,
                        ProjectileID.ExplosiveBullet,
                        ProjectileID.BulletHighVelocity,
                        ProjectileID.ChlorophyteBullet,
                        ProjectileID.CrystalBullet,
                        ProjectileID.CursedBullet,
                        ProjectileID.GoldenBullet,
                        ProjectileID.IchorBullet,
                        ProjectileID.MoonlordBullet,
                        ProjectileID.NanoBullet,
                        ProjectileID.PartyBullet,
                        ProjectileID.VenomBullet,
                        ProjectileID.MeteorShot
        };

        public override void SetDefaults(Projectile projectile) {
            Player owner = Main.player[projectile.owner];
            if (projectile.ranged && projectile.friendly && !projectile.npcProj && projectile.owner == Main.myPlayer) {
                if (owner.GetModPlayer<EGGPlayer>().hasMuzzle) //Test for muzzle and ranged projectile
                {
                    //    projectile.width = 4;
                    //    projectile.height = 4;
                    //    projectile.aiStyle = -1;
                    //    projectile.tileCollide = true;
                    //    projectile.ignoreWater = true;
                    //    projectile.extraUpdates = 100;
                    //    projectile.timeLeft = 600;
                    //    projectile.hostile = false;
                }
            }
            base.SetDefaults(projectile);
        }

        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit) {
            if (projectile.ranged && projectile.friendly && projectile.owner == Main.myPlayer && !projectile.npcProj) {
                Player owner = Main.player[projectile.owner];
                EGGPlayer modPlayer = owner.GetModPlayer<EGGPlayer>();
                //Test for bullet types
                //(projectile.type == ProjectileID.Bullet) || (projectile.type == ProjectileID.BulletHighVelocity) || (projectile.type == ProjectileID.ChlorophyteBullet) || (projectile.type == ProjectileID.CrystalBullet) || (projectile.type == ProjectileID.CursedBullet) || (projectile.type == ProjectileID.ExplosiveBullet) || (projectile.type == ProjectileID.GoldenBullet) || (projectile.type == ProjectileID.IchorBullet) || (projectile.type == ProjectileID.MoonlordBullet) || (projectile.type == ProjectileID.NanoBullet) || (projectile.type == ProjectileID.PartyBullet) || (projectile.type == ProjectileID.VenomBullet))
                if (modPlayer.hasMuzzle) //Test for muzzle and ranged projectile
                {
                    if (bulletTypes.Contains(projectile.type)) {
                        target.AddBuff(BuffID.OnFire, 60 * 8);
                    }
                }
                if (modPlayer.hasMag) //Test for muzzle and ranged projectile
                {
                    target.AddBuff(BuffID.ShadowFlame, 60 * 12);
                }
            }
            base.OnHitNPC(projectile, target, damage, knockback, crit);
        }

        public override bool PreAI(Projectile projectile) {

            Player owner = Main.player[projectile.owner];
            EGGPlayer modPlayer = owner.GetModPlayer<EGGPlayer>();
            //if (modPlayer.hasMuzzle || modPlayer.hasMag) //Test for muzzle and ranged projectile
            //{
            //    //if (bulletTypes.Contains(projectile.type)) {
            //    //    projectile.extraUpdates = 600;
            //    //    projectile.alpha = 255;
            //    //    HitscanBeamAI(projectile);
            //    //}
            //}
            if (projectile.ranged && projectile.friendly && !projectile.npcProj && projectile.owner == Main.myPlayer) {
            }
            return base.PreAI(projectile);
        }

        public override void AI(Projectile projectile) {
            Player owner = Main.player[projectile.owner];
            EGGPlayer modPlayer = owner.GetModPlayer<EGGPlayer>();
            if (projectile.ranged && projectile.friendly && !projectile.npcProj/* && projectile.owner == Main.myPlayer*/) {
                //Vector2 cursor = (Main.MouseWorld - owner.Center).SafeNormalize(Vector2.UnitX);
                //Vector2 projVelocity = cursor * projectile.velocity.Length();
                //if (modPlayer.hasGrip && (projectile.timeLeft == 600)) //Test for grip and test that the bullet just spawned
                //{
                //    //float angle = projectile.velocity.ToRotation().AngleTowards(projVelocity.ToRotation(), 30);
                //    //if (projectile.velocity.ToRotation() > projVelocity.RotatedBy(Math.PI / 12).ToRotation())/*projectile velocity rotation is greater than threshold*/{
                //    //Vector2 perturbedSpeed = projVelocity.RotatedByRandom(MathHelper.ToRadians(1f));
                //    projectile.velocity.X = projVelocity.X;
                //    projectile.velocity.Y = projVelocity.Y;
                //    projectile.netUpdate = true;
                //    //}
                //}
                if (Main.myPlayer == projectile.owner) {
                    Vector2 cursor = (Main.MouseWorld - owner.Center).SafeNormalize(Vector2.UnitX);
                    Vector2 projVelocity = cursor * projectile.velocity.Length();
                    if (modPlayer.hasGrip && (projectile.timeLeft == 600)) //Test for grip and test that the bullet just spawned
                    {
                        //float angle = projectile.velocity.ToRotation().AngleTowards(projVelocity.ToRotation(), 30);
                        //if (projectile.velocity.ToRotation() > projVelocity.RotatedBy(Math.PI / 12).ToRotation())/*projectile velocity rotation is greater than threshold*/{
                        //Vector2 perturbedSpeed = projVelocity.RotatedByRandom(MathHelper.ToRadians(1f));
                        projectile.velocity.X = projVelocity.X;
                        projectile.velocity.Y = projVelocity.Y;
                        projectile.netUpdate = true;
                        //}
                    }
                }

                if (modPlayer.hasMuzzle || modPlayer.hasMag) //Test for muzzle and ranged projectile
                {
                    if (bulletTypes.Contains(projectile.type)) 
                    {
                        projectile.extraUpdates = 100;
                        projectile.alpha = 255;
                        HitscanBeamAI(projectile);
                        projectile.netUpdate = true;
                    }
                    if (modPlayer.hasMuzzle) {
                        Lighting.AddLight(projectile.position, 1f, 0.40f, 0f);
                        if (Main.rand.Next(2) == 0) {
                            Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire);
                        }
                        projectile.netUpdate = true;
                    }
                    if (modPlayer.hasMag) {
                        Lighting.AddLight(projectile.position, 1f, 0.40f, 0f);
                        if (Main.rand.Next(2) == 0) {
                            Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Shadowflame);
                        }
                        projectile.netUpdate = true;
                    }
                }
            }
            projectile.netUpdate = true;
            base.AI(projectile);
        }

        public void HitscanBeamAI(Projectile projectile) {
            Player owner = Main.player[projectile.owner];
            Color dustColor;
            switch (owner.team) {
                case 0:
                    dustColor = Color.Gray;
                    break;
                case 1:
                    dustColor = Color.Crimson;
                    break;
                case 2:
                    dustColor = Color.LawnGreen;
                    break;
                case 3:
                    dustColor = Color.Blue;
                    break;
                case 4:
                    dustColor = Color.Goldenrod;
                    break;
                case 5:
                    dustColor = Color.Magenta;
                    break;
                default:
                    dustColor = Color.White;
                    break;
            }
            //if (projectile.owner == Main.myPlayer) // Multiplayer support
            {
                projectile.localAI[0] += 1f;
                //float delayTime = (projectile.type == ProjectileID.ChlorophyteBullet) ? 25f : 4f;
                float delayTime = 4f;
                if (projectile.localAI[0] > delayTime) {
                    for (int i = 0; i < 4; i++) {
                        Vector2 projectilePosition = projectile.position;
                        projectilePosition -= projectile.velocity * ((float)i * 0.25f);
                        projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
                        projectile.spriteDirection = projectile.direction;
                        projectile.alpha = 255;
                        int trail = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y - projectile.height / 4), 1, 1, 76/*mod.DustType("BulletTrail")*/, 0f, 0f, 0, dustColor, 1f);
                        //NetMessage.SendData(ModNetHandler.bulletTrailType, -1, -1, null, projectile.identity, trail, i);
                        Main.dust[trail].position = projectilePosition;
                        //Main.dust[trail].scale = (float)Main.rand.Next(70, 110) * 0.013f;
                        Main.dust[trail].velocity *= 0.2f;
                        Main.dust[trail].noGravity = true;
                        projectile.netUpdate = true;
                    }
                    return;
                }
            }
        }

        public override void ModifyDamageHitbox(Projectile projectile, ref Rectangle hitbox) {
            Player owner = Main.player[projectile.owner];
            if (projectile.ranged && projectile.friendly && !projectile.npcProj && projectile.owner == Main.myPlayer) {
                if (owner.GetModPlayer<EGGPlayer>().hasMuzzle) //Test for muzzle and ranged projectile
                {
                    //hitbox.Inflate(5, 5);
                }
            }
            base.ModifyDamageHitbox(projectile, ref hitbox);
        }

    }
}