using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private enum State
    {
        WaitingToStart,
        Playing

    } 
    
    private State state;
    public GameManager gameManager;
    public float velocity = 1 ;
    private Rigidbody2D rb ;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        state = State.WaitingToStart;
        rb.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
        switch(state){
        default:
        case State.WaitingToStart:
            if(Input.GetMouseButtonDown(0))
            {
                GameObject.Find("jump").GetComponent<AudioSource>().Play ();
                rb.velocity = Vector2.up * velocity ; 
                state = State.Playing;
                rb.bodyType = RigidbodyType2D.Dynamic ;
            }
            break;
        }
    }   
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GameOver();
    }
    
}
