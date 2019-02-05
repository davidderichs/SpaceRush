using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour {

public static Player_Stats Instance;

private static Color32 player_1_color, player_2_color;

	void Awake(){
		this.InstantiatePlayerSettings();
	}

	private void InstantiatePlayerSettings(){
		if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(this);
        } else if(this != Instance) {
            Destroy(this.gameObject);
        }
	}

    public static Color32 Player_1_color {
        
		get {
            return player_1_color;
        }

        set {
            player_1_color = value;
        }
    }

    public static Color32 Player_2_color {

        get {
            return player_2_color;
        }

        set {
            player_2_color = value;
        }
    }
}
