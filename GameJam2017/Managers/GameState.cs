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
        static public GameObject teste;

        Viewport defaultView, leftView, rightView;
        Camera cameraLeft, cameraRight;

        public GameState()
        {
            #region map generation
            Map mapateste = new Map();
            //mapateste.Generate();
            #endregion

            #region Camera. Split screen
            //Viewports
            
            defaultView = Game1.graphics.GraphicsDevice.Viewport;
            leftView = rightView = defaultView;

            //Dividing it in half, and adjusting the positioning.
            leftView.Width /= 2;
            rightView.Width /= 2;
            rightView.X = leftView.Width;

            //Initializing cameras.
            cameraLeft = new Camera(Vector2.Zero, 100);
            cameraRight = new Camera(new Vector2(0,0), 100);
            #endregion

            PlayerOne = new PlayerManager("teste", new Vector2(20, 20), Vector2.One * 25, PlayerNumber.playerOne);
            teste = new GameObject("Ground0", new Vector2(0, 75), Vector2.One * 30, 0f);

        }
        /// <summary>
        /// Updates the whole gamestate.
        /// </summary>
        public void Update(GameTime gameTime)
        {
            if (InputManager.MovementPlayerOne.Right == ButtonState.Pressed)
                PlayerOne.Move(Vector2.UnitX);
            if (InputManager.MovementPlayerOne.Left == ButtonState.Pressed)
                PlayerOne.Move(-Vector2.UnitX);
            if (InputManager.MovementPlayerOne.Up == ButtonState.Pressed)
                PlayerOne.Jump(gameTime);
        }
        /// <summary>
        /// Draws the whole gamestate.
        /// </summary>
        public void Draw()
        {
            //Draws the left side
            Game1.graphics.GraphicsDevice.Viewport = leftView;
            DrawCameraView(cameraLeft);

            //Draws the right side
            Game1.graphics.GraphicsDevice.Viewport = rightView;
            DrawCameraView(cameraRight);

            //Draws the whole picture.
            Game1.graphics.GraphicsDevice.Viewport = defaultView;
        }
        /// <summary>
        /// Draws the whole world for one camera.
        /// </summary>
        /// <param name="camera">Target camera to draw.</param>
        void DrawCameraView(Camera camera)
        {
            Game1.spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, camera.transform);  //THIS WAY DOESNT AFFECT PIXEL ASPECT
            PlayerOne.DrawObject(camera);
            teste.DrawObject(camera);
            Game1.spriteBatch.End();
        }
    }
}
