using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJNKFinalProject.Scenes
{
    public class MenuComponent : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont selected, notSelected;
        private Color selectedColor, notSelectedColor;
        private int selectedIndex;
        private string[] menuItems;
        private Vector2 position;
        private KeyboardState oldState;

        public int SelectedIndex { get { return selectedIndex; } }
        public MenuComponent(Game game, SpriteBatch spriteBatch, SpriteFont selected,
            SpriteFont notSelected, int selectedIndex, string[] menuItems) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.selected = selected;
            this.notSelected = notSelected;
            this.selectedIndex = selectedIndex;
            this.menuItems = menuItems;
            selectedColor = Color.Black;
            notSelectedColor = Color.DarkGray;
            this.position = new Vector2(350,100);
        }
        //load all menu options and if its selected, change the font
        public override void Draw(GameTime gameTime)
        {
            Vector2 initPos = position;
            spriteBatch.Begin();
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == selectedIndex)
                {
                    spriteBatch.DrawString(selected, menuItems[i], initPos, selectedColor);
                    initPos.Y += selected.LineSpacing;
                }
                else
                {
                    spriteBatch.DrawString(notSelected, menuItems[i], initPos, notSelectedColor);
                    initPos.Y += notSelected.LineSpacing;
                }
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
        //move the selected option in menu when key up or down is pressed
        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Down) && oldState.IsKeyUp(Keys.Down))
            {
                selectedIndex += 1;
                if (selectedIndex == menuItems.Length)
                    selectedIndex = 0;
            }

            if (ks.IsKeyDown(Keys.Up) && oldState.IsKeyUp(Keys.Up))
            {
                selectedIndex -= 1;
                if (selectedIndex == -1)
                    selectedIndex = menuItems.Length - 1;
            }
            oldState = ks;

            base.Update(gameTime);
        }
    }
}
