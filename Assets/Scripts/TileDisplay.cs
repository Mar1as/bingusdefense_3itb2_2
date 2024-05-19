using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDisplay : MonoBehaviour
{
    public Tile tileData;

    public Transform buildPlace;

    void Start()
    {
        
    }

    public void Build(GameObject building)
    {
        Instantiate(building, buildPlace.position, Quaternion.identity);
        CommandQueue.Instance.building = null;
    }

    private void OnMouseDown()
    {
        //Debug.Log($"{building} != null && {tileData.tileType} == {TileType.None}");
        if (CommandQueue.Instance.building != null && tileData.tileType == TileType.None)
        {
            GameObject building = CommandQueue.Instance.building.Prefab;

            Manager.Instance.penize -= CommandQueue.Instance.building.Cost;
            tileData.tileType = TileType.Occupied; // :(
            CommandQueue.Instance.EnqueueCommand(new BuildCommand()
            {
                where = this,
                what = building //GameObject.CreatePrimitive(PrimitiveType.Sphere) //BuildingManager.Instance.CurrentBuilding
            });
            //Destroy(gameObject);
        }
    }
}
