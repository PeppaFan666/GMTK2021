using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GMTK2021
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        int MaxEntityTypes;
        int MaxNPCTypes;
        public Texture2D[] NpcTextures;
        public static Game1 instance;
        private Paddle paddle;
        int CurrentIndex = 0;
        public NPC[] npc;
        int MaxNPCs;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            instance = this;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            MaxEntityTypes = 0;
            MaxNPCTypes = 0;
            NpcTextures = new Texture2D[MaxNPCTypes];
            for(int i =0; i < MaxEntityTypes; i++)
            {
               NpcTextures[i] = Content.Load<Texture2D>("NPCs_" + i);
            }
            paddle = new Paddle(this);
            paddle.LoadContent();
            paddle.playerPosition = new Vector2(512, 512);
            paddle.SetHealth(100);
            MaxNPCs = 100;
            npc = new NPC[MaxNPCs];
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            paddle.Update(deltaTime);
            CurrentIndex = 0;
            for (int i = 0; i < MaxNPCs; i++)
            {
                if (npc[i] != null)
                {
                    npc[i].AI();
                    npc[i].center += npc[i].velocity;
                    /* // if you want your npcs to collide with each other
                    for (int j = 0; j < MaxNPCs; j++)
                    {
                        if (npc[i].Colliding(npc[j].hitbox))
                        {
                            npc[i].OnCollide();
                        }
                            }
                    */
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            paddle.Draw(_spriteBatch);
            for (int i = 0; i < MaxNPCs; i++)
            {
                if (npc[i] != null)
                    npc[i].Draw(_spriteBatch);
            }
            base.Draw(gameTime);
        }
    }
}
