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
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            paddle.Update(deltaTime);

            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            paddle.Draw(_spriteBatch);
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
