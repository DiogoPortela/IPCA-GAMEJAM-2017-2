﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam2017
{
    class Tile : GameObject
    {
        public Vector2 Coordinates;
        public bool isSomethingOnTop;
        public bool isWalkable;


        //------------->CONSTRUCTORS<-------------//

        public Tile(int tileNumber, Vector2 coordinates, int size) : base("Tile" + tileNumber, coordinates * size, new Vector2(size, size), 0f)
        {
            this.Coordinates = coordinates;
        }

        //------------->FUNCTIONS && METHODS<-------------//

        public void DrawTile(SpriteBatch spriteBatch, Camera camera)
        {
            this.Rectangle = camera.CalculatePixelRectangle(Position, Size);
            spriteBatch.Draw(Texture, Rectangle, Color.White);
        }
    }
}
