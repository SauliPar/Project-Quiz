using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaScript : MonoBehaviour
{   
    void start(){
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }
    public void changeButtonColor(int buttonPressed, int theRightAnswer){

    }
}
