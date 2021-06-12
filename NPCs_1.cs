using Microsoft.Xna.Framework;

namespace GMTK2021
{
    class NPCs_1 : NPC
    {
        float xPos = 1;
        int speed = 1;

        public override void SetDefaults() // Floating Eye Enemy
        {
            center = new Vector2(20, 20);
        }
        public override void AI()
        {
            xPos += speed;
            center += new Vector2(xPos, 0);

            if (xPos == 5)
            {
                speed = -1;
            }
        }
    }
}
