using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Weapons.SMGs //Such namescape
{
    public class MythrilSMG : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Mythril Auto-Pistol");
            Tooltip.SetDefault("50% chance not to consume ammo");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(2f));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            return true;
        }

        public override bool ConsumeAmmo(Player player) {
            return Main.rand.NextFloat() >= .5f;
        }

        public override Vector2? HoldoutOffset() {
            return new Vector2(0, 8);
        }

        public override void SetDefaults() {
            item.damage = 14;
            item.crit = 6;
            item.ranged = true;
            item.width = 42;
            item.height = 34;
            item.useAnimation = 5;
            item.useTime = 5;
            item.reuseDelay = 0;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = 165000;
            item.rare = 4;
            item.UseSound = SoundID.Item40;//mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Item_31_4");
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 12f;
            item.scale = 0.65f;
            item.useAmmo = AmmoID.Bullet;
        }


        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            //recipe.AddIngredient(mod, "ChloroAR");
            recipe.AddIngredient(ItemID.MythrilBar, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
