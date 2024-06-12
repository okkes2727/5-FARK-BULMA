using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerManager : MonoBehaviour
{
      [SerializeField] private TextMeshProUGUI SureText;
      
      int kalanSure;

      bool sureSaysinmi=false;

      GameManager gameManager;

      private void Awake()
      {
        gameManager=Object.FindObjectOfType<GameManager>();
      }
    void Start()
    {
        kalanSure=90;
        sureSaysinmi=true;
       
    }

    public void SureyiBaslat(){
         StartCoroutine(SureTimerRoutine());
    }
    IEnumerator SureTimerRoutine(){
        while(sureSaysinmi){

            yield return new WaitForSeconds(1f);
              kalanSure--;
            if(kalanSure<10)
            {
                SureText.text="0"+kalanSure.ToString();
                
            }
            else{
                   SureText.text=kalanSure.ToString();
            }
            if(kalanSure<=0){
                sureSaysinmi=false;
                SureText.text="";
                gameManager.OyunuBitir();
            }
        
        }

        
    }
    
}
