using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Weapons.Snipers //Such namescape
{
    public class GoldenSR : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Golden Sniper Rifle");
            Tooltip.SetDefault("Shoots a powerful, high velocity bullet"
                + "\n'A reward for competitiveness'");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            if (type == ProjectileID.Bullet)   // converts bullet to high velocity
            {
                type = ProjectileID.BulletHighVelocity;
            }
            return true;
        }

        public override Vector2? HoldoutOffset() {
            return new Vector2(-7, 0);
        }

        public override void SetDefaults() {
            //item.CloneDefaults(ItemID.SniperRifle);
            item.damage = 60;
            item.crit = 29;
            item.ranged = true;
            item.width = 60;
            item.height = 20;
            item.useAnimation = 36;
            item.useTime = 36;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 8;
            item.value = 165000;
            item.rare = 3;
            item.UseSound = SoundID.Item40;
            item.autoReuse = false;
            item.shoot = 10;
            item.shootSpeed = 16f;
            item.useAmmo = AmmoID.Bullet;
        }

        /*
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                player.scope = true;
                return false;
            }
            else
            {
                
            }
            return base.CanUseItem(player);
        }
        */

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("ExtraGunGear:GoldBar", 25);
            recipe.AddIngredient(ItemID.Musket, 1);
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddIngredient(ItemID.GoldenKey, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
