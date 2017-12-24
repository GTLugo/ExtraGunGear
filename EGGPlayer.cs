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

        public override void PostUpdate()
        {
            //Check for accessory

            //Initialize bool for checking if accessory exists
            bool hasMeteorMuzzle = false;

            //Loops through accessories to check for accessory
            for (int i = 0; i < 8 + player.extraAccessorySlots; i++)
            {
                //If it exists then set hasMeteorMuzzle to true and then break
                if (player.armor[i].type == mod.ItemType("InfernoMuzzle") || player.armor[i].type == mod.ItemType("MeteorMuzzle") || player.armor[i].type == mod.ItemType("BlazingScope"))
                {
                    hasMeteorMuzzle = true;
                    break;
                }
            }

            //If player has it, set hasMeteorMuzzle to true otherwise, set it to false
            if (hasMeteorMuzzle)
            {
                hasMuzzle = true;
            }
            else
            {
                hasMuzzle = false;
            }
        }
    }
}