using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TeamTube
{
    class MenuController
    {
        ///Architecture
        ///Main menu-press space or return to play
        public bool MainMenuUpdate(KeyboardState kbState)//To be put in the update method in Game1 for the menu fsm
        {
            if (kbState.IsKeyDown(Keys.Enter))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        ///MainMenuDraw
        ///pause menu-press space to return to gameplay and x to quit
        public bool PauseMenuUpdate(KeyboardState kbState)
        {
            if (kbState.IsKeyDown(Keys.Enter))
            {
                return true;//Returns to Gameplay state if enter is pressed
            }
            else if (kbState.IsKeyDown(Keys.X))
            {
                return false;//Returns to menu if x is pressed
            }
            else
            {
                return true;
            }
        }
        ///attack menu-different possibilities
        ///     either open up new page or bring up new object-probably object
        ///     if object-new state, 3 different options
        ///     fsm for scrolling
    }
}
