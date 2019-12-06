using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTube
{
    class MenuNode
    {
        //each menu node will contain it's list of children and parent
        List<MenuNode> menuItems;
        string name;
        //we need a node type enum
        MenuItem type;

        //properties for names, type and all connected nodes
        public List<MenuNode> MenuItems { get { return menuItems; } }
        public string Name { get { return name; } }
        public MenuItem Type { get { return type; } }
        //constructor
        public MenuNode(string name, MenuItem type)
        {
            this.name = name;
            this.type = type;
            //instantiate the list
            menuItems = new List<MenuNode>();
        }

        //add method
        public void Add(MenuNode child)
        {
            //add the child to the list
            menuItems.Add(child);
        }
    }
}
