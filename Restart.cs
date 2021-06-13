using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Text score;
    
    void Start()
    {
        score.text = "Your score: " + ScoreManager.score.ToString();
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            restartGame();
        }
    }

    public void restartGame(){
        ScoreManager.score = 0;
        Hero.health = 100;
        Hero.mana = 100;
        Hero.coins = 0;
        BuyIcon.alreadyBought = false;
        Shop.isAtShop = false;
        Shop.here = false;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
