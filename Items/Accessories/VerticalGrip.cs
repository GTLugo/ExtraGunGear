
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Accessories {
    public class VerticalGrip : ModItem {
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("Increases ranged accuracy dramatically"
            //+ "\nDecreases ranged damage by 10%"
            );
        }
        public override void SetDefaults() {
            item.width = 30;
            item.height = 30;
            item.value = Item.sellPrice(0, 9, 75, 0);
            item.rare = 7;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            //player.rangedDamage -= 0.10f;
            base.UpdateAccessory(player, hideVisual);
            player.GetModPlayer<EGGPlayer>().hasGrip = true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 18);
            recipe.anyIronBar = true;
            recipe.AddIngredient(ItemID.Wood, 12);
            recipe.anyWood = true;
            recipe.AddIngredient(ItemID.Leather, 2);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}