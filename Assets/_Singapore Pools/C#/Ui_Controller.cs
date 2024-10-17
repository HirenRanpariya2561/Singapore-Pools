using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ui_Controller : MonoBehaviour
{
    [Tooltip("0.HomePanel 1.SettingPanel 2.LevelPanel 3.ShopPanel 4. GamePlayPanel 5.LevelCompletePanel 6.GameOverPanel")]
    [SerializeField] List<GameObject> All_Panel;
    public TextMeshProUGUI ShopPanel_Coin_TMP ,GamePanel_Coin_TMP;
    public TextMeshProUGUI LevelCompletePanel_Level_No_TMP , GamePanel_MoveNo_TMP , LevelCompletePanel_MoveNo_TMP;
    public GameObject LevelPrefab;
    public GameObject Partical_Water;
    public static System.Action coinUpdate;

    public static Ui_Controller instance;
    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        coinUpdate += Coin_Set;
    }

    private void OnDisable()
    {
        coinUpdate -= Coin_Set;
    }

    void Start()
    {
        coinUpdate?.Invoke();
        Panel_Set(0);
        Dotween_Animation.instance.HomePanel_Animation_Start();
    }

    public void Panel_Set(int a)
    {
        foreach (GameObject panels in All_Panel)
        {
            panels.SetActive(false);
        }
        All_Panel[a].SetActive(true);
    }

    public void HomePanel_Play_Btn_Click()
    {
        Sound_Manager.instance.Btn_Click_Clip();
        Dotween_Animation.instance.HomePanel_Animation_Close();
        LevePanel_Level_Manage.instance.Lock_Set();
        Invoke(nameof(Waiting_HomePanel_Play_Btn_Click), 0.5f);
    }

    public void Waiting_HomePanel_Play_Btn_Click()
    {
        Panel_Set(2);
        Dotween_Animation.instance.LevelPanel_Animation_Start();
    }

    public void HomePanel_Shop_Btn_Click()
    {
        Sound_Manager.instance.Btn_Click_Clip();
        StaticData.ClickShopBtn = 1;
        Dotween_Animation.instance.HomePanel_Animation_Close();
        Invoke(nameof(Waiting_HomePanel_Shop_Btn_Click), 0.5f);
    }

    public void Waiting_HomePanel_Shop_Btn_Click()
    {
        Panel_Set(3);
        Dotween_Animation.instance.ShopPanel_Animation_Start();
    }

    public void ShopPanel_Back_Btn_Click()
    {
        Sound_Manager.instance.Btn_Click_Clip();
        StaticData.ClickShopBtn = 0;
        Dotween_Animation.instance.ShopPanel_Animation_Close();
        Invoke(nameof(Waiting_ShopPanel_Back_Btn_Click), 0.5f);
    }

    public void Waiting_ShopPanel_Back_Btn_Click()
    {
        Panel_Set(0);
        Dotween_Animation.instance.HomePanel_Animation_Start();
    }

    public void HomePanel_Setting_Btn_Click()
    {
        Sound_Manager.instance.Btn_Click_Clip();
        All_Panel[1].SetActive(true);
        Dotween_Animation.instance.SettingPanel_Animation_Start();
    }

    public void SettingPanel_Close_Btn_Click()
    {
        Sound_Manager.instance.Btn_Click_Clip();
        Dotween_Animation.instance.SettingPanel_Animation_Close();
        Invoke(nameof(Waiting_SettingPanel_Close_Btn_Click), 0.5f);
    }

    public void Waiting_SettingPanel_Close_Btn_Click()
    {
        All_Panel[1].SetActive(false);
    }

    public void LevelPanel_Back_Btn_Click()
    {
        Sound_Manager.instance.Btn_Click_Clip();
        Dotween_Animation.instance.LevelPanel_Animation_Close();
        Invoke(nameof(Waiting_LevelPanel_Back_Btn_Click),0.5f);
    }

    public void Waiting_LevelPanel_Back_Btn_Click()
    {
        Panel_Set(0);
        Dotween_Animation.instance.HomePanel_Animation_Start();
    }


    public void LevelPanel_Level_Btn_Click()
    {
        Panel_Set(3);
    }

    public void Game_Panel_Back_Btn_Click()
    {
        Sound_Manager.instance.Btn_Click_Clip();
        //LevePanel_Level_Manage.instance.Lock_Set();
        Dotween_Animation.instance.GamePanel_Animation_Close();
        Invoke(nameof(Waiting_Game_Panel_Back_Btn_Click),0.5f);
    }

    public void Waiting_Game_Panel_Back_Btn_Click()
    {
        Panel_Set(2);
        Dotween_Animation.instance.LevelPanel_Animation_Start();
    }

    public void LevelComplete_Panel_Home_Btn_Click()
    {
        Sound_Manager.instance.Btn_Click_Clip();
        Dotween_Animation.instance.LevelCompletePanel_Animation_Close();
        Invoke(nameof(Waiting_LevelComplete_Panel_Home_Btn_Click),0.5f);
    }

    public void Waiting_LevelComplete_Panel_Home_Btn_Click()
    {
        Panel_Set(0);
        Dotween_Animation.instance.HomePanel_Animation_Start();
    }

    public void LevelComplete()
    {
        Debug.Log(StaticData.CurrentLevelNo);
        LevePanel_Level_Manage.instance.Lock_Set();
        LevelCompletePanel_Level_No_TMP.text = "Level No : " + (StaticData.CurrentLevelNo + 1).ToString();
        LevelCompletePanel_MoveNo_TMP.text = "Moves : " + StaticData.Move.ToString();
        StaticData.CurrentLevelNo += 1;
        if (StaticData.CurrentLevelNo == 10)
        {
            StaticData.CurrentLevelNo = 0;
        }
        if (StaticData.LevelNo <= StaticData.LevelNo)
        {
            StaticData.LevelNo = StaticData.CurrentLevelNo;
        }
        Debug.Log("Levelno - " + StaticData.LevelNo);
        Debug.Log("CurrentLevelNo - " + StaticData.CurrentLevelNo);


        //LevePanel_Level_Manage.instance.Lock_Set();
    }

    public void LevelCompletePanel_Open()
    {
        LevelComplete();
        All_Panel[5].SetActive(true);
        Dotween_Animation.instance.LevelCompletePanel_Animation_Start();
    }

    public void LevelCompletePanel_NextBtn_Click()
    {
        Sound_Manager.instance.Btn_Click_Clip();
        LevePanel_Level_Manage.instance.Level_Genrate(StaticData.CurrentLevelNo);
        Dotween_Animation.instance.LevelCompletePanel_Animation_Close();
        Invoke(nameof(Waiting_LevelCompletePanel_NextBtn_Click), 0.5f);
    }

    public void LevelCompletePanel_RetryBtn_Click()
    {
        Sound_Manager.instance.Btn_Click_Clip();
        LevePanel_Level_Manage.instance.Level_Genrate(StaticData.CurrentLevelNo-1);
        Dotween_Animation.instance.LevelCompletePanel_Animation_Close();
        Invoke(nameof(Waiting_LevelCompletePanel_NextBtn_Click), 0.5f);
    }

    public void GamePanel_RetryBtn_Click()
    {
        if (!LevelController.instance.gameWin)
        {
            Sound_Manager.instance.Btn_Click_Clip();
            LevePanel_Level_Manage.instance.Level_Genrate(StaticData.CurrentLevelNo);
        }
    }

    public void Waiting_LevelCompletePanel_NextBtn_Click()
    {
        All_Panel[5].SetActive(false);
    }

    public void Coin_Set()
    {
        ShopPanel_Coin_TMP.text = StaticData.Coin.ToString();
        GamePanel_Coin_TMP.text = StaticData.Coin.ToString();
    }

    public void UndoBtnClick()
    {
        if (StaticData.Move!=0 && !LevelController.instance.gameWin)
        {
            Sound_Manager.instance.Btn_Click_Clip();
            LevelController.instance.Backing();
            StaticData.Move--;
            MoveScore();
        }
    }

    public void MoveScore()
    {
        GamePanel_MoveNo_TMP.text = "Moves : " + StaticData.Move; 
    }

    public void ParticalEffectMove(Vector3 pos)
    {
        Debug.Log(pos);
        Instantiate(Partical_Water, pos, Quaternion.identity);
    }

}
