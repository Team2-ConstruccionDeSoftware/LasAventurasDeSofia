
using UnityEngine;

public class readcsv : MonoBehaviour
{
    [SerializeField] TextAsset levelData;

    string[] dataLines;
    
    public void Awake()
    {
        dataLines = levelData.text.Split('\n'); 
        //Debug.Log(dataLines.Length);
    }

    public string getLine(int choseRow){
        return dataLines[choseRow];
    }
}
