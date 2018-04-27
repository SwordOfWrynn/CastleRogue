using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//https://www.youtube.com/watch?v=cQHF4_YPvsM

[System.Serializable]
public class MoneyInfo
{
    public int money;
}

public class CurrencyManager : MonoBehaviour {

    public int money;
    public static CurrencyManager instance = null;


    // Use this for initialization
    private void Start () {

        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        money = 0;
        if (File.Exists(Application.persistentDataPath + "/Money.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Money.dat", FileMode.Open);

            //object myLoadedInfoT = bf.Deserialize(file);
            //Debug.Log(myLoadedInfoT.GetType().FullName);

            MoneyInfo myLoadedInfo = (MoneyInfo)bf.Deserialize(file);
            
            money = myLoadedInfo.money;
        }
        //else
            //money = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnApplicationQuit()
    {
        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Open(Application.persistentDataPath + "/Money.dat", FileMode.OpenOrCreate);
        MoneyInfo myInfo = new MoneyInfo();
        //put what ever you're saving as myInfo.whatever
        myInfo.money = money;
        bf.Serialize(file, myInfo);
        file.Close();
    }
}
