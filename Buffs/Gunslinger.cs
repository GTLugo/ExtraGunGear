using Terraria;
using Terraria.ModLoader;

namespace ExtraGunGear.Buffs {
    class Gunslinger : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Gunslinger");
            Description.SetDefault("20% increased bullet damage and knockback");
            Main.debuff[Type] = false;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex) {
            EGGPlayer modPlayer = player.GetModPlayer<EGGPlayer>();
            modPlayer.gunslingerBuff = true;
        }
    }
}
