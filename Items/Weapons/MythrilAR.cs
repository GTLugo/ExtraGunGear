using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraGunGear.Items.Weapons //Such namescape
{
    public class MythrilAR : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Grandfather Assault Rifle");
            Tooltip.SetDefault("Three round burst"
                + "\nOnly the first shot consumes ammo");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(2));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            return true;
        }
        public override bool ConsumeAmmo(Player player)
        {
            return !(player.itemAnimation < item.useAnimation - 2);
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-7, 0);
        }
        public override void SetDefaults()
		{
			item.damage = 23;
            item.crit = 1;
            item.ranged = true;
			item.width = 64;
			item.height = 22;
			item.useAnimation = 11;
			item.useTime = 4;
			item.reuseDelay = 15;
			item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 1;
			item.value = 165000;
			item.rare = 4;
			item.UseSound = SoundID.Item31;
			item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 9f;
            item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "CobaltAR");
            recipe.AddIngredient(ItemID.MythrilBar, 18);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "CobaltAR");
            recipe.AddIngredient(ItemID.OrichalcumBar, 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
