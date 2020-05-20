using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalletMovement : MonoBehaviour
{ 
    private float speed = 10.0f;
    private float translation = 0.0f;
    private Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        translation = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        transform.Translate(translation, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
            position = transform.position;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
            transform.position = position;
    }
}
