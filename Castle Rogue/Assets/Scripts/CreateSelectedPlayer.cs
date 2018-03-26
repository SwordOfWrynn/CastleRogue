﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class CreateSelectedPlayer : MonoBehaviour {

    private int character;

    public GameObject[] characterPrefabs;
	// Use this for initialization
	void Start () {
        if (File.Exists(Application.persistentDataPath + "/SelectedCharacter.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SelectedCharacter.dat", FileMode.Open);
            SelectInfo myLoadedInfo = (SelectInfo)bf.Deserialize(file);
            character = myLoadedInfo.character;
        }
        else
            character = 0;
        Instantiate(characterPrefabs[character], new Vector3(0f, 0f, 0f), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public class SelectInfo
    {
        public int character;
    }
}
