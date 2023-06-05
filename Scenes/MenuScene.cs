using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJNKFinalProject.Scenes
{
    public class MenuScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private MenuComponent menuComponent;
        private string[] menuItems = { "Start", "Help", "Credits", "Exit" };
        public MenuComponent MenuComponent { get => menuComponent; }

        public MenuScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            spriteBatch = g.SpriteBatch;
            SpriteFont font1 = g.Content.Load<SpriteFont>("Fonts/hilightFont");
            SpriteFont font2 = g.Content.Load<SpriteFont>("Fonts/regularFont");
            menuComponent = new MenuComponent(g, spriteBatch, font1, font2, 0, menuItems);
            Components.Add(menuComponent);
        }
    }
}
