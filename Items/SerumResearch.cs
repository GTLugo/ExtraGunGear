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
    public class SerumResearch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Serum Research Papers");
            Tooltip.SetDefault("Lost research on the Super Soldier Serum" +
                "\n'Perhaps someone will complete the research someday...'"
            );
        }

        public override void SetDefaults()
        {
            item.maxStack = 1;
            item.width = 32;
            item.height = 34;
            item.value = 75000;
            item.rare = -12;
            item.expert = true;
        }
}
}