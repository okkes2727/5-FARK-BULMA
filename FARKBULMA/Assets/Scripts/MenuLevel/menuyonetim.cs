using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
   [SerializeField]
   private GameObject startBtn,exitBtn;
  [SerializeField] private TextMeshProUGUI menuText;
 
    void Start()
    {
        FadeOut();
    }

    // Update is called once per frame
    void FadeOut()
    {
        menuText.GetComponent<CanvasGroup>().DOFade(1, 0.8f);
        startBtn.GetComponent<CanvasGroup>().DOFade(1, 0.8f);
 exitBtn.GetComponent<CanvasGroup>().DOFade(1, 0.8f).SetDelay(0.5f);
         

        
    }

   public void ExitGame()
   {
        Application.Quit();
    }

    public void StartGameLevel(){
            SceneManager.LoadScene("GameLevel");
    }
}
