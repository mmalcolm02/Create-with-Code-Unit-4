using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObjects : MonoBehaviour
{
    //object boundaries
    private float outOfBounds = -10;
    //connect neccessary scripts
    private GameManager gameManager;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        //call scripts
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //if an object leaves player view it is destroyed
        if (CompareTag("Enemy") && transform.position.y < outOfBounds && playerController.gameOver == false)
        {
            //if enemy destroyed and the game not over score increased
            gameManager.AddScore(+1);
            Destroy(gameObject);
        }
    }
}
