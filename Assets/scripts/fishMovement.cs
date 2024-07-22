using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class fishMovement : MonoBehaviour
{
    public float speed = 2f;
    private float direction;
    private float screenBounds;
    void Start()
    {
        direction = Random.Range(0, 2) == 0 ? 1 : -1;

        screenBounds = Camera.main.orthographicSize * Camera.main.aspect;

        if (direction == 1)
        {
            transform.position = new Vector3(screenBounds + transform.localScale.x+2, Random.Range(-Camera.main.orthographicSize+2, Camera.main.orthographicSize-2), 0);
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.position = new Vector3(-screenBounds - transform.localScale.x-2, Random.Range(-Camera.main.orthographicSize+2, Camera.main.orthographicSize-2), 0);
        }
    }

    void Update()
    {
        transform.Translate(Vector2.left * direction * speed * Time.deltaTime);

        if (direction == 1 && transform.position.x < -screenBounds - transform.localScale.x-2 || direction == -1 && transform.position.x > screenBounds + transform.localScale.x+2)
        {
            Destroy(gameObject);
        }
    }
}
