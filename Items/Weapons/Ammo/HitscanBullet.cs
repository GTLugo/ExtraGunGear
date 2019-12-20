using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Weapons.Ammo {
    class HitscanBullet : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Hitscan Bullet");
            Tooltip.SetDefault("'You shouldn't have this item...'");
        }

        public override void SetDefaults() {
            item.damage = 4;
            item.ranged = true;
            item.width = 8;
            item.height = 8;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 1.5f;
            item.value = 1;
            item.rare = -1;
            item.shoot = mod.ProjectileType("HitScan");
            //item.shootSpeed = 8f;
            item.ammo = AmmoID.Bullet;
        }
    }
}
