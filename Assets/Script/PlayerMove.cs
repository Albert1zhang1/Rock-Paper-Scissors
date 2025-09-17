using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public Button[] options;
    public int ability;
    public GameManager move;
    private void Start()
    {
        ability = options.Length + 1;
    }
    public void option()
    {
        if(move.twoClick == false && move.oneClick == false)//&& ok == true)
        {
            for (int j = 0; j < options.Length; j++)
            {
                options[j].interactable = true;
            }
        }
    }
    public void choice(int i)
    {
        for (int j = 0; j < options.Length; j++)
        {
            options[j].interactable = false;
        }
        ability = i;
        move.clicked();
    }

    public bool result(int i)
    {
        if (i <= options.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
