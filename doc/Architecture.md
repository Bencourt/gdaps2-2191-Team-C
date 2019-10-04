# Architecture

## Overview
  The architecture sheet will serve as a rough guide for when we create the actual program itself.

## General Approach
  Our general approach is to create a document containing the basic framework of the game, and to create flow charts describing the different classes and methods and how they will interact

## State Machine(s)
  We will utilize state machines for the game state (switching between menus, playing game, etc), The player state (attacking, moving, waiting for turn, etc) and the enemy state (attacking, moving, pathfinding, etc)
  see images below

## OO Design
  We will have parent classes for things like characters, Items, and walls. We will also use interfaces such as iDamagable and iMovable to better implement each object. We are also considering using something like a singleton to act as an enemy manager to keep track of our different enemies

## External Tool
  Our plan for an external tool is to use Windows Forms to create a level editor

## Images
![Game state flowchart](doc/Game state fsm.png)
![Gameplay flowchart](doc/Gameplay FSM.png)
