using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

[RequireComponent(typeof(GamingUI))]
[System.Serializable]
public class SaveAndLoad : MonoBehaviour
{
    private string savingFileName = "saveData.dat";//存檔檔名
    private string nameAndPath;//存檔路徑+檔名

    public void CreateDirectory(string filePath)
    {

        if (File.Exists(filePath))//如果資料夾位置已經存在則返回
            return;
        Directory.CreateDirectory(filePath);//新增資料夾 filePath為資料夾路徑
    }

    private string SerializeObject(object PlayerData)
    {
        string serializePlayerData = "";
        serializePlayerData = JsonConvert.SerializeObject(PlayerData);//序列化玩家存檔
        return serializePlayerData;//返回字串型態的玩家存檔
    }

    private static object DeserializeObject(string _PlayerData, Type _PlayerDataType)
    {
        object playerData = null;
        playerData = JsonConvert.DeserializeObject(_PlayerData, _PlayerDataType);//反序列化玩家的存檔
        return playerData;//返回自定義類別的玩家存檔
    }

    public void SaveData(string content)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string filePath = Application.dataPath + "/Save";
        CreateDirectory(filePath);//在目的地新增資料夾
        nameAndPath = filePath + "/" + savingFileName;//存檔的位置加檔名
        Stream s = File.Open(nameAndPath, FileMode.Create);
        bf.Serialize(s, content);
        s.Close();
    }
    public string LoadData()
    {
        string filePath = Application.dataPath + "/Save";
        nameAndPath = filePath + "/" + savingFileName;//存檔的位置加檔名

        if (File.Exists(nameAndPath))
        {
            BinaryFormatter bf = new BinaryFormatter();                                           
            Stream s = File.Open(nameAndPath, FileMode.Open);
            string data = (string)bf.Deserialize(s);
            s.Close();

            return data;
        }
        else
            return null;
        
    }
}
