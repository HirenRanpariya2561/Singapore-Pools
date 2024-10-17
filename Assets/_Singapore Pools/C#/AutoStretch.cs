using UnityEngine;

namespace HeadBoxGames
{
    public class AutoStretch : MonoBehaviour
    {

        public bool KeepAspectRatio = true;
        public bool ExecuteOnUpdate = true;
        [Range(0, 0.1f)]
        public float offset = 0.035f;

        private void Start()
        {
            Resize(KeepAspectRatio);
        }

        private void FixedUpdate()
        {
            if (ExecuteOnUpdate)
            {
                Resize(KeepAspectRatio);
            }
        }

        private void Resize(bool keepAspect = false)
        {
            SpriteRenderer component = GetComponent<SpriteRenderer>();
            transform.localScale = new Vector3(1f, 1f, 1f);
            float x = component.sprite.bounds.size.x;
            float y = component.sprite.bounds.size.y;
            float num3 = Camera.main.orthographicSize * 2f;
            float num4 = (num3 / ((float)Screen.height)) * Screen.width;
            Vector3 vector = new Vector3(1f, 1f, 1f);
            if (!keepAspect)
            {
                vector.x = num4 / x;
                vector.y = num3 / y;

                vector.x = vector.x + offset;
                vector.y = vector.y + offset;
            }
            else
            {
                Vector2 vector2 = new Vector2(x / y, y / x);
                if ((num4 / x) > (num3 / y))
                {
                    vector.x = num4 / x;
                    Vector3 vectorPtr1 = vector;
                    vectorPtr1.y = vector.x * vector2.y;
                }
                else
                {
                    vector.y = num3 / y;
                    Vector3 vectorPtr2 = vector;
                    vectorPtr2.x = vector.y * vector2.x;
                }
            }
            transform.localScale = vector;
        }
    }
}
