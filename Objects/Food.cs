using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJNKFinalProject.Objects
{
    public class Food : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D texture;
        private Vector2 position, speed, stage;
        private float scale = 0.5f;
        Rectangle rect;
        public Vector2 Speed { get => speed; set => speed = value; }
        public Vector2 Position { get => position; set => position = value; }

        public Food(Game game, SpriteBatch spriteBatch, Texture2D texture,
            Vector2 position, Vector2 speed, Vector2 stage, Rectangle rect) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.texture = texture;
            this.position = position;
            this.speed = speed;
            this.stage = stage;
            this.rect = rect;
        }
        //move the food
        public override void Update(GameTime gameTime)
        {
            position += speed;

            base.Update(gameTime);
        }
        //load the food
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, rect, Color.LightGray, 0.0f,
                new Vector2(texture.Width / 2, texture.Height / 2), scale, SpriteEffects.None, 0);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        //get size and location of food
        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, texture.Width / 2, texture.Height / 2);
        }
    }
}
