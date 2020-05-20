using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 30.0f;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("RunBall", 3);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vect = new Vector2(direction.x * speed * Time.deltaTime, direction.y * speed * Time.deltaTime);
        transform.Translate(vect.x, vect.y, 0);
    }

    public void RunBall()
    {
        float x = Random.value;
        float y = Random.value >= 0.5f ? 1f : -1f;
        direction = new Vector2(x, y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pallet")
        {
            float hitPos = (transform.position.x - collision.transform.position.x) / collision.collider.bounds.size.x;
            direction.x = hitPos * 3.0f;
            direction.y += hitPos * 0.1f;
            direction = Vector2.Reflect(direction, collision.contacts[0].normal);
        } else if(collision.gameObject.tag == "Wall") 
        {
            direction = Vector2.Reflect(direction, collision.contacts[0].normal);
        } else if (collision.gameObject.tag == "Goal")
        {
            GameController.instance.Score(collision.gameObject.name == "EnemyGoal");
            direction = Vector2.zero;
            transform.position = Vector2.zero;
            Invoke("RunBall", 2);
        }
    }
}
