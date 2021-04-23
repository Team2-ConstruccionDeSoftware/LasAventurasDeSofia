
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Threading.Tasks;
using Random=UnityEngine.Random;

public class readcsv : MonoBehaviour
{
    [SerializeField] TextAsset levelData;

    public string[] dataLines;

    HashSet<int> used = new HashSet<int>();
    
    public void Awake()
    {
        dataLines = levelData.text.Split('\n'); 
        shuffle(dataLines);
        //Debug.Log(dataLines.Length);
    }

    public string getLine(int choseRow){
        for(int row = 0; row < dataLines.Length; row++)
        {
            if (!used.Contains(row)){
                used.Add(row);
                return dataLines[row];
            }
        }
        return dataLines[choseRow];
        //return dataLines[choseRow];
    }
    public static void shuffle(string[] dataLines)  
    {  
        int n = dataLines.Length;  
        System.Random rand = new System.Random();
        for(int i = 0; i < n; i++){
            swap(dataLines, i, i + rand.Next(n - i));
        }  
    }

    public static void swap(string[] dataLines, int indxA, int indxB){
        string temp = dataLines[indxA];
        dataLines[indxA] = dataLines[indxB];
        dataLines[indxB] = temp;
    }
}
