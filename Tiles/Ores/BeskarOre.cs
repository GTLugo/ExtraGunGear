using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear.Tiles.Ores {
    class BeskarOre : ModTile {
        public override void SetDefaults() {
            base.SetDefaults();
            TileID.Sets.Ore[Type] = true;
            TileID.Sets.HellSpecial[Type] = true;
            Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
            Main.tileValue[Type] = 660; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
            Main.tileShine2[Type] = true; // Modifies the draw color slightly.
            Main.tileShine[Type] = 975; // How often tiny dust appear off this tile. Larger is less frequently
            //Main.tileMerge[TileID.Ash][Type] = true;
            //Main.tileMerge[Type][TileID.Ash] = true;
            //Main.tileMergeDirt[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("BeskarOre");
            AddMapEntry(new Color(49, 59, 64), name);
            dustType = 84;
            drop = mod.ItemType("BeskarOre");
            soundType = 21;
            soundStyle = 1;
            mineResist = 8f;
            minPick = 205;
        }

        //public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak) {
        //    bool addToList = false;
        //    if (i>5 && j>5 && i < Main.maxTilesX -5 && j < Main.maxTilesY - 5 && Main.tile[i,j] != null) {
        //        addToList = WorldGen.UpdateMapTile(i, j, true);
        //        Tile tile = Main.tile[i, j];
        //        if (tile.active()) {
        //            if (!Main.tileFrameImportant[(int)tile.type]) {
        //                Tile tile2 = Main.tile[i, j - 1];
        //                Tile tile3 = Main.tile[i, j + 1];
        //                Tile tile4 = Main.tile[i - 1, j];
        //                Tile tile5 = Main.tile[i + 1, j];
        //                Tile tile6 = Main.tile[i - 1, j + 1];
        //                Tile tile7 = Main.tile[i + 1, j + 1];
        //                Tile tile8 = Main.tile[i - 1, j - 1];
        //                Tile tile9 = Main.tile[i + 1, j - 1];
        //                int num55 = -1;
        //                int num56 = -1;
        //                int num57 = -1;
        //                int num58 = -1;
        //                int num59 = -1;
        //                int num60 = -1;
        //                int num61 = -1;
        //                int num62 = -1;
        //                if (tile.slope() == 2) {
        //                    num56 = -1;
        //                    num58 = -1;
        //                }
        //                if (tile.slope() == 1) {
        //                    num56 = -1;
        //                    num59 = -1;
        //                }
        //                if (tile.slope() == 4) {
        //                    num61 = -1;
        //                    num58 = -1;
        //                }
        //                if (tile.slope() == 3) {
        //                    num61 = -1;
        //                    num59 = -1;
        //                }
        //                if (tile.type == Type) {
        //                    WorldGen.TileMergeAttempt(-2, 57, ref num56, ref num61, ref num58, ref num59, ref num55, ref num57, ref num60, ref num62);
        //                }
        //            }
        //        }
        //    }
        //    return base.TileFrame(i, j, ref resetFrame, ref noBreak);
        //}
    }
}
