using System;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraGunGear.Items.Weapons.Ammo //Such namescape
{
    public class EndlessPartyBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Party Crate");
            Tooltip.SetDefault("'It's a party in a box!'");
        }
        public override void SetDefaults()
        {
            item.damage = 10;
            item.ranged = true;
            item.width = 36;
            item.height = 32;
            item.maxStack = 1;
            item.knockBack = 5f;
            item.value = 76000;
            item.rare = 6;
            item.shoot = 284;
            item.shootSpeed = 5.1f;
            item.ammo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "BulletBox");
            recipe.AddIngredient(ItemID.Confetti, 85);
            recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}