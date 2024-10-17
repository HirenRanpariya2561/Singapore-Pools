using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlockMovement : MonoBehaviour
{
    RaycastHit2D raycast2D;
    Vector2 startPos, endPos;
    public int colNo, rawNo;

    private void OnMouseDown()
    {
        startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        
        endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float xx = Mathf.Abs(startPos.x - endPos.x);
        float yy = Mathf.Abs(startPos.y - endPos.y);

        if (!LevelController.instance.gameWin)
        {
            Sound_Manager.instance.Jump_Click_Clip();
            if (xx > yy)
            {
                if (startPos.x - endPos.x > 0)
                {
                    raycast2D = Physics2D.Raycast(transform.localPosition, Vector2.left, 2);
                    if (raycast2D.collider == null)
                    {
                        LevelController.instance.MoveAdding(this.gameObject, colNo, rawNo);
                        if (rawNo != 0)
                        {
                            rawNo--;
                            transform.DOLocalMove(GameController.instance.allPositions[colNo].Pos[rawNo], 0.1f).OnComplete(() => { OnCompleteAfterCall(); });
                            MovingScoreSet();
                            transform.name = colNo + "," + rawNo;
                        }
                    }
                }
                else
                {
                    raycast2D = Physics2D.Raycast(transform.localPosition, Vector2.right, 2);
                    if (raycast2D.collider == null)
                    {
                        LevelController.instance.MoveAdding(this.gameObject, colNo, rawNo);
                        if (rawNo != 3)
                        {
                            rawNo++;
                            transform.DOLocalMove(GameController.instance.allPositions[colNo].Pos[rawNo], 0.1f).OnComplete(() => { OnCompleteAfterCall(); });
                            MovingScoreSet();
                            transform.name = colNo + "," + rawNo;
                        }
                    }
                }
            }
            else
            {
                if (startPos.y - endPos.y > 0)
                {
                    raycast2D = Physics2D.Raycast(transform.localPosition, Vector2.down, 2);
                    if (raycast2D.collider == null)
                    {
                        LevelController.instance.MoveAdding(this.gameObject, colNo, rawNo);
                        if (colNo != 0)
                        {
                            colNo--;
                            transform.DOLocalMove(GameController.instance.allPositions[colNo].Pos[rawNo], 0.1f).OnComplete(() => { OnCompleteAfterCall(); });
                            MovingScoreSet();
                            transform.name = colNo + "," + rawNo;
                        }
                    }
                }
                else
                {
                    raycast2D = Physics2D.Raycast(transform.localPosition, Vector2.up, 2);
                    if (raycast2D.collider == null)
                    {
                        LevelController.instance.MoveAdding(this.gameObject, colNo, rawNo);
                        if (colNo != 3)
                        {
                            colNo++;
                            transform.DOLocalMove(GameController.instance.allPositions[colNo].Pos[rawNo], 0.1f).OnComplete(() => { OnCompleteAfterCall(); });
                            MovingScoreSet();
                            transform.name = colNo + "," + rawNo;
                        }
                    }
                }
            }
        }
    }

    public void OnCompleteAfterCall()
    {
        LevelController.instance.pathPos.Clear();
        LevelController.instance.Btnclickchange();
        Ui_Controller.instance.ParticalEffectMove(transform.localPosition);
        LevelController.instance.PathChecking();
    }

    public void MovingScoreSet()
    {
        StaticData.Move++;
        Ui_Controller.instance.MoveScore();
    }
}

[System.Serializable]
public class AnsNo
{
    public int colNoAns, rawNoAns;
}
