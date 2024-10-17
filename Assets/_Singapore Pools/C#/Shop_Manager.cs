using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Manager : MonoBehaviour
{
    [SerializeField] Image[] Selected_Img_All;

    void Update()
    {
        if (StaticData.ClickShopBtn == 1)
        {
            for (int i = 0; i < Selected_Img_All.Length; i++)
            {
                if (StaticData.CurrentSelctedPlayerNo == i)
                {
                    Selected_Img_All[i].gameObject.SetActive(true);
                }
                else
                {
                    Selected_Img_All[i].gameObject.SetActive(false);
                }
            }

        }
    }
}
