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
        protected Game game;
        public Vector2 playerPosition = Vector2.Zero;
        public Point playerFrameSize = new Point(16, 16);

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
                batch.Begin();
                batch.Draw(texture, drawPosition, Color.White);
                batch.End();
            }
        }
    }
}
