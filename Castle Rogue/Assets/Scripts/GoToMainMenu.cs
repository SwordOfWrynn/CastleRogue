using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GoToMainMenu : MonoBehaviour {

	public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Reset()
    {
        File.Delete(Application.dataPath + "/Purchases.dat");
    }
}
