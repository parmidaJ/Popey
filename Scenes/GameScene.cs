﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJNKFinalProject.Scenes
{
    public abstract class GameScene : DrawableGameComponent
    {
        public List<GameComponent> Components { get; set; }
        public GameScene(Game game) : base(game)
        {
            Components = new List<GameComponent>();
            hide();
        }
        //visible
        public virtual void show()
        {
            Visible = true;
            Enabled = true;
        }
        //not visible
        public virtual void hide()
        {
            Visible = false;
            Enabled = false;
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            DrawableGameComponent component = null;
            foreach (GameComponent gc in Components)
            {
                if (gc is DrawableGameComponent)
                {
                    component = (DrawableGameComponent)gc;
                    if (component.Visible)
                        component.Draw(gameTime);
                }
            }
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach (GameComponent gc in Components)
            {
                if (gc.Enabled)
                    gc.Update(gameTime);
            }
        }
    }
}
