using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ProjectTestOfMonoGame.Source.Engine.Cactuses
{
    class FatherCactus
    {
        protected Texture2D cactus;
        protected Rectangle collison;

        protected Vector2 cactus_Position;

        protected float speed = 3f;
        protected int coord;

        public Rectangle Collison
        {
            get { return collison; }
        }

        public int Coord
        {
            set { coord = value; }
        }

        public FatherCactus(int coord)
        {
            cactus = null;
            this.coord = coord;
            cactus_Position = new Vector2(coord, 170);
        }

        public virtual void LoadContent(ContentManager content, string cactusType)
        {
            cactus = content.Load<Texture2D>(cactusType);
        }

        public virtual void Update()
        {
            cactus_Position.X -= speed;

            if (cactus_Position.X <= -1000)
            {
                cactus_Position.X = coord;
            }
            //обновление коллизии
            collison = new Rectangle(
                (int)cactus_Position.X, (int)cactus_Position.Y,
                cactus.Width - 10, cactus.Height - 10
            );
        }

        public void ReplaceCactus(int coordination)
        {
            coord = coordination;
            cactus_Position.X = coord;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(cactus, cactus_Position, Color.White);
        }
    }
}
