using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridController : MonoBehaviour {

	public Cell cellPrefab;
	public Cell[,] cells; // array of cells in grid
	private int sizeX = 20; // size and number of columns in x axis
	private int sizeY = 20; // size and number of rows in y axis


	void Awake () {
		SpawnCells (sizeX, sizeY); // create grid with set number of x columns and y row
	}
		
	void SpawnCells (int x, int y) {
		cells = new Cell[x, y]; // create cell array incrementing by 1 world unit in x and y directions
		for (int i = 0; i < x; i++) {
			for (int j = 0; j < y; j++) {
				// create new cell in scene
				Cell c = Instantiate (cellPrefab, new Vector3 ((float)i, (float)j, 0f), Quaternion.identity) as Cell; 
				//get the new cell size and adjust the scale to create small gap between cells
				c.transform.localScale = new Vector2(c.transform.localScale.x/1.1f ,c.transform.localScale.y/1.1f);
				cells [i, j] = c;
				c.Init (this, i, j); // init cell by passing this as parent and transform to it
				c.RandomState (); //sets random state in first instance
			}
		}

		// get and set references to neighbours for every cell
		for (int i = 0; i < x; i++) {
			for (int j = 0; j < y; j++) {
				cells [i, j].neighbours = GetNeighbours (i, j);
			}
		}
	}
		
	// create array with surrounding cells, incrementing x,y coodinates and dividing by columns and rows
	public Cell[] GetNeighbours (int x, int y) {
		Cell[] result = new Cell[8];
		result[0] = cells[x, (y + 1) % sizeY]; // top
		result[1] = cells[(x + 1) % sizeX, (y + 1) % sizeY]; // top right
		result[2] = cells[(x + 1) % sizeX, y % sizeY]; // right
		result[3] = cells[(x + 1) % sizeX, (sizeY + y - 1) % sizeY]; // bottom right
		result[4] = cells[x % sizeX, (sizeY + y - 1) % sizeY]; // bottom
		result[5] = cells[(sizeX + x - 1) % sizeX, (sizeY + y - 1) % sizeY]; // bottom left
		result[6] = cells[(sizeX + x - 1) % sizeX, y % sizeY]; // left
		result[7] = cells[(sizeX + x - 1) % sizeX, (y + 1) % sizeY]; // top left
		return result;
	}

}
