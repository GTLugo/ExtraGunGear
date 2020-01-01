using Terraria;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Materials {
    public class SerumResearch : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Serum Research Papers");
            Tooltip.SetDefault("Lost research on the Super Soldier Serum" +
                "\n'Perhaps someone will complete the research someday...'"
            );
        }

        public override void SetDefaults() {
            item.maxStack = 1;
            item.width = 32;
            item.height = 34;
            item.value = Item.sellPrice(1, 0, 0, 0);
            item.rare = -12;
            item.expert = true;
        }
    }
}