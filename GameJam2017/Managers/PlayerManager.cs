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
    internal enum CurrentInput
    {
        NoInput, Up, Down, Right, Left
    }
    internal class PlayerManager : GameObject
    {
        public PlayerNumber pNumber;
        private CurrentInput currentInput;
        protected Animation[] animations;
        public Animation currentAnimation;

        public PlayerManager(Vector2 position, Vector2 size, PlayerNumber number) : base(null, position, size, 0f)
        {
            this.animations = new Animation[18];
            this.pNumber = number;
            this.currentInput = CurrentInput.NoInput;

            if (number == PlayerNumber.playerOne)
            {
                animations[1] = new Animation("walk", "Walk Final P1", Vector2.One * 64, 8, 100f);
                this.currentAnimation = animations[1];
            }
            else
            {
                animations[1] = new Animation("walk", "Walk Final P2", Vector2.One * 64, 8, 100f);
                this.currentAnimation = animations[1];
            }
        }

        /// <summary>
        /// Deals with all the movement and animations.
        /// </summary>
        /// <param name="gameTime"></param>
        public void PlayerMovement(GameTime gameTime)
        {
            #region PlayerOne
            if (pNumber == PlayerNumber.playerOne)
            {
                if (InputManager.MovementPlayerOne.Right == ButtonState.Pressed && InputManager.MovementPlayerOne.Left != ButtonState.Pressed)
                {
                    if (currentInput != CurrentInput.Right)
                    {
                        this.currentAnimation.Stop();
                        this.currentAnimation = animations[1];
                        currentInput = CurrentInput.Right;

                    }
                    this.Move(Vector2.UnitX * 0.2f);
                }
                if (InputManager.MovementPlayerOne.Left == ButtonState.Pressed && InputManager.MovementPlayerOne.Right != ButtonState.Pressed)
                {
                    this.Move(-Vector2.UnitX * 0.2f);
                }
                if (InputManager.MovementPlayerOne.Up == ButtonState.Pressed)
                {
                    this.Jump(gameTime);
                }
            }
            #endregion

            #region PlayerTwo
            if(pNumber == PlayerNumber.playerTwo)
            {

            }
            #endregion

            this.currentAnimation.Play(gameTime);
        }

        public void Jump(GameTime gameTime)
        {
            position += speedDirection;

            if (Keyboard.GetState().IsKeyDown(Keys.W) && hasJumped == false)
            {
                this.position.Y += 10f;
                speedDirection.Y = 5f;
                hasJumped = true;
            }

            if (hasJumped == true)
            {
                float airtime = 3;
                speedDirection.Y -= 0.15f * airtime;
            }

            if (position.Y - Texture.Height <= 52)
            {
                hasJumped = false;
            }

            if (hasJumped == false)
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
