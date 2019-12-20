using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Projectiles {
    public class StoneBullet : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Stone Bullet");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            EGGGlobalProjectile.bulletTypes.Add(projectile.type);
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(ProjectileID.Bullet);
            projectile.ignoreWater = false;
            projectile.penetrate = 1;
            projectile.timeLeft = (60 * 10);
            projectile.friendly = true;
            projectile.hostile = false;
            aiType = ProjectileID.Bullet;
        }
        public override bool PreKill(int timeLeft) {
            projectile.type = ProjectileID.Bullet;
            return true;
        }
    }
}
