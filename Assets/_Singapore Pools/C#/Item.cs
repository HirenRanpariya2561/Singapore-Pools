using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    [SerializeField] string ItemName;
    [SerializeField] int Prize;
    [SerializeField] int Prefs_Number;
    [SerializeField] TextMeshProUGUI Prize_TMP, Buy_TMP;
    [SerializeField] GameObject Coin;
    [SerializeField] Button Purchase_Btn, Select_Btn;
    [SerializeField] Sprite Btn_Purchase_Com_Sprite, Btn_Buy_Sprite;

    int isPurchased
    {
        get
        {
            return PlayerPrefs.GetInt(ItemName, 0);
        }
        set
        {
            PlayerPrefs.SetInt(ItemName, 1);
        }
    }

    void Start()
    {
        //StaticData.Coin = 50;
        //Ui_Controller.coinUpdate?.Invoke();
        //Debug.Log("1"+Prefs_Number);
        if (Prefs_Number == 0) isPurchased = 1;
        //Debug.Log("2" + Prefs_Number);
        if (isPurchased == 1)
        {
            //Debug.Log("3" + Prefs_Number);
            Coin.SetActive(false);
            //Debug.Log("4" + Prefs_Number);
            //Debug.Log("5" + Prefs_Number);
            Purchase_Btn.transform.GetComponent<Image>().sprite = Btn_Purchase_Com_Sprite;
            Buy_TMP.text = "Purchased";
            Buy_TMP.color = Color.white;
            //Debug.Log("6" + Prefs_Number);
            Purchase_Btn.interactable = false;
            Purchase_Btn.transition = Selectable.Transition.None;
            //Debug.Log("7" + Prefs_Number);
            Select_Btn.interactable = true;
            //Debug.Log("8" + Prefs_Number);
        }
        else
        {
            Coin.SetActive(true);
            //Debug.Log("9" + Prefs_Number);
            //Debug.Log("10" + Prefs_Number);
            if (StaticData.Coin >= Prize)
            {
                Purchase_Btn.transform.GetComponent<Image>().sprite = Btn_Buy_Sprite;
                Buy_TMP.color = Color.red;
                Purchase_Btn.interactable = true;
            }
            else
            {
                Purchase_Btn.transform.GetComponent<Image>().sprite = Btn_Purchase_Com_Sprite;
                Buy_TMP.color = Color.white;
                Purchase_Btn.interactable = false;
            }
            Buy_TMP.text = "Buy";
            //Debug.Log("11" + Prefs_Number);
            //Debug.Log("12" + Prefs_Number);
            Select_Btn.interactable = false;
        }
        //Debug.Log("1" + Prefs_Number);

        Prize_TMP.text = "" + Prize.ToString();
    }

    void Update()
    {
        if (StaticData.ClickShopBtn == 1)
        {
            if (isPurchased != 1)
            {
                if (StaticData.Coin >= Prize)
                {
                    Purchase_Btn.transform.GetComponent<Image>().sprite = Btn_Buy_Sprite;
                    Buy_TMP.color = Color.red;
                    Purchase_Btn.interactable = true;
                }
                else
                {
                    Purchase_Btn.transform.GetComponent<Image>().sprite = Btn_Purchase_Com_Sprite;
                    Buy_TMP.color = Color.white;
                    Purchase_Btn.interactable = false;
                }
            }
        }
    }

    public void Btn_Click()
    {
        Sound_Manager.instance.Btn_Click_Clip();
        if (isPurchased == 0)
        {
            Sound_Manager.instance.Unlock_Buy_Clip();
            isPurchased = 1;
            StaticData.Coin -= Prize;
            //Ui_Controller.instance.ShopPanel_Coin_TMP.text = "" + StaticData.Coin.ToString();
            Ui_Controller.coinUpdate?.Invoke();
            Coin.SetActive(false);
            Purchase_Btn.transform.GetComponent<Image>().sprite = Btn_Purchase_Com_Sprite;
            Buy_TMP.color = Color.white;
            Buy_TMP.text = "Purchased";
            Purchase_Btn.interactable = false;
            Purchase_Btn.transition = Selectable.Transition.None;
            Select_Btn.interactable = true;
            StaticData.CurrentSelctedPlayerNo = Prefs_Number;
        }
    }

    public void Select_Btn_Click()
    {
        Sound_Manager.instance.Btn_Click_Clip();
        StaticData.CurrentSelctedPlayerNo = Prefs_Number;
    }
}
