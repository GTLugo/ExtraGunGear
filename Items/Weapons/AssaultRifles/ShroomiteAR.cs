using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraGunGear.Items.Weapons.AssaultRifles //Such namescape
{
    public class ShroomiteAR : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Assault Rifle");
            Tooltip.SetDefault("Four round burst"
                + "\nOnly the first shot consumes ammo"
                + "\n'Delicious and potent!'");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(2.5f));
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
            item.damage = 36;
            item.crit = 6;
            item.ranged = true;
            item.width = 60;
            item.height = 20;
            item.useAnimation = 12;
            item.useTime = 3;
            item.reuseDelay = 14;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 1;
            item.value = 165000;
            item.rare = 8;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Item_31_4");
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
            recipe.AddIngredient(ItemID.ShroomiteBar, 35);
            recipe.AddIngredient(ItemID.SoulofMight, 15);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
