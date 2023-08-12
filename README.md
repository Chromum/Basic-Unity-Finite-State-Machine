# Basic Finite State Machine for Unity

This Unity project provides an example of a simple finite state machine (FSM) implementation for an AI bot. The bot follows a patrol route and transitions to chasing the player when spotted. After losing sight of the player, the bot returns to its patrol behavior.

## Features

- Finite state machine implementation.
- AI bot with patrol and chase states.
- Smooth transitions between states.
- Example patrol route and player detection.

## Preview

![](https://github.com/Chromum/Basic-Unity-Finite-State-Machine/blob/main/ReadMeGIF.gif)


## Getting Started

### Installation

# Method 1
1. Download the latest release version from this GitHub.
2. With a unity project open, open the .UnityPackage.
3. Select all the items and press `Import`.

# Method 2

1. Clone this repository: `git clone https://github.com/Chromum/Basic-Unity-Finite-State-Machine.git`
2. Copy the file contents into a pre-existing unity project.
3. Open the project in Unity.

## Usage

1. Open the scene named `SampleScene` in the "Scenes" folder.
5. Press Play to see the bot following its patrol route and reacting to the player.

## Customization

- To modify the patrol route, update the positions of the Flag game objects around the scene
- To add more patrol positions:
  * Duplicate the flag GameObjects.
  * Select the `AI` Object.
  * Under the `Enemy` Component add the new flag object to the `Waypoints` List.
- To adjust bot behavior, examine and modify the states, transitions, actions and decisions in the `Finite State Machine` Folder.

## Resources
- Textures by [Kenney](https://www.kenney.nl/assets/prototype-textures)

## Contact

For questions or feedback, feel free to contact Me at samgreen432@hotmail.com
