using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerMove playerOne;
    public PlayerMove playerTwo;
    public bool oneClick = false;
    public bool twoClick = false;
    public Text winner;
    int healthOne = 3;
    int healthTwo = 3;
    bool timing = false;
    public PlayerHealth oneHealth;
    public PlayerHealth twoHealth;
    float timer = 5;
    int second;
    public GameObject finish;
    private void Start()
    {
        oneHealth.MaxHealth(healthOne);
        twoHealth.MaxHealth(healthTwo);
    }
    private void Update()
    {

        if (timing)
        {
            if (timer > 0)
            {
                Debug.Log(winner.text);

                timer -= Time.deltaTime;
                second = Mathf.FloorToInt(timer % 60);
                if (timer < 4)
                {
                    winner.text = second.ToString();
                }
                Debug.Log(timer);
            }
            else if (timer <= 0) 
            {
                Debug.Log(winner.text);
                timer = 5;
                winner.enabled = false;
                timing = false;
                Debug.Log(timer);
                Round();
            }
        }

        /*for (int j = 3; j > 0; j = (int)(j - Time.deltaTime))
        {
            Debug.Log(j.ToString());
            winner.text = j.ToString();
        }*/
        /*for (int j = 0; j < playerOne.options.Length; j++)
        {
            //if(playerOne, playerTwo){}
            //((3+playerOne.ability-playerTwo.ability)%3 == 1)
            //playerOne.ability;        
        }*/

    }
    public void clicked()
    {
        if (playerOne.result(playerOne.ability))
        {
            oneClick = true;
        }
        if (playerTwo.result(playerTwo.ability))
        {
            twoClick = true;
        }
        if (oneClick == true && twoClick == true)
        {
            compare();
        }
    }
    void compare()
    {

        if (((3 + playerOne.ability - playerTwo.ability) % 3) == 1 && oneClick && twoClick)
        {
            winner.text = "Player one wins";
            winner.enabled = true;
            healthTwo -= 1;
            twoHealth.currentHealth(healthTwo);
            timing = true;

        }
        else if (((3 + playerOne.ability - playerTwo.ability) % 3) == 2 && oneClick && twoClick)
        {
            winner.text = "Player two wins";
            winner.enabled = true;
            healthOne -= 1;
            oneHealth.currentHealth(healthOne);
            timing = true;
        }
        else if (oneClick && twoClick)
        {
            winner.text = "Draw";
            winner.enabled = true;
            timing = true;
        }
    }
    private void Round()
    {
        
        twoClick = false;
        oneClick = false;
        playerOne.ability = playerOne.options.Length + 1;
        playerTwo.ability = playerTwo.options.Length + 1;
        if (healthOne == 0 || healthTwo == 0)
        {
            twoClick = true;
            oneClick = true;
            finish.SetActive(true);
        }
        playerOne.option();
        playerTwo.option();
    }
    public void again()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void exit()
    {
        Application.Quit();
    }
}
