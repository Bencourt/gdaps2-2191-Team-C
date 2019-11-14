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
        KeyboardState currentKbState;
        KeyboardState previousKbState;
        ///Architecture
        ///Main menu-press space or return to play
        public GameState GameStateUpdate(KeyboardState kbState, KeyboardState prevKbState, GameState current)//To be put in the update method in Game1 for the menu fsm
        {
            //handles all the transition logic for menu states
            currentKbState = kbState;
            previousKbState = prevKbState;
            switch (current)
            {
                case GameState.mainMenu:
                    //return gameplay when enter is single pressed
                    if (SingleKeyPress(Keys.Enter))
                    {
                        return GameState.gamePlay;
                    }
                    //otherwise return mainMenu
                    else
                    {
                        return GameState.mainMenu;
                    }
                    break;
                case GameState.gamePlay:
                    //return pauseMenu when esc is single pressed
                    if (SingleKeyPress(Keys.Escape))
                    {
                        return GameState.pauseMenu;
                    }
                    //if player dies, return gameOver
                    //if(player.isdead)
                    //if exit is reached, return WinState
                    //if(playerlocation = exit)
                    //otherwise return gameplay
                    else
                    {
                        return GameState.gamePlay;
                    }
                    break;
                case GameState.pauseMenu:
                    //if esc is single pressed return gamePlay
                    if (SingleKeyPress(Keys.Escape))
                    {
                        return GameState.gamePlay;
                    }
                    //if backspace is single pressed return mainMenu
                    if (SingleKeyPress(Keys.Back))
                    {
                        return GameState.mainMenu;
                    }
                    //otherwise return pausemenu
                    else
                    {
                        return GameState.pauseMenu;
                    }
                    break;
                case GameState.gameOver:
                    //if enter or esc is single pressed return mainMenu
                    if(SingleKeyPress(Keys.Enter) || SingleKeyPress(Keys.Escape))
                    {
                        return GameState.mainMenu;
                    }
                    //otherwise return gameover
                    else
                    {
                        return GameState.gameOver;
                    }
                    break;
                case GameState.winState:
                    //if enter is single pressed return gameplay
                    if (SingleKeyPress(Keys.Enter))
                    {
                        return GameState.gamePlay;
                    }
                    //if backspace is single pressed return mainmenu
                    if (SingleKeyPress(Keys.Back))
                    {
                        return GameState.mainMenu;
                    }
                    // otherwise return winstate
                    else
                    {
                        return GameState.winState;
                    }
                    break;
                default:
                    //return mainmenu by default
                    return GameState.mainMenu;
                    break;
            }
        }
        //single key press
        public bool SingleKeyPress(Keys key)
        {
            //checks to see if the key is pressed now, but not pressed before
            if (currentKbState.IsKeyDown(key) && previousKbState.IsKeyUp(key))
            {
                return true;
            }
            return false;
        }

    }
}
