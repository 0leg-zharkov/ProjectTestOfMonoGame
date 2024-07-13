using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectTestOfMonoGame.Source.Engine;
using ProjectTestOfMonoGame.Source.Engine.Cactuses;
using System.Collections.Generic;

namespace ProjectTestOfMonoGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Menu menu = new Menu();
        private Dino dino = new Dino();
        private Ground ground = new Ground();

        private FatherCactus cactus1 = new FatherCactus(600);
        private FatherCactus cactus2 = new FatherCactus(900);
        private FatherCactus cactus3 = new FatherCactus(1100);

        private List<FatherCactus> cactuses = new List<FatherCactus>();

        private bool isActive;
        private bool isNotRunning;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 600;
            _graphics.PreferredBackBufferHeight = 300;
            _graphics.ApplyChanges();

            isNotRunning = true;
            isActive = false;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            menu.LoadContent(Content);
            dino.LoadContent(Content);
            ground.LoadContent(Content);
            cactus1.LoadContent(Content, "Cactus-1");
            cactus2.LoadContent(Content, "Cactus-2");
            cactus3.LoadContent(Content, "Cactus-5");
            cactuses.Add(cactus1);
            cactuses.Add(cactus2);
            cactuses.Add(cactus3);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (isNotRunning)
            {
                menu.UpdateBegin();
                if (menu.IsBegin)
                {
                    isActive = true;
                    isNotRunning = false;
                }
            }

            if (isActive)
            {
                ground.Update();
                dino.Update(gameTime);
                foreach (FatherCactus cactus in cactuses) cactus.Update();
                Collide();
            }
            else if (!isActive && !isNotRunning)
            {
                menu.UpdateReload();
                if (menu.IsReload)
                {
                    cactus1.ReplaceCactus(600);
                    cactus2.ReplaceCactus(900);
                    cactus3.ReplaceCactus(1100);
                    isActive = true;
                    dino.IsAlive = true;
                    menu.IsReload = false;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();

            if (isNotRunning) menu.DrawBegin(_spriteBatch);
            if (!isActive && !isNotRunning) menu.DrawReload(_spriteBatch);
            dino.Draw(_spriteBatch);
            ground.Draw(_spriteBatch);
            foreach (FatherCactus cactus in cactuses) cactus.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void Collide()
        {
            foreach (FatherCactus cactus in cactuses)
            {
                if (dino.Collision.Intersects(cactus.Collison))
                {
                    isActive = false;
                    dino.IsAlive = false;
                }
            }
        }

        //пока не использую
        private void DrawCactuses()
        {
            foreach (FatherCactus cactus in cactuses)
            {
                int isAbove = 0;
                for (int i = 0; i < cactuses.Count; i++)
                {
                    if (cactuses[i].Collison.Intersects(cactus.Collison))
                    {
                        ++isAbove;
                    }
                }
                if (isAbove == 2)
                {
                    cactus.Coord = -50;
                }
            }
        }
    }
}
