using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SureManager : MonoBehaviour
{
    
   [SerializeField] private TextMeshProUGUI SureText;
    private int kalanSure = 10;
    private bool sureSaysinmi = true;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        SureText.text = "Kalan Süre: " + kalanSure.ToString("D2");
        StartCoroutine(SureTimerRoutine());
    }

    IEnumerator SureTimerRoutine()
    {
        while (sureSaysinmi && kalanSure > 0)
        {
            yield return new WaitForSeconds(1f);
            kalanSure--;
            SureText.text = "Kalan Süre: " + kalanSure.ToString("D2");
            if (kalanSure <= 0)
            {
                sureSaysinmi = false;
                SureText.text = "";
                gameManager.OyunuBitir();
            }
        }
    }
}
