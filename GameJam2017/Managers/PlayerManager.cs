﻿using System;
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
        protected Animation[] animations;
        public Animation currentAnimation;

        public PlayerManager(string texture, Vector2 position, Vector2 size,PlayerNumber number) : base(texture, position, size, 0f)
        {
            this.animations = new Animation[18];
            this.pNumber = number;

            this.currentAnimation = new Animation("walk", "Walk P1", Vector2.One * 64, 8, 200f);

            if(number == PlayerNumber.playerOne)
            {
                //animations.Add();
            }
            else
            {
                //animations.Add();
            }
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
                Game1.spriteBatch.Draw(currentAnimation.spriteTexture, this.Rectangle, currentAnimation.currentFrameRec, Color.White);
            }
        }
    }
}
