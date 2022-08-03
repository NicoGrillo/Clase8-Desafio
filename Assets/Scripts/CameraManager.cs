using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject[] cameras;
    public int i = 1;

    private void Start()
    {
        i = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            CameraSelect();
        }
    }

    private void CameraSelect()
    {
        Debug.Log(i);
        cameras[0].SetActive(false);
        cameras[1].SetActive(false);
        cameras[2].SetActive(false);
        cameras[i].SetActive(true);
        i++;

        if (i == 3)
        {
            i = 0;
        }
    }
}
