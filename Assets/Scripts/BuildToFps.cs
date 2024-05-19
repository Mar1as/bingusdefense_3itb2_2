using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildToFps : MonoBehaviour
{
    [SerializeField] GameObject fps;
    [SerializeField] GameObject rts;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Fight();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Build();
        }
    }

    public void Fight()
    {
        Cursor.visible = false;
        rts.SetActive(false);
        fps.SetActive(true);

    }
    public void Build()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        fps.SetActive(false);
        rts.SetActive(true);
    }
}
