using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    public float playerSpeed = 5.0f;
    public int playerHitPoints = 12;
    public int playerManaPoints = 6;
    public bool isInvulnerable = false;
    public SpriteRenderer playerSprite;
    private Coroutine stateCoroutine;
    private Vector2 playerMovement;

    public AudioSource playerSE;
    public AudioClip playerShootSound;
    public AudioClip playerHurtSound;


    public GameObject playerBullet;
    public bool bulletsSlowed = false;
    public float bulletSpeedModifier = 1.0f;

    public GameObject gameManager;

    public Animator animator;

    private bool isGameOver = false;
 
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

        if(!isGameOver)
        {
            MovePlayer(playerMovement);
        
        
            //When space is pressed, shoot
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //Debug.Log("bang!");
                ShootBullet(playerBullet, this.gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("EnemyBullet") && !isInvulnerable)
        {
            Debug.Log("Took Damage!");
            //play sound
            playerSE.PlayOneShot(playerHurtSound);

            playerHitPoints--;

            gameManager.GetComponent<GameManager>().playerTakeDamage();
            if(playerHitPoints <= 0)
            {
                //display game over screen
                DisablePlayerMovement();
                OnPlayerDeath?.Invoke();
                
            }

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

        playerSE.PlayOneShot(playerShootSound);
        temp = Instantiate(bullet,bulletPosition,Quaternion.identity,gameManager.transform);
        
        temp.GetComponent<MoveUp>().modifier *= bulletSpeedModifier;
        

    }

    IEnumerator InvulnerableState(int invulTime)
    {
        isInvulnerable = true;
        //Animation for invulnerability
        Color32 temp = playerSprite.color;
        Color32 translucent = new Color32(255,255,255,175);
        Color32 reddened = new Color32(255,175,175,255);

        playerSprite.color = reddened;
        yield return new WaitForSeconds(0.1f);
        for(int i = invulTime*2; i>0; i--)
        {
            playerSprite.color = translucent;
            yield return new WaitForSeconds(0.5f);
            playerSprite.color = temp;
            yield return new WaitForSeconds(0.5f);
        }

        isInvulnerable = false;
        playerSprite.color = temp;

    }

    public void DisablePlayerMovement()
    {
        animator.enabled = false;
        isGameOver = true;
    }

    public void EnablePlayerMovement()
    {
        animator.enabled = true;
        isGameOver = false;     
    }
}
