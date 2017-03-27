using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour
{
    public enum Career { none, lumberjack, digger, thief, forging, casting, alchemist, sworder, archer, magician };

    public int[] _hp = new int[2];
    public int[] _sp = new int[2];
    public int[] _str = new int[2];
    public int[] _con = new int[2];
    public int[] _int = new int[2];
    public int[] _luc = new int[2];
    public int[] _dex = new int[2];
    public int[] _wis = new int[2];
    public int _level;
    public int _point;

    public PlayerData.Career[] _career = new PlayerData.Career[2];
    public int[] _careerLevel = new int[9];
    public int[] _careerProficiency = new int[9];
    public Item[] _equipment = new Item[5];

    private GameDataManager gameDataManager;

    void Awake()
    {
        gameDataManager = GameObject.Find("GameDataManager").GetComponent<GameDataManager>();
    }

    public void ReadDataFromXML()
    {
        gameDataManager.Load();
        GameData data = gameDataManager.gameData;

        _hp[0] = _hp[1] = data.player_hp[1];
        _sp[0] = _sp[1] = data.player_sp[1];
        _str[0] = _str[1] = data.player_str[1];
        _con[0] = _con[1] = data.player_con[1];
        _int[0] = _int[1] = data.player_int[1];
        _luc[0] = _luc[1] = data.player_luc[1];
        _dex[0] = _dex[1] = data.player_dex[1];
        _wis[0] = _wis[1] = data.player_wis[1];
        _level = data.player_level[1];
        _point = data.player_point[1];

        _career[0] = data.player_career[0];
        _career[1] = data.player_career[1];

        for(int i = 0; i < 9;i++)
        {
            if(i < 5)
            {
                _equipment[i] = data.player_equipment[i];
            }
            _careerLevel[i] = data.player_careerLevel[i];
            _careerProficiency[i] = data.player_careerProficiency[i];
        }


    }

    public void WriteDataToXML()
    {
        GameData data = gameDataManager.gameData;

        data.player_hp[1] = _hp[0];
        data.player_sp[1] = _sp[0];
        data.player_str[1] = _str[0];
        data.player_con[1] = _con[0];
        data.player_int[1] = _int[0];
        data.player_luc[1] = _luc[0];
        data.player_dex[1] = _dex[0];
        data.player_wis[1] = _wis[0];
        data.player_level[1] = _level;
        data.player_point[1] = _point;

        data.player_career[0] = _career[0];
        data.player_career[1] = _career[1];

        for(int i = 0; i < 9; i++)
        {
            if(i < 5)
            {
                data.player_equipment[i] = _equipment[i];
            }
            data.player_careerLevel[i] = _careerLevel[i];
            data.player_careerProficiency[i] = _careerProficiency[i];
        }

        gameDataManager.Save();

    }

}
