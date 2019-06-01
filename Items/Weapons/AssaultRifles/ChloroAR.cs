using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace ExtraGunGear.Items.Weapons.AssaultRifles //Such namescape
{
    public class ChloroAR : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pitcher's Pitfall");
            Tooltip.SetDefault("Four round burst"
                + "\nOnly the first shot consumes ammo"
                + "\nOccassionally fires an additional explosive flower"
                + "\nShoots a powerful, high velocity bullet");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.Bullet)   // converts bullet to high velocity
            {
                type = ProjectileID.BulletHighVelocity;
            }
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(1f));  
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            if (!(player.itemAnimation < item.useAnimation - 2))
            {
                Random rnd = new Random();
                int rocketChance = rnd.Next(0, 3);
                if (rocketChance < 1)
                {
                    int numberProjectiles = 1; //Fires extra projectile
                    for (int i = 1; i == numberProjectiles; i++)
                    {
                        Vector2 perturbedSpeed2 = new Vector2(speedX * 2f, speedY * 2f).RotatedByRandom(MathHelper.ToRadians(5f));
                        speedX = perturbedSpeed2.X;
                        speedY = perturbedSpeed2.Y;
                        Vector2 perturbedSpeed3 = new Vector2(speedX, speedY);
                        Projectile.NewProjectile(position.X, position.Y, perturbedSpeed3.X, perturbedSpeed3.Y, mod.ProjectileType("SpikeBall"), 20, 5, player.whoAmI);
                    }
                }
            }
            return true;
        }

        public override bool ConsumeAmmo(Player player)
        {
            return !(player.itemAnimation < item.useAnimation - 2);
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-9, 0);
        }
        public override void SetDefaults()
		{
			item.damage = 23;
			item.ranged = true;
			item.width = 66;
			item.height = 28;
            item.useAnimation = 12;
            item.useTime = 3;
            item.reuseDelay = 14;
			item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 1;
			item.value = 165000;
			item.rare = 8;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Item_31_4");
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 13f;
            item.useAmmo = AmmoID.Bullet;
        }
	}
}
