using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GMTK2021
{
    public class GameObject
    {
        protected string textureName = "Player";
        protected Texture2D texture;
        public int fullWidth;
        public Texture2D healthbar;
        public Texture2D dephealth;
        protected Game game;
        public Vector2 playerPosition = Vector2.Zero;
        public Point playerFrameSize = new Point(16, 16);
        public int actualHealth;

        public GameObject(Game ggame)
        {
            game = ggame;
        }
        public virtual void LoadContent()
        {
            if (textureName != "")
            {
                texture = game.Content.Load<Texture2D>(textureName);
            }
            dephealth = game.Content.Load<Texture2D>("dephealth");
        }

        public virtual void Update(float deltaTime)
        {
            
        }
        public virtual void Draw(SpriteBatch batch)
        {
            if (texture != null)
            {
                Vector2 drawPosition = playerPosition;
                drawPosition.X -= texture.Width / 2;
                drawPosition.Y -= texture.Height / 2;
                Vector2 hbDrawPos = new Vector2(16, 16);
                batch.Begin();
                batch.Draw(texture, drawPosition, Color.White);
                healthbar = new Texture2D(Game1.instance.GraphicsDevice, fullWidth, 10);
                Color[] data = new Color[fullWidth * 10];
                for (int i = 0; i < data.Length; ++i) data[i] = Color.LightGreen;
                healthbar.SetData(data);
                batch.Draw(healthbar, hbDrawPos, Color.LightGreen);
                batch.End();
            }
        }
        public void SetHealth(int maxHealth)
        {
            actualHealth = maxHealth;
            fullWidth = maxHealth;
        }
        public void Hit(int damage)
        {
            actualHealth -= damage;
            fullWidth -= damage;
        }
        public void Kill()
        {
            actualHealth = 0;
        }
    }
}
