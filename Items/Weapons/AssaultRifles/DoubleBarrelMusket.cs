using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ExtraGunGear.Items.Weapons.AssaultRifles //Such namescape
{
	public class DoubleBarrelMusket : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Double Barrel Musket");
			Tooltip.SetDefault("Two shot burst"
                + "\nOnly the first shot consumes ammo"
                + "\n'Almost twice the firepower...'");
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(1)); //Random spread
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
			item.damage = 8;
			item.ranged = true;
			item.width = 56;
			item.height = 18;
            item.useAnimation = 12;
            item.useTime = 6;
            item.reuseDelay = 14;
			item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 7;
			item.value = 50000;
			item.rare = 2;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Item_31_2");
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 9f;
            item.useAmmo = AmmoID.Bullet;
        }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Musket, 1);
            recipe.AddIngredient(ItemID.DemoniteBar, 20);
            recipe.AddIngredient(ItemID.ShadowScale, 12);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
