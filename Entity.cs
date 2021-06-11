using Microsoft.Xna.Framework;

namespace GMTK2021
{
    class Entity
    {
        Rectangle hitbox;
        public virtual void SetDefaults() { }
        public virtual void OnLoad() { }
        public bool Colliding(Rectangle targethitbox)
        {
            return this.hitbox.Intersects(targethitbox);
        }
    }
}
