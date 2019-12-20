
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Accessories {
    public class EnchantedMag : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Magic Magazine");
            Tooltip.SetDefault("12% increased ranged damage and critical strike chance"
            + "\nIncreased ranged accuracy"
            + "\n30% chance not to consume ammo"
            + "\nAccelerates bullets to the speed of light"
            + "\nRanged attacks inflict Shadowflame");
        }
        public override void SetDefaults() {
            item.width = 26;
            item.height = 22;
            item.value = Item.sellPrice(0, 42, 25, 0);
            item.rare = 9;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            EGGPlayer modPlayer = player.GetModPlayer<EGGPlayer>();
            
            player.rangedDamage += 0.12f;
            player.rangedCrit += 12;
            //modPlayer.hasMuzzle = true; //Not required anymore
            modPlayer.hasGrip = true;
            modPlayer.hasMag = true;
            base.UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DestroyerEmblem, 1);
            recipe.AddIngredient(mod, "AccessoryKit");
            recipe.AddIngredient(ItemID.ShadowFlameHexDoll);
            recipe.AddIngredient(mod, "BeskarBar", 4);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}