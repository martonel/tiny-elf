using System.Collections;
using System.Threading;
using UnityEngine;

public class Timing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Time.timeScale = 0.0f;
    }

    public void SetTime(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    public void SetTimerWithWaitTime(float timeScale)
    {
        StartCoroutine(TimerCorutine(timeScale));
    }

    private IEnumerator TimerCorutine(float timeScale)
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = timeScale;

    }

}
