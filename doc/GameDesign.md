# Game Design

## Overview
	A spooky turn based roguelike akin to pokemon mystery dungeon. The player has to manage resources, health, and moves in an attempt to traverse a dungeon.

### Genre
	Roguelike
	strategy
	role playing game
	Gatcha game
	pay to win

### Feature set
	Turn based movement and combat, Menus for attacks and Items. Possible future features include: Multiple items, procedurally generated dungeons and multiple enemies and random encounters

### Game Flow Summary
	Linear game flow, player proceeds from dungeon to dungeon, floor to floor. 

### look and feel
	INTENDED FEEL SHOULD DIRECT THE LOOK
	Spooky yet fun feel. The look of the game should be dark considering the horror setting, but at the same time visual gags and reversals should point to a more whimsical overall feeling.

### Background Story
	Top down rougelike rpg in the theme of darkest dungeon. Takes place in SpookyTown USA in the year 1998. You play as the town mayor trying to get rid of the monsters that have invaded town. The monsters have invaded the sewer system and you have to traverse the levels of tunnels and rooms exterminating the monsters.

### Game world and story
	 Located in United States suburbia in the late 90's, SpookyTown is a humble place full of happy upper-middle class families. Known for their incredible displays of Halloween spirit and rampant consumerism, SpookyTown is the perfect location for a vengeful sewer infestation of evil monsters.

### Character(s)
	Mayor John Mayor: The Mayor of SpookyTown USA, John is a portly politician with a proficiency for pounding monsters. His shiny bald head and bushy mustache light up the darkness and sweep the streets free of evil.

### Objectives
	make a game?
	1. character movement
		-player controller takes in input on the player's turn
		-grid based movement
		-character asset
	2. enemy movement
		-enemy moves along the grid
		-enemy moves only after the player does (on enemy turn)
		-enemy moves toward player
		-enemy asset
		-enemy avoids obstacles to get to player
	3. combat
		-player can attack
		-player's attack expends a turn
		-enemy can take damage and die
		-enemy can attack
		-enemy's attack expends its turn
		-player can take damage and die
		-attack effect
		-player can have multiple attacks
		-enemy can have multiple attacks
	3.5 start menu and ui
	4. items
		-create an item that can be used to heal the player
		-create an item that can damage enemies 
		-create item assets
		-Aoe damage item
		-inventory list
	5. Background art and assets

### Inspiration and References
	- Pokemon Mystery Dungeon
		- Game
		- Good example of roguelike tile based movement and combat with multiple attacks and items
	- Darkest Dungeon
		- Game
		- Theme, art style, feel
	- Hotline Miami
		- Game
		- Setting, art style, feel

## Game Play
	The gameplay is turn based movement and combat, with a limited set of moves and movement options. The goal of each level is to eliminate the monsters and proceed to the next level
    
    the game is played on a level by level basis, where each level consists of a handful of rooms on a square tile grid. the rooms are connected through hallways that are one tile wide. The rooms that have not yet been visited by the player should not yet be visible to the player. Rooms that have not yet been visited by the player will spawn enemies randomly based on how many enemies there are in the level and how many rooms are undiscovered. 
    
    turn structure:
        Player turn
            player can:
            - (stretch goal) change direction they're facing for an attack
            - (stretch goal) look around the level
            - one of the following
                move one space in any direction (no diagonal movement through convex corners)
                use an item
                attack
                
        enemy turn
            if the player is in the same room as the enemy:
            - face the player
            - one of the following:
                move toward the player
                attack if in range
            if the player is in another room
            - move randomly
            
    The player gets minimal information about enemies
    possible low health indicator for enemies
                
### Game Modes
	one mode, dungeon crawl

### Controls
	arrow keys to move, z and x as accept and decline
	c to open menu, arrow keys to navigate menu
    possible extra contols: 
    	Hold s and use the arrow keys to move the camera
	hold d and use the arrow keys to change the direction of the character

### Levels
	minimum viable product- one static level
    		stretch goal 1- multiple static levels
    		stretch goal 2- multiple random levels

### Player(s)
	single player

### Non-playable characters
	enemies

## Assets
	minimum viable product - ground image, wall image, player square, enemy square, item square
    		stretch goal 1 - ground texture, wall texture, player sprite with animation, enemy sprite with animation, item sprite
    		stretch goal 2 - varied ground textures, varied wall textures, multiple enemy sprites, multiple item sprites

### Graphics
	pixel art, 32x32px sprites
    camera follows the player
    		stretch goal 1 - lighting and shadows
			-Lighting has begun to be implemented 
            	stretch goal 2 - camera able to move independently from the player (looking around into previously visited rooms)

### Text
	minimum viable product - menu text at most
    		stretch goal 1 - combat text
    		stretch goal 2 - story text

### Sound
	minimum viable product - no sounds
    		stretch goal 1 - combat sounds and item sounds
    		stretch goal 2 - level music and atmospheric sounds

## Screenshots & Demo Videos


## External References


## monetization plan
	microtransactions out the ass
    		pay to grade
			subscription fees
