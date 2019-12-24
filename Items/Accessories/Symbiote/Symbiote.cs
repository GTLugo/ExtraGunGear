using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Accessories.Symbiote {
    class Symbiote : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("V-252");
            Tooltip.SetDefault("Covers the host in a symbiote"/* and turns them into a merfolk when entering water"*/ +
                "\nIncreases to all stats" + 
                "\nDramatically increased life regeneration" +
                "\nGrants spider powers and ability to dodge attacks" +
                "\n+8 defense");
        }
        public override void SetDefaults() {
            item.width = 30;
            item.height = 30;
            item.accessory = true;
            item.value = Item.sellPrice(0, 55, 25, 0);
            item.rare = 10;
        }

        public override void ArmorSetShadows(Player player) {
            base.ArmorSetShadows(player);
            player.armorEffectDrawShadow = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            EGGPlayer modPlayer = player.GetModPlayer<EGGPlayer>();
            modPlayer.hasSymbiote = true;
            player.blackBelt = true;
            player.dash = 1;
            player.spikedBoots = 2;
            if (hideVisual) modPlayer.symbioteHideVanity = true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CelestialShell);
            recipe.AddIngredient(ItemID.MasterNinjaGear);
            recipe.AddIngredient(ItemID.LunarBar, 3);
            recipe.AddIngredient(ItemID.FragmentStardust, 3);
            recipe.AddIngredient(ItemID.Gel, 15);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    public class SymbioteHead : EquipTexture {
        public override bool DrawHead() {
            return false;
        }
    }

    public class SymbioteBody : EquipTexture {
        public override bool DrawBody() {
            return false;
        }
    }

    public class SymbioteLegs : EquipTexture {
        public override bool DrawLegs() {
            return false;
        }
    }
}
