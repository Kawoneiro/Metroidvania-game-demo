using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shopEnter : MonoBehaviour
{
    public int nextScene = 2;
    public Animator swap;

    bool colliding = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        colliding = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        colliding = false;
    }
    private void Update()
    {
        if (colliding && Input.GetKeyDown(KeyCode.UpArrow))
        {
            SceneManager.LoadScene(nextScene);
        }
    }

}
