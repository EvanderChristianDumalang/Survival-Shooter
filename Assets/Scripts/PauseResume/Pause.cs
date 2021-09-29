using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    bool paused = false;

    public void pausegame()
    {
        if (paused)
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
            paused = false;
        }
        else
        {
            Time.timeScale = 0;
            AudioListener.pause = true;
            paused = true;
        }
    }
}
