<p align="center">
  <img width="100%" alt="SpacePong" src="https://github.com/HazzelNat/Space-Pong/blob/main/Screenshot%202024-11-15%20105227.png">  <!--FOTO-->
  </br>
</p>

## 📌INTRODUCTION

Space Pong is a pong game based in space. It has four game modes which are 
 - Single Player - Story Mode
 - Single Player - Vs Bot
 - Two Player - Couch Mode
 - Two Player - Online Multiplayer

## 🎥 GAMEPLAY
<img src="https://github.com/HazzelNat/Space-Pong/blob/main/Space%20Pong.gif" alt="1" style="width:100%;height:auto;">

## 🎮 DOWNLOAD
Itch.io : [https://hazzelnat.itch.io/space-pong](https://hazzelnat.itch.io/space-pong)

## 📋 PROJECT INFO
This project using Unity 2022.3.22f1

| **Role** | **Name** | **Development Time** 
|:-|:-|:-|
| Game Programmer | Hazzel Nathaniel Wu | 7 Days |

##  📜 FEATURES

- Online multiplayer using Photon

|  Script       | Description                                                  |
| ------------------- | ------------------------------------------------------------ |
| `ConnecToServer.cs` | Connect to Photon Server and load the scene|
| `Network.cs` | Instantiates player and start the game if there are two players connected |
| `etc`  | |

## 📂 FILES DESCRIPTION

```
 ├── Space Pong                      # In this Folder, containing all the Unity project files, to be opened by a Unity Editor
   ├── ...
   
   ├── Assets                            # In this folder contains all our code, assets, scenes, etc
      ├── Resources                         # In this folder contains all prefabs which are used for Photon
      ├── Photon                            # In this folder, there are Photon package essentials
      ├── Sprites                           # In this folder, there are 2D sprited used for the game
      ├── ....
   ├── ...
      
```

## 🕹️ GAME CONTROLS

The following controls are bound in-game, for gameplay and testing.

| Key Binding       | Function          |
| ----------------- | ----------------- |
| W, S              | Up and Down (Player 1)      |
| Up Arrow, Down Arrow| Up and Down (Player 2)          |
