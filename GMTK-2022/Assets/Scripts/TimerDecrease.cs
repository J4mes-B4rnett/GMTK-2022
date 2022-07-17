using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDecrease : MonoBehaviour
{

    private Image TimeBarImage;
    public float MaxTime = 120f;
    public float CurrentTime;
    public bool TimeIsDone = false;
    
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
          CurrentTime -= 1 * Time.deltaTime;
          TimeBarImage.fillAmount = CurrentTime / MaxTime;
      }
      else
      {
          // Game Over
      }
    }
}
