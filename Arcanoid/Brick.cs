using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arcanoid
{
    class Brick : GameObject
    {
        public Brick(Texture2D _texture, Vector2 _position, Rectangle _screen) : base(_texture, _position, _screen)
        {
            
        }
    }
}
