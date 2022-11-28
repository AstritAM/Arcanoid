using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arcanoid
{
    public class MenuOptions : GameState
    {
        private List<Components> _components;
        Button newGameBut;
        Button exitGameBut;
        Rectangle rectangle = new Rectangle(45, 60, 500, 300);
        Texture2D texture1;
      //  Button playerGameBut;
        public MenuOptions(Game1 game,ContentManager content) : base(game, content)
        {

        } 
        public override void LoadContent()
        {
            texture1 = _content.Load<Texture2D>("arcanoid11");

            newGameBut = new Button(_content.Load<Texture2D>("butt"), _content.Load<SpriteFont>("Button"))
            {
                Posishion = new Vector2(50, 300),
                Text = "New Game"
            };
            newGameBut.Click += NewGameBut_Click;

            exitGameBut = new Button(_content.Load<Texture2D>("butt"), _content.Load<SpriteFont>("Button"))
            {
                Posishion = new Vector2(50, 500),
                Text = "Exit"
            };
            exitGameBut.Click += ExitGameBut_Click;
            //playerGameBut = new Button(_content.Load<Texture2D>("butt"), _content.Load<SpriteFont>("score"))
            //{
            //    Posishion = new Vector2(50, 300),
            //    Text = "Player"
            //};
            //playerGameBut.Click += PlayerGameBut_Click;

            _components = new List<Components>()
            {
                newGameBut,
               // playerGameBut,
                exitGameBut
            };
        }

        //private void PlayerGameBut_Click(object sender, EventArgs e)
        //{
        //    _game.ChangeState(new PlayGame(_game, _content));
        //}

        private void ExitGameBut_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        private void NewGameBut_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new PlayGame(_game, _content));
        }
        public override void Update(GameTime gameTime)
                {
                    foreach (var component in _components)
                        component.Update(gameTime);
                }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack);

            spriteBatch.Draw(texture1, rectangle, Color.White);
          // spriteBatch.DrawString(_content.Load<SpriteFont>("Button"), $"Arcanoid", new Vector2(160, 50), Color.Black);
          
            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

       

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        
    }
}
