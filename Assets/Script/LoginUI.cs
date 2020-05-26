using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginUI : MonoBehaviour
{
    public InputField _Userid;
    public Dropdown _Diffcult;
    public Button _StartGame;

    public static string UserName;
    public static string setting_diffcult;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        _Userid = GameObject.Find("Canvas/Panel/InputNameField").GetComponent<InputField>();
        _StartGame.onClick.AddListener(StartGame);
        _Diffcult.onValueChanged.AddListener(SetDiffcult) ;
    }

    void StartGame()
    {
        UserName = _Userid.text.ToString();
        SceneManager.LoadScene("GameScene");
    }

    void SetDiffcult(int index)
    {
        switch (index)
        {
            case 0:
                setting_diffcult = "easy";
                break;
            case 1:
                setting_diffcult = "diffcult";
                break;
        }
    }
}
