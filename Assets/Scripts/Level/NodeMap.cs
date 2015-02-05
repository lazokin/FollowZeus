using UnityEngine;
using System.Collections;

public class NodeMap
{
    private int[,] nodeIdMatrix;
    private int mapWidth;
    private int mapHeight;
    private int mapCenterX;
    private int mapCenterZ;
    private int gridSize;

    public NodeMap(int[,] nodeIdMatrix, int mapWidth, int mapHeight, int mapCenterX, int mapCenterZ, int gridSize)
    {
        this.nodeIdMatrix = nodeIdMatrix;
        this.mapWidth = mapWidth;
        this.mapHeight = mapHeight;
        this.mapCenterX = mapCenterX;
        this.mapCenterZ = mapCenterZ;
        this.gridSize = gridSize;
    }

    public int ClosestNodeId(Vector3 position)
    {
        int nodeId = -1;

        float translatedPosX = position.x + mapWidth / 2 - mapCenterX;
        float translatedPosZ = position.z + mapHeight / 2 - mapCenterZ;

        bool withinMapBoundsX = (translatedPosX >= 0) && (translatedPosX <= mapWidth);
        bool withinMapBoundsZ = (translatedPosZ >= 0) && (translatedPosZ <= mapHeight);

        if (withinMapBoundsX && withinMapBoundsZ)
        {
            int xPos = (int)(translatedPosX / (float)gridSize);
            int zPos = (int)(translatedPosZ / (float)gridSize);
            nodeId = nodeIdMatrix [xPos, zPos];
        }

        return nodeId;
    }

}
