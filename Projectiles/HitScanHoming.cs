using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ExtraGunGear.Projectiles {
    public class HitScanHoming : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Homing Hit-Scan Bullet");     //The English name of the projectile
        }

        public override void SetDefaults() {
            //projectile.CloneDefaults(ProjectileID.ShadowBeamFriendly);
            //aiType = ProjectileID.ShadowBeamFriendly;
            projectile.width = 4;
            projectile.height = 4;
            projectile.ranged = true;
            projectile.magic = false;
            projectile.penetrate = 1;
            projectile.aiStyle = -1;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.extraUpdates = 100;
            projectile.timeLeft = 600;
            projectile.friendly = true;
            projectile.hostile = false;
        }

        public override void AI() {
            projectile.localAI[0] += 1f;
            if (projectile.localAI[0] > 2f) {
                for (int i = 0; i < 4; i++) {
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
        }

        public override void ModifyDamageHitbox(ref Rectangle hitbox) {
            hitbox.Inflate(10, 10);
            base.ModifyDamageHitbox(ref hitbox);
        }

        public override bool OnTileCollide(Vector2 oldVelocity) {
            //If collide with tile, reduce the penetrate.
            //So the projectile can reflect at most 5 times
            projectile.penetrate--;
            if (projectile.penetrate <= 0) {
                projectile.Kill();
            }
            return false;
        }

        public override void Kill(int timeLeft) {
            // This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
            Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item10, projectile.position);
        }
    }
}
