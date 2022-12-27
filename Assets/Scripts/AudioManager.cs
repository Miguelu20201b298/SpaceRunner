using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource reproductor;
    public AudioSource fondo;
    public AudioClip jump;
    public AudioClip coin;
    public AudioClip gameOver;
    public static AudioManager obj;

    private void Awake()
    {
        if (obj == null)
        {
            obj = this;
        }
        reproductor = gameObject.GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        reproductor.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayMenu()
    {
        reproductor.volume = 0.3f;
        reproductor.Stop();
        reproductor.Play();
    }
    public void PlayJump()
    {
        reproductor.PlayOneShot(jump);
    }
    public void PlayCoin()
    {
        reproductor.PlayOneShot(coin, 0.3f);
    }
    public void PlayGameOver()
    {
        reproductor.PlayOneShot(gameOver, 0.3f);
    }
    public void StopAudio()
    {
        reproductor.Stop();
        fondo.Stop();
    }
    public void StarGame()
    {
        reproductor.volume = 1f;
        fondo.Play();
    }
}
