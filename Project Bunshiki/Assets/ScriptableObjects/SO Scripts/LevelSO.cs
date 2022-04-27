using UnityEngine;

[CreateAssetMenu (fileName ="New Level", menuName = "ScriptableObjects/Level")]
public class LevelSO : ScriptableObject
{
    public int levelIndex;
    public int loadIndex;
    public string levelName;
    public string levelDescription;
    public string[] topicsCovered;
    public Color nameColor;
    public Sprite levelImage;
    public Object sceneToLoad;

}
