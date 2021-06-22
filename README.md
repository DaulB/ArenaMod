# ArenaMod
A plugin for making a grid on the floor of an arena. 

The idea for this plugin is that it will allow a user to create a grid on the floor for any arena they choose, adding additional definition on arenas that lack markings on the ground, or for making new markings beyond what the warmarks system allows. 

It will support two different grid types (circular and square) and may or may not automatically populate the arena when you load in.

I'm investigating whether it'll be initialized with a marker, or by getting the player character's location (or the location of a pet, etc). After you get the center of the arena it will create the either grid, and will have a number of units or rings based on your input.

Eventually, there will be support for sharing these layouts, allowing your entire raid to operate off of a shared set of coordinates, making coordination easier on maps where there's basically no definition at all. 
