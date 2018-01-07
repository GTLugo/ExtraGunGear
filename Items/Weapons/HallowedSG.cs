
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Weapons
{
    class HallowedSG : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hallowed Spreader");
            Tooltip.SetDefault("Shoots a ricocheting, crystal bullet"
                + "\n'What you use when you want bullets on toast'");
        }

        public override void SetDefaults()
        {
            item.damage = 26;
            item.ranged = true;
            item.width = 62;
            item.height = 24;
            item.useTime = 40;
            item.useAnimation = 40;
            //item.reuseDelay = 30;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 6f;
            item.value = 10000;
            item.rare = 5;
            item.UseSound = SoundID.Item36;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 7f;
            item.useAmmo = AmmoID.Bullet;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-3, 2);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.Bullet)
            {
                type = ProjectileID.CrystalBullet;
            }
            int numberProjectiles = 5 + Main.rand.Next(2);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false; // return false because we don't want tmodloader to shoot projectile
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 18);
            recipe.AddIngredient(ItemID.IllegalGunParts);
            recipe.AddIngredient(ItemID.SoulofFright, 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
