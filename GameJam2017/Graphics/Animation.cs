using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam2017
{
    class Animation
    {
        public string name;
        public Texture2D spriteTexture;
        Vector2 size;
        public Rectangle currentFrameRec;

        int maxFrames;
        int currentFrame;
        float frameRate;
        float LastFrameTime;


        public Animation(string name, string texture, Vector2 size, int numberFrames, float frameRate)
        {
            this.name = name;
            spriteTexture = Game1.content.Load<Texture2D>(texture);
            maxFrames = numberFrames;
            this.frameRate = frameRate;
            currentFrame = 0;
            LastFrameTime = 0;
        }

        public void Play(GameTime gameTime)
        {
            LastFrameTime += gameTime.ElapsedGameTime.Milliseconds;
            if(LastFrameTime > frameRate)
            {
                LastFrameTime -= frameRate;

                currentFrame++;
                LastFrameTime = 0;
                if(currentFrame == maxFrames)
                {
                    currentFrame = 0;
                }
                currentFrameRec = new Rectangle(spriteTexture.Width / maxFrames * currentFrame, 0, (int)size.X, (int)size.Y);
            }
        }
        public void Stop()
        {
            currentFrame = 0;
            LastFrameTime = 0;
        }
    }
}
