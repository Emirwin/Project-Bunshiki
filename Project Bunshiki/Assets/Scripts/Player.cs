using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    private Vector2 playerMovement;
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
    }

    void MovePlayer(Vector2 direction)
    {
        transform.Translate(direction * Time.deltaTime * playerSpeed);
    }
}
