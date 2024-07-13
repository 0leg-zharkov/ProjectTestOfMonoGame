using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using ProjectTestOfMonoGame.Source.MyInput;

namespace ProjectTestOfMonoGame.Source.Engine
{
    class Menu
    {
        private Texture2D begin;
        private Texture2D reload;
        private Vector2 position;
        private KeyboardState keyState;

        private bool isBegin;
        private bool isReload;

        public bool IsBegin
        {
            get { return isBegin; }
            set { isBegin = value; }
        }

        public bool IsReload
        {
            get { return isReload; }
            set { isReload = value; }
        }

        public Menu()
        {
            begin = null;
            reload = null;
            isBegin = false;
            isReload = false;
            position = new Vector2(265, 0);
        }

        public void LoadContent(ContentManager content)
        {
            begin = content.Load<Texture2D>("BeginGame");
            reload = content.Load<Texture2D>("ReloadGame");
        }

        public void UpdateBegin()
        {
            keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Space))
            {
                isBegin = true;
            }
        }

        public void UpdateReload()
        {
            keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Space))
            {
                isReload = true;
            }
        }

        public void DrawBegin(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(begin, position, Color.White);
        }

        public void DrawReload(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(reload, position, Color.White);
        }
    }
}
