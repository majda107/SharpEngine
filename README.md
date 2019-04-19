# Sharp engine #

Simple **OpenGL-based** engine written completely in C#.

![Screenshot-01](Images/screenshot01.jpg?raw=true "Screenshot-01")
![Screenshot-02](Images/screenshot02.jpg?raw=true "Screenshot-02")

*Please keep in mind, that this project is in development state!* 

## Already working ##

* Keyboard processor (for processing key-presses)
* Mouse processor
* Camera, including mouse movement
* Inheritance-based object system (Block solid, Cube solid...) 
* Configurable lightning 
* Transparency
* Basic hitbox rendering
* .obj loader
* Implement .mtl loader to .obj loader for textures
* Working hitbox collisions (functions, events...)
* Physics elements (Rigidbody with gravity)

*You can see example of working hitbox collisions and gravity in Game.cs class*

## Planned implementations ##

* Separated cameras (both first and third person)
* On-screen display (crosshair, stats...)
* Font to texture loader
* Fix hitbox rendering related to solid rotation
* Pivot and solid rotation
