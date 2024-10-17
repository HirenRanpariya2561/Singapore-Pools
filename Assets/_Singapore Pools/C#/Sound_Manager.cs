using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound_Manager : MonoBehaviour
{
    public static Sound_Manager instance;
    [SerializeField] AudioSource Background,Player;
    [SerializeField] AudioClip Btn_Click, Jump_Click, Level_Complete,Coin_Collect,Unlock_Buy;
    [SerializeField] Sprite Sound_ON, Sound_OFF,Music_ON,Music_OFF;
    [SerializeField] Button Sound,Music;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        BackGround_Controll();
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            Sound.GetComponent<Image>().sprite = Sound_ON;
        }
        else
        {
            Sound.GetComponent<Image>().sprite = Sound_OFF;
        }

        if (PlayerPrefs.GetInt("Music") == 0)
        {
            Music.GetComponent<Image>().sprite = Music_ON;
        }
        else
        {
            Music.GetComponent<Image>().sprite = Music_OFF;
        }
    }

    public void Music_Btn_Click()
    {
        if(Music.GetComponent<Image>().sprite == Music_ON)
        {
            Music.GetComponent<Image>().sprite = Music_OFF;
            PlayerPrefs.SetInt("Music", 1);
        }
        else
        {
            Music.GetComponent<Image>().sprite = Music_ON;
            PlayerPrefs.SetInt("Music", 0);
        }
        Btn_Click_Clip();
        BackGround_Controll();
    }

    public void Sound_Btn_Click()
    {
        if (Sound.GetComponent<Image>().sprite == Sound_ON)
        {
            Sound.GetComponent<Image>().sprite = Sound_OFF;
            PlayerPrefs.SetInt("Sound", 1);
        }
        else
        {
            Sound.GetComponent<Image>().sprite = Sound_ON;
            PlayerPrefs.SetInt("Sound", 0);
        }
        Btn_Click_Clip();
    }




    public void BackGround_Controll()
    {
        Debug.Log(PlayerPrefs.GetInt("Music"));
        if (PlayerPrefs.GetInt("Music") == 0) Background.enabled = true;
        else Background.enabled = false;
    }

    public void Btn_Click_Clip()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            Player.PlayOneShot(Btn_Click);
        }
    }
   

    public void level_Complete_Clip()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            Player.PlayOneShot(Level_Complete);
        }
    }

    public void Jump_Click_Clip()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            Player.PlayOneShot(Jump_Click);
        }
    }

    public void Coin_Collect_Clip()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            Player.PlayOneShot(Coin_Collect);
        }
    }

    public void Unlock_Buy_Clip()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            Player.PlayOneShot(Unlock_Buy);
        }
    }



}
