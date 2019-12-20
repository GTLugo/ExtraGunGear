using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Armor.Outlaw {
    [AutoloadEquip(EquipType.Body)]
    public class OutlawJacket : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            Tooltip.SetDefault("5% increased damage resistance");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = 10000;
            item.rare = 2;
            item.defense = 5;
        }

        public override void UpdateEquip(Player player) {
            player.endurance += .05f;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Leather, 3);
            recipe.AddIngredient(ItemID.MeteoriteBar, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}