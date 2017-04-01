using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;

namespace GameJam2017
{
    internal enum PlayerNumber
    {
        playerOne = 1, playerTwo
    }
    internal class PlayerManager : GameObject
    {
        public PlayerNumber pNumber;
        protected Texture2D WalkSpriteSheet;

        public PlayerManager(string texture, Vector2 position, Vector2 size,PlayerNumber number) : base(texture, position, size, 0f)
        {
            this.pNumber = number;
        }
        public void Jump(GameTime gameTime)
        {
            position += speedDirection;

            if(Keyboard.GetState().IsKeyDown(Keys.W) && hasJumped == false)
            {
                this.position.Y += 10f;
                speedDirection.Y = 5f;
                hasJumped = true;
            }

            if(hasJumped == true)
            {
                float airtime = 3;
                speedDirection.Y -= 0.15f * airtime;
            }

            if(position.Y - Texture.Height <= 52)
            {
                hasJumped = false;
            }

            if(hasJumped == false)
            {
                speedDirection.Y = 0;
            }
        }

        public override void DrawObject(Camera camera)
        {
            if (isActive)
            {
                this.Rectangle = camera.CalculatePixelRectangle(this.position, this.Size);
                Rectangle source = ;
                Game1.spriteBatch.Draw(this.Texture, this.Rectangle, , Color.White);
            }
        }
    }
}
