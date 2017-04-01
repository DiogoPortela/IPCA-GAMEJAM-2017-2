using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GameJam2017
{
    class Camera
    {
        public Matrix transform;
        Vector2 centre;

        /// <summary>
        /// Moves the camera to target position.
        /// </summary>
        /// <param name="position">Position to be moved to.</param>
        public void Update(Vector2 position)
        {
            centre = new Vector2(position.X - (Game1.graphics.PreferredBackBufferWidth / 4), position.Y - (Game1.graphics.PreferredBackBufferHeight/ 2));
            transform = Matrix.CreateScale(new Vector3(1, 1, 0)) * Matrix.CreateTranslation(new Vector3(-centre.X, -centre.Y, 0));
        }
    }
}
