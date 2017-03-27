//=========================================================================================================
//Note: Data Managing.
//Date Created: 2012/04/17 by 风宇冲
//Date Modified: 2012/12/14 by 风宇冲
//=========================================================================================================
using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;
using System.Text;
using System.Xml;
using System.Security.Cryptography;

//GameData,储存数据的类，把需要储存的数据定义在GameData之内就行//
public class GameData
{
    //密钥,用于防止拷贝存档//
    public string key;

    //下面是添加需要储存的内容

    // 角色数值系
    // 数组第一项为orign值，第二项为计算用值，第三项为基础值（即不计算buff的值）
    public int[] player_hp = new int[2];
    public int[] player_sp = new int[2];
    public int[] player_str = new int[2];
    public int[] player_con = new int[2];
    public int[] player_int = new int[2];
    public int[] player_luc = new int[2];
    public int[] player_dex = new int[2];
    public int[] player_wis = new int[2];
    public int[] player_level = new int[2];
    public int[] player_point = new int[2];

    public PlayerData.Career[] player_career = new PlayerData.Career[2];
    public int[] player_careerLevel = new int[9];
    public int[] player_careerProficiency = new int[9];
    public Item[] player_equipment = new Item[5];

    // 系统数值系
    public int system_gold;
    public int system_floor;
    public Item[] system_bag = new Item[30];

    public GameData()
    {
        player_hp[0] = player_sp[0] = 100;
        player_str[0] = player_con[0] = player_int[0] = player_luc[0] = player_dex[0] = player_wis[0] = 1;
        player_level[0] = 1;
        player_point[0] = 0;
    }

    public void InitData()
    {
        player_hp[1] = player_hp[0];
        player_sp[1] = player_sp[0];
        player_str[1] = player_str[0];
        player_con[1] = player_con[0];
        player_int[1] = player_int[0];
        player_luc[1] = player_luc[0];
        player_dex[1] = player_dex[0];
        player_wis[1] = player_wis[0];
        player_level[1] = player_level[0];
        player_point[1] = player_point[0];

        player_career[0] = player_career[1] = PlayerData.Career.none;
        for(int i = 0; i < 9;i++)
        {
            if (i < 5)
            {
                player_equipment[i] = new Item();
            }
            player_careerLevel[i] = 1;
            player_careerProficiency[i] = 0;
        }

    }

}
//管理数据储存的类//
public class GameDataManager : MonoBehaviour
{
    private string dataFileName = "rogueData.dat";//存档文件的名称,自己定//
    private XmlSaver xs = new XmlSaver();

    public GameData gameData;

    public void Awake()
    {        
        gameData = new GameData();
     
        //设定密钥，根据具体平台设定//
        gameData.key = SystemInfo.deviceUniqueIdentifier;
        Load();
    }

    //存档时调用的函数//
    public void Save()
    {
        string gameDataFile = GetDataPath() + "/" + dataFileName;
        string dataString = xs.SerializeObject(gameData, typeof(GameData));
        xs.CreateXML(gameDataFile, dataString);
    }

    //读档时调用的函数//
    public void Load()
    {
        string gameDataFile = GetDataPath() + "/" + dataFileName;
        if (xs.hasFile(gameDataFile))
        {
            string dataString = xs.LoadXML(gameDataFile);
            GameData gameDataFromXML = xs.DeserializeObject(dataString, typeof(GameData)) as GameData;

            Debug.Log(gameDataFromXML);
            Debug.Log(gameDataFromXML.key);
            Debug.Log(gameData);
            Debug.Log(gameData.key);

            //是合法存档//
            if (gameDataFromXML.key
                == gameData.key)
            {
                gameData = gameDataFromXML;
            }
            //是非法拷贝存档//
            else
            {
                //留空：游戏启动后数据清零，存档后作弊档被自动覆盖//
            }
        }
        else
        {
            if (gameData != null)
                Save();
        }
    }

    //获取路径//
    private static string GetDataPath()
    {
        // Your game has read+write access to /var/mobile/Applications/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/Documents
        // Application.dataPath returns ar/mobile/Applications/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/myappname.app/Data             
        // Strip "/Data" from path
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            string path = Application.dataPath.Substring(0, Application.dataPath.Length - 5);
            // Strip application name
            path = path.Substring(0, path.LastIndexOf('/'));
            return path + "/Documents";
        }
        else
            //    return Application.dataPath + "/Resources";
            return Application.dataPath;
    }
}