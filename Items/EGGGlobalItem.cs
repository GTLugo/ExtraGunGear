
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraGunGear {
    public class EGGGlobalItem : GlobalItem {
        private static int count = 0;
        public override bool CanUseItem(Item item, Player player) {
            if (item.ranged && player.GetModPlayer<EGGPlayer>().hasStock && player.altFunctionUse != 2) {
                item.autoReuse = true;
            }
            else if (item.ranged && !player.GetModPlayer<EGGPlayer>().hasStock && player.altFunctionUse != 2) {
                Item itemClone = item.Clone();
                itemClone.CloneDefaults(item.type);
                item.autoReuse = itemClone.autoReuse;
            }

            return base.CanUseItem(item, player);
        }

        public override void PickAmmo(Item weapon, Item ammo, Player player, ref int type, ref float speed, ref int damage, ref float knockback) {
            EGGPlayer modPlayer = player.GetModPlayer<EGGPlayer>();
            if (weapon.useAmmo == AmmoID.Bullet && modPlayer.gunslingerBuff) {
                knockback = (int)((double)((float)knockback) * 1.2f);
                damage = (int)((double)((float)damage) * 1.2f);
            }
            base.PickAmmo(weapon, ammo, player, ref type, ref speed, ref damage, ref knockback);
        }

        //public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
        //    Main.NewText("Modified Shoot " + count++);
        //    if (item.ranged) {
        //        //Main.NewText("item is ranged");
        //        if (player.GetModPlayer<EGGPlayer>().hasMuzzle) {
        //            //Main.NewText("player has muzzle");
        //            if (type == ProjectileID.Bullet || type == ProjectileID.BulletHighVelocity) {
        //                //Main.NewText("bullet is hitscan");
        //                //type = mod.ProjectileType("HitScan");
        //            }
        //            else if (type == ProjectileID.ChlorophyteBullet) {
        //                //Main.NewText("bullet is homing hitscan");
        //                //type = mod.ProjectileType("HitScanHoming");
        //            }
        //        }
        //    }
        //    return base.Shoot(item, player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        //}
    }
}
