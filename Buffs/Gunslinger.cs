using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace ExtraGunGear.Buffs {
    class Gunslinger : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Gunslinger");
            Description.SetDefault("20% increased bullet damage");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex) {
            EGGPlayer modPlayer = player.GetModPlayer<EGGPlayer>();
            if (modPlayer.hasSymbiotePrev) {
                modPlayer.symbioteBuff = true;

                player.moveSpeed += 0.2f;
                player.jumpSpeedBoost += 2f;
                player.lifeRegen += 4;
                player.statDefense += 8;
                player.meleeSpeed += 0.2f;
                player.meleeDamage += 0.2f;
                player.meleeCrit += 3;
                player.rangedDamage += 0.2f;
                player.rangedCrit += 3;

            }
            else {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}
