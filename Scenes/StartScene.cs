using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PJNKFinalProject.GameManagement;
using PJNKFinalProject.Objects;

namespace PJNKFinalProject.Scenes
{
    public class StartScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D personTex, heartTex, fireTex;
        private Person _person;
        private Heart _heart;
        private Fire _fire;
        private Heart _fixedHeart;
        private Texture2D[] foodTexes = new Texture2D[5];
        private Food[] _foods = new Food[5];
        private Texture2D[] junkFoodTexes = new Texture2D[5];
        private JunkFood[] _junkFoods = new JunkFood[5];
        private CollisionManager _collisionManager;
        private MonoString pointString, pointHeartString, timerString, messageString;
        private SpriteFont _font;
        private string pointText, pointHeartText, timerText, messageText;
        Game1 g;

        public StartScene(Game game) : base(game)
        {
            g = (Game1)game;
            this.spriteBatch = g.SpriteBatch;

            _font = g.Content.Load<SpriteFont>("Fonts/regularFont");

            personTex = g.Content.Load<Texture2D>("Images/person");
            heartTex = g.Content.Load<Texture2D>("Images/heart");
            fireTex = g.Content.Load<Texture2D>("Images/fire");

            foodTexes[0] = g.Content.Load<Texture2D>("Images/foods1");
            foodTexes[1] = g.Content.Load<Texture2D>("Images/foods2");
            foodTexes[2] = g.Content.Load<Texture2D>("Images/foods3");
            foodTexes[3] = g.Content.Load<Texture2D>("Images/foods4");
            foodTexes[4] = g.Content.Load<Texture2D>("Images/foods5");

            junkFoodTexes[0] = g.Content.Load<Texture2D>("Images/junkfoods1");
            junkFoodTexes[1] = g.Content.Load<Texture2D>("Images/junkfoods2");
            junkFoodTexes[2] = g.Content.Load<Texture2D>("Images/junkfoods3");
            junkFoodTexes[3] = g.Content.Load<Texture2D>("Images/junkfoods4");
            junkFoodTexes[4] = g.Content.Load<Texture2D>("Images/junkfoods5");

            Vector2 stageP = new Vector2(g.graphics.PreferredBackBufferWidth + personTex.Width,
                g.graphics.PreferredBackBufferHeight);

            Vector2 stage = new Vector2(g.graphics.PreferredBackBufferWidth,
                g.graphics.PreferredBackBufferHeight);

            Rectangle rectangle = new Rectangle(0, 0, personTex.Width, personTex.Height);
            Rectangle recFood = new Rectangle(0, 0, foodTexes[0].Width, foodTexes[0].Height);
            Rectangle recHeart = new Rectangle(0, 0, heartTex.Width, heartTex.Height);
            Rectangle recFire = new Rectangle(0, 0, fireTex.Width, fireTex.Height);

            _person = new Person(g, spriteBatch, personTex,
                new Vector2(g.graphics.PreferredBackBufferWidth / 2, g.graphics.PreferredBackBufferHeight
                - personTex.Height / 3) , new Vector2(6, 0), stageP, rectangle);
            this.Components.Add(_person);

            _heart = new Heart(g, spriteBatch, heartTex,
                new Vector2(20, 730), new Vector2(0, 1), stage, recHeart);
            this.Components.Add(_heart);

            _fire = new Fire(g, spriteBatch, fireTex, new Vector2(20, 730), new Vector2(0, 2),
                stage, recFire);
            this.Components.Add(_fire);

            _fixedHeart = new Heart(g, spriteBatch, heartTex,
                new Vector2(780, 70), new Vector2(0, 0), stage, recHeart);
            this.Components.Add(_fixedHeart);

            //load all foods and junk foods
            for (int i = 0; i < 5; i++)
            {
                _foods[i] = new Food(g, spriteBatch, foodTexes[i],
                new Vector2(150 * i + 20, g.graphics.PreferredBackBufferHeight / 7 - foodTexes[i].Height),
                new Vector2(0, (i + 1) * 0.4f), stage, recFood);
                this.Components.Add(_foods[i]);

                _junkFoods[i] = new JunkFood(g, spriteBatch, junkFoodTexes[i],
                new Vector2(170 * i + 20, g.graphics.PreferredBackBufferHeight / 7 - junkFoodTexes[i].Height),
                new Vector2(0, (i + 1) * 0.5f), stage, recFood);
                this.Components.Add(_junkFoods[i]);
            }
            //create 5 collision managers
            for (int i = 0; i < 5; i++)
            {
                _collisionManager = new CollisionManager(g,spriteBatch, _person, _foods[i], _junkFoods[i],
                    _heart,_fire, stage);
                this.Components.Add(_collisionManager);
            }
            
            pointText = PointsManager.Points.ToString();
            Vector2 posVec = new Vector2(g.graphics.PreferredBackBufferWidth - _font.MeasureString(pointText).X,
                g.graphics.PreferredBackBufferHeight - _font.MeasureString(pointText).Y);
            pointString = new MonoString(g, spriteBatch, _font, pointText, posVec, Color.Black);
            this.Components.Add(pointString);

            messageText = "Level 1";
            Vector2 posVec4 = new Vector2(10,10);
            messageString = new MonoString(g, spriteBatch, _font, messageText, posVec4, Color.Black);
            this.Components.Add(messageString);

            pointHeartText = " ";
            Vector2 posVec2 = new Vector2(0,0);
            pointHeartString = new MonoString(g, spriteBatch, _font, pointHeartText, posVec2, Color.Black);
            this.Components.Add(pointHeartString);

            timerText = " ";
            Vector2 posVec3 = new Vector2(750, 450);
            timerString = new MonoString(g, spriteBatch, _font, timerText, posVec3, Color.Black);
            this.Components.Add(timerString);
        }
        //update points on screen, heart points, timer countdown, and the level number
        public override void Update(GameTime gameTime)
        {
            pointText = PointsManager.Points.ToString();
            Vector2 posVec = new Vector2(g.graphics.PreferredBackBufferWidth- _font.MeasureString(pointText).X-10,
                _font.MeasureString(pointText).Y+10);

            pointString.Position = posVec;
            pointString.Text = pointText;

            pointHeartText = PointsManager.PointsHearts.ToString();
            
            pointHeartString.Position = new Vector2(750, 55);
            pointHeartString.Text = pointHeartText;

            if (LevelManager.Level == 3)
                PointsManager.Counter--;

            timerText = (PointsManager.Counter / 100).ToString() + " s";
            timerString.Position = new Vector2(760, 450); ;
            timerString.Text = timerText;
            
            messageString.Position = new Vector2(730, 10);
            messageString.Text = "Level " + LevelManager.Level.ToString();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);

            base.Draw(gameTime);
        }
    }
}
