using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;


namespace ExtraGunGear.Projectiles
{
	public class FireBullet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Incendiary Bullet");     //The English name of the projectile
		}

		public override void SetDefaults()
		{
            projectile.CloneDefaults(ProjectileID.Bullet);
            aiType = ProjectileID.Bullet;
            projectile.penetrate = 1;
            projectile.timeLeft = (60 * 10);
            projectile.friendly = true;
            projectile.hostile = false;
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.position, 1f, 0.40f, 0f);
            if (projectile.owner == Main.myPlayer && Main.rand.Next(2) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire);
            }
        }

        public override bool PreKill(int timeLeft)
        {
            projectile.type = ProjectileID.Bullet;
            return true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 60 * 8);
        }
    }
}
