using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour
{
    public float speed = 10.0f;
    private GameObject ball;
    private Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindWithTag("Ball");
        if (ball == null)
            Debug.Log("Problem ze znalezieniem piłki " + ball.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        float translation = 0.0f;
        var bounds = GetComponent<BoxCollider2D>().bounds.size;

        float xPlusBounds = transform.position.x + bounds.x / 2;
        float xMinusBounds = transform.position.x - bounds.x / 2;

        if (xPlusBounds < ball.transform.position.x)
            translation = speed * Time.deltaTime;
        else if (xMinusBounds > ball.transform.position.x)
            translation = -1 * speed * Time.deltaTime;
        else if (xMinusBounds < ball.transform.position.x && xPlusBounds > ball.transform.position.x)
            translation = 0;

        transform.Translate(translation, 0, 0);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
            position = transform.position;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
            transform.position = position;
    }
}
