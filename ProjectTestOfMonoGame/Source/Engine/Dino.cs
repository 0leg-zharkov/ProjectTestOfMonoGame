using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using ProjectTestOfMonoGame.Source.MyInput;

namespace ProjectTestOfMonoGame.Source.Engine
{
    public class Dino
    {
        private Texture2D texture;
        private Texture2D jump;
        private Texture2D death;
        private Vector2 position;
        private Rectangle collison;
        private DinoAnimation animation;

        private KeyboardState keyState;

        private bool isJump;
        private bool isTop;
        private bool isAlive;

        public Rectangle Collision
        {
            get { return collison; }
        }

        public bool IsAlive
        {
            set { isAlive = value; }
        }

        public Dino()
        {
            texture = null;
            position = new Vector2(10, 170);
            isJump = false;
            isTop = false;
            isAlive = true;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("spritesheet");
            jump = content.Load<Texture2D>("Dino-stand");
            death = content.Load<Texture2D>("Dino-big-eyes");
            animation = new DinoAnimation(texture, 2, 0.1f);
        }

        public void Update(GameTime gt)
        {
            //прыжок
            keyState = MyKeyboard.GetState();
            if (keyState.IsKeyDown(Keys.Space)) if (MyKeyboard.hasNotBeenPressed(Keys.Space)) isJump = true;

            if (isJump)
            {
                if (!isTop) position.Y -= 4;
                else position.Y += 3;
                if (position.Y <= 98) isTop = true;
            }

            if (position.Y == 170)
            {
                isTop = false;
                isJump = false;
            }

            //обновление коллизии
            if (isJump)
            {
                collison = new Rectangle(
                (int)position.X, (int)position.Y - 2,
                texture.Width / 2 - 10, texture.Height - 5
            );
            } 
            else
            {
                collison = new Rectangle(
                (int)position.X - 1, (int)position.Y - 1,
                texture.Width / 2 - 10, texture.Height - 5
            );
            }
            
            animation.Update(gt);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isAlive)
            {
                if (isJump) spriteBatch.Draw(jump, position, Color.White);
                else animation.Draw(spriteBatch, position);
            } else spriteBatch.Draw(death, position, Color.Red);
        }
    }
}
