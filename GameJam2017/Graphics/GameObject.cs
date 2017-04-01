﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam2017
{
    public class GameObject
    {
        protected Texture2D Texture;
        public Vector2 TextureCenter; //For rotations.
        protected Rectangle Rectangle;

        //public Vector2 Position { get; set; }
        protected Vector2 position;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Size { get; set; }
        public float RotationAngle { get; set; }

        protected float speed;
        protected Vector2 speedDirection;
        protected Vector2 objectDiretion;

        public bool isActive { get; set; }    //If it's necessary to turn an object on/off.


        //------------->CONSTRUCTORS<-------------//


        //Empty constructor, therefore is not active.
        public GameObject()
        {
            isActive = false;
        }

        //Constructor with all the atributtes that can be set.
        public GameObject(string texture, Vector2 position, Vector2 size, float rotation)
        {
            if(texture != null)
            {
                this.Texture = Game1.content.Load<Texture2D>(texture);
                this.TextureCenter.X = Texture.Width / 2;
                this.TextureCenter.Y = Texture.Height / 2;
            }
            
            this.Position = position;
            this.Size = size;
            this.RotationAngle = rotation;
            this.speed = 0f;
            this.speedDirection = Vector2.Zero;
            this.objectDiretion = -Vector2.UnitY;
            this.isActive = true;
        }

        //------------->FUNCTIONS && METHODS<-------------//

        /// <summary>
        /// Moves the object in a given direction, with a given speed.
        /// </summary>
        /// <param name="direction">Movement direction.</param>
        /// <param name="speed">Movement speed.</param>
        public void Move(Vector2 direction, float speed)
        {
            if (isActive)
            {
                this.Position += direction * speed;
            }
        }
        /// <summary>
        /// Moves the object in a given direction.
        /// </summary>
        /// <param name="direction">Movement direction.</param>
        public void Move(Vector2 direction)
        {
            if (isActive)
            {
                this.position += direction;
            }
        }
        /// <summary>
        /// Draws object on a camera.
        /// </summary>
        /// <param name="camera">Camera to draw to.</param>
        public virtual void DrawObject(Camera camera)
        {
            if (isActive)
            {
                this.Rectangle = camera.CalculatePixelRectangle(this.position, this.Size);
                Game1.spriteBatch.Draw(this.Texture, this.Rectangle, Color.White);
            }
        }
        public virtual void DrawObjectFree(Camera camera, float size)
        {
            if (isActive)
            {
                this.Rectangle = camera.CalculatePixelRectangle(this.position, this.Size * size);
                Game1.spriteBatch.Draw(this.Texture, this.Rectangle, Color.White);
            }
        }
        ///        
    }
}
