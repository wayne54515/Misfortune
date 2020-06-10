using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class GamingUI : MonoBehaviour
{
    public Text tv_showPlayerName;
    public Text tv_showTime;
    public Text tv_showDistance;
    public GameObject GameOverUI;
    public GameObject TeachUI;

    public static int timer;
    public static int distance;
    public GameObject player;

    public Text showPlayerName;
    public Text showTotalDistance;
    public Text showTotalTime;
    public Text showMaxDistanceE, showMaxDistanceH;

    private bool isGameOver = false;
    private int noMoveFramesCount = 0;
    private float gameTime = 0;

    public Button btn_restart, btn_quitGame;

    private SaveAndLoad SL;

    // Start is called before the first frame update
    void Start()
    {
        SL = GetComponent<SaveAndLoad>();

        tv_showPlayerName.text = LoginUI.UserName;
        showPlayerName.text = "Name : " + LoginUI.UserName;
        GameOverUI.SetActive(false);
        TeachUI.SetActive(true);

        btn_restart.onClick.AddListener(btn_restart_onClick);
        btn_quitGame.onClick.AddListener(btn_quitGame_onClick);
    }

    void btn_restart_onClick()
    {
        SceneManager.LoadScene("LoginScene");
    }

    void btn_quitGame_onClick()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) { return; }

        if ((int)player.transform.position.z == distance)
        {
            noMoveFramesCount += 1;
        }
        else
        {
            noMoveFramesCount = 0;
        }

        gameTime += Time.deltaTime;
        distance = (int)player.transform.position.z;

        tv_showTime.text = "Time : " + ((int)gameTime).ToString();
        tv_showDistance.text = "Distance : " + distance.ToString();

        //Debug.Log(gameTime);
        if (gameTime >= 4)
        {
            TeachUI.SetActive(false);
        }

        if (noMoveFramesCount > 60)
        {
            ShowGameOver();
            isGameOver = true;
        }

        

    }

    void ShowGameOver()
    {
        GameOverUI.SetActive(true);
        TeachUI.SetActive(false);
        showTotalTime.text = "Time : " + ((int)gameTime).ToString();
        showTotalDistance.text = "Distance: " + distance.ToString();
        LoadAndSaveDis();
    }

    public void LoadAndSaveDis()
    {
        maxDistance md = new maxDistance();
        md = (maxDistance)LoadDis();
        
        if (LoginUI.setting_diffcult.Equals("easy"))
        {
            if (int.Parse(md.easyDis) < distance)
            {
                md.easyDis = distance.ToString();            
            }
        }
        else
        {
            if (int.Parse(md.hardDis) < distance)
            {
                md.hardDis = distance.ToString();
            }
        }
        SL.SaveData(md);


    }
    public object LoadDis()
    {
        maxDistance md = new maxDistance();
        
        md = (maxDistance)SL.LoadData();

        showMaxDistanceE.text = "Easy Max Distance : " + md.easyDis;
        showMaxDistanceH.text = "Hard Max Distance : " + md.hardDis;
        return md;

        //Debug.Log(md);
    }
}

[System.Serializable]
public class maxDistance
{
    public string easyDis;
    public string hardDis;
}
