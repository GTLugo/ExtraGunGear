using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Projectiles {
    public class PumpkinSickle : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Pumpkin Sickle");
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(ProjectileID.DeathSickle);
            aiType = ProjectileID.DeathSickle;
            projectile.timeLeft = 45;
            projectile.friendly = true;
            projectile.hostile = false;
        }

        public override bool OnTileCollide(Vector2 velocityChange) {
            projectile.Kill();
            return true;
        }
        public override bool PreKill(int timeLeft) {
            projectile.type = ProjectileID.DeathSickle;
            return true;
        }

        public override void AI() {
            Player owner = Main.player[projectile.owner];
            projectile.alpha = 0;
        }
    }
}