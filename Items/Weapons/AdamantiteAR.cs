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
    public class AdamantiteAR : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Big Ben");
            Tooltip.SetDefault("Four round burst"
                + "\nOnly the first shot consumes ammo");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(1.5f));
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
            item.crit = 2;
            item.ranged = true;
			item.width = 60;
			item.height = 24;
			item.useAnimation = 11;
			item.useTime = 3;
			item.reuseDelay = 15;
			item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 1;
			item.value = 165000;
			item.rare = 5;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Item_31_4");
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 10f;
            item.useAmmo = AmmoID.Bullet;
        }


        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ClockworkAssaultRifle);
            recipe.AddIngredient(ItemID.AdamantiteBar, 20);
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddIngredient(ItemID.SoulofMight, 22);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ClockworkAssaultRifle);
            recipe.AddIngredient(ItemID.TitaniumBar, 20);
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddIngredient(ItemID.SoulofMight, 22);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
