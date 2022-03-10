using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    public int playerHitPoints = 12;
    private Vector2 playerMovement;
    public GameObject playerBullet;
    public GameObject gameManager;
 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Move Player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        playerMovement = new Vector2(horizontalInput, verticalInput);

        MovePlayer(playerMovement);

        //When space is pressed, shoot
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("bang!");
            ShootBullet(playerBullet, this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("EnemyBullet"))
        {
            Debug.Log("Took Damage!");
            playerHitPoints--;
        }
    }

    void MovePlayer(Vector2 direction)
    {
        transform.Translate(direction * Time.deltaTime * playerSpeed);
    }

    public void ShootBullet(GameObject bullet, GameObject source)
    {
        Vector3 bulletPosition = new Vector3(transform.position.x,transform.position.y + 0.5f,0);
        Instantiate(bullet,bulletPosition,Quaternion.identity,gameManager.transform);
    }

}
