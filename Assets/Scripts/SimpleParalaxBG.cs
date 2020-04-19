using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// скрипт для создания эффекта смещения заднего фона

public class SimpleParalaxBG : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float startPosX;
    [SerializeField] private float endPosX;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= endPosX)
        {
            transform.position = new Vector2(startPosX, transform.position.y);
        }
    }
}
