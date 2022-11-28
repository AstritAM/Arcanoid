using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Arcanoid
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static  Rectangle screen;
      
        //Platform platform;
        //Ball ball;
        //int score=0;
      //  SpriteFont spriteFont; 
        //List<Brick> bricks = new List<Brick>();
        public  int ScreenWidht = 600;
        public  int ScreenHeight = 800;

       // private List<Components> components;
        private GameState _currentState;
        private GameState _nextState;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = ScreenWidht;
            _graphics.PreferredBackBufferHeight = ScreenHeight;
            

            screen = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
        }

        public void ChangeState(GameState state)
        {
            _nextState = state;
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }
       

        protected override void LoadContent()
        {
            #region butt
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _currentState = new MenuOptions(this, Content);
            _currentState.LoadContent();
            _nextState = null;


            #endregion
            //platform = new Platform(Content.Load<Texture2D>("platform20"), screen);

            //ball = new Ball(Content.Load<Texture2D>("ball3"), Vector2.Zero,screen);
            //spriteFont = Content.Load<SpriteFont>("Score");
            // Start();

        }
        #region START

        //private void Start()

        //{



        //    for (int i = 0; i < 9; i++)
        //    {
        //        for (int j = 0; j < 4; j++)
        //        {
        //          //  if ((j / 2 == 0) && (i / 2 == 0)){
        //                var BrickTexture = Content.Load<Texture2D>("brick");

        //                bricks.Add(new Brick(BrickTexture, new Vector2((i * BrickTexture.Width) + ((i + 1) * 10), (j * BrickTexture.Height)
        //                    + ((j + 2) *10)), screen));

        //        }
        //    }
        //    ball.k = 0;
        //    ball.forStart = false;
        //    ball.gameOver = false;
        //    score = 0;
        //   platform.StartPos();
        //    ball.StartPosition(platform);

        //}
        //protected override void UnloadContent()
        //{
        //    platform.Update();
        //}
        #endregion
        protected override void Update(GameTime gameTime)
        {

            
            #region RRR
            //KeyboardState keyState = Keyboard.GetState();
            //KeyboardState presKey= Keyboard.GetState();

            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || keyState.IsKeyDown(Keys.Escape))
            //{

            //}
            //foreach (var comp in components)
            //{
            //    comp.Update(gameTime);
            //}







            //            platform.Update(gameTime);
            //            ball.Update(gameTime);
            //            ball.PaddelRebound(platform);

            //            if (ball.forStart == false)
            //                ball.StartPosition(platform);

            //            foreach (Brick b in bricks)
            //            {
            //                b.Update(gameTime);
            //            }

            //            var ran = new Random();

            //            //удар по блокам
            //            for (int k = 0; k < bricks.Count; k++)
            //            {
            //                Brick b = bricks[k];
            //                if (ball.gameObjBox.Intersects(b.gameObjBox))
            //                {



            //                    bricks.RemoveAt(k);
            //                    ball.BrickFigth(b);
            //                    k--;
            //                    score += 1 * 2;


            //                }
            //            }
            //            if (ball.gameOver)
            //            {
            //                score = 0;
            //                Start();
            //            }


            //presKey = keyState;



            #endregion
            if (_nextState != null)
            {
                _currentState = _nextState;
                _currentState.LoadContent();

                _nextState = null;
            }

            _currentState.Update(gameTime);

            _currentState.PostUpdate(gameTime);


            base.Update(gameTime);
        }

        //string gameTitle = "Arcanoid";
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlueViolet);

           // _spriteBatch.Begin();

            #region gd


            //platform.Draw(_spriteBatch,Color.White);
            //ball.Draw(_spriteBatch, Color.White);

            //foreach (Brick b in bricks)
            //{
            //    b.Draw(_spriteBatch, Color.DarkMagenta);
            //}
            //_spriteBatch.DrawString(spriteFont, $"Score:{score}", new Vector2(10, 10), Color.White);


            #endregion
            _currentState.Draw(gameTime, _spriteBatch);


          //  _spriteBatch.End();

            base.Draw(gameTime);
        }



    }
}
