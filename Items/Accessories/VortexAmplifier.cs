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
    public class VortexAmplifier : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arc Reactor");
            Tooltip.SetDefault("Provides life regeneration and dramatically reduces the cooldown of healing potions" +
                "\nReduces damage taken by 12%" +
                "\nMay confuse nearby enemies after being struck"
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

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            scale *= 0.5f;
            Texture2D texture = mod.GetTexture("Items/Accessories/VortexAmplifier");
            spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    item.position.X - Main.screenPosition.X + item.width * 0.5f,
                    item.position.Y - Main.screenPosition.Y + item.height * 0.5f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                rotation,
                texture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );
            return false;
        }

        public override void PostUpdate()
        {
            Lighting.AddLight((int)((item.position.X + item.width / 2) / 16f), (int)((item.position.Y + item.height / 2) / 16f), 0.2f, 1.0f, 0.9f);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.endurance += .12f;
            item.lifeRegen = 1;
            player.pStone = true;
            player.brainOfConfusion = true;
            player.GetModPlayer<EGGPlayer>().hasAmp = true;
            base.UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("ExtraGunGear:EvilAccessory", 1);
            recipe.AddIngredient(ItemID.CharmofMyths);
            recipe.AddIngredient(mod, "SunPowerSeed");
            recipe.AddIngredient(ItemID.FragmentVortex, 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
}
}