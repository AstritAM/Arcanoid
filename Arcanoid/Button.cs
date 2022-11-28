using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arcanoid
{
    class Button : Components
    {
        //Game1 game1;
        private MouseState mouseState1;
        private SpriteFont spriteFont;
        private bool ishovering;
        private MouseState previosMouse;
        private Texture2D texture;

        public event EventHandler Click;
        public bool Clicked { get; private set; }
        public Color Pen { get; set; }
        public Vector2 Posishion { get; set; }
        public Rectangle rectangle
        {
            get => new Rectangle((int)Posishion.X, (int)Posishion.Y, 500, 200);
        }
        public string Text { get; set; }
        public bool IsHoving { get =>ishovering; set=>ishovering=value; }

        public Button(Texture2D _texture,SpriteFont front)
        {
            texture = _texture;
            spriteFont = front;
        
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var color = Color.White;
            if (ishovering)
                color = Color.Gray;
            spriteBatch.Draw(texture, rectangle, color);

            if (!string.IsNullOrEmpty(Text))
            {
                var x = (rectangle.X + (rectangle.Width / 2)) - (spriteFont.MeasureString(Text).X / 2);
                var y= (rectangle.Y + (rectangle.Height/ 2)) - (spriteFont.MeasureString(Text).Y / 2);
                spriteBatch.DrawString(spriteFont, Text, new Vector2(x, y), Color.Black);
            }
        }

        public override void Update(GameTime gameTime)
        {
            previosMouse = mouseState1;
            mouseState1 = Mouse.GetState();
            var mouseRect = new Rectangle(mouseState1.X, mouseState1.Y, 1, 1);
            ishovering = false;
            if (mouseRect.Intersects(rectangle))
            {
                ishovering = true;

                if (mouseState1.LeftButton == ButtonState.Released && previosMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }

        }
    }
}
