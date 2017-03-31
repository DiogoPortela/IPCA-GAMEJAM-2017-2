using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameJam2017
{
    class GameState
    {
        static public PlayerManager PlayerOne;
        static public PlayerManager PlayerTwo;

        public GameState()
        {
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
