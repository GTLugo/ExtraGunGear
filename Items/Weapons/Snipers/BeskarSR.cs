using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Weapons.Snipers //Such namescape
{
    public class BeskarSR : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Beskar Disruptor");
            Tooltip.SetDefault("Shoots an explosive bullet"
                + "\n'This is the way'");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            if (type == ProjectileID.Bullet)   // converts bullet to high velocity
            {
                type = ProjectileID.ExplosiveBullet;
                //type = ProjectileID.BulletHighVelocity;
            }
            if (type == ProjectileID.ExplosiveBullet) {
            }
            return true;
        }

        public override Vector2? HoldoutOffset() {
            return new Vector2(-7, 0);
        }

        public override void SetDefaults() {
            //item.CloneDefaults(ItemID.SniperRifle);
            item.damage = 205;
            item.crit = 29;
            item.ranged = true;
            item.width = 60;
            item.height = 20;
            item.useAnimation = 28;
            item.useTime = 28;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 8;
            item.value = Item.sellPrice(0, 85, 0, 0);
            item.rare = 9;
            item.UseSound = SoundID.Item40;
            item.autoReuse = false;
            item.shoot = 10;
            item.shootSpeed = 16f;
            item.useAmmo = AmmoID.Bullet;
        }

        public override bool ReforgePrice(ref int reforgePrice, ref bool canApplyDiscount) {
            reforgePrice /= 2;
            return base.ReforgePrice(ref reforgePrice, ref canApplyDiscount);
        }

        //public override bool AltFunctionUse(Player player)
        //{
        //    return true;
        //}

        //public override bool CanUseItem(Player player)
        //{
        //    if (player.altFunctionUse == 2) {
        //        //item.ranged = false;
        //        player.scope = true;

        //        return false;
        //        //item.useAnimation = 999;
        //        //item.useTime = 999;
        //    }
        //    else {
        //        //item.ranged = true;
        //        //item.useAnimation = 28;
        //        //item.useTime = 28;
        //    }
        //    return base.CanUseItem(player);
        //}


        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "BeskarBar", 25);
            recipe.AddRecipeGroup("Wood", 12);
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
