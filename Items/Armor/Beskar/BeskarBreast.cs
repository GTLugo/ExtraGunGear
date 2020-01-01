using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Armor.Beskar {
    [AutoloadEquip(EquipType.Body)]
    public class BeskarBreast : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Beskar Breastplate");
            Tooltip.SetDefault("10% increased damage resistance" +
                "\n20% chance not to consume ammo");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(1, 75, 0, 0);
            item.rare = 9;
            item.defense = 27;
        }

        public override void UpdateEquip(Player player) {
            EGGPlayer modPlayer = player.GetModPlayer<EGGPlayer>();
            player.endurance += .1f;
            modPlayer.hasBeskarBreast = true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Leather, 3);
            recipe.AddIngredient(mod, "BeskarBar", 22);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}