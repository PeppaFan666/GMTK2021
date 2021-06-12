using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GMTK2021
{
    public class Paddle : GameObject
    {
        public Paddle(Game ggame) :
   base(ggame)
        {
            textureName = "Player";
        }
        public float speed = 500;
        public override void Update(float deltaTime)
        {
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.W))
            {
                playerPosition.Y -= speed * deltaTime;
            }
            if (keyState.IsKeyDown(Keys.S))
            {
                playerPosition.Y += speed * deltaTime;
            }
            if (keyState.IsKeyDown(Keys.A))
            {
                playerPosition.X -= speed * deltaTime;
            }
            if (keyState.IsKeyDown(Keys.D))
            {
                playerPosition.X += speed * deltaTime;
            }
            base.Update(deltaTime);
        }
    }
}
