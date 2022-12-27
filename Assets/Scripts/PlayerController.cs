using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 6f;
    public bool estaEnSuelo=false;
    public bool caida = false;
    Rigidbody2D rb;
    Animator anim;
    public LayerMask groundMask;
    public float rayDist = 2f;
    public float speed=2f;
    public int vidaActual;
    public const int VIDA_INICIAL = 100, VIDA_MAX = 200, VIDA_MIN = 10;
    Vector3 posicionInicial;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = this.transform.position;
        vidaActual = VIDA_INICIAL;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.obj.gameState == GameState.inGame)
        {
            isGrounded();
            Fall();
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && estaEnSuelo)
            {
                Jump();
            }

            anim.SetBool("caida", caida);
            anim.SetBool("estaEnPiso", estaEnSuelo);
        }
        Debug.DrawRay(this.transform.position, Vector2.down * rayDist, Color.red);
        //if (currentGameState != GameState.inGame)
        //{
        //    Time.timeScale = 0f;
        //}
        //else
        {
            Time.timeScale = 1f;
        }
    }
    private void FixedUpdate()
    {
        if (GameManager.obj.gameState == GameState.inGame)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = new Vector2(speed * 2, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
    public void StartGame()
    {
        AudioManager.obj.StopAudio();
        AudioManager.obj.StarGame();
        anim.SetBool("estaVivo", true);
        anim.SetBool("estaEnPiso", true);
        vidaActual = VIDA_INICIAL;
        GameManager.obj.resetCoin();
        this.transform.position = posicionInicial;
        rb.velocity = Vector2.zero;
        GameObject camaraPrincipal = GameObject.Find("Main Camera");
        camaraPrincipal.GetComponent<CameraFollow>().ResetCameraPosition();
    }
    void Jump()
    {
        AudioManager.obj.PlayJump();
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    void Fall()
    {
        if (rb.velocity.y >= 0)
        {
            caida = false;
        }
        else
        {
            caida = true;
        }
    }

    public void isGrounded()
    {
        if(Physics2D.Raycast(this.transform.position,Vector2.down, rayDist, groundMask))
        {
            estaEnSuelo = true;
        }else
        {
            estaEnSuelo = false;
        }
    }

    public void Die()
    {
        AudioManager.obj.StopAudio();
        AudioManager.obj.PlayGameOver();
        float distanciaRecorrida = getDistanceTraveled();
        float maximaDistanciaPrevia = PlayerPrefs.GetFloat("maxscore", 0f);
        if(distanciaRecorrida>maximaDistanciaPrevia)
        {
            PlayerPrefs.SetFloat("maxscore", distanciaRecorrida);
        }
        anim.SetBool("estaVivo", false);
        GameManager.obj.gameState=GameState.GameOver;
        GameManager.obj.GameOver();
    }

    public void ColeccionarVida(int vida)
    {
        this.vidaActual += vida;
        if (this.vidaActual >= VIDA_MAX)
        {
            this.vidaActual = VIDA_MAX;
        }
        if(this.vidaActual<=0)
        {
            Die();
        }
    }

    public int getVida()
    {
        return this.vidaActual;
    }

    public float getDistanceTraveled()
    {
        return this.transform.position.x - posicionInicial.x;
    }
}
