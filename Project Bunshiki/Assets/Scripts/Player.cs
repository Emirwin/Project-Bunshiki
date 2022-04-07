using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    public int playerHitPoints = 12;
    public int playerManaPoints = 6;
    public bool isInvulnerable = false;
    private Coroutine stateCoroutine;
    private Vector2 playerMovement;

    public GameObject playerBullet;
    public bool bulletsSlowed = false;
    public float bulletSpeedModifier = 1.0f;

    public GameObject gameManager;

    public Animator animator;
 
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        //Move Player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        playerMovement = new Vector2(horizontalInput, verticalInput);

        //Animation
        animator.SetFloat("PlayerTranformX", horizontalInput);

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
        if(other.CompareTag("EnemyBullet") && !isInvulnerable)
        {
            Debug.Log("Took Damage!");
            playerHitPoints--;

            gameManager.GetComponent<GameManager>().playerTakeDamage();

            StartCoroutine(InvulnerableState(2));

        }
    }

    void MovePlayer(Vector2 direction)
    {
        transform.Translate(direction * Time.deltaTime * playerSpeed);
    }

    public void ShootBullet(GameObject bullet, GameObject source)
    {
        Vector3 bulletPosition = new Vector3(transform.position.x,transform.position.y + 0.5f,0);
        GameObject temp;

        temp = Instantiate(bullet,bulletPosition,Quaternion.identity,gameManager.transform);
        
        temp.GetComponent<MoveUp>().modifier *= bulletSpeedModifier;
        

    }

    IEnumerator InvulnerableState(int invulTime)
    {
        isInvulnerable = true;
        //Animation for invulnerability
        yield return new WaitForSeconds(invulTime);
        isInvulnerable = false;
    }
}
