using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelController : MonoBehaviour
{
    public List<Vector3> pathPos;
    public enum Direction { Up, Down, Left, Right }
    public PathType pathSystem = PathType.CatmullRom;
    public Direction dir, startStaticDir;
    public GameObject raycastingObj, startObj;
    RaycastHit2D raycast2D;
    public Transform player, Holder;
    public Vector3 playerStartPos;
    public static LevelController instance;
    public bool gameWin;
    public Stack<Data> Move = new Stack<Data>();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PlayerGenrate();
    }

    public void PlayerGenrate()
    {
        GameObject playerGen = Instantiate(GameController.instance.allPlayers[StaticData.CurrentSelctedPlayerNo]);
        playerGen.transform.localPosition = playerStartPos;
        playerGen.transform.SetParent(Holder);
        player = playerGen.transform;
    }

    public void PathChecking()
    {
        raycast2D = Physics2D.Raycast(raycastingObj.transform.localPosition, dir1(), 2);
        pathPos.Add(raycastingObj.transform.localPosition);
        if (raycast2D.collider.CompareTag("Right_Down") && (dir == Direction.Up || dir == Direction.Left))
        {
            if (dir == Direction.Up)
            {
                dir = Direction.Right;
                raycastingObj = raycast2D.collider.gameObject;
                PathChecking();
            }
            else if (dir == Direction.Left)
            {
                dir = Direction.Down;
                raycastingObj = raycast2D.collider.gameObject;
                PathChecking();
            }
        }
        else if (raycast2D.collider.CompareTag("Left_Down") && (dir == Direction.Right || dir == Direction.Up))
        {
            if (dir == Direction.Right)
            {
                dir = Direction.Down;
                raycastingObj = raycast2D.collider.gameObject;
                PathChecking();
            }
            else if (dir == Direction.Up)
            {
                dir = Direction.Left;
                raycastingObj = raycast2D.collider.gameObject;
                PathChecking();
            }
        }
        else if (raycast2D.collider.CompareTag("Right_Up") && (dir == Direction.Left || dir == Direction.Down))
        {
            if (dir == Direction.Left)
            {
                dir = Direction.Up;
                raycastingObj = raycast2D.collider.gameObject;
                PathChecking();
            }
            else if (dir == Direction.Down)
            {
                dir = Direction.Right;
                raycastingObj = raycast2D.collider.gameObject;
                PathChecking();
            }
        }
        else if (raycast2D.collider.CompareTag("Left_Up") && (dir == Direction.Right || dir == Direction.Down))
        {
            if (dir == Direction.Right)
            {
                dir = Direction.Up;
                raycastingObj = raycast2D.collider.gameObject;
                PathChecking();
            }
            else if (dir == Direction.Down)
            {
                dir = Direction.Left;
                raycastingObj = raycast2D.collider.gameObject;
                PathChecking();
            }
        }
        else if (raycast2D.collider.CompareTag("Vertical") && (dir == Direction.Down || dir == Direction.Up))
        {
            raycastingObj = raycast2D.collider.gameObject;
            PathChecking();
        }
        else if (raycast2D.collider.CompareTag("Horizontal") && (dir == Direction.Left || dir == Direction.Right))
        {
            raycastingObj = raycast2D.collider.gameObject;
            PathChecking();
        }

        else if (raycast2D.collider.CompareTag("Win"))
        {
            gameWin = true;
            
            pathPos.Add(raycast2D.collider.transform.localPosition);
            Invoke(nameof(PlayerMove), 1f);
        }
    }

    public Vector2 dir1()
    {
        if (dir == Direction.Down) return Vector2.down;
        else if (dir == Direction.Left) return Vector2.left;
        else if (dir == Direction.Right) return Vector2.right;
        else return Vector2.up;
    }

    public void PlayerMove()
    {
        Sound_Manager.instance.level_Complete_Clip();
        Player.instance.startAnimation();
        player.DOPath(pathPos.ToArray(), pathPos.Count / 2, pathSystem).OnComplete(() => { Invoke(nameof(OpenWinPanel), 1f); });
    }

    public void OpenWinPanel()
    {
        Ui_Controller.instance.LevelCompletePanel_Open();
    }

    public void MoveAdding(GameObject a, int colno, int rowno)
    {
        Data d = new Data();
        d.name = a;
        d.colNo = colno;
        d.rawno = rowno;
        Move.Push(d);
    }

    public void Backing()
    {
        if (!gameWin)
        {
            var aa = Move.Peek();
            Move.Pop();

            aa.name.transform.DOLocalMove(GameController.instance.allPositions[aa.colNo].Pos[aa.rawno], 0.1f);
            aa.name.GetComponent<BlockMovement>().colNo = aa.colNo;
            aa.name.GetComponent<BlockMovement>().rawNo = aa.rawno;
        }
    }

    public void Btnclickchange()
    {
        raycastingObj = startObj;
        dir = startStaticDir;
    }

}

[System.Serializable]
public class Data
{
    public GameObject name;
    public int colNo, rawno;
}
