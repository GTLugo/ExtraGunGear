using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear
{
    public class EGGPlayer : ModPlayer
    {
        public bool hasMuzzle;
        public bool hasGrip;

        public override void ResetEffects()
        {
            hasMuzzle = false;
            hasGrip = false;
            base.ResetEffects();
        }
    }
}