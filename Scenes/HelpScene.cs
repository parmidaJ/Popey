using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PJNKFinalProject.GameManagement;
using PJNKFinalProject.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJNKFinalProject.Scenes
{
    public class HelpScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D texture;
        private MonoString pointString;
        private SpriteFont _font;
        private string textHelp;
        public HelpScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            spriteBatch = g.SpriteBatch;
            texture = g.Content.Load<Texture2D>("Images/keyboardArrows");
            _font = g.Content.Load<SpriteFont>("Fonts/regularFont");
            textHelp = 
                "Rules: " +
                "\n -Eat healthy food (colorful) to get points, avoid fastfood (black and white) to not lose points" +
                "\n -Get 20 points for level 2 (heart and will fire activate), 40 for level 3 (countdown will start)," +
                "\n  60 to win , you have 75 seconds in level 3." +
                "\n -If you get -10 points you lose, unless you have hearts in which you lose one heart and" +
                "\n get back to 0 points." +
                "\n -Fire can kill you if you dont have any hearts, if you do, you just lose one heart and " +
                "\n you can continue." +
                "\n -By losing points, you get back to previous level and features get deactivated (timer will stop)" +
                "\n -Press ESC to go back to main menu" +
                "\n\n ";
            Vector2 posVec = new Vector2(10,10);
            pointString = new MonoString(g, spriteBatch, _font, textHelp, posVec, Color.DarkOliveGreen);
            this.Components.Add(pointString);
        }
        //load the text and picture
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, new Vector2(10, _font.MeasureString(textHelp).Y), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
