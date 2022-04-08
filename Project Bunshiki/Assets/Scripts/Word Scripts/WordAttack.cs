using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Word objects for the sight specifically
public class WordAttack : MonoBehaviour
{
    public int hitPoints = 6;
    public bool isIndestructible = false;
    public GameObject gameManager;
    public TextMeshPro textRenderer;
    public Color32 damageColor = new Color32(255,175,175,255);

    private IEnumerator coroutine;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        textRenderer = gameObject.GetComponent<TextMeshPro>();
    }
    void Update()
    {
        if(hitPoints==0)
        {
            //Once destroyed add to mana
            gameManager.GetComponent<GameManager>().playerUpdateMana(2);
            Destroy(gameObject);
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Wall"))
        {
            Debug.Log($"{gameObject.name} collided with {other.name}!");
            Destroy(gameObject);
        }
        else if(other.CompareTag("Bullet") && !isIndestructible)
        {
            Debug.Log($"{gameObject.name} collided with {other.name}! Dealing {other.GetComponentInParent<Bullet>().bulletPower} damage!");
            hitPoints -= other.GetComponentInParent<Bullet>().bulletPower;

            //damage animation
            coroutine = FlashColor(damageColor);
            StartCoroutine(coroutine);
            
            if(string.Equals(gameObject.name,gameManager.GetComponent<GameManager>().weakPoint))
            {
                Debug.Log($"BONUS DAMAGE!"); 
                hitPoints -= 2;
                //Particle Effect
            }
        }
        else if(other.CompareTag("Bullet") && isIndestructible)
        {
            coroutine = FlashColor(new Color32(255,255,255,176));
            StartCoroutine(coroutine);
        }
    }

    IEnumerator FlashColor(Color32 newColor)
    {
        Color32 temp = textRenderer.color;
        textRenderer.color = newColor;
        //wait for seconds
        yield return new WaitForSeconds(0.1f);

        textRenderer.color = temp;
    }

}
