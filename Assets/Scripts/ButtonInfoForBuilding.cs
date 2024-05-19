using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInfoForBuilding : MonoBehaviour
{
    BuildingData building;

    public void Click()
    {
        if (Manager.Instance.penize >= building.Cost)
        {
            CommandQueue.Instance.building = building;
        }
    }

    public void SetBuilding(BuildingData building)
    {
        this.building = building;
    }
}
