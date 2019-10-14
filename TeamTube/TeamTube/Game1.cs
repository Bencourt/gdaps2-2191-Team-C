using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TeamTube
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public enum TileType
    {
        Wall,
        floor,
        entrance,
        exit,
        error
    }
    public class Game1 : Game
    {
        

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //temporary wall and floor texture
        Texture2D wallTexture;
        Texture2D floorTexture;

        //we need a tile Controller
        TileContoller tileContoller;

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

            //load temporary wall and floor assets
            wallTexture = Content.Load<Texture2D>("wall");
            floorTexture = Content.Load<Texture2D>("floor");

            //instantiate Tile Controller
            tileContoller = new TileContoller(26,26);
            //create first level with filepath 
            tileContoller.CreateLevel1("..\\..\\..\\..\\Levels\\LevelExample.txt");

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

            //begin
            spriteBatch.Begin();

            tileContoller.DrawLevel(spriteBatch, wallTexture, floorTexture);

            //end
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
