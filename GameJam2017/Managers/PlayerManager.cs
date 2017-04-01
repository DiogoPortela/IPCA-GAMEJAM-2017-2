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

        public bool isFalling;
        public bool hasJumped;
        private float fallingSpeed;

        //------------->CONSTRUCTORS<-------------//

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

        //------------->FUNCTIONS && METHODS<-------------//


        /// <summary>
        /// Deals with all the movement and animations.
        /// </summary>
        /// <param name="gameTime"></param>
        public void PlayerMovement(GameTime gameTime)
        {
            #region PlayerOne
            if (pNumber == PlayerNumber.playerOne)
            {
                
                //Movement Controls.
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

                #region Y movement
                if (this.Position.Y < this.Size.X)
                {
                    isFalling = false;
                    hasJumped = false;
                    fallingSpeed = 0;
                    this.position.Y = this.Size.X;
                }
                //While it's falling fall.
                if (isFalling)
                {
                    this.Fall(gameTime);
                }

                if (InputManager.MovementPlayerOne.Up == ButtonState.Pressed && !hasJumped)
                {
                    fallingSpeed = 0.7f;
                    isFalling = true;
                    hasJumped = true;
                }
                #endregion
            }
            #endregion

            #region PlayerTwo
            if(pNumber == PlayerNumber.playerTwo)
            {

            }
            #endregion

            this.currentAnimation.Play(gameTime);
        }
        public void Fall(GameTime gameTime)
        {
            position.Y += fallingSpeed;
            if (fallingSpeed > -0.9)
            {
                fallingSpeed -= (0.001f * gameTime.ElapsedGameTime.Milliseconds);
            }
        }
        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (Rectangle.TouchingTopOf(newRectangle))
            {
                Rectangle.Y = newRectangle.Y - Rectangle.Height;
                speedDirection.Y = 0f;
                hasJumped = false;
            }

            if (Rectangle.TouchingLeftOf(newRectangle))
            {
                position.X = newRectangle.X - Rectangle.Width - 2;
            }

            if (Rectangle.TouchingRightOf(newRectangle))
            {
                position.X = newRectangle.X + newRectangle.Width + 2;
            }

            if (Rectangle.TouchingBottomOf(newRectangle))
            {
                speedDirection.Y = 1f;
            }

            if (position.X < 0)
            {
                position.X = 0;
            }

            if (position.X > xOffset - Rectangle.Width)
            {
                position.X = xOffset - Rectangle.Width;
            }

            if (position.Y < 0)
            {
                speedDirection.Y = 1f;
            }

            if (position.Y > yOffset - Rectangle.Height)
            {
                position.Y = yOffset - Rectangle.Height;
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
