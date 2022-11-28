using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcanoid
{
    class PlayGame : GameState
    {
     //   Rectangle screen;
        Platform platform;
        Ball ball;
        int score = 0;
        SpriteFont spriteFont;
        List<Brick> bricks = new List<Brick>();
        bool vinscreen = false;
        enum GState
        {
            Game,Vin
        }
        GState gState=GState.Game;
        public PlayGame(Game1 game, ContentManager content)
     : base(game, content)
        {

        }
        private void Start()

        {



            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //  if ((j / 2 == 0) && (i / 2 == 0)){
                    var BrickTexture = _content.Load<Texture2D>("brick");

                    bricks.Add(new Brick(BrickTexture, new Vector2((i * BrickTexture.Width) + ((i + 1) * 10), (j * BrickTexture.Height)
                        + ((j + 2) * 10)),Game1. screen));

                }
            }
            ball.k = 0;
            ball.forStart = false;
            ball.gameOver = false;
            score = 0;
            platform.StartPos();
            ball.StartPosition(platform);

        }

       

       

        public override void LoadContent()
        {
            platform = new Platform(_content.Load<Texture2D>("platform20"), Game1.screen);

            ball = new Ball(_content.Load<Texture2D>("ball3"), Vector2.Zero,Game1. screen);
            spriteFont = _content.Load<SpriteFont>("Score");
            Start();
        }


        public override void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                _game.ChangeState(new MenuOptions(_game, _content));
            }

          



               
                platform.Update(gameTime);
                ball.Update(gameTime);
                ball.PaddelRebound(platform);

                if (ball.forStart == false)
                    ball.StartPosition(platform);

                foreach (Brick b in bricks)
                {
                    b.Update(gameTime);
                }

                        
                var ran = new Random();
                       
                        //удар по блокам
                  for (int k = 0; k <bricks.Count; k++)
                  {
                            

                                Brick b = bricks[k];
                                if (ball.gameObjBox.Intersects(b.gameObjBox))
                                {

                                    bricks.RemoveAt(k);
                                    ball.BrickFigth(b);
                                    k--;
                                    score += 1 * 2;
                                }

                        


                    }
                    //  bol = true;

                  if (bricks.Count == 0)
                  { 
                        platform.StartPos();
                                
                       ball.StartPosition(platform);
                        gState = GState.Vin;

                            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                            {
                               
                                
                                _game.ChangeState(new MenuOptions(_game, _content));
                            }
                  }

                if (ball.gameOver)
                {
                    score = 0;
                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        Start();
                    } 
                }
                        
             
        }
    

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            spriteBatch.Begin();



            if (gState == GState.Game)
            {

                platform.Draw(spriteBatch, Color.White);
                ball.Draw(spriteBatch, Color.White);

                foreach (Brick b in bricks)
                {
                    b.Draw(spriteBatch, Color.DarkMagenta);
                }
                spriteBatch.DrawString(spriteFont, $"Score:{score}", new Vector2(10,10), Color.White);

            }
            if (ball.gameOver)
            {

               

                spriteBatch.DrawString(_content.Load<SpriteFont>("Title"), $"Game Over\nPress Space", new Vector2(100, 330), Color.Black);
            }
            if (gState == GState.Vin)
            {



                spriteBatch.DrawString(_content.Load<SpriteFont>("Title"), $"Win\nScore:{score} \nPress Space", new Vector2(100, 330), Color.Black);

            }
            

            spriteBatch.End();

            
        }
    }
}
