using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BitisManager : MonoBehaviour
{
    
   
    public void OyunaYenidenBasla(){
        SceneManager.LoadScene("GameLevel");


    }

    public void AnaMenuyeDon(){
        SceneManager.LoadScene("MenuLevel");
    }
}
