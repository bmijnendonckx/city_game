using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid:MonoBehaviour {
    [Header("Tile Prefab")]
    public Transform tilePrefab;

    public const int gridX = 50, gridY = 50;
    const int tileSize = 1;

    void Start() {
        GameObject map = new GameObject("Map");
        Transform mapHolder = map.transform;
        mapHolder.SetParent(transform);

        for(int x = 0; x < gridX; x++) {
            for(int y = 0; y < gridY; y++) {
                Vector3 tilePosition = coordToPosition(new TileCoord(x, y));
                Transform tile = Instantiate(tilePrefab);
                tile.position = tilePosition;
                tile.SetParent(mapHolder);
            }
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = new Color(1, 1, 1, 0.3f);
        for(int x = 0; x < gridX; x++) {
            for(int y = 0; y < gridY; y++) {
                Gizmos.DrawWireCube(coordToPosition(new TileCoord(x, y)), new Vector3(tileSize, 0, tileSize));
            }
        }
    }

    public static TileCoord positionToCoord(Vector3 position) {
        return new TileCoord(Mathf.FloorToInt(position.x / tileSize), Mathf.FloorToInt(position.z / tileSize));
    }

    public static Vector3 coordToPosition(TileCoord tilecoord) {
        return new Vector3( (tilecoord.x * tileSize) + (tileSize/2f), 0.1f, (tilecoord.y * tileSize) + (tileSize/2f) );
    }
}