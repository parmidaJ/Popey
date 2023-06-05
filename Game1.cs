using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using PJNKFinalProject.GameManagement;
using PJNKFinalProject.Objects;
using PJNKFinalProject.Scenes;
using PJNKFinalProject.Scenes.InGameScenes;
using SharpDX.Direct3D9;
using System;

namespace PJNKFinalProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private MenuScene _menuScene;
        private Vector2 stage;
        private StartScene _startScene;
        private HelpScene _helpScene;
        private TextScene _loseScene, _winScene, _aboutScene;
        private SoundEffect winSound, levelSound, loseSound;
        private const int POINT_LOSE = -10, POINT_L2 = 20, POINT_L3 = 40, POINT_WIN = 60;

        public SpriteBatch SpriteBatch { get => _spriteBatch; set => _spriteBatch = value; }
        public GraphicsDeviceManager graphics { get => _graphics;}

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        private void hideAllScenes()
        {
            _startScene.hide();
            _helpScene.hide();
            _aboutScene.hide();
            _loseScene.hide();
            _winScene.hide();
        }
        private void resetGame()
        {
            PointsManager.Points = 0;
            PointsManager.PointsHearts = 0;
            PointsManager.Counter = 7500;
            LevelManager.Level=1;
        }
        protected override void Initialize()
        {
            stage = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            levelSound = this.Content.Load<SoundEffect>("Sounds/level");
            winSound = this.Content.Load<SoundEffect>("Sounds/win");
            loseSound = this.Content.Load<SoundEffect>("Sounds/lose");

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _startScene = new StartScene(this);
            this.Components.Add(_startScene);
            _menuScene = new MenuScene(this);
            this.Components.Add(_menuScene);
            _helpScene = new HelpScene(this);
            this.Components.Add(_helpScene);
            _aboutScene = new TextScene(this, "The game \"Popey\" is created by \"Parmida Jahanbani\" and" +
                "\n\n \"Negar Khalaj Moazen\" for the game final project in 2022");
            this.Components.Add(_aboutScene);
            _loseScene = new TextScene(this,"You lost!");
            this.Components.Add(_loseScene);
            _winScene = new TextScene(this, "You won!");
            this.Components.Add(_winScene);

            hideAllScenes();
            _menuScene.show();
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            int index = 0;

            if (_menuScene.Enabled)
            {
                index = _menuScene.MenuComponent.SelectedIndex;
                if (index == 3 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    Exit();
                }
                else if (index == 0 && ks.IsKeyDown(Keys.Enter))
                {
                    _menuScene.hide();
                    _startScene.show();
                }
                else if (index == 1 && ks.IsKeyDown(Keys.Enter))
                {
                    _menuScene.hide();
                    _helpScene.show();
                }
                else if (index == 2 && ks.IsKeyDown(Keys.Enter))
                {
                    _menuScene.hide();
                    _aboutScene.show();
                }
            }
            else if (ks.IsKeyDown(Keys.Escape))
            {
                // hide for all other scenes
                hideAllScenes();
                _menuScene.show();
                resetGame();
            }
            if (PointsManager.Points == POINT_LOSE || PointsManager.PointsHearts < 0)
            {
                if(PointsManager.PointsHearts <= 0)
                {
                    hideAllScenes();
                    _loseScene.show();
                    loseSound.Play();
                    resetGame();
                }
                else
                {
                    PointsManager.PointsHearts--;
                    PointsManager.Points = 0;
                }
            }
            if (PointsManager.Points == POINT_L2)
            {
                LevelManager.Level=2;
                
                if(LevelManager.Second <= 2)
                {
                    LevelManager.Second++;
                    levelSound.Play();
                } 
            }
            if (PointsManager.Points < POINT_L2)
                LevelManager.Level=1;
            
            if (PointsManager.Points == POINT_L3)
            {
                LevelManager.Level=3;
               
                if (LevelManager.Second <= 4)
                {
                    LevelManager.Second++;
                    levelSound.Play();
                }
            }                
            if (PointsManager.Points < POINT_L3 && PointsManager.Points>=POINT_L2)
                LevelManager.Level=2;

            if (PointsManager.Points == POINT_WIN)
            {
                resetGame();
                hideAllScenes();
                _winScene.show();
                winSound.Play();
            }
            if (PointsManager.Counter == 0)
            {
                if(PointsManager.PointsHearts>0)
                    PointsManager.Points += PointsManager.PointsHearts*10;
                
                if(PointsManager.Points< POINT_WIN)
                {
                    resetGame();
                    hideAllScenes();
                    _loseScene.show();
                    loseSound.Play();
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);
            base.Draw(gameTime);
        }
    }
}