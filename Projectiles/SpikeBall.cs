using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Projectiles {
    public class SpikeBall : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Spike Ball");
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(ProjectileID.RocketI);
            aiType = ProjectileID.RocketI;
            projectile.penetrate = 1;
            projectile.timeLeft = 30;
            projectile.friendly = true;
            projectile.hostile = false;
        }

        public override bool OnTileCollide(Vector2 velocityChange) {
            projectile.Kill();
            return true;
        }

        public override bool PreKill(int timeLeft) {
            projectile.type = ProjectileID.RocketI;
            return true;
        }

        public override void AI() {
            Player owner = Main.player[projectile.owner]; //Makes a player variable of owner set as the player using the projectile
            projectile.alpha = 0; //Semi Transparent
        }
        /*public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            damage = 30;
            target.AddBuff(BuffID.CursedInferno, 300);
        }*/
    }
}