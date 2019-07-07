using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Accessories
{
    public class MythicalSeed : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mythical Seed");
            Tooltip.SetDefault("Provides life regeneration and dramatically reduces the cooldown of healing potions" +
                "\nReduces damage taken by 12%" +
                "\nMay confuse nearby enemies after being struck"
            //+ "\nDecreases ranged damage by 10%"
            );
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.value = 75000;
            item.rare = -12;
            item.expert = true;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.endurance += .12f;
            item.lifeRegen = 1;
            player.pStone = true;
            player.brainOfConfusion = true;
            player.GetModPlayer<EGGPlayer>(mod).hasSeed = true;
            base.UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {/*
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CharmofMyths);
            recipe.AddIngredient(mod, "SunPowerSeed");
            recipe.AddIngredient(ItemID.WormScarf);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CharmofMyths);
            recipe.AddIngredient(mod, "SunPowerSeed");
            recipe.AddIngredient(ItemID.BrainOfConfusion);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
         */
        }
    }
}