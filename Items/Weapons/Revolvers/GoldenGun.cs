using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ExtraGunGear.Items.Weapons.Revolvers //Such namescape
{
	public class GoldenGun : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golden Gun");
			Tooltip.SetDefault("Right click to fire a 6-shot burst"
                + "\nSets musket balls ablaze"
                + "\n'The enemy can't kill if they're dead!'");
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.Bullet)
            {
                type = mod.ProjectileType("FireBullet");
            }
            if (player.altFunctionUse == 2)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
                speedX = perturbedSpeed.X;
                speedY = perturbedSpeed.Y;
                knockBack = item.knockBack * 2;
                return true;
            }
            else
            {
                return true;
            }
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-7, 2);
        }
        public override void SetDefaults()
		{
            item.damage = 100;
            item.ranged = true;
            item.width = 80;
            item.height = 36;
            item.useAnimation = 15;
            item.useTime = 15;
            item.reuseDelay = 0;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 3f;
            item.value = 50000;
            item.rare = 10;
            item.UseSound = mod.GetLegacySoundSlot(Terraria.ModLoader.SoundType.Item, "Sounds/Item/McCree Gunshot (no reverb)");
            item.autoReuse = false;
            item.shoot = 10;
            item.shootSpeed = 9f;
            item.scale = 0.65f;
            item.useAmmo = AmmoID.Bullet;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.useAnimation = 36;
                item.useTime = 6;
                item.reuseDelay = 90;
                item.useStyle = 5;
                item.UseSound = mod.GetLegacySoundSlot(Terraria.ModLoader.SoundType.Item, "Sounds/Item/McCree Gunshot 6-shot");
                item.shoot = 10;
                item.autoReuse = false;
            }
            else
            {
                item.useAnimation = 15;
                item.useTime = 15;
                item.reuseDelay = 0;
                item.useStyle = 5;
                item.UseSound = mod.GetLegacySoundSlot(Terraria.ModLoader.SoundType.Item, "Sounds/Item/McCree Gunshot (no reverb)");
                item.shoot = 10;
                item.autoReuse = false;
            }
            return base.CanUseItem(player);
        }


	}
}
