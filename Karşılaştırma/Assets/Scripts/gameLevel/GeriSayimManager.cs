using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class GeriSayimManager : MonoBehaviour
{
   [SerializeField] private GameObject GeriSayimObje;
    [SerializeField] private TextMeshProUGUI geriSayimText;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        StartCoroutine(GeriyeSayRoutine());
    }

    IEnumerator GeriyeSayRoutine()
    {
        if (GeriSayimObje == null)
        {
            Debug.LogError("GeriSayimObje not assigned!");
            yield break;
        }

        geriSayimText.text = "3";
        yield return new WaitForSeconds(0.1f);

        GeriSayimObje.GetComponent<RectTransform>().DOScale(1, 0.1f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.2f);
        GeriSayimObje.GetComponent<RectTransform>().DOScale(0, 0.1f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.1f);

        geriSayimText.text = "2";
        yield return new WaitForSeconds(0.1f);

        GeriSayimObje.GetComponent<RectTransform>().DOScale(1, 0.1f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.1f);
        GeriSayimObje.GetComponent<RectTransform>().DOScale(0, 0.1f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.1f);

        geriSayimText.text = "1";
        yield return new WaitForSeconds(0.1f);

        GeriSayimObje.GetComponent<RectTransform>().DOScale(1, 0.1f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.2f);
        GeriSayimObje.GetComponent<RectTransform>().DOScale(0, 0.2f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.2f);

        StopAllCoroutines();

        gameManager.OyunaBaşla();
    }
}
