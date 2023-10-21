using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private Rigidbody enemyRB;
    public float enemySpeed = 2.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        //call rigidbody to add force
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        

    }

    // Update is called once per frame
    void Update()
    {
        //calculate vector to player then add force
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRB.AddForce(lookDirection * enemySpeed);

        


    }
}
