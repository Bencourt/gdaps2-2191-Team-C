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
        MenuNode parent;
        List<MenuNode> menuItems;
        string name;
        //we need a node type enum
        MenuItem type;

        //properties for names and all connected nodes
        public MenuNode Parent
        {
            get { return parent; }
            set { parent = value; }
        }
        public List<MenuNode> MenuItems { get { return menuItems; } }
        public string Name { get { return name; } }

        //constructor
        public MenuNode(string name, MenuItem type)
        {
            this.name = name;
            parent = null;
            this.type = type;
            //intantiate the list
            menuItems = new List<MenuNode>();
        }

        //add method
        public void Add(MenuNode child)
        {
            //add the child to the list
            menuItems.Add(child);
            //set the child's parent to this node
            child.Parent = this;
        }
    }
}
