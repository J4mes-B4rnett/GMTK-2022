using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDecrease : MonoBehaviour
{

    private Image TimeBarImage;
    public float MaxTime = 60f;
    public float CurrentTime;
    public bool TimeIsDone = false;

<<<<<<< Updated upstream:GMTK-2022/Assets/TimerDecrease.cs
    // Start is called before the first frame update
=======
    void Awake()
    {
        Time.timeScale = 1f;
    }
    
>>>>>>> Stashed changes:GMTK-2022/Assets/Scripts/TimerDecrease.cs
    void Start()
    {
        TimeBarImage = GetComponent<Image>();
        CurrentTime = MaxTime;
    } 

    // Update is called once per frame
    void Update()
    {
      if (CurrentTime > 0)
      {
<<<<<<< Updated upstream:GMTK-2022/Assets/TimerDecrease.cs
            CurrentTime -= 1 * Time.deltaTime;
            TimeBarImage.fillAmount = CurrentTime / MaxTime;
=======
          CurrentTime -= 1 * Time.deltaTime;
          TimeBarImage.fillAmount = CurrentTime / MaxTime;
      }
      else
      {
          GameObject.FindObjectOfType<GameOverManager>().GetComponent<GameOverManager>().GameOver();
>>>>>>> Stashed changes:GMTK-2022/Assets/Scripts/TimerDecrease.cs
      }

    }
}
