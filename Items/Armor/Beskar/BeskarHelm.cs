using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Armor.Beskar {
    [AutoloadEquip(EquipType.Head)]
    public class BeskarHelm : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Beskar Helmet");
            Tooltip.SetDefault("30% increased ranged damage" +
                "\n35% increased critical strike chance");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(1, 50, 0, 0);
            item.rare = 9;
            item.defense = 13;
        }

        public override void UpdateEquip(Player player) {
            player.rangedDamage += .3f;
            player.rangedCrit += 35;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair) {
            drawHair = false;
            drawAltHair = false;
            base.DrawHair(ref drawHair, ref drawAltHair);
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == mod.ItemType("BeskarBreast") && legs.type == mod.ItemType("BeskarLegs");
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = "15% increased movement speed";
            player.moveSpeed += 0.15f;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Leather, 2);
            recipe.AddIngredient(mod, "BeskarBar", 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}