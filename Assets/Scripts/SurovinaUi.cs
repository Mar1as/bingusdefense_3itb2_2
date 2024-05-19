using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SurovinaUi : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSurovina();
    }

    void UpdateSurovina()
    {
        text.text = "Peníze: " + Manager.Instance.penize.ToString();
    }
}
