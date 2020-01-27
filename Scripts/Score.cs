using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Player player;
    
    public Text health;
    // Update is called once per frame
    void Update()
    {
        health.text = "HEALTH: \n" + player.hp;
        health.lineSpacing = 2;

    }
}
