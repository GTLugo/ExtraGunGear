using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Projectiles {
    public class SunGodFlames : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Sun God Flames");
            //ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            //ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(ProjectileID.Flames);
            projectile.ignoreWater = false;
            projectile.penetrate = 3;
            projectile.timeLeft = (60 * 10);
            projectile.friendly = false;
            projectile.hostile = true;
        }

        public override void OnHitPlayer(Player player, int damage, bool crit) {
            if (Main.expertMode) {
                player.AddBuff(BuffID.OnFire, 100, true);
            }
        }

        public override bool PreKill(int timeLeft) {
            projectile.type = ProjectileID.Flames;
            return true;
        }
    }
}
