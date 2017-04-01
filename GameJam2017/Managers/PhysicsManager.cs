using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam2017
{
    class PhysicsManager
    {
        static Vector2 g = new Vector2(0.0f, -9.8f);
        public Vector2 pos, vel, acc, accumForce;
        float dt;
        public float mass;
        public bool USE_GRAVITY = true;

        /* Constructor */
        public PhysicsManager()
        {
            this.mass = 1;
        }

        public void Engage(ref GameTime gameTime, float maxX, float maxY)
        {

            Vector2 F = Vector2.Zero;
            if (USE_GRAVITY)
            {
                F = accumForce + mass * g;
            }

            acc = F / mass;
            dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            vel += acc * dt;// v = u + a*t
            pos += vel * dt;// s = u*t + 0.5*a*t*t,
            pos.X %= maxX;
            pos.Y %= maxY;
            accumForce.X += pos.X;
            accumForce.Y += pos.Y;
        }

        public void ApplyForce(ref Vector2 pos)
        {
            pos += accumForce;
        }
    }
}
