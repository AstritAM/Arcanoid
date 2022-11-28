using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Arcanoid
{
    class Ball : GameObject
    {
        public bool gameOver { get; set; }
        public bool   forStart  { get; set; }
        public float Speed { get => speed; set => speed = value; }

        public Ball(Texture2D _texture, Vector2 _position, Rectangle _screen) : base(_texture,_position, _screen)
        {
            speed = 6f;
            gameOver = false;
            forStart = false;
            
        }


       public int k = 0;
        public override void Update(GameTime gameTime)

        {


            if (k == 0)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    direction.X = 1;
                    direction.Y = -1;
                    forStart = true;
                    k++;
                }
            }
            BoundsMovement();
            
            
       
            if (position.Y > screen.Height)
            {
                gameOver = true;

            }
            base.Update(gameTime);
        }

        private void BoundsMovement()
        {
            if (position.X <= 0 || position.X >= screen.Width - texture.Width)
                direction.X *= -1;
            if (position.Y <= 0 )
                direction.Y *= -1;

        }

        public void BallStop()
        {
            direction.X = 0;
            direction.Y = 0;
        }

        public Vector2 StartPosition(Platform platform)
        {

            position.X = platform.gameObjBox.X + platform.gameObjBox.Width/2 - texture.Width/2;

            position.Y = platform.gameObjBox.Y - texture.Height;

            return new Vector2(platform.gameObjBox.X + platform.gameObjBox.Width / 2 - texture.Width / 2, platform.gameObjBox.Y - texture.Height);
        }
        public void PaddelRebound(Platform platform)
        {
            if (this.gameObjBox.Intersects(platform.gameObjBox))
            {
                direction.Y = -1;//platform.gameObjBox.Y - texture.Height;
           

            }
        }
        public void BrickFigth(Brick b)
        {
            if (this.gameObjBox.Intersects(b.gameObjBox))
            {
                direction.Y = -direction.Y;//platform.gameObjBox.Y - texture.Height;
            }

            
        }


       
    }
}
