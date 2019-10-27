using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ExtraGunGear.Items.Weapons.Revolvers //Such namescape
{
	public class GoldenGun : ModItem
    {
        //public static short glowMask;
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golden Gun");
			Tooltip.SetDefault("Right click to fire a 6-shot burst"
                + "\nSets musket balls ablaze"
                + "\n'The enemy can't kill if they're dead!'");
            //if (Main.netMode != NetmodeID.Server)
            //    glowMask = GlowMaskAPI.Tools.instance.AddGlowMask(mod.GetTexture("Items/Weapons/Revolvers/GoldenGun_Glow"));
        }

        public override void SetDefaults() {
            item.damage = 100;
            item.ranged = true;
            item.width = 60;
            item.height = 26;
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
            //item.glowMask = glowMask;
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
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            scale *= (2f / 3f);
            Texture2D baseTexture = mod.GetTexture("Items/Weapons/Revolvers/GoldenGun");
            Texture2D glowTexture = mod.GetTexture("Items/Weapons/Revolvers/GoldenGun_Glow");
            spriteBatch.Draw
            (
                baseTexture,
                new Vector2
                (
                    item.position.X - Main.screenPosition.X + item.width * 0.5f,
                    item.position.Y - Main.screenPosition.Y + item.height * 0.6f
                ),
                new Rectangle(0, 0, baseTexture.Width, baseTexture.Height),
                lightColor,
                rotation,
                baseTexture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );
            spriteBatch.Draw
            (
                glowTexture,
                new Vector2
                (
                    item.position.X - Main.screenPosition.X + item.width * 0.5f,
                    item.position.Y - Main.screenPosition.Y + item.height * 0.6f
                ),
                new Rectangle(0, 0, glowTexture.Width, glowTexture.Height),
                Color.White,
                rotation,
                glowTexture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );
            return false;
        }
    }
}
