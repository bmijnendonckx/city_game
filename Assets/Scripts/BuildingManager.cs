using UnityEngine;
using System.Collections;

public class BuildingManager:MonoBehaviour {
    protected bool hasPlaced = false;
    protected Vector3 p;
    protected Transform currentObject;
    private static GameObject[,] gridObjects = new GameObject[Grid.gridX, Grid.gridY];

    public bool HasPlaced {
        get {return hasPlaced;}
        set {hasPlaced = value;}
    }

    public static GameObject[,] GridObjects {
        get {return gridObjects;}
        set {gridObjects = value;}
    }

    void Update(){
        if(currentObject != null & !hasPlaced) {
            castToGround(out p);

            TileCoord coord = Grid.positionToCoord(p);

            currentObject.position = Grid.coordToPosition(coord);
            
            if(Input.GetMouseButtonDown(0) & GridObjects[coord.x, coord.y] == null) {
                hasPlaced = true;
                GridObjects[coord.x, coord.y] = currentObject.gameObject;
            } else if(Input.GetMouseButtonDown(1)) {
                DestroyImmediate(currentObject.gameObject);
            }
        }
	}

    public void OnIconPress(GameObject prefab) {
        hasPlaced = false;
        currentObject = (Instantiate(prefab)).transform;
    }

    public static bool castToGround (out Vector3 point) {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo = new RaycastHit();
        // User Layer 8 -- 1 8 bit locaties naar links 2^8 (8ste bit 1 = collidable)
        if(Physics.Raycast(ray, out hitInfo, Mathf.Infinity, 1 << 8)) {
            point = hitInfo.point;
            return true;
        }
        point = Vector3.zero;
        return false;
    }
}