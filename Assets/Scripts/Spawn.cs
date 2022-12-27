using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemy;
    public float tiempo;
    // Start is called before the first frame update
    void Start()
    {

        tiempo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.obj.gameState == GameState.inGame)
        {
            if (tiempo >= 5)
            {
                crearEnemigo();
                tiempo = 0;
            }
            tiempo += Time.deltaTime;
        }
    }
    void crearEnemigo()
    {
        Instantiate(enemy);
    }
}
