using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using GameJam2017.Graphics;

namespace GameJam2017
{
    internal enum PlayerNumber
    {
        playerOne = 1, playerTwo
    }
    internal class PlayerManager : GameObject
    {
        public PlayerNumber pNumber;

        public PlayerManager(string texture, Vector2 position, Vector2 size,PlayerNumber number) : base(texture, position, size, 0f)
        {
            this.pNumber = number;
        }
    }
}
