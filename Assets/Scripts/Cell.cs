using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cell : MonoBehaviour {

	public enum States {
		Dead, Alive
	}

	public int x, y;
	public Cell[] neighbours;

	public States state;
	private States nextState;

	public GridController grid;


	// called from Grid and sets parent transform
	public void Init (GridController gc, int x, int y) {
		grid = gc;
		transform.parent = gc.transform;

		this.x = x;
		this.y = y;

	}

	// update cells depending on rules of the game
	public void CellUpdate () {
		int aliveCells = GetAliveNeighbours ();
		if (state == States.Alive) { // check if alive
			if (aliveCells < 2 || aliveCells > 3) // if alive cell has less than 2 (underpopulation) and more than three (over population)
				nextState = States.Dead;
		} else { // if dead
			if (aliveCells == 3) // if cell has exactly 3 alive neighbors (creation of life)
				nextState = States.Alive;
		}
		state = nextState;
		//update colour
		UpdateColour ();
	
	}

	// check how many neighbours are alive
	private int GetAliveNeighbours () {
		int aliveCount = 0;
		for (int i = 0; i < neighbours.Length; i++) {
			if (neighbours[i] != null && neighbours [i].state == States.Alive)
				aliveCount++;
		}
		return aliveCount;
	}


	// sets first random state
	public void RandomState () {
		state = (UnityEngine.Random.Range (0.0f, 1.0f) < 0.5f) ? States.Dead : States.Alive;
		UpdateColour ();
	}

	// change cell appearance based on its state
	private void UpdateColour () {
		if (state == States.Alive)
			GetComponent<SpriteRenderer> ().color = Color.green;
		else
			GetComponent<SpriteRenderer> ().color = Color.white;
	}


}

