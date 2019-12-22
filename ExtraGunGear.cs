using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExtraGunGear {
    class ExtraGunGear : Mod {
        internal static ExtraGunGear Instance;

        public ExtraGunGear() {
            Properties = new ModProperties() {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }

        public override void Load() {
            if (!Main.dedServ) {
                // Add certain equip textures
                AddEquipTexture(new Items.Accessories.Symbiote.SymbioteHead(), null, EquipType.Head, "SymbioteHead", "ExtraGunGear/Items/Accessories/Symbiote/Symbiote_Head");
                AddEquipTexture(new Items.Accessories.Symbiote.SymbioteBody(), null, EquipType.Body, "SymbioteBody", "ExtraGunGear/Items/Accessories/Symbiote/Symbiote_Body", "ExtraGunGear/Items/Accessories/Symbiote/Symbiote_Arms", "ExtraGunGear/Items/Accessories/Symbiote/Symbiote_FemaleBody");
                AddEquipTexture(new Items.Accessories.Symbiote.SymbioteLegs(), null, EquipType.Legs, "SymbioteLegs", "ExtraGunGear/Items/Accessories/Symbiote/Symbiote_Legs");
                AddDust("BulletTrail", new Dusts.BulletTrail(), "ExtraGunGear/Dusts/BulletTrail");
            }
            base.Load();
        }

        public override void PostSetupContent() {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            //List<int> CollectionItemIDs = ;
            //List<int> LootItemIDs = ;
            if (bossChecklist != null) {
                bossChecklist.Call(
                    "AddBoss",
                    12.5f, 
                    ModContent.NPCType<NPCs.Bosses.SunGod.SunGod>(), 
                    this, 
                    "Sun God", 
                    (Func<bool>)(() => EGGWorld.downedSunGod), 
                    ModContent.ItemType<Items.MayanCalendar>(),
                    new List<int>() { 

                    },
                    new List<int>(){
                        ModContent.ItemType<Items.Weapons.Revolvers.GoldenGun>(),
                        ModContent.ItemType<Items.Accessories.SunPowerSeed>(),
                        ModContent.ItemType<Items.Materials.Beskar.BeskarBar>(),
                        ModContent.ItemType<Items.Materials.Beskar.BeskarOre>()
                    }, 
                    "Craft a Mayan calendar at the Lihzahrd Altar and use it at night to summon the Sun God", 
                    "The Sun God reigns supreme", 
                    "ExtraGunGear/NPCs/Bosses/SunGod/SunGod2",
                    "ExtraGunGear/NPCs/Bosses/SunGod/SunGod_Head_Boss"
                );
            }
        }

        //public override void HandlePacket(BinaryReader reader, int whoAmI) {
        //  ModNetHandler.HandlePacket(reader, whoAmI);
        //}

        public override void AddRecipeGroups() {
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

        public override void AddRecipes() {
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
            if (recipe2 != null) {
                RecipeEditor editor = new RecipeEditor(recipe2);
                editor.DeleteRecipe();
            }
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI) {
            EGGModMessageType msgType = (EGGModMessageType)reader.ReadByte();
            switch (msgType) {
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
            //ModNetHandler.HandlePacket(reader, whoAmI);
        }
    }

    internal enum EGGModMessageType : byte {
        EGGPlayerSyncPlayer
    }

    internal class ModNetHandler {
        // When a lot of handlers are added, it might be wise to automate
        // creation of them
        public const byte bulletTrailType = 2;
        internal static BulletTrailPacketHandler bulletTrail = new BulletTrailPacketHandler(bulletTrailType);
        public static void HandlePacket(BinaryReader r, int fromWho) {
            switch (r.ReadByte()) {
                case bulletTrailType:
                    bulletTrail.HandlePacket(r, fromWho);
                    break;
            }
        }
    }

    internal abstract class PacketHandler {
        internal byte HandlerType { get; set; }

        public abstract void HandlePacket(BinaryReader reader, int fromWho);

        protected PacketHandler(byte handlerType) {
            HandlerType = handlerType;
        }

        protected ModPacket GetPacket(byte packetType, int fromWho) {
            var p = ExtraGunGear.Instance.GetPacket();
            p.Write(HandlerType);
            p.Write(packetType);
            if (Main.netMode == NetmodeID.Server) {
                p.Write((byte)fromWho);
            }
            return p;
        }
    }

    internal class BulletTrailPacketHandler : PacketHandler {
        public const byte SyncProjectile = 2;
        public BulletTrailPacketHandler(byte handlerType) : base(handlerType) {
        }

        public override void HandlePacket(BinaryReader reader, int fromWho) {
            //throw new NotImplementedException();
            switch (reader.ReadByte()) {
                case (SyncProjectile):
                    ReceiveProjectile(reader, fromWho);
                    break;
            }
        }

        public void SendProjectile(int toWho, int fromWho, int projectile, int trail, int iter) {
            ModPacket packet = GetPacket(SyncProjectile, fromWho);
            packet.Write(projectile);
            packet.Write(trail);
            packet.Write(iter);
            packet.Send(toWho, fromWho);
        }

        public void ReceiveProjectile(BinaryReader reader, int fromWho) {
            int projectile = reader.ReadInt32();
            int trail = reader.ReadInt32();
            int iter = reader.ReadInt32();
            if (Main.netMode == NetmodeID.Server) {
                SendProjectile(-1, fromWho, projectile, trail, iter);
            }
            else {
                Projectile targetProj = Main.projectile[projectile];
                Dust dust = Main.dust[trail];

                Vector2 projectilePosition = targetProj.position;
                projectilePosition -= targetProj.velocity * ((float)iter * 0.25f);

                Main.dust[trail].position = projectilePosition;
                //Main.dust[trail].scale = (float)Main.rand.Next(70, 110) * 0.013f;
                Main.dust[trail].velocity *= 0.2f;
                Main.dust[trail].noGravity = true;
                targetProj.netUpdate = true;
            }
        }
    }
}
