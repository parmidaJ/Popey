using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PJNKFinalProject.Objects;
using Microsoft.Xna.Framework.Graphics;

namespace PJNKFinalProject.GameManagement
{
    public class CollisionManager : GameComponent
    {
        private Person person;
        private Food food;
        private Heart heart;
        private JunkFood junkFood;
        private Random random = new Random();
        private Vector2 stage, animationPos;
        private ExplosionAnimation _explosionAnimation;
        private SpriteBatch spriteBatch;
        private Fire fire;
        private bool animationShow = false;
        Game1 game;

        public CollisionManager(Game game, SpriteBatch spriteBatch, Person person, Food food, JunkFood junkFood,
            Heart heart,Fire fire, Vector2 stage
            ) : base(game)
        {
            this.person = person;
            this.spriteBatch = spriteBatch;
            this.food = food;
            this.junkFood = junkFood;
            this.stage = stage;
            this.game = (Game1)game;
            this.heart = heart;
            this.fire = fire;
        }
        public override void Update(GameTime gameTime)
        {
            //get size of person, food, junk food, fire and hurt
            Rectangle personRect = person.getBounds(), foodRect = food.getBounds(),
                junkFoodRect = junkFood.getBounds(), heartRect = heart.getBounds(),
                fireRect = fire.getBounds();

            //if food hits the ground show explosion effect and reload that food in a random x again
            if (food.Position.Y >= stage.Y)
            {
                animationShow = true;
                animationPos = new Vector2(food.Position.X-40, food.Position.Y-40);

                _explosionAnimation = new ExplosionAnimation(game,
                spriteBatch, game.Content.Load<Texture2D>("Images/explosion"), 1, animationPos,
                animationShow);

                game.Components.Add(_explosionAnimation);
                food.Position = new Vector2(random.Next(20, 700), 0);
            }
            //if junk food hits to ground reload it with a random x
            if (junkFood.Position.Y >= stage.Y)
                junkFood.Position = new Vector2(random.Next(20, 700), 0);
            //if person hits a food, increase points,and reload food
            if (personRect.Intersects(foodRect))
            {
                food.Position = new Vector2(random.Next(20, 700), 0);
                PointsManager.Points++;
            }
            //if person hits junk food, decrease point, reload the junk food, change the number of second
            //for the siund effect to play
            if (personRect.Intersects(junkFoodRect))
            {
                junkFood.Position = new Vector2(random.Next(20, 700), 0);
                PointsManager.Points--;

                switch(LevelManager.Level)
                {
                    case 1:
                        LevelManager.Second = 0;
                        break;
                    case 2:
                        LevelManager.Second = 2;
                        break;
                    case 3:
                        LevelManager.Second = 4;
                        break;
                    default:
                        LevelManager.Second = 0;
                        break;
                }
            }
            //if heart hits the ground, reload it
            if (heart.Position.Y >= stage.Y && LevelManager.Level>=2)
                heart.Position = new Vector2(random.Next(20, 700), 0);
            //if person hits heart, increase heart points, reload heart
            if (personRect.Intersects(heartRect) && LevelManager.Level>=2)
            {
                heart.Position = new Vector2(random.Next(20, 700), 0);
                PointsManager.PointsHearts++;
            }
            //reload fire when it hits the ground
            if (fire.Position.Y >= stage.Y && LevelManager.Level>=2)
                fire.Position = new Vector2(random.Next(20, 700), 0);
            //if person fits fire, decrease heart points
            if (personRect.Intersects(fireRect) && LevelManager.Level>=2)
            {
                fire.Position = new Vector2(random.Next(20, 700), 0);
                PointsManager.PointsHearts--;
            }
            base.Update(gameTime);
        }
    }
}
