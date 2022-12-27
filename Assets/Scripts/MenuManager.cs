using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager obj;
    public Canvas menuCanvas;
    public Canvas gameCanvas;
    public Canvas gameOverCanvas;
    // Start is called before the first frame update
    void Start()
    {
        if(obj==null)
        {
            obj = this;
        }
    }

    public void MostrarMenu()
    {
        menuCanvas.enabled = true;
    }

    public void OcultarMenu()
    {
        menuCanvas.enabled = false;
    }

    public void MostrarGameCanvas()
    {
        gameCanvas.enabled = true;
    }

    public void OcultarGameCanvas()
    {
        gameCanvas.enabled = false;
    }

    public void MostrarGameOver()
    {
        gameOverCanvas.enabled = true;
    }

    public void OcultarGameOver()
    {
        gameOverCanvas.enabled = false;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
