using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2018_Game_Background_Tester
{
    public class Game1 : Game
    {
        #region Refrences
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Reference
        public static int screenWidth;
        public static int screenHieght;
        public static Vector2 screenMiddle;

        Background1 background;
        Background1 background2;
        Midground midground;
        Foreground foreground;

        Midground debris;

        Player _player;
        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            #region Graphics Control
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            // Reference
            screenWidth = GraphicsDevice.Viewport.Width;
            screenHieght = GraphicsDevice.Viewport.Height;
            screenMiddle = new Vector2(screenWidth / 2, screenHieght / 2);
            #endregion


            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _player = new Player(Content.Load<Texture2D>("MC_Sprite_Sheet_V2_x6_GIMP"), 4, 150, 276);
            _player.position = new Vector2(1500, 672);

            #region Lvl_1_Room_1
            background = new Background1(Content.Load<Texture2D>("Brick_Wall_Background_Shadowed_Lvl_1_Room_1_V2_x6"), new Rectangle(0, 0, 1920, 1080));
            background2 = new Background1(Content.Load<Texture2D>("Brick_Wall_Background_Shadowed_Lvl_1_Room_1_V2_x6"), new Rectangle(0, 0, 1920, 1080));
            midground = new Midground(Content.Load<Texture2D>("Lvl_1_Room_1_Floor_V2_x6_GIMP"), new Rectangle(0, 0, 1920, 1080));
            foreground = new Foreground(Content.Load<Texture2D>("Lvl_1_Room_1_Foreground_V2_x6_GIMP"), new Rectangle(0, 0, 1920, 1080));

            debris = new Midground(Content.Load<Texture2D>("Debris_Pile_Shadowed_x6_GIMP"), new Rectangle((screenWidth - 487), (screenHieght - 528), 402, 258));
            #endregion

        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _player.HandleSpriteMovement(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            background2.Draw(spriteBatch);
            background.Draw(spriteBatch);
            midground.Draw(spriteBatch);

            spriteBatch.Draw(_player.playerTexture, _player.position, _player.playerRec, Color.White, 0f, _player.origin, 1.0f, SpriteEffects.None, 0);

            debris.Draw(spriteBatch);
            foreground.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
