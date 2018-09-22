using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text text;

    float time;
    bool running = false;

    private void Start()
    {
        text.text = string.Format("{0:0}:{1:00}.{2:00}", 0, 0, 0);
    }

    void Update() {
        if (running)
        {
            time += Time.deltaTime;
            text.text = string.Format("{0:0}:{1:00}.{2:00}", time/60,  Mathf.Floor(time)%60, Mathf.Floor((time * 100) % 100));
        }
	}

    public void StartTimer()
    {
        time = 0;
        running = true;
    }

    public void StopTimer()
    {
        running = false;
    }

}
