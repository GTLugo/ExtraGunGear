
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Accessories {
    public class MythicalSeed : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Mythical Seed");
            Tooltip.SetDefault("Provides life regeneration" +
                "\nDramatically reduces the cooldown and slightly increases potency of healing potions"
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
            item.lifeRegen = 1;
            player.pStone = true;
            player.GetModPlayer<EGGPlayer>().hasMSeed = true;
            base.UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CharmofMyths);
            recipe.AddIngredient(mod, "SunPowerSeed");
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}