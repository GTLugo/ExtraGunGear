using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Armor.Outlaw {
    [AutoloadEquip(EquipType.Head)]
    public class OutlawHat : ModItem {
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("5% increased ranged damage");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = 10000;
            item.rare = 2;
            item.defense = 4;
        }

        public override void UpdateEquip(Player player) {
            player.rangedDamage += .05f;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair) {
            drawAltHair = true;
            base.DrawHair(ref drawHair, ref drawAltHair);
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == mod.ItemType("OutlawJacket") && legs.type == mod.ItemType("OutlawPants");
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = "15% increased movement speed";
            player.moveSpeed += 0.15f;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Leather, 2);
            recipe.AddIngredient(ItemID.MeteoriteBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}