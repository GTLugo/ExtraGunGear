using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Terraria;
using System.IO;

namespace ExtraGunGear
{
	class ExtraGunGear : Mod
    {
        internal static ExtraGunGear Instance;

        public ExtraGunGear()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
        }

        public override void AddRecipeGroups()
        {
            RecipeGroup goldRecipeGroup = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Gold Bar", new int[]
            {
                    ItemID.GoldBar,
                    ItemID.PlatinumBar
            });
            RecipeGroup.RegisterGroup("ExtraGunGear:GoldBar", goldRecipeGroup);
            RecipeGroup evilChunkRecipeGroup = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Evil Chunk", new int[]
            {
                    ItemID.RottenChunk,
                    ItemID.Vertebrae
            });
            RecipeGroup.RegisterGroup("ExtraGunGear:EvilChunk", evilChunkRecipeGroup);
            RecipeGroup evilAccRecipeGroup = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Evil Accessory", new int[]
            {
                    ItemID.WormScarf,
                    ItemID.BrainOfConfusion
            });
            RecipeGroup.RegisterGroup("ExtraGunGear:EvilAccessory", evilAccRecipeGroup);
        }

        public override void AddRecipes()
        {
            ModRecipe newLeather = new ModRecipe(this);
            newLeather.AddRecipeGroup("ExtraGunGear:EvilChunk", 3);
            newLeather.AddTile(TileID.WorkBenches);
            newLeather.SetResult(ItemID.Leather);
            newLeather.AddRecipe();

            RecipeFinder finder = new RecipeFinder();
            finder.AddIngredient(ItemID.RottenChunk, 5);
            finder.AddTile(TileID.WorkBenches);
            finder.SetResult(ItemID.Leather);
            Recipe recipe2 = finder.FindExactRecipe();
            if (recipe2 != null)
            {
                RecipeEditor editor = new RecipeEditor(recipe2);
                editor.DeleteRecipe();
            }
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            EGGModMessageType msgType = (EGGModMessageType)reader.ReadByte();
            switch (msgType)
            {
                // This message syncs ExamplePlayer.exampleLifeFruits
                case EGGModMessageType.EGGPlayerSyncPlayer:
                    byte playernumber = reader.ReadByte();
                    EGGPlayer eggPlayer = Main.player[playernumber].GetModPlayer<EGGPlayer>();
                    int serums = reader.ReadInt32();
                    eggPlayer.serums = serums;
                    // SyncPlayer will be called automatically, so there is no need to forward this data to other clients.
                    break;
                default:
                    //.WarnFormat("ExtraGunGear: Unknown Message type: {0}", msgType);
                    break;
            }
        }
    }

    internal enum EGGModMessageType : byte
    {
        EGGPlayerSyncPlayer
    }
}
