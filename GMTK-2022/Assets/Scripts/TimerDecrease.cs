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

    // Start is called before the first frame update
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

    }
}
