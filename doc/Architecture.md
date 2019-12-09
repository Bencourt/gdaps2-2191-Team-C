# Architecture

## Overview
  The architecture sheet will serve as a rough guide for when we create the actual program itself.

## General Approach
  Our general approach is to create a document containing the basic framework of the game, and to create flow charts describing the different classes and methods and how they will interact

## State Machine(s)
  We will utilize state machines for the game state (switching between menus, playing game, etc), The player state (attacking, moving, waiting for turn, etc) and the enemy state (attacking, moving, pathfinding, etc)
  see images below
  Our current implementation of gamestates contains basic menus such as pause, main menu, gameover and a winstate, which transition between each other and the gameplay state based on the player's input. 

## OO Design
  We will have parent classes for things like characters, Items, and walls. We will also use interfaces such as iDamagable and iMovable to better implement each object. We are also considering using something like a singleton to act as an enemy manager to keep track of our different enemies
  Our most important managing classes are our Controllers. Our controllers each have a function specific to one or more of our classes, and their function is to manage the objects that inherit from these classes.
  Our TileController holds a list of "Tile arrays" which hold the levels used by our game. Tile controller loads in text files, using file.io and arranges them in a neat tile array to be drawn, searched and interacted with.
  Our GameStateController contains all of the gamestate logic needed to swap between the mainmenu, gamplay, pause menu, gaveover menu, and win menu. This way we can make the update method in game1 without cluttering the method with confusing code, we can simply call it once at the end.
  Our CharacterController manages the movement of our player and our enemies as well as the attack functionality for our player.
  Our last milestone came with it a tree and stack of menu nodes to give the player a potentially near limitless depth of menu options.
  

## External Tool
  Our external tool can load, edit and save a text file full of numbers, which represent tiles. These text files can be read by our TileController, passing them into our game to use.

## Images
![Game state flowchart](doc/Game state fsm.png)
![Gameplay flowchart](doc/Gameplay FSM.png)
