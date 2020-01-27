using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robak : MonoBehaviour
{
    public int health = 100;
    int currentHp;
    public float movementspeed;
    public Transform leftp;
    public Transform rightp;
    Vector3 localscale;
    bool movingRight = true;
    Rigidbody2D rb;

    private void Start()
    {
        currentHp = health;
        localscale = transform.localScale;
        rb = GetComponent<Rigidbody2D> ();
        leftp = GameObject.Find("LeftWayPoint").GetComponent<Transform>();
        rightp = GameObject.Find("RightWayPoint").GetComponent<Transform>();
    }
    void Update()
    {
        if (transform.position.x > rightp.position.x)
        {
            movingRight = false;
        }
        if (transform.position.x < leftp.position.x)
        {
            movingRight = true;
        }
        if (movingRight == true)
        {
            moveR();
        }
        else moveL();
    }

    void moveR()
    {
        movingRight = true;
        localscale.x = 1;
        transform.localScale = localscale;
        rb.velocity = new Vector2(localscale.x + movementspeed, rb.velocity.y);
    }
    void moveL()
    {
        movingRight = false;
        localscale.x = -1;
        transform.localScale = localscale;
        rb.velocity = new Vector2(localscale.x - movementspeed, rb.velocity.y);
    }
    public void TakeDMG(int dmg)
    {
        currentHp -= dmg;

        if(currentHp <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
