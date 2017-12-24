using System;
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
    public class EndlessExplodingBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Exploding Crate");
            Tooltip.SetDefault("*explodnbublz*"
                + "\n'I promise it's not the crate that explodes!'");
        }
        public override void SetDefaults()
        {
            item.damage = 10;
            item.ranged = true;
            item.width = 36;
            item.height = 32;
            item.maxStack = 1;
            item.knockBack = 6.6f;
            item.value = 76000;
            item.rare = 6;
            item.shoot = 286;
            item.shootSpeed = 4.7f;
            item.ammo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "BulletBox");
            recipe.AddIngredient(ItemID.ExplosivePowder, 85);
            recipe.AddIngredient(ItemID.SoulofNight, 18);
            recipe.AddIngredient(ItemID.SoulofSight, 18);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}