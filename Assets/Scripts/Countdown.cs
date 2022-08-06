using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Text textBox;
    public float timeStart =  60f;
    public float delayTime = 2f;
    public bool enableTimer = false;
    void Start()
    {
        
    }
    void gameChanger(){
        GameManagerScript gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        gameManager.GameOver();
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    
    if (enableTimer == false){
        if(timeStart < 10f){
           textBox.text = timeStart.ToString("F1"); 
        } else { textBox.text = timeStart.ToString("F0"); }  
    }
    else if (timeStart > 10f && enableTimer){
        timeStart -= Time.deltaTime;
        textBox.text = timeStart.ToString("F0");
    }
    else if (timeStart <= 10f && timeStart > 0.01f && enableTimer){
        timeStart -= Time.deltaTime;
        textBox.text = timeStart.ToString("F1");
        textBox.color = Color.red;
        textBox.fontSize = 60;
    }
    else if (timeStart <= 0.01f && enableTimer){
        timeStart = 0f;
        textBox.text = timeStart.ToString("F0");
        Invoke("gameChanger", delayTime);
    }
}  
}
