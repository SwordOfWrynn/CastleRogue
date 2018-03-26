using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSelectedPlayer : MonoBehaviour {

    private int selectedPlayer;

	// Use this for initialization
	void Start () {
        if (File.Exists(Application.persistentDataPath + "/SelectedCharacter.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SelectedCharacter.dat", FileMode.Open);
            SelectInfo myLoadedInfo = (UnlockInfo)bf.Deserialize(file);
            selectedPlayer = myLoadedInfo.character;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public class SelectInfo
    {
        public int selectedPlayer;
    }
}
