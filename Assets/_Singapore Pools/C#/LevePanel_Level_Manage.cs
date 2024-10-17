using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class LevePanel_Level_Manage : MonoBehaviour
{
    [SerializeField] Button[] Level_Btn;
    [SerializeField] GameObject[] Levels;
    [SerializeField] TextMeshProUGUI GamePanel_LevelNo_TMP;
    GameObject Level_Gen;
    float Last_value = -15, Canvas_Width;

    public static LevePanel_Level_Manage instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Lock_Set();
    }

    public void Lock_Set()
    {
        for (int i = 0; i < Level_Btn.Length; i++)
        {
            if (StaticData.LevelNo >= i)
            {
                Level_Btn[i].transform.GetChild(0).gameObject.SetActive(false);
                Level_Btn[i].transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                Level_Btn[i].transform.GetChild(0).gameObject.SetActive(true);
                Level_Btn[i].transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }

    public void Level_Btn_Click(int a)
    {
        Sound_Manager.instance.Btn_Click_Clip();
        Level_Genrate(a);
        Dotween_Animation.instance.LevelPanel_Animation_Close();
        Invoke(nameof(Waiting_LevelPanel_Btn_Click), 0.5f);
    }

    public void Waiting_LevelPanel_Btn_Click()
    {
        Ui_Controller.instance.Panel_Set(4);
        Dotween_Animation.instance.GamePanel_Animation_Start();
    }

    public void Level_Genrate(int a)
    {
        GamePanel_LevelNo_TMP.text = "Level : "+(a+1).ToString();
        StaticData.CurrentLevelNo = a;
        StaticData.Move = 0;
        Ui_Controller.instance.MoveScore();
        if (Level_Gen != null) Destroy(Level_Gen);
        Level_Gen = Instantiate(Levels[a]);
    }

}
