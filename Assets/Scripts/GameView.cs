using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    public Text coinsText, scoreText, bestScoreText;
    private PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.obj.gameState==GameState.inGame)
        {
            int coins= GameManager.obj.collectableObj;
            float score= controller.getDistanceTraveled();
            float bestScore=PlayerPrefs.GetFloat("maxscore",0);

            coinsText.text = coins.ToString();
            scoreText.text = "Score: "+score.ToString("f1");
            bestScoreText.text = "Best Score: " + bestScore.ToString("f1");
        }
    }
}
