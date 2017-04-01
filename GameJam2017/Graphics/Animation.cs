using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam2017.Graphics
{
    class Animation
    {
        string name;
        Texture2D spriteTexture;
        int maxFrames;
        int currentFrame;
        int frameRate;

        public Animation(string name, string texture, int numberFrames, int frameRate)
        {
            this.name = name;
            spriteTexture = Game1.content.Load<Texture2D>(texture);
            maxFrames = numberFrames;
            this.frameRate = frameRate;
            currentFrame = 0;
        }

        public void Update()
        {

        }
    }
}
