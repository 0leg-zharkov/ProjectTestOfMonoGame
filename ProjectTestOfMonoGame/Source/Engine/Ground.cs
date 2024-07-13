using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using ProjectTestOfMonoGame.Source.Engine.Cactuses;

namespace ProjectTestOfMonoGame.Source.Engine
{
    public class Ground
    {
        private Texture2D texture;
        private Vector2 position1;
        private Vector2 position2;

        //private FatherCactus cactus1;
        //private FatherCactus cactus2;
        //private FatherCactus cactus3;
        //private FatherCactus cactus4;
        //private FatherCactus cactus5;

        private float speed;

        public Ground()
        {
            texture = null;
            speed = 3f;
            position1 = new Vector2(0, 200);
            position2 = new Vector2(1200, 200);

            //cactus1 = new FatherCactus(0, 1200);
            //cactus2 = new FatherCactus(-600, 600);
            //cactus3 = new FatherCactus(-200, 1000);
            //cactus4 = new FatherCactus(-300, 900);
            //cactus5 = new FatherCactus(-150, 1050);
            //cactus1 = new FatherCactus(0, 600);
            //cactus2 = new FatherCactus(-600, 900);
            //cactus3 = new FatherCactus(-200, 1100);
            //cactus4 = new FatherCactus(-300, 1700);
            //cactus5 = new FatherCactus(-150, 2000);
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Ground");
            //cactus1.LoadContent(content, "Cactus-1");
            //cactus2.LoadContent(content, "Cactus-2");
            //cactus3.LoadContent(content, "Cactus-3");
            //cactus4.LoadContent(content, "Cactus-4");
            //cactus5.LoadContent(content, "Cactus-5");
        }

        public void Update()
        {
            position1.X -= speed;
            position2.X -= speed;

            if (position1.X <= -1200)
            {
                position1.X = 0;
                position2.X = 1200;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position1, Color.White);
            spriteBatch.Draw(texture, position2, Color.White);
        }
    }
}
