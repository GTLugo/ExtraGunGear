using Terraria;
using Terraria.ModLoader;

namespace ExtraGunGear.Buffs {
    class Symbiote : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Symbiote");
            Description.SetDefault("We are Venom!");
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
                player.magicDamage += 0.2f;
                player.magicCrit += 3;
                player.pickSpeed -= 0.2f;
                player.minionDamage += 0.2f;
                player.minionKB += 0.75f;
                player.thrownDamage += 0.2f;
                player.thrownCrit += 3;
            }
            else {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}
