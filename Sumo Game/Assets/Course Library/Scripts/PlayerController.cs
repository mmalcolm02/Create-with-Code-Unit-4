using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5.0f;
    private Rigidbody playerRB;
    private GameObject focalPoint;
    public bool hasPowerup;
    private float powerupStrength = 15.0f;
    public GameObject powerupIndicator;
    public bool gameOver;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {

        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {

        float forwardInput = Input.GetAxis("Vertical");
        playerRB.AddForce(focalPoint.transform.forward * speed * forwardInput);

        //power up indicator following player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.62f, 0);

        //if player falls off game over and display score
        if (transform.position.y < -10)
        {
            gameOver = true;
            Debug.Log("Game Over! Total Score: " + gameManager.score);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //has player collided with powerup
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true; //turn on powerup
            Destroy(other.gameObject); //remove powerup object
            StartCoroutine(PowerupCooldown()); 
            powerupIndicator.gameObject.SetActive(true); //activate/visible powerup object
        }
    }

    IEnumerator PowerupCooldown() //start loop outside of update
    {
        yield return new WaitForSeconds(7); //active time of powerup
        hasPowerup = false; //turnoff powerup
        powerupIndicator.gameObject.SetActive(false); //deactivate/invisible powerup object
    }

    private void OnCollisionEnter(Collision collision)
    {
        //parameters of collision - with enemy and with powerup active
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            //call enemy rigidbody
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            //determine vector player to enemy
            Vector3 enemyDirection = (collision.gameObject.transform.position - transform.position);
            //log when collission occurs
            Debug.Log("Collided with " + collision.gameObject.name + "with power up set to" + hasPowerup);
            //adding force to collision if powerup active
            enemyRigidbody.AddForce(enemyDirection * powerupStrength, ForceMode.Impulse);
        }
    }
}
