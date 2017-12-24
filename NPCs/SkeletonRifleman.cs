using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using System;

namespace ExtraGunGear.NPCs
{
    public class SkeletonRifleman : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Skeleton Soldier");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Skeleton];
        }

        public override void SetDefaults()
        {
            npc.width = 18;
            npc.height = 40;
            npc.damage = 24;
            npc.defense = 25;
            npc.lifeMax = 400;
            npc.HitSound = SoundID.NPCHit2;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 60f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 3;
            npc.buffImmune[BuffID.Poisoned] = true;
            npc.buffImmune[BuffID.Venom] = true;
            aiType = NPCID.Skeleton;
            animationType = NPCID.Skeleton;
        }
        public override void NPCLoot()
        {
            Random rnd = new Random();
            int dropChance = rnd.Next(0, 10);
            if (dropChance > 9f)
            {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ChloroAR"));
            }
            base.NPCLoot();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Terraria.NPC.downedMechBoss1 == true && Terraria.NPC.downedMechBoss2 == true && Terraria.NPC.downedMechBoss3 == true)
            {
                return SpawnCondition.UndergroundJungle.Chance;
            }
            else return SpawnCondition.UndergroundJungle.Chance * 0f;
        }
    }
}
