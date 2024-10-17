using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class StaticData 
{
    const string LevelNoID = "LevelNOID";
    const string CurrentLevelID = "CurrentLevelID";
    const string CurrentSelctedPlayerID = "CurrentSelctedPlayerID";
    const string CoinID = "CoinID";
    const string ClickShopBtnID = "ClickShopBtnID";
    const string MoveID = "MoveID";  

    public static int LevelNo
    {
        get => PlayerPrefs.GetInt(LevelNoID, 0);
        set => PlayerPrefs.SetInt(LevelNoID, value);
    }

    public static int CurrentLevelNo
    {
        get => PlayerPrefs.GetInt(CurrentLevelID, 0);
        set => PlayerPrefs.SetInt(CurrentLevelID, value);
    }

    public static int CurrentSelctedPlayerNo
    {
        get => PlayerPrefs.GetInt(CurrentSelctedPlayerID, 0);
        set => PlayerPrefs.SetInt(CurrentSelctedPlayerID, value);
    }

    public static int Coin
    {
        get => PlayerPrefs.GetInt(CoinID, 0);
        set => PlayerPrefs.SetInt(CoinID, value);
    }

    public static int ClickShopBtn
    {
        get => PlayerPrefs.GetInt(ClickShopBtnID, 0);
        set => PlayerPrefs.SetInt(ClickShopBtnID, value);
    }

    public static int Move
    {
        get => PlayerPrefs.GetInt(MoveID, 0);
        set => PlayerPrefs.SetInt(MoveID, value);
    }
}
