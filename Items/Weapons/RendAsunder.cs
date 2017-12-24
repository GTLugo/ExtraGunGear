using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ExtraGunGear.Items.Weapons //Such namescape
{
	public class RendAsunder : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rend Asunder");
			Tooltip.SetDefault("Two shot burst"
                + "\nOnly the first shot consumes ammo"
                + "\n'An assassin's right-hand man'");
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
			item.damage = 8;
			item.ranged = true;
			item.width = 56;
			item.height = 26;
			item.useAnimation = 9;
			item.useTime = 5;
			item.reuseDelay = 15;
			item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 1;
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
            recipe.AddIngredient(ItemID.TheUndertaker, 1);
            recipe.AddIngredient(ItemID.CrimtaneBar, 20);
            recipe.AddIngredient(ItemID.TissueSample, 30);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
