using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Materials.Beskar {
    class BeskarOre : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Beskar Ore");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 58;
        }

        public override void SetDefaults() {
            base.SetDefaults();
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 2, 50, 0);
            item.rare = 8;

            item.useStyle = 1;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = mod.TileType("BeskarOre");
        }
    }
}
