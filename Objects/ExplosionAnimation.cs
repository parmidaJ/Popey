using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJNKFinalProject
{
    public class ExplosionAnimation : DrawableGameComponent
    {
        private SpriteBatch _spriteBatch;
        private Texture2D _texture;
        private Vector2 dimantion, _position, pos;
        private int delay;
        private const int ROWS = 5, COLS = 5;
        private List<Rectangle> frames;
        private int frameIndex = -1, delayCounter = 0;
        private bool show;

        public ExplosionAnimation(Game game, SpriteBatch spriteBatch,
            Texture2D texture, int delay, Vector2 pos, bool show) : base(game)
        {
            _spriteBatch = spriteBatch;
            _texture = texture;
            _position = Vector2.Zero;
            frames = new List<Rectangle>();
            this.delay = delay;
            dimantion = new Vector2(_texture.Width / ROWS, _texture.Height / COLS);

            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    Rectangle current = new Rectangle((int)(j * dimantion.X), (int)(i * dimantion.Y),
                        (int)(dimantion.X), (int)(dimantion.Y));
                    frames.Add(current);
                }
            }

            this.pos = pos;
            this.show = show;
        }
        //load the animation
        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            if (frameIndex >= 0)
                _spriteBatch.Draw(_texture, _position, frames[frameIndex], Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
        //update the animation
        public override void Update(GameTime gameTime)
        {
            if (show && frameIndex == -1)
            {
                frameIndex = 0;
                _position = pos;
                show = false;
            }
            if (frameIndex >= 0)
            {
                delayCounter++;
                if (delayCounter > delay)
                {
                    frameIndex++;
                    delayCounter = 0;

                    if (frameIndex == frames.Count)
                        frameIndex = -1;
                }
            }

            base.Update(gameTime);
        }
    }
}
