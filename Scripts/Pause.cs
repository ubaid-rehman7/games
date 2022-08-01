using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool ispause;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }
    private void PauseGame()
    {
        if (ispause)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
        if (Input.GetKeyDown(KeyCode.Escape))
            ispause = !ispause;
    }
}
