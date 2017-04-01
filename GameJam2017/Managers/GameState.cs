using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam2017
{
    class GameState : Game
    {
        static public PlayerManager PlayerOne;
        static public PlayerManager PlayerTwo;

        Viewport defaultView;
        Viewport leftView;
        Viewport rightView;

        Camera cameraLeft, cameraRight;

        public GameState()
        {
            #region map generation
            Map mapateste = new Map();
            mapateste.Generate();
            #endregion

            #region Camera. Split screen
            //Viewports
            defaultView = GraphicsDevice.Viewport;
            leftView = rightView = GraphicsDevice.Viewport;

            //Dividing it in half, and adjusting the positioning.
            leftView.Width /= 2;
            rightView.Width /= 2;
            rightView.X = leftView.Width;

            //Initializing cameras.
            cameraLeft = new Camera();
            cameraRight = new Camera();
            #endregion

            PlayerOne = new PlayerManager("teste", new Vector2(20, 20), Vector2.One * 25, PlayerNumber.playerOne);
        }
        public void Update()
        {
            if (InputManager.MovementPlayerOne.Right == ButtonState.Pressed)
                PlayerOne.Move(Vector2.UnitX);
            if (InputManager.MovementPlayerOne.Left == ButtonState.Pressed)
                PlayerOne.Move(-Vector2.UnitX);
            cameraLeft.Update(PlayerOne.Position);
        }
        public void Draw()
        {
            //Draws the left side
            GraphicsDevice.Viewport = leftView;
            DrawCameraView(cameraLeft);

            //Draws the right side
            GraphicsDevice.Viewport = rightView;
            DrawCameraView(cameraRight);

            //Draws the whole picture.
            GraphicsDevice.Viewport = defaultView;
        }

        /// <summary>
        /// Draws the whole world for one camera.
        /// </summary>
        /// <param name="camera">Target camera to draw.</param>
        void DrawCameraView(Camera camera)
        {
            Game1.spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, camera.transform);  //THIS WAY DOESNT AFFECT PIXEL ASPECT
            PlayerOne.DrawObject();
            Game1.spriteBatch.End();
        }
    }
}
