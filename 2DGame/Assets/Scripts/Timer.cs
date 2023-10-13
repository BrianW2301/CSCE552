using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
  public float timeRemaining;
  public bool timerOn;
  public Text timerText;
  [SerializeField] GameObject loseScreen;
  [SerializeField] GameObject backgroundMusic;
  [SerializeField] GameObject loseSound;

    // Start is called before the first frame update
  void Start()
  {
    loseSound.SetActive(false);
    timeRemaining = 25;
    loseScreen.SetActive(false);
    timerOn = true;
  }

    // Update is called once per frame
  void Update()
  {
    if (timerOn)
    {
      if (timeRemaining > 0)
      {
        timeRemaining = timeRemaining - Time.deltaTime;
        changeTime(timeRemaining);
      }
      else
      {
        Time.timeScale = 0f;
        loseSound.SetActive(true);
        backgroundMusic.SetActive(false);
        loseScreen.SetActive(true);
      }
    }
  }

  void changeTime(float timeRemaining)
  {
    float rounded = Mathf.Round(timeRemaining);
    timerText.text = rounded.ToString();
  }
}
