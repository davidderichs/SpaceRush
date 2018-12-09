using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;   

public static class JSONParser {

	public static MoveCards read_Default_Stack_from_JSON(){

		MoveCards cardList = new MoveCards();

		string filePath = Path.Combine(Application.streamingAssetsPath, "../Resources/JSONFiles/default_Movement_Stack");

		if(File.Exists(filePath)){

			string[] objectArray = File.ReadAllLines(filePath);
			string dataAsJson;

			for(int i=0; i<objectArray.Length; i++){
				dataAsJson = objectArray[i];
				MoveCard newMoveCard = JsonUtility.FromJson<MoveCard>(dataAsJson);
				cardList.add_MoveCard(newMoveCard);
			}	

		} else {
			Debug.Log("JSON-File doesn't exist");
		}

		return cardList;
	}
}