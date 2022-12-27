using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType
{
    potion,
    money
}
public class Collectable : MonoBehaviour
{
    public CollectableType type = CollectableType.money;

    private SpriteRenderer sprite;
    private CircleCollider2D colision;

    bool recolectada = false;
    private GameObject player;
    public int value = 1;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        colision = GetComponent<CircleCollider2D>();
    }
    void Start()
    {
        player = GameObject.Find("Player");
    }
    void Show()
    {
        sprite.enabled = true;
        colision.enabled = true;
        recolectada = false;
    }

    void Hide()
    {
        sprite.enabled = false;
        colision.enabled = false;
        
    }

    void Collect()
    {
        Hide();
        recolectada = true;

        switch(this.type)
        {
            case CollectableType.money:
                AudioManager.obj.PlayCoin();
                GameManager.obj.CollectableOBJ(this); break; 
            case CollectableType.potion: player.GetComponent<PlayerController>().ColeccionarVida(this.value); break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {     
            Collect();
        }
    }
}
