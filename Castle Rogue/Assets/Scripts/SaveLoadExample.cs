using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadExample : MonoBehaviour
{
    public int unlock = 0;
    
    void Start()
    {
        unlock = PlayerPrefs.GetInt("unlock");
    }
    //Save the player info out to a binary file
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Open(Application.persistentDataPath + "/File Name Here No Space.dat", FileMode.OpenOrCreate);
        UnlockInfo myInfo = new UnlockInfo();

        //put what ever you're saving as myInfo.whatever
        myInfo.unlock = unlock;
        bf.Serialize(file, myInfo);
        file.Close();
    }
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/File Name Here No Space.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/File Name Here No Space.dat", FileMode.Open);
            UnlockInfo myLoadedInfo = (UnlockInfo)bf.Deserialize(file);
            unlock = myLoadedInfo.unlock;
        }
    }
    [System.Serializable]
    public class UnlockInfo
    {
        public int unlock;
    }
}