using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Arcanoid
{
    class Platform : GameObject
    {
       //public Rectangle platrec;
        public Platform(Texture2D _texture, Rectangle _screen) : base(_texture, _screen)
        {
            // platrec= new Rectangle(280 ,700,300,800 );
            position = StartPos(); //new Vector2(.Width /2 - texture.Width / 2, platrec.Height -  texture.Height);
            speed = 9f;
            
        }
  
        public override void Update(GameTime gameTime)
        { 
            direction = Vector2.Zero;

            Input();
            BoundsRestriction();
           
            base.Update(gameTime);
        }

        //ограничения игрового поля
        private void BoundsRestriction()
        {
            if (position.X <= 0)
                position.X = 0;
            if (position.X >= screen.Width - texture.Width)
            {
                position.X = screen.Width - texture.Width;
            }
        }
        

        private void Input()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                direction.X = -1;
            if  (Keyboard.GetState().IsKeyDown(Keys.Right))
                    direction.X = 1;
        }

       
        public  Vector2 StartPos()
        {
           
           return  position = new Vector2(screen.Width/2 - texture.Width/2 , screen.Height -2* texture.Height);
        }
    }
}
