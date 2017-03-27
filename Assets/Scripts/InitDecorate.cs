using UnityEngine;
using System.Collections;

public class InitDecorate : MonoBehaviour {

    public GameObject[] decorates;
    private GameData data;

    void Awake()
    {
        Invoke("GetData", 0.5f);
    }

    void GetData()
    {
        data = GameObject.Find("GameDataManager").GetComponent<GameDataManager>().gameData;

        // int total = Random.Range(30, 50);        
        int total = data.system_floor * 10;
        int length = decorates.Length;
        for (int i = 0; i <= total; i++)
        {
            GameObject go = Instantiate(decorates[(int)(Random.Range(0, length - 0.1f))], Vector3.zero, Quaternion.identity) as GameObject;
            go.transform.position = new Vector3((int)(Random.Range(-11, 11.9f)), (int)(Random.Range(-11, 11.9f)), -1);
            go.transform.localScale = new Vector3(Random.Range(0, 2f) > 1 ? 3.2f : -3.2f, 3.2f, 3.2f);
            go.transform.parent = GameObject.Find("Ground").transform;
        }
    }

}
