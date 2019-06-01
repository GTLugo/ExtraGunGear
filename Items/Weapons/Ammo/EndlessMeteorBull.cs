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
    public class EndlessMeteorBull : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Meteor Pouch");
            Tooltip.SetDefault("'NASA would kill for one of these'");
        }

        public override void SetDefaults()
        {
            item.damage = 9;
            item.ranged = true;
            item.width = 26;
            item.height = 26;
            item.maxStack = 1;
            item.knockBack = 1f;
            item.value = 76000;
            item.rare = 6;
            item.shoot = 36;
            item.shootSpeed = 3f;
            item.ammo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "BulletPouch");
            recipe.AddIngredient(ItemID.MeteoriteBar, 60);
            recipe.AddIngredient(ItemID.SoulofLight, 6);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}