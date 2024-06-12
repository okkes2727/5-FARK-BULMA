using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;




public class PauseManager : MonoBehaviour
{
    // Start is called before the first frame update
     [SerializeField]
 private GameObject pausePaneli;
  private void OnEnable()
  {
      Time.timeScale = 0f;
  }

  private void OnDisable()
  {
      Time.timeScale = 1f;
  }


  public void YenidenOyna()
  {
      pausePaneli.SetActive(false);
  }

  public void MenuyeDon()
  {
      SceneManager.LoadScene("MenuLevel");
  }

  public void OyundanCik()
  {
      Application.Quit();
  }

}
