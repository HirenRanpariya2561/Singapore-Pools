using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject starBoard;
    
    public List<GameObject> allPlayers;
    public List<Positions> allPositions;
    public static GameController instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
}

[System.Serializable]
public class Positions
{
    public List<Vector2> Pos;
}
