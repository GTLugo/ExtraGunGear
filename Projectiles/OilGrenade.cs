using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Projectiles {
    public class OilGrenade : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Oil Grenade");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            //EGGGlobalProjectile.bulletTypes.Add(projectile.type);
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(ProjectileID.ToxicFlask);
            projectile.width = 15;
            projectile.height = 15;
            projectile.penetrate = 1;
            projectile.timeLeft = (60 * 3);
            projectile.friendly = true;
			projectile.tileCollide = true;
            projectile.hostile = false;
            aiType = ProjectileID.Grenade;
		}

		//     public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) {
		//         // Vanilla explosions do less damage to Eater of Worlds in expert mode, so we will too.
		//         if (Main.expertMode) {
		//             if (target.type >= NPCID.EaterofWorldsHead && target.type <= NPCID.EaterofWorldsTail) {
		//                 damage /= 5;
		//             }
		//         }
		//     }

		public override bool OnTileCollide(Vector2 oldVelocity) {
			// Die immediately if ai[1] isn't 0 (We set this to 1 for the 5 extra explosives we spawn in Kill)
			//if (projectile.ai[1] != 0) {
			//             return true;
			//         }
			// OnTileCollide can trigger quite quickly, so using soundDelay helps prevent the sound from overlapping too much.
			if (projectile.soundDelay == 0) {
				// We use WithVolume since the sound is a bit too loud, and WithPitchVariance to give the sound some random pitch variance.

			}
			projectile.soundDelay = 10;
			return true;
		}

		public override void AI() {
			if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3) {
				projectile.tileCollide = false;
				// Set to transparent. This projectile technically lives as  transparent for about 3 frames
				projectile.alpha = 255;
				// change the hitbox size, centered about the original projectile center. This makes the projectile damage enemies during the explosion.
				projectile.position = projectile.Center;
				//projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
				//projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
				projectile.width = 250;
				projectile.height = 250;
				projectile.Center = projectile.position;
				//projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
				//projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
				projectile.damage = 120;
				projectile.knockBack = 10f;
			}
			else {
				// Smoke and fuse dust spawn.
				if (Main.rand.NextBool()) {
					int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1f);
					Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
					Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
					Main.dust[dustIndex].noGravity = true;
					Main.dust[dustIndex].position = projectile.Center + new Vector2(0f, (float)(-(float)projectile.height / 2)).RotatedBy((double)projectile.rotation, default(Vector2)) * 1.1f;
					dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1f);
					Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
					Main.dust[dustIndex].noGravity = true;
					Main.dust[dustIndex].position = projectile.Center + new Vector2(0f, (float)(-(float)projectile.height / 2 - 6)).RotatedBy((double)projectile.rotation, default(Vector2)) * 1.1f;
				}
			}
			//projectile.ai[0] += 1f;
			//if (projectile.ai[0] > 5f) {
			//	projectile.ai[0] = 10f;
			//	// Roll speed dampening.
			//	if (projectile.velocity.Y == 0f && projectile.velocity.X != 0f) {
			//		projectile.velocity.X = projectile.velocity.X * 0.97f;
			//		//if (projectile.type == 29 || projectile.type == 470 || projectile.type == 637)
			//		{
			//			projectile.velocity.X = projectile.velocity.X * 0.99f;
			//		}
			//		if ((double)projectile.velocity.X > -0.01 && (double)projectile.velocity.X < 0.01) {
			//			projectile.velocity.X = 0f;
			//			projectile.netUpdate = true;
			//		}
			//	}
			//	projectile.velocity.Y = projectile.velocity.Y + 0.2f;
			//}
			//// Rotation increased by velocity.X 
			//projectile.rotation += projectile.velocity.X * 0.1f;
			return;
		}

		public override void Kill(int timeLeft) {
			// If we are the original projectile, spawn the 5 child projectiles
			//if (projectile.ai[1] == 0) {
			//	for (int i = 0; i < 3; i++) {
			//		// Random upward vector.
			//		Vector2 vel = new Vector2(Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-10, -8));
			//		Projectile.NewProjectile(projectile.Center, vel, projectile.type, projectile.damage, projectile.knockBack, projectile.owner, 0, 1);
			//	}
			//}
			// Play explosion sound
			Main.PlaySound(SoundID.Shatter, projectile.position);
			// Smoke Dust spawn
			for (int i = 0; i < 50; i++) {
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
			// Fire Dust spawn
			for (int i = 0; i < 80; i++) {
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 3f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 5f;
				//dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2f);
				//Main.dust[dustIndex].velocity *= 3f;
			}
			//// Large Smoke Gore spawn
			//for (int g = 0; g < 2; g++) {
			//	int goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
			//	Main.gore[goreIndex].scale = 1.5f;
			//	Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
			//	Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;
			//	goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
			//	Main.gore[goreIndex].scale = 1.5f;
			//	Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;
			//	Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;
			//	goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
			//	Main.gore[goreIndex].scale = 1.5f;
			//	Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
			//	Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;
			//	goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
			//	Main.gore[goreIndex].scale = 1.5f;
			//	Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;
			//	Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;
			//}
			//// reset size to normal width and height.
			//projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
			//projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
			//projectile.width = 10;
			//projectile.height = 10;
			//projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
			//projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
		}

		//public override bool PreKill(int timeLeft) {
		//          projectile.type = ProjectileID.Bullet;
		//          return true;
		//      }

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            target.AddBuff(BuffID.Oiled, 60 * 8);
		}
    }
}
