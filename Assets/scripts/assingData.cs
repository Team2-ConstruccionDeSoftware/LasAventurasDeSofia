using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Threading.Tasks;
using Random=UnityEngine.Random;

public class assingData : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject prefab;
    GameObject instance;
    [SerializeField] GameObject background;
    [SerializeField] int Qnumber;
    string[] csvData;

    void Start()
    {
        string dataLines = background.GetComponent<readcsv>().getLine(Qnumber);

        csvData = dataLines.Trim('\r', '\n').Split(',');  

        instance = Instantiate(prefab, transform.position, Quaternion.identity);

        instance.transform.parent = transform;

        SpriteRenderer[] sprites = instance.GetComponentsInChildren<SpriteRenderer>();//Arreglo con todos los sprite rederers

        sprites[0].sprite = Resources.Load<Sprite>(csvData[0]);

        //Lista con los sprites de getComponentsInChildren
        int[] order = {3,4,5}; //relacionar con los botones

        //Randomizar lista
        shuffle(order);
        
        foreach(int number in order){
            Debug.Log("'"+ csvData[number] + "'");
        }
        
        //Asignar valores, los valores para las respuestas son 2,4,6
        sprites[2].sprite = Resources.Load<Sprite>(csvData[order[0]]);
        sprites[4].sprite = Resources.Load<Sprite>(csvData[order[1]]);
        sprites[6].sprite = Resources.Load<Sprite>(csvData[order[2]]);
        
        //Condicion para saber cual fue el correcto checando order, los botones en srpites son 1,3,5
        int counter = 1;
        foreach(var indx in order){
            if(indx == 3){
                break;
            }
            counter = counter + 2;
        }
        sprites[counter].gameObject.GetComponent<boton>().correct = true;
        //Tag button colliders as correct or incorrect
        sprites[counter].gameObject.tag = "correcto";
    }
    public static void shuffle(int[] list)  
    {  
        int n = list.Length;  
        System.Random rand = new System.Random();
        for(int i = 0; i < n; i++){
            swap(list, i, i + rand.Next(n - i));
        }  
    }

    public static void swap(int[] list, int indxA, int indxB){
        int temp = list[indxA];
        list[indxA] = list[indxB];
        list[indxB] = temp;
    }
}
