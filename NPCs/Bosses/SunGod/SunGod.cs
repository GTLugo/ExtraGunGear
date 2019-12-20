using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace ExtraGunGear.NPCs.Bosses.SunGod {
    [AutoloadBossHead]
    public class SunGod : ModNPC {
        internal static Player player;
        //internal static float speed;
        internal static float rotationCount;
        internal static bool changingPhase;
        //internal static int BossPhase;
        internal static bool canHit;
        internal static bool attackDirection;
        internal static Vector2 lungeVelocity;
        internal static int NPCsSpawned;


        //internal static bool closeAttack;

        private float BossPhase {   // values from 0 - 2
            get { return npc.ai[0]; }
            set { npc.ai[0] = value; }
        }

        private float AttackSelection {   // values from 0 - 3, with 0 being unassigned
            get { return npc.ai[1]; }
            set { npc.ai[1] = value; }
        }

        private float AttackCooldown {
            get { return npc.ai[2]; }
            set { npc.ai[2] = value; }
        }

        private float PhaseCooldown {
            get { return npc.ai[3]; }
            set { npc.ai[3] = value; }
        }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Sun God");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults() {
            npc.aiStyle = -1;
            npc.rotation = 0f;
            npc.lifeMax = 50000; //100000;
            npc.damage = 100;
            npc.defense = 50;
            npc.knockBackResist = 0f;
            npc.width = 150;
            npc.height = 150;
            npc.visualOffset = new Vector2(0, 50f);
            npc.value = Item.buyPrice(0, 25, 0, 0);
            npc.npcSlots = 3f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit30;
            npc.DeathSound = SoundID.NPCDeath33;
            music = MusicID.Boss1;
            bossBag = mod.ItemType("SunGodBag");
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.lifeMax = (int)((float)npc.lifeMax * 0.625f * bossLifeScale);
            npc.damage = (int)((float)npc.damage * 0.6f);
        }

        public override void AI() {
            if (Main.netMode != 1) {
                GetTarget();
                Despawn();
                canHit = true;
                PhaseControl();

                if (!changingPhase) {
                    AttackControl();
                }
                npc.netUpdate = true;
            }
        }


        private void GetTarget() {
            npc.TargetClosestUpgraded();
            player = Main.player[npc.target];
        }

        private float PhaseControl() {
            if (npc.life <= (float)npc.lifeMax * (2f / 3f)) {
                if (PhaseCooldown < 200f) ChangePhase(1);
                else if (npc.life <= (float)npc.lifeMax * (1f / 3f)) {
                    if (PhaseCooldown < 400f) ChangePhase(2);
                }
            }
            else {
                BossPhase = 0;
            }
            return BossPhase;
        }

        private void AttackControl() {
            if (AttackSelection == 0f) {
                //Main.NewText("Choosing Attack...");
                float randomF = Main.rand.NextFloat();
                switch ((int)BossPhase) {
                    case 0:
                        if (randomF <= 1.0f) {
                            AttackSelection = 1;
                            //Main.NewText("Attack = Flames");
                        }
                        break;
                    case 1:
                        if (randomF <= 0.25f) {
                            AttackSelection = 2;
                            attackDirection = Main.rand.NextBool();
                            int left = (attackDirection) ? 1 : -1;

                            lungeVelocity.X = 3f * left;
                            lungeVelocity.Y = 15f;
                        }
                        else {
                            AttackSelection = 1;
                        }
                        break;
                    case 2:
                        if (randomF <= (3f / 10f)) {
                            AttackSelection = 3;
                            attackDirection = Main.rand.NextBool();
                        }
                        else if (randomF <= (4f / 10f)) {
                            AttackSelection = 2;
                            attackDirection = Main.rand.NextBool();
                            int left = (attackDirection) ? 1 : -1;

                            lungeVelocity.X = 3f * left;
                            lungeVelocity.Y = 15f;
                        }
                        else {
                            AttackSelection = 1;
                        }
                        break;
                    default:
                        AttackSelection = 0;
                        //Main.NewText("Attack = Default");
                        break;
                }
                switch ((int)AttackSelection) {
                    case 1:
                        AttackCooldown = 75f;
                        //Main.NewText("AttackCooldown = 200");
                        break;
                    case 2:
                        AttackCooldown = 150f;
                        break;
                    case 3:
                        AttackCooldown = 175f;
                        break;
                    default:
                        //AttackCooldown = 200f;
                        //Main.NewText("AttackCooldown = 0");
                        break;
                }
                MoveToTarget(player.Center, new Vector2(0, -200f), 8f);
            }
            if (AttackCooldown > 0f) {
                switch ((int)AttackSelection) {
                    case 1:
                        //Main.NewText("Attacking...");
                        ShootFlames();

                        MoveToTarget(player.Center, new Vector2(0, -200f), 10f);
                        //Main.NewText("Attacked");
                        break;
                    case 2:
                        LungeAttack();

                        // moving is just for debug //
                        MoveToTarget(player.Center, new Vector2(0, -200f), 10f);
                        break;
                    case 3:
                        NapalmRun();

                        // moving is just for debug //
                        //MoveToTarget(player.Center, new Vector2(0, -200f), 10f);
                        break;
                    default:
                        //AttackCooldown = 200f;
                        //Main.NewText("Defaulted");
                        break;
                }
            }
            else {
                //MoveToTarget(player.Center, new Vector2(0, -200f), 6f);
            }

            --AttackCooldown;
            if (AttackCooldown <= 0f) {
                if (NPCsSpawned < ((BossPhase + 1f) * 5f)) {
                    RingFlames(3f, 15);
                    NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("SunMinion"));
                    ++NPCsSpawned;
                }

                AttackSelection = 0f;
                AttackCooldown = 0f;
            }
            npc.netUpdate = true;
        }

        private void ChangePhase(int phase) {
            PhaseCooldown += 1f;
            if (Main.netMode != 1) {
                if (PhaseCooldown % 200 == 0) {
                    canHit = true;
                    changingPhase = false;
                    npc.immortal = false;
                    BossPhase = phase;
                    RingFlames(5f, 30);
                }
                else {
                    canHit = false;
                    changingPhase = true;
                    npc.immortal = true;
                }

                //float inputValue = (PhaseCooldown % 200f) / 2f;
                //float dampingFunc = (float)(Math.Pow(Math.E, -0.03 * inputValue) * 50.0 * Math.Cos(-0.8 * inputValue));
                //MoveToTarget(new Vector2(npc.position.X + 25f * (float)Math.Sin((Math.PI / 5.0) * inputValue), npc.position.Y), new Vector2(0, 0), 6f);
                MoveToTarget(new Vector2(npc.Center.X + 75f * (float)Main.rand.NextFloat(-1f, 1f), npc.Center.Y + 25f * (float)Main.rand.NextFloat(-1f, 1f)), new Vector2(0, 0), 16f);

                npc.netUpdate = true;
            }
        }

        private void MoveToTarget(Vector2 target, Vector2 offset, float speed) {
            if (Main.netMode != 1) {
                Vector2 moveTo = target + offset;
                Vector2 move = moveTo - npc.Center;
                float magnitude = MagnitudeOf(move);
                move /= magnitude;

                //if (magnitude > speed)
                {
                    move *= speed;
                }
                float turnResist = 10f;
                move = (npc.velocity * turnResist + move) / (turnResist + 1f);
                //magnitude = MagnitudeOf(move);
                //if (magnitude > speed)
                {
                    //move *= speed / magnitude;
                }

                //if (noMove) move *= 0f;
                npc.velocity = move;
                npc.netUpdate = true;
            }
        }

        private void ShootFlames() {
            if (Main.netMode != 1) {
                if (AttackCooldown == 75f) {
                    int type = mod.ProjectileType("SunGodFlames");
                    Vector2 velocity = player.Center - npc.Center;
                    float magnitude = MagnitudeOf(velocity);
                    if (magnitude > 0) {
                        velocity *= 12f / magnitude; // Normalizes vector and multiplies by value
                    }
                    else {
                        velocity = new Vector2(0f, 5f);
                    }

                    float ratio = velocity.X / (-1f * velocity.Y);
                    float normalMagn = (float)Math.Sqrt(1.0 + Math.Pow(ratio, 2.0));

                    Vector2 flameOffset = new Vector2(0, 0) {
                        X = 1f / normalMagn,
                        Y = ratio / normalMagn
                    };

                    for (int i = -50; i <= 50; i += 10) {
                        float velocityRandomFactor = Main.rand.NextFloat(0.75f, 1.25f);
                        Vector2 offsetVelocity = velocity * velocityRandomFactor;
                        //for (int j = 0; j <= 5; ++j)
                        {
                            Vector2 temp = new Vector2(flameOffset.X, flameOffset.Y);
                            temp *= i;

                            int damage = (npc.damage - 30) / 2;
                            if (Main.expertMode) {
                                damage = (int)(damage / Main.expertDamage);
                            }
                            Projectile.NewProjectile(new Vector2(npc.Center.X + temp.X, npc.Center.Y + temp.Y), offsetVelocity, type, damage, 0f);
                        }
                    }
                    //Main.NewText("Sun God: Shot Flames");
                    npc.netUpdate = true;
                }
            }
        }

        private void LungeAttack() {
            int right = (attackDirection) ? 1 : -1;
            if (AttackCooldown >= 100f) {
                //if (AttackCooldown == 200f) Main.NewText("Sun God: Preparing to Drop Napalm...");
                MoveToTarget(player.Center, new Vector2(-600f * right, -300f), 50f);
            }
            if (AttackCooldown < 100f && AttackCooldown >= 50f) {
                RingFlames(3f, 4);

                MoveToTarget(npc.Center + lungeVelocity, new Vector2(0f, 0f), 75f);

                lungeVelocity = lungeVelocity.RotatedBy((2f * Math.PI / 3f) / 25f * right * -1);
            }
            if (AttackCooldown < 50f && AttackCooldown >= 25f) {
                MoveToTarget(new Vector2(npc.Center.X + 600f * right, npc.Center.Y), new Vector2(0f, 0f), 50f);
            }
            if (AttackCooldown < 25f) {
                MoveToTarget(player.Center, new Vector2(0, -200f), 50f);
            }
            npc.netUpdate = true;
        }

        private void NapalmRun() {
            int right = (attackDirection) ? 1 : -1;
            if (AttackCooldown >= 125f) {
                //if (AttackCooldown == 200f) Main.NewText("Sun God: Preparing to Drop Napalm...");
                MoveToTarget(player.Center, new Vector2(-600f * right, -300f), 25f);
            }
            if (AttackCooldown < 125f && AttackCooldown >= 50f) {
                //if (AttackCooldown == 149f) Main.NewText("Sun God: Dropping Napalm...");
                int type = mod.ProjectileType("SunGodFlames");
                Vector2 velocity;
                velocity.X = 0f;
                velocity.Y = 9f;

                float velocityRandomFactor = Main.rand.NextFloat(0.75f, 1.25f);
                Vector2 offsetVelocity = velocity * velocityRandomFactor;

                int damage = (npc.damage) / 2;
                if (Main.expertMode) {
                    damage = (int)(damage / Main.expertDamage);
                }
                for (int i = 0; i < 2; ++i)
                    Projectile.NewProjectile(new Vector2(npc.Center.X, npc.Center.Y), offsetVelocity, type, damage, 0f);

                MoveToTarget(new Vector2(npc.Center.X + 600f * right, npc.Center.Y), new Vector2(0f, 0f), 20f);
            }
            if (AttackCooldown < 50f) {
                MoveToTarget(player.Center, new Vector2(0, -200f), 25f);
            }
            npc.netUpdate = true;
        }

        private void RingFlames(float size, int segments) {
            Vector2 velocity = player.Center - npc.Center;
            float magnitude = MagnitudeOf(velocity);
            if (magnitude > 0) {
                velocity *= size / magnitude; // Normalizes vector and multiplies by value
            }
            else {
                velocity = new Vector2(0f, 5f);
            }

            float ratio = velocity.X / (-1f * velocity.Y);
            float normalMagn = (float)Math.Sqrt(1.0 + Math.Pow(ratio, 2.0));

            Vector2 flameOffset = new Vector2(0, 0) {
                X = 1f / normalMagn,
                Y = ratio / normalMagn
            };

            for (int i = 0; i <= segments; ++i) {
                float velocityRandomFactor = Main.rand.NextFloat(0.75f, 1.25f);
                Vector2 offsetVelocity = velocity * velocityRandomFactor;

                Vector2 temp = new Vector2(flameOffset.X, flameOffset.Y);
                temp *= i;
                int damage = (npc.damage) / 2;
                if (Main.expertMode) {
                    damage = (int)(damage / Main.expertDamage);
                }
                Projectile.NewProjectile(new Vector2(npc.Center.X + temp.X, npc.Center.Y + temp.Y), offsetVelocity, mod.ProjectileType("SunGodFlames"), damage, 0f);
                velocity = velocity.RotatedBy((2f * Math.PI) / (float)segments); // divide the circle into segments so each value of i is equally spaced
            }
        }

        public override void OnHitPlayer(Player player, int damage, bool crit) {
            if (Main.expertMode) {
                player.AddBuff(BuffID.OnFire, 600, true);
            }
        }

        public override bool StrikeNPC(ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit) {
            if (!canHit) {
                damage = 0;
                canHit = true;
                Main.PlaySound(npc.HitSound, npc.position);
                return false;
            }
            return true;
        }

        private void Despawn() {
            if (!player.active || player.dead || Main.dayTime) {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
                if (!player.active || player.dead || Main.dayTime) {
                    npc.velocity = new Vector2(0f, -10f);
                    if (npc.timeLeft > 10) {
                        npc.timeLeft = 10;
                    }
                    return;
                }
            }
        }

        public override bool CheckDead() {
            RingFlames(5f, 30);
            return base.CheckDead();
        }

        private float MagnitudeOf(Vector2 vector2) {
            return (float)Math.Sqrt(vector2.X * vector2.X + vector2.Y * vector2.Y);
        }

        /*public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 1;
            npc.frameCounter %= 20;
            int frame = (int)(npc.frameCounter / 2.0);
            if(frame >= Main.npcFrameCount[npc.type])
            {
                frame = 0;
            }
            npc.frame.Y = frame * frameHeight;
        }*/

        public override void NPCLoot() {
            if (Main.expertMode) {
                npc.DropBossBags();
            }
            else {
                if (Main.rand.NextBool(7)) {
                    // Mask
                    //player.QuickSpawnItem(mod.ItemType(" "));
                }

                int[] drops = {
                    mod.ItemType("GoldenGun"),
                    mod.ItemType("SunPowerSeed"),
                    mod.ItemType("BeskarBar")
                };
                var dropChooser = new WeightedRandom<int>();
                for (int i = 0; i < drops.Length; ++i) {
                    dropChooser.Add(drops[i], 1);
                }
                int choice = dropChooser;
                player.QuickSpawnItem(choice);
                dropChooser.Clear();
                for (int i = 0; i < drops.Length; ++i) {
                    if (drops[i] != choice) dropChooser.Add(drops[i], 1);
                }
                int choice2 = dropChooser;
                player.QuickSpawnItem(choice2);
                player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(15, 20));
                player.QuickSpawnItem(mod.ItemType("BeskarOre"), Main.rand.Next(15, 20));
            }
            SpawnOre();
            if (!EGGWorld.downedSunGod) {
                EGGWorld.downedSunGod = true;
                if (Main.netMode == NetmodeID.Server) {
                    NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
                }
            }
        }

        public override void BossLoot(ref string name, ref int potionType) {
            name = "The " + name;
            potionType = ItemID.GreaterHealingPotion;
        }

        private void SpawnOre() {
            Main.NewText("The underworld marvels at the discovery of Beskar Ore", 200, 200, 55);  //this is the message that will appear when the npc is killed  , 200, 200, 55 is the text color

            // Ores are quite simple, we simply use a for loop and the WorldGen.TileRunner to place splotches of the specified Tile in the world.
            // "6E-05" is "scientific notation". It simply means 0.00006 but in some ways is easier to read.
            for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 33E-05); k++) {
                // The inside of this for loop corresponds to one single splotch of our Ore.
                // First, we randomly choose any coordinate in the world by choosing a random x and y value.
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY); // WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.

                //// Then, we call WorldGen.TileRunner with random "strength" and random "steps", as well as the Tile we wish to place. Feel free to experiment with strength and step to see the shape they generate.
                //WorldGen.TileRunner(x, y, (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), mod.TileType("BeskarOre"), false, 0f, 0f, false, true);

                // Alternately, we could check the tile already present in the coordinate we are interested. Wrapping WorldGen.TileRunner in the following condition would make the ore only generate in Snow.
                Tile tile = Framing.GetTileSafely(x, y);
                //if (tile.active() && ((tile.type == TileID.SnowBlock || tile.type == TileID.IceBlock || tile.type == TileID.CorruptIce || tile.type == TileID.FleshIce || tile.type == TileID.HallowedIce) ||
                //    (tile.type == TileID.Dirt || tile.type == TileID.Stone || tile.type == TileID.Ebonstone || tile.type == TileID.Crimstone || tile.type == TileID.Pearlstone))) {
                if (tile.active() && tile.type == TileID.Ash) {
                    WorldGen.TileRunner(x, y, (double)WorldGen.genRand.Next(3, 14), WorldGen.genRand.Next(2, 7), mod.TileType("BeskarOre"), false, 0f, 0f, false, true);

                    // 	WorldGen.TileRunner(.....);
                }
            }
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position) {
            scale = 1.5f;
            return null;
        }

        public float Rotate(float angle) {
            rotationCount += angle;
            return (float)Math.Asin((double)Math.Sin(rotationCount)) * 2;
        }
        private void DrawCorona(SpriteBatch spriteBatch, Color drawColor) {
            Texture2D corona;
            switch ((int)BossPhase) {
                case 0:
                    corona = mod.GetTexture("NPCs/Bosses/SunGod/Corona/SunGodCoronaRed");
                    break;
                case 1:
                    corona = mod.GetTexture("NPCs/Bosses/SunGod/Corona/SunGodCoronaYellow");
                    break;
                case 2:
                    corona = mod.GetTexture("NPCs/Bosses/SunGod/Corona/SunGodCoronaBlue");
                    break;
                default:
                    corona = mod.GetTexture("NPCs/Bosses/SunGod/Corona/SunGodCoronaRed");
                    break;
            }
            spriteBatch.Draw
            (
                corona,
                new Vector2
                (
                    npc.position.X - Main.screenPosition.X + npc.width * 0.5f,
                    npc.position.Y - Main.screenPosition.Y + npc.height * 0.5f
                ),
                new Rectangle(0, 0, corona.Width, corona.Height),
                drawColor,
                Rotate(0.01f),
                corona.Size() * 0.5f,
                npc.scale,
                SpriteEffects.None,
                0f
            );
            spriteBatch.Draw
            (
                corona,
                new Vector2
                (
                    npc.position.X - Main.screenPosition.X + npc.width * 0.5f,
                    npc.position.Y - Main.screenPosition.Y + npc.height * 0.5f
                ),
                new Rectangle(0, 0, corona.Width, corona.Height),
                drawColor,
                Rotate(0.01f) * -1f,
                corona.Size() * 0.5f,
                npc.scale,
                SpriteEffects.None,
                0f
            );
        }
        private void DrawBody(SpriteBatch spriteBatch, Color drawColor) {
            Texture2D body;
            switch ((int)BossPhase) {
                case 0:
                    body = mod.GetTexture("NPCs/Bosses/SunGod/Body/SunGodBodyRed");
                    break;
                case 1:
                    body = mod.GetTexture("NPCs/Bosses/SunGod/Body/SunGodBodyYellow");
                    break;
                case 2:
                    body = mod.GetTexture("NPCs/Bosses/SunGod/Body/SunGodBodyBlue");
                    break;
                default:
                    body = mod.GetTexture("NPCs/Bosses/SunGod/Body/SunGodBodyRed");
                    break;
            }

            spriteBatch.Draw
            (
                body,
                new Vector2
                (
                    npc.position.X - Main.screenPosition.X + npc.width * 0.5f,
                    npc.position.Y - Main.screenPosition.Y + npc.height * 0.5f
                ),
                new Rectangle(0, 0, body.Width, body.Height),
                drawColor,
                npc.rotation,
                body.Size() * 0.5f,
                npc.scale,
                SpriteEffects.None,
                0f
            );
        }
        private void DrawFace(SpriteBatch spriteBatch, Color drawColor) {
            Texture2D face;
            if (!changingPhase) {
                switch ((int)BossPhase) {
                    case 0:
                        face = mod.GetTexture("NPCs/Bosses/SunGod/Face/SunGodEyesRed");
                        break;
                    case 1:
                        face = mod.GetTexture("NPCs/Bosses/SunGod/Face/SunGodEyesYellow");
                        break;
                    case 2:
                        face = mod.GetTexture("NPCs/Bosses/SunGod/Face/SunGodEyesBlue");
                        break;
                    default:
                        face = mod.GetTexture("NPCs/Bosses/SunGod/Face/SunGodEyesRed");
                        break;
                }
            }
            else face = mod.GetTexture("NPCs/Bosses/SunGod/Face/SunGodCrossEyes");
            spriteBatch.Draw
            (
                face,
                new Vector2
                (
                    npc.position.X - Main.screenPosition.X + npc.width * 0.5f,
                    npc.position.Y - Main.screenPosition.Y + npc.height * 0.5f
                ),
                new Rectangle(0, 0, face.Width, face.Height),
                drawColor,
                npc.rotation,
                face.Size() * 0.5f,
                npc.scale,
                SpriteEffects.None,
                0f
            );

            Texture2D smile;
            switch ((int)BossPhase) {
                case 0:
                    smile = mod.GetTexture("NPCs/Bosses/SunGod/Face/SunGodSmileRed");
                    break;
                case 1:
                    smile = mod.GetTexture("NPCs/Bosses/SunGod/Face/SunGodSmileYellow");
                    break;
                case 2:
                    smile = mod.GetTexture("NPCs/Bosses/SunGod/Face/SunGodSmileBlue");
                    break;
                default:
                    smile = mod.GetTexture("NPCs/Bosses/SunGod/Face/SunGodSmileRed");
                    break;
            }
            if (!changingPhase)
                spriteBatch.Draw
                (
                    smile,
                    new Vector2
                    (
                        npc.position.X - Main.screenPosition.X + npc.width * 0.5f,
                        npc.position.Y - Main.screenPosition.Y + npc.height * 0.5f
                    ),
                    new Rectangle(0, 0, smile.Width, smile.Height),
                    drawColor,
                    npc.rotation,
                    smile.Size() * 0.5f,
                    npc.scale,
                    SpriteEffects.None,
                    0f
                );
        }

        // Custom rendering //
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor) {
            DrawCorona(spriteBatch, Color.White);
            DrawBody(spriteBatch, Color.White);

            DrawFace(spriteBatch, Color.White);
            return false;
        }
    }
}
