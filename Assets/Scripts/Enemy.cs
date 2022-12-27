using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int velocidad;
    private Rigidbody2D rb;
    Vector3 posicionInicial;
    private float posy;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocidad = Random.Range(3, 8);
        posy = Random.Range(-6, 2.5f);
        posicionInicial = GameObject.Find("Spawner").transform.position;
        transform.position = new Vector3(posicionInicial.x, posy, 0);
        Destroy(gameObject,10f);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.obj.gameState!=GameState.inGame)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(-velocidad, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().ColeccionarVida(-40);
            Destroy(gameObject);
        }
    }
}
