using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GMTK2021
{
  public class NPC : Entity
    {
        int Type;
        Texture2D sprite;
        public Color color = Color.White;
        public float roatation = 0f;
        public SpriteEffects spriteEffects = SpriteEffects.None;
        public float scale = 1f;
        public bool CustomSprite = false;

        protected override void OnLoad()
        {
            SetDefaults();
            if (CustomSprite)
                CustomSpriteFind();
            else
                sprite = Game1.instance.NpcTextures[Type];
            center = Vector2.One;
        }
        public virtual void AI() { }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, center, null, color, roatation, Vector2.Zero,scale, spriteEffects, 0f);
        }
        public virtual void CustomSpriteFind() { }
    }
}
