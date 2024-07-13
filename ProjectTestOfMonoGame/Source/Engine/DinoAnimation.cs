using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace ProjectTestOfMonoGame.Source.Engine
{
    class DinoAnimation
    {
        private readonly Texture2D texture;
        private readonly List<Rectangle> sourceRectangles = new List<Rectangle>();
        private readonly int frames;
        private int frame;
        private readonly float frameTime;
        private float frameTimeLeft;
        private bool active = true;

        public DinoAnimation(Texture2D texture, int framesX, float frameTime)
        {
            this.texture = texture;
            this.frameTime = frameTime;
            frameTimeLeft = this.frameTime;
            frames = framesX;
            var frameWidth = texture.Width / framesX;
            var frameHeight = texture.Height;

            for (int i = 0; i < frames; i++)
            {
                sourceRectangles.Add(new Rectangle(i * frameWidth, 0, frameWidth, frameHeight));
            }
        }

        public void Stop()
        {
            active = false;
        }

        public void Start()
        {
            active = true;
        }

        public void Reset()
        {
            frame = 0;
            frameTimeLeft = frameTime;
        }

        public void Update(GameTime gt)
        {
            if (!active) return;

            frameTimeLeft -= (float)gt.ElapsedGameTime.TotalSeconds;

            if (frameTimeLeft <= 0)
            {
                frameTimeLeft += frameTime;
                frame = (frame + 1) % frames;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            spriteBatch.Draw(texture, pos, sourceRectangles[frame], Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 1);
        }
    }
}
