using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitGame : MonoBehaviour
{
    public GameObject MainCam;
    public GameObject CMCam;
    public GameObject QuitArea;
    // Start is called before the first frame update
    void Start()
    {
        MainCam.SetActive(true);
        CMCam.SetActive(true);
        QuitArea.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainCam.SetActive(false);
            CMCam.SetActive(false);
            QuitArea.SetActive(true);
        }
    }
}
