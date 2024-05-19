using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingsUI : MonoBehaviour
{
    [SerializeField]
    BuildingDataScriptable dataForBuildings;

    [SerializeField]
    GameObject buttonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        foreach(var bld in dataForBuildings.Buildings)
        {
            var btn = Instantiate(buttonPrefab, transform);
            btn.GetComponent<Button>().GetComponentInChildren<TMPro.TMP_Text>().text = bld.Name;
            btn.GetComponent<ButtonInfoForBuilding>().SetBuilding(bld);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
