using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace ExtraGunGear.Items.BossBags {
    class SunGodBag : ModItem {

        //public static short glowMask;

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
            //if (Main.netMode != NetmodeID.Server)
            //    glowMask = GlowMaskAPI.Tools.instance.AddGlowMask(mod.GetTexture("Items/BossBags/SunGodBag_Glow"));
        }
        public override void SetDefaults() {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 24;
            item.height = 24;
            item.rare = -12;
            item.expert = true;
            //item.glowMask = glowMask;
        }

        public override bool CanRightClick() {
            return true;
        }

        public override void OpenBossBag(Player player) {
            player.TryGettingDevArmor();
            if (Main.rand.NextBool(7)) {
                // Mask
                //player.QuickSpawnItem(mod.ItemType(" "));
            }

            int[] drops = {
                    mod.ItemType("GoldenGun"),
                    mod.ItemType("SunPowerSeed"),
                    mod.ItemType("BeskarBar")
                };
            var dropChooser = new WeightedRandom<int>();
            for (int i = 0; i < drops.Length; ++i) {
                dropChooser.Add(drops[i], 1);
            }
            int choice = dropChooser;
            if (choice == mod.ItemType("BeskarBar")) {
                player.QuickSpawnItem(choice, Main.rand.Next(5, 10));
            }
            else {
                player.QuickSpawnItem(choice);
            }
            dropChooser.Clear();
            for (int i = 0; i < drops.Length; ++i) {
                if (drops[i] != choice) dropChooser.Add(drops[i], 1);
            }
            int choice2 = dropChooser;
            player.QuickSpawnItem(choice2);

            // Guaranteed drops
            player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(30, 50));
            player.QuickSpawnItem(mod.ItemType("BeskarOre"), Main.rand.Next(15, 20));
            // Expert
            //player.QuickSpawnItem(mod.ItemType("SunPowerSeed"));
            //if (player.GetModPlayer<EGGPlayer>().serums < EGGPlayer.maxSerums) {
            player.QuickSpawnItem(mod.ItemType("SerumResearch"));
            //}
        }

        public override int BossBagNPC => mod.NPCType("SunGod");
    }
}
