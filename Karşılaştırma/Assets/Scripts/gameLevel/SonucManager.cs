using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class SonucManager : MonoBehaviour
{
       [SerializeField]
    private TextMeshProUGUI dogruAdetTxt, yanlisAdetTxt, puanTxt;
   
    int puanSure=10;
    int toplamPuan,yazdirilacakPuan,artisPuani;
    bool sureBittimi=true;
     public void SonuclariGoster(int dogruAdet,int yanlisAdet,int puan)
 {
     dogruAdetTxt.text = dogruAdet.ToString();
     yanlisAdetTxt.text = yanlisAdet.ToString();
    puanTxt.text = puan.ToString();
      toplamPuan = puan;
  artisPuani = toplamPuan / 10;

  StartCoroutine(PuaniYazdirRoutine());

 }
 
    IEnumerator PuaniYazdirRoutine()
    {
        while(sureBittimi)
        {
            yield return new WaitForSeconds(0.1f);

            yazdirilacakPuan += artisPuani;

            if(yazdirilacakPuan>=toplamPuan)
            {
                yazdirilacakPuan = toplamPuan;
            }

            puanTxt.text = yazdirilacakPuan.ToString();


            if(puanSure<=0)
            {
                sureBittimi = false;
            }

            puanSure--;
        }
    }

     public void AnaMenuyeDon()
 {
     SceneManager.LoadScene("MenuLevel");
 }

 public void TekrarOyna()
 {
     SceneManager.LoadScene("GameLevel");
 }

  
}
