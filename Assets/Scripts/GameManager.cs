using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private Cell[] cellControllers;

	void Start (){
		cellControllers = GameObject.FindObjectsOfType<Cell> ();
	}

		void Update (){
			//move to next state when mouse clicked
			if (Input.GetMouseButtonDown (0)) {
			foreach (Cell cell in cellControllers) {
				cell.CellUpdate ();		
			}
			}

		}

		public void RestartGame() {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
		}


}
