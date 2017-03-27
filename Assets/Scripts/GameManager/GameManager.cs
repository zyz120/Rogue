using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject gameDataManager;
    public GameObject[] maps;

    private GameDataManager dataManager;
    private GameData data;

    void Awake()
    {
        dataManager = gameDataManager.GetComponent<GameDataManager>();

        Instantiate(maps[0], Vector3.zero, Quaternion.identity);

    }

	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.R))
        {
            dataManager.gameData.system_floor++;
            dataManager.Save();
            SceneManager.LoadScene(0);
        }
	}
}
