using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace ExtraGunGear.Items.Weapons.SMGs //Such namescape
{
    public class SilverSMG : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silver SMG");
            Tooltip.SetDefault("33% chance not to consume ammo");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5f));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            return true;
        }

        public override bool ConsumeAmmo(Player player)
        {
            Random rnd = new Random();
            double saveChance = rnd.NextDouble();
            return !(saveChance < 0.33);
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 3);
        }

        public override void SetDefaults()
        {
            item.damage = 3;
            item.crit = 4;
            item.ranged = true;
            item.width = 76;
            item.height = 32;
            item.useAnimation = 10;
            item.useTime = 10;
            item.reuseDelay = 0;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 1.75f;
            item.value = 15000;
            item.rare = 8;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 12f;
            item.scale = 0.85f;
            item.useAmmo = AmmoID.Bullet;
        }


        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            //recipe.AddIngredient(mod, "ChloroAR");
            recipe.AddIngredient(ItemID.SilverBar, 8);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
