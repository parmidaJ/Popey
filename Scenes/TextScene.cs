using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using PJNKFinalProject.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJNKFinalProject.Scenes.InGameScenes
{
    public class TextScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private MonoString pointString;
        private SpriteFont _font;
        public TextScene(Game game, string text) : base(game)
        {
            Game1 g = (Game1)game;
            spriteBatch = g.SpriteBatch;
            _font = g.Content.Load<SpriteFont>("Fonts/regularFont");
            Vector2 posVec = new Vector2(10, 10);
            pointString = new MonoString(g, spriteBatch, _font, text, posVec, Color.DarkOliveGreen);
            this.Components.Add(pointString);
        }
    }
}
