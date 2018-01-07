
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Weapons
{
    class WoodSG : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pipe Shotgun");
            Tooltip.SetDefault("Fires a spread of bullets" 
                + "\n'For those who are wanderers'");
        }

        public override void SetDefaults()
        {
            item.damage = 11;
            item.ranged = true;
            item.width = 42;
            item.height = 18;
            item.useTime = 45;
            item.useAnimation = 45;
            //item.reuseDelay = 30;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 6f;
            item.value = 10000;
            item.rare = 0;
            item.UseSound = SoundID.Item36;
            //item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 7f;
            item.useAmmo = AmmoID.Bullet;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 2 + Main.rand.Next(2);
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
            recipe.AddIngredient(ItemID.CopperBar, 15);
            recipe.AddIngredient(ItemID.Wood, 25);
            recipe.anyWood = true;
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TinBar, 15);
            recipe.AddIngredient(ItemID.Wood, 25);
            recipe.anyWood = true;
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
