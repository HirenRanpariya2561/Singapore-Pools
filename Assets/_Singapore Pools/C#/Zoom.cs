using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public SpriteRenderer targetSize;
    public Canvas canvas;

    void Start()
    {
        Debug.Log(canvas.GetComponent<RectTransform>().rect.height);

        if (canvas.GetComponent<RectTransform>().rect.height > 1921)
        {
            float screenRatio = (float)Screen.width / (float)Screen.height;
            float targetRatio = targetSize.bounds.size.x / targetSize.bounds.size.y;

            if (screenRatio >= targetRatio)
            {
                Camera.main.orthographicSize = targetSize.bounds.size.y / 2;
            }
            else
            {
                float differenceInSize = targetRatio / screenRatio;
                Camera.main.orthographicSize = targetSize.bounds.size.y / 2 * differenceInSize;
            }
        }
    }

} // Class Ends
