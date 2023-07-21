using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpSystem : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator  animator;

    public void PopUp()
    {
        popUpBox.SetActive(true);
        animator.SetTrigger("pop");
    }
}
