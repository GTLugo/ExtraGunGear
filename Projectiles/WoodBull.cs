using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Projectiles
{
    public class WoodBull : ModProjectile
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wooden Bullet");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()
		{
            projectile.CloneDefaults(ProjectileID.Bullet);
			projectile.ignoreWater = false;
            projectile.penetrate = 1;
            projectile.timeLeft = (60 * 10);
            projectile.friendly = true;
            projectile.hostile = false;
            aiType = ProjectileID.Bullet;
		}
        public override bool PreKill(int timeLeft)
        {
            projectile.type = ProjectileID.Bullet;
            return true;
        }
    }
}
