# Setup
1. Make sure you are using the latest release of Unity 2018.4 or higher.
2. Create a new empty 2D project.
3. Import Connect from the Asset Store.

Connect is a complete game template, therefore all project settings will already been set up correctly
after the import and no further setup should be required. If you still have problems importing the
project or getting shown any error messages, please check out the Troubleshooting section.

# Run the game
To run the game in the editor, simply open the Menu scene and click the Play button.
![image](https://github.com/InboraStudio/2D-Unity-Colour-Match-Game/assets/96738915/294dee49-068c-41cb-9a5f-31d53b456d6b)

# Build the game
Connect has been build and tested on Windows and Android. The project does not require any
special configuration or setup on your site, other than the normal steps required for every Unity
project. If you have never built a game with Unity, please check out the guides provided by Unity
before reading on.

# Android

To create an Android build, open the Build Settings, select the Android platform and click Build. 

![image](https://github.com/InboraStudio/2D-Unity-Colour-Match-Game/assets/96738915/30e21216-2655-4a7f-9549-612745b5e75e)

# Windows

To create a Windows build, open the Build Settings, select the PC, Mac & Linux Standalone platform
and click Build. Select a build folder and continue. To run the build, execute the Connect.exe file in
the build folder.

![image](https://github.com/InboraStudio/2D-Unity-Colour-Match-Game/assets/96738915/275c02b5-6e51-4d42-a0a3-74fb90e7b8ba)

# Troubleshooting

Depending on the version of Unity, the Android SDK or Windows SDK installed on your system, it
might happen that problems occur when building the game, which are not related to the Connect
project itself. Please check the following questions:
1. Can you build an empty project?
The simplest way to find out if your system is not configured properly to build a project, is to
create a new empty project containing only a sample scene and trying to build it. If this is
not possible, the problem is not related to the Connect project.
2. Can you build the project with Unity 2018.4?
Connect has been developed with Unity 2018.4, therefore we highly recommend using this
version to build it. If you are using a newer version and are encountering problems with
building the project, the easiest way to get everything working might be to go back to
2018.4.
3. Did you modify the project?
If you modified the project, it might be that the problems occurred as a result of these
modifications. To check out if this is the case, create a new project, import Connect and
check if the problems still occur.
If these steps did not help and you are still having problems with the project or getting shown any error messages after the import

# Project Architecture

This section provides to you the most important information about the architecture of the project in
order to understand how the project works.

# Scene structure

The project is split up into the following scenes, which can be found in the “Connect/Scenes” folder:

• Menu
The main menu and starting point of the game
• Settings
Allows the user to configure the volume of the sound effects
• Help
Contains a short description of how to play the game
• Game
The game scene containing all the gameplay logic
• Game Over
Gets loaded after the game has ended and presents the users reached score

We’ve created a script called SceneNames.cs, which holds all scene names. If you need to change the
name of a scene, you only need to propagate the change to this file.

# InitializeOnLoad

Some GameObjects are required by multiple scenes and therefore need to be persistent over the
complete lifecycle of the application:
• Highscore Manager
Holds the players high score and allows other components to access it
• Scene Loading Manager
Allows to smoothly load scenes, by fading an overlay image in and out when a scene is loaded
• SFX Manager
Allows to control the games volume and to play sound effects
• Background Particles
Automatically plays some background particles to improve the games look

These GameObjects are placed in the “Connect/Resources/InitializeOnLoad” folder of the project
and are automatically loaded and initialized by the InitializeOnLoad.cs script, just before the first
scene is loaded. This has the advantage, that no initialization scene is required and greatly increases
the workflow when working on a specific scene.

