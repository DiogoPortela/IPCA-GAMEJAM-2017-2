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

        //Viewport defaultView;
        Viewport leftView;
        Viewport rightView;

        Camera cameraLeft, cameraRight;

        public GameState()
        {
            Map mapateste = new Map();
            mapateste.Generate();
            leftView = rightView = GraphicsDevice.Viewport;
            leftView.Width /= 2;
            rightView.Width /= 2;
            rightView.X = leftView.Width;

            cameraLeft = new Camera();
            cameraRight = new Camera();

            PlayerOne = new PlayerManager("teste", new Vector2(20, 20), Vector2.One * 25, PlayerNumber.playerOne);
        }
        public void Update()
        {
            if (InputManager.MovementPlayerOne.Right == ButtonState.Pressed)
                PlayerOne.Move(Vector2.UnitX);
            if (InputManager.MovementPlayerOne.Left == ButtonState.Pressed)
                PlayerOne.Move(-Vector2.UnitX);
        }
        public void Draw()
        {
            PlayerOne.DrawObject();
        }
    }
}
