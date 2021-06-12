using Microsoft.Xna.Framework;

namespace GMTK2021
{
   public class Entity
    {
       public Rectangle hitbox;
       public Vector2 center;
        public virtual void SetDefaults() { }
        protected virtual void OnLoad() { }
        public bool Colliding(Rectangle targethitbox)
        {
            return this.hitbox.Intersects(targethitbox);
        }
    }
}
