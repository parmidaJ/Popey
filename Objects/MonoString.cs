using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJNKFinalProject.Objects
{
    public class MonoString : DrawableGameComponent
    {
        protected SpriteBatch spriteBatch;
        protected SpriteFont spriteFont;
        protected string text;
        protected Vector2 position;
        protected Color color;
        public string Text { get { return text; } set { text = value; } }
        public Vector2 Position { get { return position; } set { position = value; } }
        public MonoString(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont,
            string text, Vector2 position, Color color) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;
            this.text = text;
            this.position = position;
            this.color = color;
        }
        //draw the text on screen
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(spriteFont, text, position, color);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
