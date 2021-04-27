using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class wwwFormGameData : MonoBehaviour 
{
    // The route for the api that inserts data.
    [SerializeField] string apiURL = "http://localhost:5000/gamedata";
    // References for the scripts that hold the information that is going to be inserted.
    //This object help later to access get methos on score script
    public GameObject score;
    /*public string playerId;
    
    public void getPlayerId(string playerIdFromWeb){
        playerId = playerIdFromWeb;
    }*/
    // We need to start a coroutine that calls the request
    public IEnumerator uploadData()
    {
        string playerId = PlayerPrefs.GetString("playerId", "");//Pomer Email anonimo
        // Unity sends a form, just as a html form. 
        WWWForm form = new WWWForm();
        int correctIncorrect = score.GetComponent<score>()
                                      .getcorrectIncorrect();
        int questionId = score.GetComponent<score>()
                                      .getQuestionId();
        Debug.Log(correctIncorrect);
        Debug.Log(questionId);
        Debug.Log(playerId);
        // We need to create the form first, by manually adding fields. These fields match the names of the columns in the database.
        // The values from the other scripts is checked here and added to the form.
        form.AddField("idPreguntaPR", questionId);
        form.AddField("contestoBien", correctIncorrect);
        form.AddField("idJugadorPR", playerId);
        //Id jugador: Help
        
        Debug.Log(form);

        // We create a request that makes a post to the url, and sends the form we just created.
        using (UnityWebRequest request = UnityWebRequest.Post(apiURL, form))
        {
            // The yield return line is the point at which execution will pause, and be resumed after the request ends.
            yield return request.SendWebRequest();

            // If there are no errors...
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                // We get the response text and log it in the console.
                Debug.Log(request.downloadHandler.text);
                Debug.Log("Form upload complete!");
            }
        }
    }
}