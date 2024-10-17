using UnityEngine;
using DG.Tweening;

public class Dotween_Animation : MonoBehaviour
{
    public static Dotween_Animation instance;

    //public enum Panel
    //{
    //    HomePanel,LevelPanel,GamePanel,LevelCompletePanel
    //}

    //public Panel Panels;

    //Home Panel Animation Object
    [SerializeField] RectTransform HomePanel_Title, HomePanel_Play_Btn, HomePanel_Setting_Btn,HomePanel_Shop_Btn, HomePanel_Rate_Btn, HomePanel_Share_Btn,HomePanel_Leader_Btn;

    //Level Panel Animation object
    [SerializeField] RectTransform LevelPanel_Title, LevelPanel_Back_Btn, LevelPanel_Map;

    ////LevelComplete Panel Animation Object
    //[SerializeField] RectTransform LevelCompletePanel_Home_Btn, LevelCompletePanel_Next_Btn, LevelCompletePanel_Title ,LevelCompletePanel_LevelTMP;

    //Game Panel Animation Object
    [SerializeField] RectTransform GamePanel_Level_TMP, GamePanel_Back_Btn, GamePanel_Moves_TMP, GamePanel_Star ,GamePanel_LowerImg;

    //Setting Panel Animation Object
    [SerializeField] RectTransform Setting_Panel;

    //Shop Panel Animation Object
    [SerializeField] RectTransform ShopPanel_Title,ShopPanel_Back_Btn, ShopPanel_StarBoard, Ch1,Ch2,Ch3,Ch4;

    //LevelCompletePanel Animation Object
    [SerializeField] RectTransform LevelCompletePanel;

    //GameOverPanel Animation Object
    [SerializeField] RectTransform GameOverPanel;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        LevelPanel_Animation_Close();
        SettingPanel_Animation_Close();
        ShopPanel_Animation_Close();
        GamePanel_Animation_Close();
        LevelCompletePanel_Animation_Close();
        GameOverPanel_Animation_Close();
    }


    public void ShopPanel_Animation_Start()
    {
        ShopPanel_Title.DOAnchorPosY(-30, 0.5f);
        ShopPanel_Back_Btn.DOAnchorPosX(30, 0.5f);
        ShopPanel_StarBoard.DOAnchorPosX(-30, 0.5f);
        Ch1.DOAnchorPosX(-255,0.5f);
        Ch2.DOAnchorPosX(263,0.5f);
        Ch3.DOAnchorPosY(-328, 0.5f);
        Ch4.DOAnchorPosY(-328, 0.5f);
    }

    public void ShopPanel_Animation_Close()
    {
        ShopPanel_Title.DOAnchorPosY(300, 0.5f);
        ShopPanel_Back_Btn.DOAnchorPosX(-300, 0.5f);
        ShopPanel_StarBoard.DOAnchorPosX(300, 0.5f);
        Ch1.DOAnchorPosX(-1000, 0.5f);
        Ch2.DOAnchorPosX(1000, 0.5f);
        Ch3.DOAnchorPosY(-1500, 0.5f);
        Ch4.DOAnchorPosY(-1500, 0.5f);
    }

    public void SettingPanel_Animation_Start()
    {
        Setting_Panel.DOAnchorPosY(0, 0.5f);
    }

    public void SettingPanel_Animation_Close()
    {
        Setting_Panel.DOAnchorPosY(-2000, 0.5f);
    }

    public void LevelCompletePanel_Animation_Start()
    {
        LevelCompletePanel.DOAnchorPosY(0, 0.5f);
    }

    public void LevelCompletePanel_Animation_Close()
    {
        LevelCompletePanel.DOAnchorPosY(-2000, 0.5f);
    }

    public void GameOverPanel_Animation_Start()
    {
        GameOverPanel.DOAnchorPosY(0, 0.5f);
    }

    public void GameOverPanel_Animation_Close()
    {
        GameOverPanel.DOAnchorPosY(-2000, 0.5f);
    }

    public void GamePanel_Animation_Start()
    {
        GamePanel_Level_TMP.DOAnchorPosY(-15, 0.5f);
        GamePanel_Back_Btn.DOAnchorPosX(30, 0.5f);
        GamePanel_Moves_TMP.DOAnchorPosX(-20, 0.5f);
        GamePanel_Star.DOAnchorPosY(-250, 0.5f);
        GamePanel_LowerImg.DOAnchorPosY(70, 0.5f);
    }

    public void GamePanel_Animation_Close()
    {
        GamePanel_Level_TMP.DOAnchorPosY(300, 0.5f);
        GamePanel_Back_Btn.DOAnchorPosX(-300, 0.5f);
        GamePanel_Moves_TMP.DOAnchorPosX(300, 0.5f);
        GamePanel_Star.DOAnchorPosY(300, 0.5f);
        GamePanel_LowerImg.DOAnchorPosY(-300, 0.5f);
    }

    //public void LevelCompletePanel_Animation_Start()
    //{
    //    //LevelComplete_Coin_TMP.transform.DOLocalMoveX(0, 0.5f);
    //    LevelCompletePanel_Next_Btn.DOAnchorPosY(0, 0.5f);
    //    LevelCompletePanel_Home_Btn.DOAnchorPosY(0, 0.5f);
    //    LevelCompletePanel_Title.DOAnchorPosY(-50, 0.5f);
    //    LevelCompletePanel_LevelTMP.DOAnchorPosY(-200,0.5f);
    //}

    //public void LevelCompletePanel_Animation_Close()
    //{
    //    //LevelComplete_Coin_TMP.transform.DOLocalMoveX(1000, 0.5f);
    //    LevelCompletePanel_Next_Btn.DOAnchorPosY(-300, 0.5f);
    //    LevelCompletePanel_Home_Btn.DOAnchorPosY(-300,0.5f);
    //    LevelCompletePanel_Title.DOAnchorPosY(500, 0.5f);
    //    LevelCompletePanel_LevelTMP.DOAnchorPosY(300, 0.5f);

    //}

    public void HomePanel_Animation_Start()
    {
        HomePanel_Title.DOAnchorPosY(-260, 0.5f);
        HomePanel_Play_Btn.DOAnchorPosX(0, 0.5f);
        HomePanel_Setting_Btn.DOAnchorPosX(30, 0.5f);
        HomePanel_Shop_Btn.DOAnchorPosY(32, 0.5f);
        HomePanel_Share_Btn.DOAnchorPosY(32, 0.5f);
        HomePanel_Rate_Btn.DOAnchorPosY(32, 0.5f);
        HomePanel_Leader_Btn.DOAnchorPosX(-30, 0.5f);
    }

    public void HomePanel_Animation_Close()
    {
        HomePanel_Title.DOAnchorPosY(1200, 0.5f);
        HomePanel_Play_Btn.DOAnchorPosX(1000, 0.5f);
        HomePanel_Setting_Btn.DOAnchorPosX(-300, 0.5f);
        HomePanel_Shop_Btn.DOAnchorPosY(-300, 0.5f);
        HomePanel_Share_Btn.DOAnchorPosY(-300, 0.5f);
        HomePanel_Rate_Btn.DOAnchorPosY(-300, 0.5f);
        HomePanel_Leader_Btn.DOAnchorPosX(300,0.5f);
    }

    public void LevelPanel_Animation_Start()
    {
        LevelPanel_Title.DOAnchorPosY(-30, 0.5f);
        LevelPanel_Back_Btn.DOAnchorPosX(30, 0.5f);
        LevelPanel_Map.DOAnchorPosY(0, 0.5f);
    }

    public void LevelPanel_Animation_Close()
    {
        LevelPanel_Title.DOAnchorPosY(300, 0.5f);
        LevelPanel_Back_Btn.DOAnchorPosX(-400, 0.5f);
        LevelPanel_Map.DOAnchorPosY(-1800, 0.5f);
    }

   

    //public void Panel_Animation_Set()
    //{
    //    switch(Panels)
    //    {
    //        case Panel.HomePanel:
    //            HomePanel_Animation_Start();
    //            break;

    //        case Panel.LevelCompletePanel:
    //            level
    //            break;
    //    }
    //}


}
