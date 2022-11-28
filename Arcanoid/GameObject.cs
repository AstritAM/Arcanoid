using SharpDX.DirectWrite;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Arcanoid
{
    class GameObject
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected Vector2 direction;
        protected Rectangle screen;
        protected float speed;
        //Границы обьекта
        public Rectangle gameObjBox { get => new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height); }
                
        public GameObject(Texture2D _texture,Vector2 _position,Rectangle _screen)
        {
            texture = _texture;
            position = _position;
            screen = _screen;
            speed = 0;

        }
        public GameObject(Texture2D _texture, Rectangle _screen)
        {
            texture = _texture;
           
            screen = _screen;
            speed = 0;

        }



        public virtual void Update(GameTime gameTime)
        {
            position += direction * speed;
        }

        public virtual void Draw(SpriteBatch spriteBatch ,Color color)
        {
            spriteBatch.Draw(texture, position,color);
        }

    }
}
