using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
  [SerializeField] GameObject pauseScreen;
  public AudioSource selectSound;

  void Start()
  {
     pauseScreen.SetActive(false);
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetButtonDown("Cancel"))
    {
      if (!pauseScreen.activeSelf)
      {
        Time.timeScale = 0f;
        pauseScreen.SetActive(true);
      }
      else
      {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
      }
    }
  }

  public void Resume()
  {
    selectSound.Play();
    Time.timeScale = 1f;
    pauseScreen.SetActive(false);
  }

  public void Menu()
  {
    selectSound.Play();
    Time.timeScale = 1f;
    SceneManager.LoadSceneAsync(0);
  }
}