using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam2017
{
    class Button
    {
        Texture2D texture;
        Vector2 position;
        Rectangle rectangle;
        Color colour = Color.White;
        public Vector2 size;

        bool down;
        public bool isClicked;

        public Button(Texture2D newTexture, GraphicsDevice graphics)
        {
            texture = newTexture;
            size = new Vector2(newTexture.Width,newTexture.Height);
            rectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
        }

        public void Update(MouseState mouse)
        {

            Vector2 mouseXY = new Vector2(mouse.X, mouse.Y);

            if(rectangle.Contains(mouseXY))
            {
                if (colour.A == 255)
                    down = false;
                if (colour.A == 0)
                    down = true;
                if(down)
                {
                    colour.A += 3;
                }
                if(mouse.LeftButton == ButtonState.Pressed)
                {
                    isClicked = true;
                }
            }
            else if(colour.A < 255)
            {
                colour.A += 3;
                isClicked = false;
            }
        }

        public void setPosition(Vector2 newPosition)
        {
            position = newPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, colour);
        }

    }
}
