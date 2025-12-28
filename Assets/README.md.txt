#space shooter prototype
This project is a small space shooter game developed with unity.
the player controls a spaceship,moves using a virtual joystick,
and shoots automatically when enemies are visible on screen.

## Engine & platform
- Unity 6
- Android (Landscape)


## Controls 
- Virtuals joystick on the left side of the screen for movement
- Auto-shoot system handles firing automatically


## Gameplay
- Enemies spawn in waves
- Player has HP and loses health on collision
- Game ends when player HP reaches zero or when enough enemies are destroyed


## Code Structure 
- GameManager 
Handles game status such as playing, pause ,win and lose.

- PlayerController 
Manages player movement and auto-shooting logic.

-EnemyBase
Base class for all enemy types

-EnemySinForward
enemy that moves forward with a sine movement on x axis

- objectPool
Reuses bullets and enemies to improv performance.


## Technical notes 
- Object pooling is used to avoid frequent instantiation
- Input system is used for mobile joystick Input
- All scripts are modular and easy to extend


## How to Run
1. Open the project in Unity Hub
2. Load the main screen
3. Press player

or

Install the APK on an Android device