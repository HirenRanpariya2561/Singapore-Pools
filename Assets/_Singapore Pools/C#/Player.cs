using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public static Player instance;
    private void Awake()
    {
        instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("star"))
        {
            Vector2 starBoardPosWorld = Camera.main.ScreenToWorldPoint(GameController.instance.starBoard.transform.position);
            Sound_Manager.instance.Coin_Collect_Clip();
            collision.gameObject.transform.parent = null;
            Debug.Log(collision.gameObject.name);
            StaticData.Coin++;
            Ui_Controller.coinUpdate?.Invoke();
            collision.gameObject.transform.DOLocalMove(starBoardPosWorld, 0.5f).OnComplete(() => { Destroy(collision.gameObject); });
            collision.gameObject.transform.DOScale(new Vector3(0,0,0), 0.5f);
        }
    }

    public void startAnimation()
    {
        DOTween.Sequence()
           .Append(transform.DORotate(new Vector3(0, 0,7), 0.3f))
           .Append(transform.DORotate(new Vector3(0, 30, 0), 0.3f))
           .Append(transform.DORotate(new Vector3(0, 0, -7), 0.3f))
           .Append(transform.DORotate(new Vector3(0, -30, 0), 0.3f))
           .SetLoops(-1);
    }
}
