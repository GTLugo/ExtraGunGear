using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items
{
    public class SuperSoldierSerum : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases maximum life by 100" +
                "\nMinor increases to all stats" +
                "\nCan only be used once, but effects are quite permanent" +
                "\n'His reflexes, his physical condition, his courage, will be second to none!'"
            );
        }

        public override void SetDefaults()
        {
            item.useStyle = 2;
            item.consumable = true;
            item.potion = true;
            item.useTurn = true;
            item.maxStack = 1;
            item.width = 34;
            item.height = 38;
            item.value = 75000;
            item.rare = -12;
            item.expert = true;
        }

        public override bool CanUseItem(Player player)
        {
            // Any mod that changes statLifeMax to be greater than 500 is broken and needs to fix their code.
            // This check also prevents this item from being used before vanilla health upgrades are maxed out.
            return player.GetModPlayer<EGGPlayer>(mod).serums < EGGPlayer.maxSerums;
        }

        public override bool UseItem(Player player)
        {
            // Do not do this: player.statLifeMax += 2;
            player.statLifeMax2 += 100;
            player.statLife += 100;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(100, true);
            }
            player.GetModPlayer<EGGPlayer>().serums += 1;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "SerumResearch");
            recipe.AddIngredient(ItemID.Vitamins);
            recipe.AddIngredient(ItemID.Bezoar);
            recipe.AddIngredient(ItemID.EyeoftheGolem);
            recipe.AddIngredient(ItemID.BloodWater, 20);
            recipe.AddIngredient(ItemID.LifeFruit, 2);
            recipe.AddIngredient(ItemID.SoulofMight, 10);
            recipe.AddIngredient(ItemID.SoulofSight, 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "SerumResearch");
            recipe.AddIngredient(ItemID.Vitamins);
            recipe.AddIngredient(ItemID.Bezoar);
            recipe.AddIngredient(ItemID.EyeoftheGolem);
            recipe.AddIngredient(ItemID.UnholyWater, 20);
            recipe.AddIngredient(ItemID.LifeFruit, 2);
            recipe.AddIngredient(ItemID.SoulofMight, 10);
            recipe.AddIngredient(ItemID.SoulofSight, 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
}
}