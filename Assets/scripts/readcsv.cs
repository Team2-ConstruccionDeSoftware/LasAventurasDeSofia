using System;
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
    public Dictionary<string, int> preguntas = new Dictionary<string, int>();
    public Dictionary<string, int> before = new Dictionary<string, int>();
    public int line;
    [SerializeField] public string level = "1";

    public void Awake()
    {
        dataLines = levelData.text.Split('\n'); 
        if(level == "1"){
            for(int i = 0; i < dataLines.Length; i++){
            before.Add(dataLines[i], i+2);
        }
        }
        else{
            for(int i = 0; i < dataLines.Length; i++){
            before.Add(dataLines[i], i+1);
            }
        }
        shuffle(dataLines);
    }
    public string getLine(int choseRow){
        for(int row = 0; row < dataLines.Length; row++)
        {
            if (!used.Contains(row)){
                if(before.ContainsKey(dataLines[row])){
                    used.Add(row);
                    int second = before[dataLines[row]];
                    Debug.Log("second"+second);
                    string lineStr = level + Convert.ToString(second);
                    line = Convert.ToInt32(lineStr);
                    var csvData = dataLines[row].Trim('\r', '\n').Split(','); 
                    string key = csvData[0];
                    preguntas.Add(key, line);
                    var test = preguntas[key];
                    return dataLines[row];
                }
            }
        }
        return dataLines[choseRow];
    }
    public int getIdPregunta(string pathPregunta){
        if(preguntas.ContainsKey(pathPregunta)){
            int valuePregunta = preguntas[pathPregunta];
            return valuePregunta;
        }
        return -1;
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
