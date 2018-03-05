# GameOfLife
Conway's Game of Life in Unity

This project contains three scripts:

GridController.cs
Spawns the grid of cells, and finds each cell's neighbors

Cell.cs
Controls each cell's activity depending on rules of game

GameController.cs
Updates cells on click, and restarts game when restart button clicked

Game of Life Instructions

The Game of Life is set in an infinite two-dimensional grid inhabited by “cells”.
Every cell interacts with up to eight neighbours, which are the cells that are
horizontally, vertically, or diagonally adjacent.
From an initial seed grid the game &quot;evolves&quot; one iteration at a time. An iteration
applies rules to the grid to determine its next state. These scenarios are:

Scenario 0: No interactions
Given a game of life
When there are no live cells
Then on the next step there are still no live cells

Scenario 1: Underpopulation
Given a game of life
When a live cell has fewer than two neighbours
Then this cell dies

Scenario 2: Overcrowding
Given a game of life
When a live cell has more than three neighbours
Then this cell dies

Scenario 3: Survival
Given a game of life
When a live cell has two or three neighbours
Then this cell stays alive

Scenario 4: Creation of Life
Given a game of life
When an empty position has exactly three neighbouring cells
Then a cell is created in this position
