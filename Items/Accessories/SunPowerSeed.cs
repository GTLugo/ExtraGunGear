
using Terraria;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Accessories {
    public class SunPowerSeed : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Sunpower Seed");
            Tooltip.SetDefault("Increases potency of healing potions"
            //+ "\nDecreases ranged damage by 10%"
            );
        }

        public override void SetDefaults() {
            item.width = 28;
            item.height = 28;
            item.value = 75000;
            item.rare = 8;
            //item.expert = true;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            //player.rangedDamage -= 0.10f;
            base.UpdateAccessory(player, hideVisual);
            player.GetModPlayer<EGGPlayer>().hasSeed = true;
        }
    }
}