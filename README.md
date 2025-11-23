# 🌧️ Rhythm Rain: 3-Lane Rhythm Prototype


> **A high-speed 3D rhythm-action game built as an iterative internship task.**

<img width="1601" height="897" alt="image" src="https://github.com/user-attachments/assets/f71e0b60-f8e8-4147-a2bf-42a6782e359d" />
<img width="1600" height="896" alt="image" src="https://github.com/user-attachments/assets/81a9f131-f908-425f-80d3-2e91672c66d2" />

**Rhythm Rain** is a "survival mode" challenge where the player controls a character in a 3-lane environment, tasked with catching falling musical notes. The goal is perfection: keep the music playing by catching every single note.

---

## 📖 About The Project
This project was developed to focus on **rapid prototyping**, **feedback implementation**, and building a polished **core gameplay loop**.

The scene is built using the **Universal Render Pipeline (URP)**, featuring a custom night sky, a reflective "wet" platform, and multi-layered rain particle systems to create an immersive atmosphere.

---

## ✨ Core Features

* **3-Lane Rhythm Gameplay:** Fast-paced action requiring quick reflexes to switch between Left, Middle, and Right lanes.
* **"Don't Miss" Challenge:** A pure survival mode. If a single note hits the floor, the game ends immediately.
* **Juicy Movement:** Utilizes **DOTween** for smooth, "snappy" easing, making the movement feel responsive and fluid.
* **Dynamic Note Spawning:** Four distinct note types (Red, Blue, Green, Yellow) spawn at high speeds.
* **Reactive Audio:** Each note color triggers a unique harmonious sound (C-Major arpeggio), allowing the player to "build" the melody as they catch notes.

---

## 🛠️ Tech Stack

| Component | Details |
| :--- | :--- |
| **Engine** | Unity 2022.3 (Universal Render Pipeline) |
| **Language** | C# |
| **Animation** | **DOTween (HOTween v2)** - Used for fluid, non-linear player movement. |
| **UI** | TextMeshPro |

---

## 🎮 How to Play

**Objective:** Catch every falling note to keep the music alive.

| Action | Controls |
| :--- | :--- |
| **Move Left** | <kbd>A</kbd> or <kbd>←</kbd> |
| **Move Right** | <kbd>D</kbd> or <kbd>→</kbd> |

**Lose Condition:** If you miss a single note and it touches the floor, the Game Over screen triggers.

---

## 📊 Project Status & Roadmap

**Current Status:** Alpha Prototype
*The core loop is functional, stable, and meets all initial design requirements.*

---
