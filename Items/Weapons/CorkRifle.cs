using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Weapons //Such namescape
{
    public class CorkRifle : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Cork Rifle");
            Tooltip.SetDefault("Shoots a cork out at your enemies");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(2.5f));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("Cork"), item.damage, item.knockBack, player.whoAmI);
            return false;
        }

        public override Vector2? HoldoutOffset() {
            return new Vector2(-7, 2);
        }
        public override void SetDefaults() {
            item.damage = 4;
            item.crit = 6;
            item.ranged = true;
            item.width = 60;
            item.height = 20;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 0;
            item.value = 5000;
            item.rare = 0;
            item.UseSound = SoundID.Item11;
            item.autoReuse = false;
            item.shoot = 10;
            item.shootSpeed = 8f;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 12);
            recipe.anyWood = true;
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
