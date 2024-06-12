using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class GameManager : MonoBehaviour
{

   [SerializeField] public int tiklanabilirAlanlar=5; 
   public TextMeshProUGUI farkText;
   public TextMeshProUGUI bulunanfarkText;
   [SerializeField] private GameObject sonucPaneli;
     [SerializeField] private AudioClip buttonClickSound; // Buton tıklama sesi
    private AudioSource audioSource;
  
  public AudioSource sonucPaneliSesi; // Sonuç paneli sesi

    
    SureManager sureManager;
    // Start is called before the first frame update

        private void Awake()
     {
    sonucPaneli.GetComponent<RectTransform>().localScale = Vector3.zero;
      audioSource = GetComponent<AudioSource>();
    if (audioSource == null)
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }
     }
   void Start()
    {
       
        farkText.text = "Kalan fark sayısı: " + tiklanabilirAlanlar.ToString();
     
    if (sonucPaneliSesi != null)
    {
        sonucPaneliSesi.Stop();
    }
    }

   public void Farkbulundu()
 {
       tiklanabilirAlanlar--;
        if (tiklanabilirAlanlar == 0)
        {
            Debug.Log("Tüm farklar bulundu!");
            OyunuBitir();
        }
        else
        {
            // Fark sayısını güncelle
            farkText.text = "Kalan fark sayısı: " + tiklanabilirAlanlar.ToString();
        }
   // Butonu görünür yap ve etkinliği kaldır
    GameObject btnObject = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
    if (btnObject != null)
    {
        CanvasGroup canvasGroup = btnObject.GetComponent<CanvasGroup>();
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 1f; // Alfa değerini 1'e çek
            canvasGroup.interactable = false; // Etkinliği kaldır
            canvasGroup.blocksRaycasts = false; // Tıklamayı engelle
        }
    }

        
      // Ses çal
        if (buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }

        
 }

 public void OyunuBitir(){
       bulunanfarkText.text = (5 - tiklanabilirAlanlar).ToString();
       sonucPaneli.GetComponent<RectTransform>().DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack);
      
    if (sonucPaneliSesi != null && sonucPaneliSesi.clip != null)
    {
        sonucPaneliSesi.PlayOneShot(sonucPaneliSesi.clip);
    }
 }
}
