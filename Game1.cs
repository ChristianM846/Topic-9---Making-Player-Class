using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Topic_9___Making_Player_Class
{
    public class Game1 : Game
    {
        Player amoeba;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        KeyboardState keyboardState;

        Texture2D amoebaTexture;
        Texture2D wallTexture;
        Texture2D foodTexture;

        List<Rectangle> barriers;
        List<Rectangle> food;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            barriers = new List<Rectangle>();
            barriers.Add(new Rectangle(100, 100, 10, 200));
            barriers.Add(new Rectangle(400, 400, 100, 10));

            food = new List<Rectangle>();
            food.Add(new Rectangle(50, 50, 10, 10));
            food.Add(new Rectangle(600, 100, 10, 10));
            food.Add(new Rectangle(50, 200, 10, 10));

            base.Initialize();
            amoeba = new Player(amoebaTexture, 10, 10);


        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            amoebaTexture = Content.Load<Texture2D>("amoeba");
            wallTexture = Content.Load<Texture2D>("rectangle");
            foodTexture = Content.Load<Texture2D>("circle");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            keyboardState = Keyboard.GetState();
            amoeba.HSpeed = 0;
            amoeba.VSpeed = 0;

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                amoeba.VSpeed = -3;
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                amoeba.VSpeed = 3;
            }

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                amoeba.HSpeed = 3;
            }
            else if (keyboardState.IsKeyDown(Keys.Left))
            {
                amoeba.HSpeed = -3;
            }

            amoeba.Update();

            foreach (Rectangle barrier in barriers)
            {
                if (amoeba.Collide(barrier))
                {
                    amoeba.UndoMove();
                }
            }

            for (int i = 0; i < food.Count; i++)
            {
                if (amoeba.Collide(food[i]))
                {
                    amoeba.Grow();
                    food.RemoveAt(i);
                    i--;
                }
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            amoeba.Draw(_spriteBatch);

            foreach (Rectangle barrier in barriers)
            {
                _spriteBatch.Draw(wallTexture, barrier, Color.White);
            }

            foreach (Rectangle bit in food)
            {
                _spriteBatch.Draw(foodTexture, bit, Color.Green);
            }


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}