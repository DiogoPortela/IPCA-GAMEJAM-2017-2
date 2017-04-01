using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace GameJam2017
{
    internal struct MovementInputPlayerOne
    {
        private ButtonState GetState(Keys key)
        {
            if (Keyboard.GetState().IsKeyDown(key))
                return ButtonState.Pressed;
            return ButtonState.Released;
        }

        public ButtonState Up { get { return GetState(Keys.W); } }
        public ButtonState Down { get { return GetState(Keys.S); } }
        public ButtonState Left { get { return GetState(Keys.A); } }
        public ButtonState Right { get { return GetState(Keys.D); } }
        public ButtonState TimeSwap { get { return GetState(Keys.Space); } }
        public ButtonState Start { get { return GetState(Keys.Escape); } }
        public ButtonState Select { get { return GetState(Keys.Back); } }

    }
    internal struct MovementInputPlayerTwo
    {
        private ButtonState GetState(Keys key)
        {
            if (Keyboard.GetState().IsKeyDown(key))
                return ButtonState.Pressed;
            return ButtonState.Released;
        }

        public ButtonState Up { get { return GetState(Keys.Up); } }
        public ButtonState Down { get { return GetState(Keys.Down); } }
        public ButtonState Left { get { return GetState(Keys.Left); } }
        public ButtonState Right { get { return GetState(Keys.Right); } }
        public ButtonState TimeSwap { get { return GetState(Keys.NumPad0); } }
        public ButtonState Start { get { return GetState(Keys.Escape); } }
        public ButtonState Select { get { return GetState(Keys.Back); } }

        //Buttons1..2..3
    }
    class InputManager
    {
        static public MovementInputPlayerOne MovementPlayerOne = new MovementInputPlayerOne();
        static public MovementInputPlayerTwo MovementPlayerTwo = new MovementInputPlayerTwo();
    }
}
