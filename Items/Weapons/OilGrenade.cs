using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Weapons {
    class OilGrenade : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Oil Grenade [WIP]");
        }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 120;
            item.crit = 9;
            item.width = 14;
            item.height = 20;
            item.useStyle = 1;
            item.shootSpeed = 10f;
            item.shoot = mod.ProjectileType("OilGrenade");
            item.maxStack = 30;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.thrown = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.consumable = true;
        }
    }
}
