# YachtGame
2D Platformer where you avoid generic recruiters by using C# code.

The idea of the game is to have a basic platformer game which instead of with the arrowkeys, is controlled by loading in a decisionmaking script,
which will determine how your character will beat the level. 

At the moment, the base game and most of it's functionalities like walking, jumping, and dying are functional. Refactoring and documentation are
the biggest things to work upon right now. 

As for the player generated code, the player will be given a class to fill in to their own heart's desire, with one constraint. They will have to provide
a decision about what to do for every frame of the game, being either walking, jumping, or sometimes standing still, and give it as the return value
of a function with the following signature:

public Decision MakeDecision(WorldInfo info)

Decision will most likely be a enum with all movement options available to the player.
WorldInfo will contain all relevant information about the current level, such as all positions of all gameObjects, a timer, level completion requirements etc.

Using this information, the player will write their own class making use of all functionality .NET 4.x provides, through the use of a console provided
in the game. 
