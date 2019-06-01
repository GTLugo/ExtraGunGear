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
	public class Cork : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cork");     //The English name of the projectile
		}

		public override void SetDefaults()
		{
            projectile.CloneDefaults(ProjectileID.BoneArrow);
            aiType = ProjectileID.Bullet;
            projectile.penetrate = 1;
            projectile.timeLeft = (60 * 10);
            projectile.friendly = true;
            projectile.hostile = false;
        }
        public override void AI()
        {

        }

        public override bool PreKill(int timeLeft)
        {
            projectile.type = ProjectileID.Bullet;
            return true;
        }
    }
}
