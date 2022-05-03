using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sakanobori : Yakuyaki
{
    public List<GameObject> miniPlayer;
    [SerializeField]
    private int currMini = 0;
    public int miniPlayerLives;
    public TextMeshPro miniPlayerLivesUI;
    private Rigidbody2D miniPlayerRb;
    private Vector2 currDestination;
    private Vector2 prevDestination;
    public bool isMiniMoving = false;

    public GameObject nextProblemButton;

    public AudioSource mySE;
    public AudioClip jumpSE, landOnWaterSE, landOnRocksSE;

    private bool noMoreFish = false;

    public override void Start()
    {
        miniPlayerRb = miniPlayer[currMini].GetComponent<Rigidbody2D>();

        miniPlayerLives = miniPlayer.Count - 1;

        miniPlayerLivesUI = GameObject.Find("LivesUI").GetComponent<TextMeshPro>();
        miniPlayerLivesUI.text = $"{miniPlayerLives - currMini}";

        activeProblem = GameObject.FindGameObjectWithTag("ActiveProblem");
        
        
        currDestination = Vector2.zero;
        prevDestination = currDestination;
        base.Start();
        
    }
    public override void Update()
    {
        base.Update();
        if(miniPlayerRb.velocity != Vector2.zero && !isMiniMoving) 
        {
            isMiniMoving = true;
        }
        if(noMoreFish && !nextProblemButton.activeInHierarchy)
        {
            nextProblemButton.SetActive(true);
        }
    }

    public enum jumpDirection {
        Left, Center, Right
    }
    public void Jump(jumpDirection direction)
    {
        mySE.PlayOneShot(jumpSE);
        if(direction==jumpDirection.Left) {
            //miniPlayerSprite[currMini].transform.rotation = new Quaternion(0,0,-0.310049385f,0.950720489f);
            miniPlayer[currMini].GetComponent<SakanoboriMiniCollision>().miniSprite.transform.rotation = new Quaternion(0,0,0.5f,0.866025388f);

            currDestination = new Vector2(prevDestination.x -3f,prevDestination.y +2f);
            
        }
        else if(direction==jumpDirection.Right) {
            miniPlayer[currMini].GetComponent<SakanoboriMiniCollision>().miniSprite.transform.rotation = new Quaternion(0,0,-0.5f,0.866025388f);
            currDestination = new Vector2(prevDestination.x +3f,prevDestination.y +2f);
        }
        else {
            miniPlayer[currMini].GetComponent<SakanoboriMiniCollision>().miniSprite.transform.rotation = new Quaternion(0,0,0,1);
            currDestination = new Vector2(prevDestination.x,prevDestination.y +2f);
        }

        miniPlayerRb.AddForce(currDestination, ForceMode2D.Impulse);
        
        
        //miniPlayerRb.transform.Translate(new Vector3(1,1,1));
    }

    public void StopMini()
    {
        isMiniMoving = false;
        miniPlayerRb.velocity = Vector2.zero;
    }

    public void NextMini()
    {
        miniPlayer[currMini].SetActive(false);
        currMini++;
        if(!miniPlayer[currMini].Equals(null)) 
        {
            miniPlayer[currMini].SetActive(true);

            miniPlayerRb = miniPlayer[currMini].GetComponent<Rigidbody2D>();
            currDestination = Vector2.zero;
            prevDestination = currDestination;

            isMiniMoving = false;
        }
        else
        {
            Debug.Log("No more fish!");
            noMoreFish = true;
            nextProblemButton.SetActive(true);
        }
    
        miniPlayerLivesUI.text = $"{miniPlayerLives - currMini}";
    
    }

    public void ResetMini(Vector3 position)
    {
        StopMini();
        miniPlayer[currMini].GetComponent<SakanoboriMiniCollision>().miniSprite.transform.rotation = new Quaternion(0,0,0,1);

        miniPlayer[currMini].GetComponent<SakanoboriMiniCollision>().transform.position = miniPlayer[currMini].GetComponent<SakanoboriMiniCollision>().startPosition;

        currDestination = Vector2.zero;
        prevDestination = currDestination;

    }

    public void NextProblem()
    {
        Debug.Log("Next Problem");
        StartCoroutine(DestroyProblemDelay());
        if(!noMoreFish)
        {
            ResetMini(miniPlayer[currMini].GetComponent<SakanoboriMiniCollision>().startPosition);

        }
        
        
    }

    public override void SpawnProblem(GameObject problem)
    {
        numberSpawned++;
        noActiveProblem = false;
        nextProblemButton.SetActive(false);

        Vector3 problemPos = problem.transform.position;
        Debug.Log($"Spawning {problem}");
        activeProblem = Instantiate(problem, problemPos, Quaternion.identity, gameObject.transform);
        
        
    }

    IEnumerator DestroyProblemDelay()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(activeProblem);
    }

    public void PlayLandOnSE(string landOnWhat)
    {
        if(landOnWhat == "water")
        {
            mySE.PlayOneShot(landOnWaterSE);
        }
        else if(landOnWhat == "rock")
        {
            mySE.PlayOneShot(landOnWaterSE);
        }
    }
}
