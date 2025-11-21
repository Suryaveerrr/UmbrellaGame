Rhythm Rain: A 3-Lane Rhythm Prototype


This is a 3D rhythm-action prototype built in Unity (URP). The player controls a character in a 3-lane environment, tasked with catching falling musical notes. The game is a "survival mode" challenge where the player must catch every note to keep the music playing.

This project was developed as an iterative internship task, focusing on rapid prototyping, implementing feedback, and building a polished core gameplay loop.

✨ Core Features

3-Lane Rhythm Gameplay: Fast-paced, lane-switching action (Left, Middle, Right).

"Don't Miss" Challenge: A pure survival mode. If a single note hits the floor, the game ends.

Juicy Player Movement: Uses DOTween for smooth, "snappy" easing as the player moves between lanes with a single tap.

Dynamic Note Spawning: Four different types of colored notes (Red, Blue, Green, Yellow) spawn at high speed in one of the three lanes.

Reactive Audio System: Each note color plays a unique, harmonious sound (a C-Major arpeggio), allowing the player to create a melody as they play.

Atmospheric Scene: Built with URP, featuring a custom night sky, reflective "wet" platform, and multi-layered particle systems for rain.

Game Loop: Includes a "Game Over" screen with a functional "Restart" button, and a full ambient audio mix (rain, background music).

🛠️ Tech Stack

Engine: Unity 2022.3 (Universal Render Pipeline - URP)

Language: C#

Key Packages:

DOTween (HOTween v2): Used for all player "snap" movement, creating a fluid, non-linear motion.

TextMeshPro: For all UI text elements.

🎮 How to Play

Move Left: Press 'A' or the Left Arrow key.

Move Right: Press 'D' or the Right Arrow key.

Objective: Catch every falling note.

Lose Condition: If you miss a single note and it hits the floor, the game is over.

📊 Project Status

Status: Alpha Prototype

The core gameplay loop is complete and functional. The game is stable and playable, successfully meeting all current design requirements.

Future Goals:

Implement player animations (Idle, Strafe Left, Strafe Right) to match the movement.

Add a scoring system that rewards consecutive hits.

Create more complex, pre-defined note sequences (beatmaps) instead of random spawning.
