using UnityEngine;
using System.Collections;
using System.Linq;

public class Building:MonoBehaviour {
    /* Uitleg Lamda Expression
    bool (GameObject e) {
        return e != null;
    }
    */

    public bool isRoadNextToBuilding() {
        if(BuildingManager.GridObjects[Grid.gridX, Grid.gridY]) {
            GameObject[] conditions = { BuildingManager.GridObjects[Grid.gridX + 1, Grid.gridY],
                                        BuildingManager.GridObjects[Grid.gridX - 1, Grid.gridY],
                                        BuildingManager.GridObjects[Grid.gridX, Grid.gridY + 1],
                                        BuildingManager.GridObjects[Grid.gridX, Grid.gridY - 1],
            };

            if(conditions.Any(e => {return e != null;})) {

            }
        }
        return false;
    }
}