using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogToScreen : MonoBehaviour
{
    uint qsize = 15;
    Queue mylogQueue = new Queue(); 
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started up logging"); 
        
    }
    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog; 
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog; 
    }

    void HandleLog(string logString , string stackTrace , LogType type )
    {
        mylogQueue.Enqueue( "["+type+"] : "+logString );
        if (type == LogType.Exception)
            mylogQueue.Enqueue(stackTrace);
        while (mylogQueue.Count > qsize)
            mylogQueue.Dequeue(); 
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width - 400, 0, 400, Screen.height));
        GUILayout.Label("\n " + string.Join("\n ", mylogQueue.ToArray())); 
        GUILayout.EndArea();
    }
}
