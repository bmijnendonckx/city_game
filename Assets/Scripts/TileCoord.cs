using UnityEngine;
using System.Collections;

public struct TileCoord {
    public int y;
    public int x;

    public TileCoord (int _x, int _y) {
        this.x = _x;
        this.y = _y;
    }

    // TileCoord.ToString()
    public override string ToString() {
        return "(" + x + ", " + y + ")";
        // ex: (0, 2)
    }
}