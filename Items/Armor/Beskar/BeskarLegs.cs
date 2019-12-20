using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Armor.Beskar {
    [AutoloadEquip(EquipType.Legs)]
    public class BeskarLegs : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Beskar Leggings");
            Tooltip.SetDefault("20% increased ranged damage" +
                "\n15% increased movement speed");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(1, 25, 0, 0);
            item.rare = 9;
            item.defense = 18;
        }

        public override void UpdateEquip(Player player) {
            player.rangedDamage += .2f;
            player.moveSpeed += .15f;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Leather, 2);
            recipe.AddIngredient(mod, "BeskarBar", 16);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}