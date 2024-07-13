using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace ProjectTestOfMonoGame.Source.Engine
{
    public class Cactus
    {
        private Texture2D cactus1;
        private Texture2D cactus2;
        private Texture2D cactus3;
        private Texture2D cactus4;
        private Texture2D cactus5;
        private Rectangle collison;

        private Vector2 cactus1_Position1;
        private Vector2 cactus1_Position2;
        private Vector2 cactus2_Position1;
        private Vector2 cactus2_Position2;
        private Vector2 cactus3_Position1;
        private Vector2 cactus3_Position2;
        private Vector2 cactus4_Position1;
        private Vector2 cactus4_Position2;
        private Vector2 cactus5_Position1;
        private Vector2 cactus5_Position2;

        private float speed;

        public Rectangle Collison
        {
            get { return collison;}
        }

        public Cactus()
        {
            cactus1 = null;
            cactus2 = null;
            cactus3 = null;
            cactus4 = null;
            cactus5 = null;

            //cactus1_Position1 = new Vector2(0, 170);
            //cactus1_Position2 = new Vector2(1200, 170);
            //cactus2_Position1 = new Vector2(-950, 170);
            //cactus2_Position2 = new Vector2(250, 170);
            //cactus3_Position1 = new Vector2(-500, 170);
            //cactus3_Position2 = new Vector2(700, 170);
            //cactus4_Position1 = new Vector2(-300, 170);
            //cactus4_Position2 = new Vector2(900, 170);
            //cactus5_Position1 = new Vector2(-100, 170);
            //cactus5_Position2 = new Vector2(1100, 170);

            cactus1_Position1 = new Vector2(0, 170);
            cactus1_Position2 = new Vector2(1200, 170);
            cactus2_Position1 = new Vector2(-950, 170);
            cactus2_Position2 = new Vector2(250, 170);
            cactus3_Position1 = new Vector2(-500, 170);
            cactus3_Position2 = new Vector2(700, 170);
            cactus4_Position1 = new Vector2(-300, 170);
            cactus4_Position2 = new Vector2(900, 170);
            cactus5_Position1 = new Vector2(-100, 170);
            cactus5_Position2 = new Vector2(1100, 170);

            speed = 5f;
        }

        public void LoadContent(ContentManager content)
        {
            cactus1 = content.Load<Texture2D>("Cactus-1");
            cactus2 = content.Load<Texture2D>("Cactus-2");
            cactus3 = content.Load<Texture2D>("Cactus-3");
            cactus4 = content.Load<Texture2D>("Cactus-4");
            cactus5 = content.Load<Texture2D>("Cactus-5");
        }

        public void Update()
        {
            ChangePosition();

            if (cactus1_Position1.X <= -1200)
            {
                cactus1_Position1.X = 0;
                cactus1_Position2.X = 1200;
                cactus2_Position1.X = -250;
                cactus2_Position2.X = 950;
                cactus3_Position1.X = -500;
                cactus3_Position2.X = 800;
                cactus4_Position1.X = -400;
                cactus4_Position2.X = 900;
                cactus5_Position1.X = -100;
                cactus5_Position2.X = 1100;
            }

            //обновление коллизии
            collison = new Rectangle(
                (int)cactus1_Position2.X, (int)cactus1_Position2.Y,
                cactus1.Width, cactus1.Height
            );
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(cactus1, cactus1_Position1, Color.White);
            spriteBatch.Draw(cactus1, cactus1_Position2, Color.White);

            spriteBatch.Draw(cactus2, cactus2_Position1, Color.White);
            spriteBatch.Draw(cactus2, cactus2_Position2, Color.White);

            spriteBatch.Draw(cactus3, cactus3_Position1, Color.White);
            spriteBatch.Draw(cactus3, cactus3_Position2, Color.White);

            spriteBatch.Draw(cactus4, cactus4_Position1, Color.White);
            spriteBatch.Draw(cactus4, cactus4_Position2, Color.White);

            spriteBatch.Draw(cactus5, cactus5_Position1, Color.White);
            spriteBatch.Draw(cactus5, cactus5_Position2, Color.White);
        }

        private void ChangePosition()
        {
            cactus1_Position1.X -= speed;
            cactus1_Position2.X -= speed;
            cactus2_Position1.X -= speed;
            cactus2_Position2.X -= speed;
            cactus3_Position1.X -= speed;
            cactus3_Position2.X -= speed;
            cactus4_Position1.X -= speed;
            cactus4_Position2.X -= speed;
            cactus5_Position1.X -= speed;
            cactus5_Position2.X -= speed;
        }
    }
}
