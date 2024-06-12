using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject puanSurePaneli;

    [SerializeField]
    private GameObject pausePaneli,sonucPaneli;

    [SerializeField]
    private GameObject PuaniKapYazisi,BuyukOlanSayiyiSecYazisi;
    
       [SerializeField] private TextMeshProUGUI ustText, altText, puanText;


    [SerializeField]
    private GameObject ustDikdörtgen,altDikdörtgen;

    TimerManager timerManager;
    DairelerManager dairelerManager;

    TrueFalseManager trueFalseManager;

    SonucManager SonucManager;

    int oyunSayac,KacinciOyun;

    int ustDeger,altDeger;

    int buyukDeger;

    int toplamPuan,artisPuani;
    
    int dogruAdet,yanlisAdet;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip baslangicSesi,dogruSesi,yanlisSesi,bitisSesi;

    int butonDegeri;
    private void Awake(){
        timerManager=Object.FindObjectOfType<TimerManager>();
        dairelerManager = Object.FindObjectOfType<DairelerManager>(); 
        trueFalseManager=Object.FindObjectOfType<TrueFalseManager>();
        
        audioSource=GetComponent<AudioSource>();
        
        
    }

    
    void Start()
    {
        KacinciOyun=0;
        oyunSayac=0;
        ustText.text = "";
        altText.text = "";
        puanText.text = "0";
        toplamPuan=0;
        SahneEkraniniGuncelle();
    }

   void SahneEkraniniGuncelle()
   {
    puanSurePaneli.GetComponent<CanvasGroup>().DOFade(1,1f);
    PuaniKapYazisi.GetComponent<CanvasGroup>().DOFade(1,1f);

    ustDikdörtgen.GetComponent<RectTransform>().DOLocalMoveX(0,0.7f).SetEase(Ease.OutBack);
    altDikdörtgen.GetComponent<RectTransform>().DOLocalMoveX(0,0.7f).SetEase(Ease.OutBack);
        OyunaBaşla();
   }
   public void OyunaBaşla(){
    audioSource.PlayOneShot(baslangicSesi);
  PuaniKapYazisi.GetComponent<CanvasGroup>().DOFade(0,1f);
   BuyukOlanSayiyiSecYazisi.GetComponent<CanvasGroup>().DOFade(1,1f);
        kacinciOyun();
        timerManager.SureyiBaslat();

   }

   void kacinciOyun(){
    
        if (oyunSayac < 5)
        {
            KacinciOyun = 1;
            artisPuani=25;
            
        }
        else if (oyunSayac >= 5 && oyunSayac < 10)
        {
            KacinciOyun = 2;
            artisPuani=50;
        }
        else if (oyunSayac >= 10 && oyunSayac < 15)
        {
            KacinciOyun = 3;
            artisPuani=75;
        }
        else if (oyunSayac >= 15 && oyunSayac <20)
        {
            KacinciOyun = 4;
            artisPuani=100;

          
        }
        else if (oyunSayac >= 20 && oyunSayac < 25)
        {
            KacinciOyun = 5;
            artisPuani=125;
    
        } else
        {
            KacinciOyun = Random.Range(1, 6);
            artisPuani=150;
        }

        switch (KacinciOyun)
        {
            case 1:
                BirinciFonksiyon();
                break;

            case 2:
                IkinciFonksiyon();
                break;

            case 3:
                UcuncuFonksiyon();
                break;

            case 4:
                DorduncuFonksiyon();
                break;

            case 5:
                BesinciFonksiyon();
                break;

        }
   }

   void BirinciFonksiyon(){
    int rastgeleDeger = Random.Range(1, 50);

if (rastgeleDeger <= 25)
{
    ustDeger = Random.Range(2, 50);
    altDeger = ustDeger + Random.Range(1, 15);
}
else
{
    ustDeger = Random.Range(2, 50);
    altDeger = ustDeger - Mathf.Max(Random.Range(1, 15), 0); // Negatif değerleri önlemek için Mathf.Max kullanılır
}


    if(ustDeger<altDeger)
    {
        buyukDeger=ustDeger;
    }else{
        buyukDeger=altDeger;
    }
    buyukDeger = Mathf.Max(ustDeger, altDeger);
    ustText.text=ustDeger.ToString();   
    altText.text=altDeger.ToString();
   }

   void IkinciFonksiyon()
{
    int birinciSayi = Random.Range(1, 10);
    int ikinciSayi = Random.Range(1, 20);

    int ucuncuSayi = Random.Range(1, 10);
    int dorduncuSayi = Random.Range(1, 20);

    ustDeger = birinciSayi + ikinciSayi;
    altDeger = ucuncuSayi + dorduncuSayi;

    if (ustDeger > altDeger)
    {
        buyukDeger = ustDeger;
    }
    else if (ustDeger < altDeger)
    {
        buyukDeger = altDeger;
    }

    if (ustDeger == altDeger)
    {
        IkinciFonksiyon();
        return;
    }

    ustText.text = birinciSayi + "+" + ikinciSayi;
    altText.text = ucuncuSayi + "+" + dorduncuSayi;

}
   
    void UcuncuFonksiyon()
 {
     int birinciSayi = Random.Range(11, 30);
     int ikinciSayi = Random.Range(1, 11);

     int ucuncuSayi = Random.Range(11, 40);
     int dorduncuSayi = Random.Range(1, 11);

     ustDeger = birinciSayi - ikinciSayi;
     altDeger = ucuncuSayi - dorduncuSayi;

     if (ustDeger > altDeger)
     {
         buyukDeger = ustDeger;
     }
     else if (ustDeger < altDeger)
     {
         buyukDeger = altDeger;
     }

     if (ustDeger == altDeger)
     {
         UcuncuFonksiyon();
         return;
     }

     ustText.text = birinciSayi + "-" + ikinciSayi;
     altText.text = ucuncuSayi + "-" + dorduncuSayi;

 }

 void DorduncuFonksiyon()
 {
     int birinciSayi = Random.Range(1, 10);
     int ikinciSayi = Random.Range(1, 10);

     int ucuncuSayi = Random.Range(1, 10);
     int dorduncuSayi = Random.Range(1, 10);

     ustDeger = birinciSayi * ikinciSayi;
     altDeger = ucuncuSayi * dorduncuSayi;

     if (ustDeger > altDeger)
     {
         buyukDeger = ustDeger;
     }
     else if (ustDeger < altDeger)
     {
         buyukDeger = altDeger;
     }

     if (ustDeger == altDeger)
     {
         DorduncuFonksiyon();
         return;
     }

     ustText.text = birinciSayi + " x " + ikinciSayi;
     altText.text = ucuncuSayi + " x " + dorduncuSayi;

 }

 void BesinciFonksiyon()
 {
     int bolen1 = Random.Range(2, 10);
     ustDeger = Random.Range(2, 10);

     int bolunen1 = bolen1 * ustDeger;


     int bolen2 = Random.Range(2, 10);
     altDeger = Random.Range(2, 10);

     int bolunen2 = bolen2 * altDeger;

     if (ustDeger > altDeger)
     {
         buyukDeger = ustDeger;
     }
     else if (ustDeger < altDeger)
     {
         buyukDeger = altDeger;
     }

     if (ustDeger == altDeger)
     {
         BesinciFonksiyon();
         return;
     }

     ustText.text = bolunen1 + " / " + bolen1;
     altText.text = bolunen2 + " / " + bolen2;

 }
   public void ButonDegeriniBelirle(string butonAdi)
   {
   
// ButonDegeriniBelirle fonksiyonunda buton değerlerini belirlerken doğru değeri al
        if(butonAdi == "ustButon")
        {
            butonDegeri = ustDeger; 
        }
        else if(butonAdi == "altButon")
        {
            butonDegeri = altDeger;
        }

            if(butonDegeri==buyukDeger){
                trueFalseManager.TrueFalseScaleAc(true);
                dairelerManager.DaireninScaleAc(oyunSayac % 5);
                oyunSayac++;
                toplamPuan+=artisPuani;
                puanText.text=toplamPuan.ToString();
                dogruAdet++;
                  audioSource.PlayOneShot(dogruSesi);
                
                kacinciOyun();
            }
            else{
                trueFalseManager.TrueFalseScaleAc(false);
                HatayaGoreSayaciAzalt();
                yanlisAdet++;
                  audioSource.PlayOneShot(yanlisSesi);
                kacinciOyun();
                
            }
   }
   
   void HatayaGoreSayaciAzalt()
 {
     oyunSayac -= (oyunSayac % 5 + 5);

     if(oyunSayac<0)
     {
         oyunSayac = 0;
     }

    dairelerManager.DairelerinScaleKapat();
     
 }

  public void PausePaneliniAc()
 {
     pausePaneli.SetActive(true);
 }

 public void OyunuBitir()
 {

      audioSource.PlayOneShot(bitisSesi);
     sonucPaneli.SetActive(true);
    SonucManager=Object.FindObjectOfType<SonucManager>();
    SonucManager.SonuclariGoster(dogruAdet,yanlisAdet,toplamPuan);
     
    

 }
}
