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
    class MenuStack
    {
        //need a stack to hold the nodes
        Stack<MenuNode> stack;
        //current node selected
        int selectedNode;
        //root node
        MenuNode root;

        //need a player to heal/ effect with items
        Player player;

        //constructor
        public MenuStack(MenuNode root, Player player)
        {
            //instantiate the stack
            stack = new Stack<MenuNode>();
            //always start at 0 (first item in menu)
            selectedNode = 0;
            //we need a reference to the root node
            this.root = root;

            this.player = player;
        }

        #region helper methods
        /// <summary>
        /// gets the number of menu items contained in the menu item on top of the stack
        /// </summary>
        /// <returns></returns>
        int TopCount()
        {
            return stack.Peek().MenuItems.Count();
        } 

        /// <summary>
        /// returns true if the key given is just pressed, false if otherwise
        /// </summary>
        /// <param name="current"></param>
        /// <param name="previous"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        bool SingleKeyPress(KeyboardState current, KeyboardState previous, Keys key)
        {
            //return true if key is currently down and previously was up
            if(current.IsKeyDown(key) && previous.IsKeyUp(key))
            {
                return true;
            }
            else //it isn't being pressed just now
            {
                return false;
            }
        }

        /// <summary>
        /// exit to previous will pop the top off of the stack
        /// </summary>
        void Back()
        {
            //remove the top of the stack
            stack.Pop();
            //set selected to 0 for the next menu
            selectedNode = 0;
        }
        /// <summary>
        /// moving to another menu will add the selected menu to the top of the stack
        /// </summary>
        void NextMenu(MenuNode menu)
        {
            //push the next menu
            stack.Push(menu);
            //set selected to 0
            selectedNode = 0;
        }

        /// <summary>
        /// determine whether or not the player has this kind of item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool PlayerHasItemType(Type type)
        {
            //go through each of the items
            foreach(Item item in player.ItemsHeld)
            {
                //check if they are the same type
                if (ReferenceEquals(item.GetType(), type)) 
                {
                    //if so, return true
                    return true;
                }
            }
            //if none of them return true, return false
            return false;
        }

        /// <summary>
        /// uses the first potion in the list if the player has any potions
        /// </summary>
        /// <param name="items"></param>
        /// <param name="player"></param>
        void UsePotion()
        {
            //saves the index of the potion we are using. if the index is null, don't remove anything
            int? indexToRemove = null;

            //check all the elements in the list
            foreach (Item item in player.ItemsHeld)
            {
                //if this one is a potion
                if(item is HealthPotion)
                {
                    HealthPotion potion = (HealthPotion)item;
                    //use it
                    potion.Use(player);
                    //remove it from the list
                    indexToRemove = player.ItemsHeld.IndexOf(item);
                    //don't check anymore elements in the list
                    break;
                }
            }
            //remove the item if the index isn't null
            if(indexToRemove != null)
            {
                int valueInt = (int)indexToRemove;
                player.ItemsHeld.RemoveAt(valueInt);
            }
        }
        #endregion

        #region update
        //big update method, it is true if the menu is open, it is false if the menu is closed
        public bool update(KeyboardState current, KeyboardState previous)
        {
            //if the stack is empty 
            if(stack.Count == 0)
            {
                //check if the player is pressing f
                if (SingleKeyPress(current, previous, Keys.F))
                {
                    //if so, push the root to the stack
                    stack.Push(root);
                    return true;
                }
                else //dont do the rest of this method, the menu isn't open
                {
                    return false;
                }
            }


            //get the top count of the menu items once for this whole method
            int topcount = TopCount();

            //update the menu item that is selected
            //if F is pressed when a menu item is selected, ACTIVATE IT
            if (SingleKeyPress(current, previous, Keys.F))
            {
                //activate the menu item
                switch (stack.Peek().MenuItems.ElementAt<MenuNode>(selectedNode).Type) //switch case based on what kind of menu item is selected
                {
                    case MenuItem.menu:
                        //adds the selected menu to the top of the stack
                        NextMenu(stack.Peek().MenuItems.ElementAt<MenuNode>(selectedNode));
                        break;
                    case MenuItem.back:
                        //remove the top of the stack 
                        Back();
                        break;
                    case MenuItem.item:
                        //case for type of item
                        switch (stack.Peek().MenuItems.ElementAt<MenuNode>(selectedNode).Name)
                        {
                            case "use health potion":
                                //use a health potion if we got one
                                UsePotion();
                                break;
                        }

                        break;
                    case MenuItem.attack:
                        //do something real specific

                        break;
                }
            }

            //check if W or S is single pressed and increase or derease accordingly (allows player scrolling through menu)
            if (SingleKeyPress(current, previous, Keys.Up))
            {
                //lower the selected node by 1
                selectedNode--;
                 
            }
            if (SingleKeyPress(current, previous, Keys.Down))
            {
                //increase the selected node by 1
                selectedNode++;
            }

            //make sure that the selected node is within the index of the topcount
            // if the selected node is less than 0, then set the selected node to topcount -1 
            if (selectedNode < 0)
            {
                selectedNode = topcount - 1;
            }
            //if the selected node is greater than topcount, then set the selected node to 0
            if (selectedNode >= topcount)
            {
                selectedNode = 0;
            }

            //the menu is open
            return true;
        }
        #endregion

        #region draw
        //draw
        public void Draw(SpriteBatch sb, Texture2D menuTexture, SpriteFont font)
        {
            //if the stack is empty don't do anything
            if(stack.Count == 0)
            {
                return;
            }

            //first, draw the menu box
            sb.Draw(menuTexture,new Rectangle(0,5,200,300),Color.White);

            //then display all the text
            //name of the menu
            sb.DrawString(font, stack.Peek().Name, new Vector2(35, 15), Color.White,0,Vector2.Zero,2,SpriteEffects.None,0);
            //all the menu items
            int spacing = 1;
            foreach(MenuNode node in stack.Peek().MenuItems)
            {
                //if it is at selected index, make it yellow
                if (node == stack.Peek().MenuItems.ElementAt<MenuNode>(selectedNode))
                {
                    sb.DrawString(font, node.Name, new Vector2(35, (spacing * 30) + 50),Color.Yellow, 0, Vector2.Zero, 2, SpriteEffects.None, 0);
                }
                else //otherwise make it white
                {
                    sb.DrawString(font, node.Name, new Vector2(25, (spacing * 30) + 50), Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 0);
                }

                //if it is an item, and we don't have any of that kind, make it red
                if (node.Type == MenuItem.item)
                {
                    //switch case determining what kind of item it is
                    //case for type of item
                    switch (node.Name)
                    {
                        case "use health potion":
                            //check if player has any health potions
                            if (!PlayerHasItemType(typeof(HealthPotion)))
                            {
                                //if they don't, put a red x next to it
                                sb.DrawString(font, "X", new Vector2(5, (spacing * 30) + 50), Color.Red, 0, Vector2.Zero, 2, SpriteEffects.None, 0);
                            }
                            break;
                    }
                }
                spacing++;
            }
        }
        #endregion
    }
}
