using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicePositionRand : MonoBehaviour
{
    public List<GameObject> choices;
    
    private List<Transform> location;
    // Start is called before the first frame update
    void Start()
    {
        location = new List<Transform>();
        List<Vector3> newLocation = new List<Vector3>();


        //populate location list
        for(int choiceNo = 0; choiceNo < choices.Count; choiceNo++)
        {
            location.Add(choices[choiceNo].transform);
            Debug.Log($"Added {location[choiceNo]}: {location[choiceNo].position}");
        }

        //populate newLocation list
        for(int entryNo = 0; entryNo < choices.Count; entryNo++)
        {
            int randomIndex = Random.Range(0,location.Count);
            //Debug.Log($"Accessing {randomIndex} : {location[randomIndex].position}");
            newLocation.Add(location[randomIndex].position);

            location.RemoveAt(randomIndex);
        }

        //now we set object transform values to those in newLocation
        for(int choiceNo = 0; choiceNo < choices.Count; choiceNo++)
        {
            Debug.Log($"New Location {choiceNo}: {newLocation[choiceNo]}");
            choices[choiceNo].transform.position = newLocation[choiceNo];
        }
    }

    public bool OneIsDestroyed()
    {
        for(int i = 0; i < choices.Count; i++)
        {
            if(choices[i].Equals(null) || choices[i] == null)
            {
                return true;
            }
        }
        return false;
    }
}
