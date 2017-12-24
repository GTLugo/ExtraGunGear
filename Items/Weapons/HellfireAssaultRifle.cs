using System;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ExtraGunGear.Items.Weapons //Such namescape
{
    public class HellfireAssaultRifle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellfire Assault Rifle");
            Tooltip.SetDefault("Three round burst"
                + "\nOnly the first shot consumes ammo"
                + "\n'Die die die!'");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(2));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            return true;
        }
        /*public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            base.ModifyTooltips(tooltips);
            float flavorChance = MathHelper.Lerp(0f, 10f, (float)Main.rand.NextDouble());
            if (flavorChance > 5f)
            {
                TooltipLine line = new TooltipLine(mod, "Hellfire Assault Rifle", "Die die die");
                tooltips.Add(line);
            }
            else
            {
                TooltipLine line = new TooltipLine(mod, "Hellfire Assault Rifle", "You made a tactical error");
                tooltips.Add(line);
            }
        }*/
        public override bool ConsumeAmmo(Player player)
        {
            return !(player.itemAnimation < item.useAnimation - 2);
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }

        public override void SetDefaults()
		{
			item.damage = 15;
			item.ranged = true;
			item.width = 56;
			item.height = 18;
			item.useAnimation = 11;
			item.useTime = 4;
			item.reuseDelay = 22;
			item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 0;
			item.value = 150000;
			item.rare = 3;
			item.UseSound = SoundID.Item31;
			item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 8f;
            item.useAmmo = AmmoID.Bullet;
        }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 25);
            recipe.AddIngredient(ItemID.Handgun, 1);
            recipe.AddIngredient(ItemID.Boomstick, 1);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
