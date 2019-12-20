using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Weapons.AssaultRifles //Such namescape
{
    public class HellfireAssaultRifle : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Hellfire Assault Rifle");
            Tooltip.SetDefault("Three round burst"
                + "\nOnly the first shot consumes ammo"
                + "\n'Die die die!'");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(1));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            return true;
        }

        public override bool ConsumeAmmo(Player player) {
            return !(player.itemAnimation < item.useAnimation - 2);
        }
        public override Vector2? HoldoutOffset() {
            return new Vector2(-10, 0);
        }

        public override void SetDefaults() {
            item.damage = 15;
            item.ranged = true;
            item.width = 56;
            item.height = 18;
            item.useAnimation = 12;
            item.useTime = 4;
            item.reuseDelay = 14;
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

        //TerrariaOverhaul Compatibility
        public int shotsAmount = 3;
        public int shotsLeft;

        public void OverhaulInit() {
            //TerrariaOverhaul.Weapon
            /*if (ExtraGunGear.overhaulLoaded != null)
            {
                if (OverhaulStuff)
                {

                }
            }*/
        }

        /*public bool OverhaulStuff
        {
            get { return TerrariaOverhaul.Weapon.Update(); }
        }

        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            if (ExtraGunGear.overhaulLoaded != null)
            {
                if (OverhaulStuff)
                {

                }
            }
            base.Update(ref gravity, ref maxFallSpeed);
        }*/

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 30);
            recipe.AddIngredient(ItemID.HellstoneBar, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
