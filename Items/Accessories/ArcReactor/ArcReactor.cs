using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Items.Accessories.ArcReactor {
    [AutoloadEquip(EquipType.Neck)]
    public class ArcReactor : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Arc Reactor");
            Tooltip.SetDefault("Provides life regeneration" +
                "\nDramatically reduces the cooldown and slightly increases potency of healing potions" +
                "\nReduces damage taken by 12%" +
                "\nMay confuse nearby enemies after being struck"
                );
        }

        public override void SetDefaults() {
            item.width = 28;
            item.height = 28;
            item.value = Item.sellPrice(0, 12, 25, 0);
            item.rare = 9;
            //item.expert = true;
            item.accessory = true;
        }

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI) {
            scale *= 0.5f;
            Texture2D texture = mod.GetTexture("Items/Accessories/ArcReactor/ArcReactor");
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

        //public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor) {
        //    color = Color.White;
        //    base.DrawArmorColor(drawPlayer, shadow, ref color, ref glowMask, ref glowMaskColor);
        //}

        public override void PostUpdate() {
            Lighting.AddLight((int)((item.position.X + item.width / 2) / 16f), (int)((item.position.Y + item.height / 2) / 16f), 0.2f, 1.0f, 0.9f);
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.endurance += .12f;
            item.lifeRegen = 1;
            player.pStone = true;
            player.brainOfConfusion = true;
            player.GetModPlayer<EGGPlayer>().hasMSeed = true;
            player.GetModPlayer<EGGPlayer>().hasAmp = true;
            base.UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("ExtraGunGear:EvilAccessory");
            recipe.AddIngredient(mod, "MythicalSeed");
            recipe.AddIngredient(mod, "BeskarBar", 3);
            recipe.AddIngredient(ItemID.FragmentVortex, 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}