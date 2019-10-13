using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TeamTube
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    enum TileType
    {
        Wall,
        floor,
        entrance,
        exit,
        error
    }
    enum GameState
    {
        mainMenu,
        gamePlay,
        moveSelect,
        pauseMenu,
        gameOver
    }
    enum MenuState//Item state will be put in at a later time
    {
        attack,
        strongAttack,
        exit
    }
    public class Game1 : Game
    {
        

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameState gState;
        MenuState mState;
        KeyboardState kbState;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            gState = new GameState();
            mState = new MenuState();
            kbState = Keyboard.GetState();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            while (gState == GameState.mainMenu)
            {
                if (kbState.IsKeyDown(Keys.Enter))
                {
                    gState = GameState.gamePlay;
                }
            }
            while (gState == GameState.gamePlay)
            {
                if (kbState.IsKeyDown(Keys.Space))
                {
                    gState = GameState.pauseMenu;
                }
                if (kbState.IsKeyDown(Keys.F))
                {
                    gState = GameState.moveSelect;
                }
            }
            while (gState == GameState.pauseMenu)
            {
                if (kbState.IsKeyDown(Keys.Enter))
                {
                   gState=GameState.gamePlay;//Returns to Gameplay state if enter is pressed
                }
                else if (kbState.IsKeyDown(Keys.X))
                {
                    gState = GameState.mainMenu;//Returns to menu if x is pressed
                }
            }
            while (gState == GameState.moveSelect)
            {//Exiting the menu will be allowed once an attack method has been implemented
                if (mState == MenuState.exit)//Allows scrolling through the menu
                {
                    if (kbState.IsKeyDown(Keys.Up))
                    {
                        mState = MenuState.attack;
                    }
                    else if (kbState.IsKeyDown(Keys.Down))
                    {
                        mState = MenuState.strongAttack;
                    }
                    else if (kbState.IsKeyDown(Keys.Enter))
                    {
                        gState = GameState.gamePlay;
                    }
                }
                else if (mState == MenuState.attack)
                {
                    if (kbState.IsKeyDown(Keys.Up))
                    {
                        mState = MenuState.strongAttack;
                    }
                    else if (kbState.IsKeyDown(Keys.Down))
                    {
                        mState = MenuState.exit;
                    }
                }
                else if (mState == MenuState.strongAttack)
                {
                    if (kbState.IsKeyDown(Keys.Up))
                    {
                        mState = MenuState.exit;
                    }
                    else if (kbState.IsKeyDown(Keys.Down))
                    {
                        mState = MenuState.attack;
                    }
                }
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
