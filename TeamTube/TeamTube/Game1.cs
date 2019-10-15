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
    enum GameState
    {
        mainMenu,
        gamePlay,
        moveSelect,
        itemSelect,
        pauseMenu,
        gameOver
    }
    enum MenuState//Item state will be put in at a later time
    {
        attack,
        strongAttack,
        item,
        exit
    }
    enum ItemState
    {
        bomb,
        potion,
        exit
    }
    public class Game1 : Game
    {
        

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //temporary wall and floor texture
        Texture2D wallTexture;
        Texture2D floorTexture;
        Texture2D entranceTexture;
        Texture2D exitTexture;


        //temp player texture
        Texture2D playerTexture;
        Rectangle playerRectangle;

        CharacterController characterController;
        Player player;

        //we need a tile Controller
        TileController tileController;

        //Enum items
        GameState gState;
        MenuState mState;
        ItemState iState;
        KeyboardState kbState;

        //check if items have been picked up
        bool bombActive;
        bool potionActive;
        //Attack selection
        Vector2 exitVector;
        Vector2 attackVector;
        Vector2 strongVector;
        SpriteFont selectionText;

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
            iState = new ItemState();
            kbState = Keyboard.GetState();
            bombActive = false;
            potionActive = false;
            playerRectangle = new Rectangle(new Point(96, 96), new Point(32, 32));
            exitVector = new Vector2(20, 60);
            attackVector = new Vector2(20, 50);
            strongVector = new Vector2(20, 40);
            selectionText = Content.Load<SpriteFont>("AttackFont");
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
            entranceTexture = Content.Load<Texture2D>("entrance");
            exitTexture = Content.Load<Texture2D>("exit");

            //load temp player texture
            playerTexture = Content.Load<Texture2D>("Player_Placeholder");

            //instantiate Tile Controller
            tileController = new TileController(26,26);
            //create first level with filepath 
            tileController.CreateLevel1("..\\..\\..\\..\\Levels\\LevelExample.txt");
            characterController = new CharacterController(26, 26);
            player = new Player(characterController, tileController, 10, playerRectangle, playerTexture);
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
            #region menu logic
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (gState == GameState.mainMenu)
            {
                if (kbState.IsKeyDown(Keys.Enter))
                {
                    gState = GameState.gamePlay;
                }
            }
            if (gState == GameState.gamePlay)
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
            if (gState == GameState.pauseMenu)
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
            if (gState == GameState.moveSelect)
            {//Exiting the menu will be allowed once an attack method has been implemented
                if (mState == MenuState.exit)//Allows scrolling through the menu
                {
                    if (kbState.IsKeyDown(Keys.Up))
                    {
                        mState = MenuState.item;
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
                else if (mState == MenuState.item)
                {
                    if (kbState.IsKeyDown(Keys.Up))
                    {
                        mState = MenuState.attack;
                    }
                    else if (kbState.IsKeyDown(Keys.Down))
                    {
                        mState = MenuState.exit;
                    }
                    else if (kbState.IsKeyDown(Keys.Enter))
                    {
                        gState = GameState.itemSelect;
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
                        mState = MenuState.item;
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
            if (gState == GameState.itemSelect)//Item logic
            {
                if (iState == ItemState.bomb)
                {
                    if (potionActive == true)//What is selected if potion is or isn't activated and down is pressed
                    {
                        //coordinate change
                        if (kbState.IsKeyDown(Keys.Down))
                        {
                            iState = ItemState.potion;
                        }
                    }
                    else
                    {
                        if (kbState.IsKeyDown(Keys.Down))
                        {
                            iState = ItemState.exit;
                        }
                    }
                    if (kbState.IsKeyDown(Keys.Up))//What happens when up is pressed, whethere or not potion is activated
                    {
                        iState = ItemState.exit;
                    }
                    //will put coordinates after assets have been added in.
                }
                else if (iState==ItemState.potion)
                {
                    if (bombActive == true)//What is selected if bomb is or isn't activated and up is pressed
                    {
                        if (kbState.IsKeyDown(Keys.Up))
                        {
                            iState = ItemState.bomb;
                        }
                    }
                    else
                    {
                        if (kbState.IsKeyDown(Keys.Up))
                        {
                            iState = ItemState.exit;
                        }
                    }
                    if (kbState.IsKeyDown(Keys.Down))//What happens when down is pressed, whethere or not bomb is activated
                    {
                        iState = ItemState.exit;
                    }
                }
                else if (iState == ItemState.exit)
                {
                    if (bombActive == true && potionActive == true)//if both items are active
                    {
                        if (kbState.IsKeyDown(Keys.Up))
                        {
                            iState = ItemState.potion;
                        }
                        else if (kbState.IsKeyDown(Keys.Down))
                        {
                            iState = ItemState.bomb;
                        }
                    }
                    else if (bombActive == true && potionActive != true)//if only bomb is active
                    {
                        if (kbState.IsKeyDown(Keys.Up) || kbState.IsKeyDown(Keys.Down))
                        {
                            iState = ItemState.bomb;
                        }
                    }
                    else if (bombActive != true && potionActive == true)//if only potion is active
                    {
                        if (kbState.IsKeyDown(Keys.Up) || kbState.IsKeyDown(Keys.Down))
                        {
                            iState = ItemState.potion;
                        }
                    }
                    if (kbState.IsKeyDown(Keys.Enter))//if enter is pressed, go back to move select
                    {
                        gState = GameState.moveSelect;
                    }
                }
            }

            // TODO: Add your update logic here
            
            #endregion

            kbState = Keyboard.GetState();
            player.Update(kbState);

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

            tileController.DrawLevel(spriteBatch, wallTexture, floorTexture, entranceTexture, exitTexture, 1);
            player.Draw(spriteBatch);
            if (gState == GameState.moveSelect)//What shows up in the attack selection
            {
                if (mState == MenuState.exit)//changes colors if selected
                {
                    spriteBatch.DrawString(selectionText, "Exit", exitVector, Color.Blue);
                }
                else
                {
                    spriteBatch.DrawString(selectionText, "Exit", exitVector, Color.White);
                }
                if (mState == MenuState.attack)
                {
                    spriteBatch.DrawString(selectionText, "Attack", attackVector, Color.Blue);
                }
                else
                {
                    spriteBatch.DrawString(selectionText, "Attack", attackVector, Color.White);
                }
                if (mState == MenuState.strongAttack)
                {
                    spriteBatch.DrawString(selectionText, "Strong Attack", strongVector, Color.Blue);
                }
                else
                {
                    spriteBatch.DrawString(selectionText, "Strong Attack", strongVector, Color.White);
                }                
            }
            //end
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
