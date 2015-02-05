using UnityEngine;
using System.Collections.Generic;

public class LevelSetup : MonoBehaviour
{

    private GameObject ground;

    private LevelData levelData;

    private int mapWidth;
    private int mapHeight;
    private int gridSize;

    private int mapCenterX;
    private int mapCenterZ;

    private int gridWidth;
    private int gridHeight;

    void Awake()
    {
	
        ground = GameObject.Find("Ground");

        levelData = GetComponent<LevelData>();

        mapWidth = (int)ground.transform.localScale.x;
        mapHeight = (int)ground.transform.localScale.z;
        mapCenterX = (int)ground.transform.position.x;
        mapCenterZ = (int)ground.transform.position.z;

        gridSize = levelData.GridSize;

        gridWidth = mapWidth / gridSize;
        gridHeight = mapHeight / gridSize;

        GeneratePathFindingData();

    }

    private void GeneratePathFindingData()
    {
        Graph graph = new Graph();
        int[,] nodeIdMatrix = new int[gridWidth, gridHeight];
        bool[,] goNoGoMatrix = new bool[gridWidth, gridHeight];

        levelData.Graph = graph;
        levelData.GoNoGoMatrix = goNoGoMatrix;


        // Create nodes
        int nodeId = 0;
        for (int z = 0; z < gridHeight; z++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                nodeIdMatrix [x, z] = nodeId;
                float gridCenterPosX = x * gridSize + (gridSize / 2) - (mapWidth / 2) + mapCenterX;
                float gridCenterPosZ = z * gridSize + (gridSize / 2) - (mapHeight / 2) + mapCenterZ;
                if (!ObstacleInGrid(gridCenterPosX, gridCenterPosZ))
                {
                    Node node = new Node(nodeId + "", new Vector3(gridCenterPosX, 0, gridCenterPosZ));
                    graph.AddNode(node);
                    goNoGoMatrix [x, z] = true;
                } else
                {
                    goNoGoMatrix [x, z] = false;
                }
                nodeId++;
            }
        }

        // Create Tile Map
        levelData.NodeMap = new NodeMap(nodeIdMatrix, mapWidth, mapHeight, mapCenterX, mapCenterZ, gridSize);

        // Create connections
        for (int z = 0; z < gridHeight; z++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                for (int k = z - 1; k <= z + 1; k++)
                {
                    for (int i = x - 1; i <= x + 1; i++)
                    {
                        if ((i >= 0 && i < gridWidth) && (k >= 0 && k < gridHeight))
                        {
                            if (goNoGoMatrix [x, z] == true && goNoGoMatrix [i, k] == true)
                            {
                                if ((z == k) && (x == i))
                                {
                                    continue;
                                }
                                
                                bool tilesConnected = true;
                                
                                if ((k == z - 1) && (i == x - 1))
                                {
                                    tilesConnected = false;
                                }
                                
                                if ((k == z + 1) && (i == x - 1))
                                {
                                    tilesConnected = false;
                                }
                                
                                if ((k == z + 1) && (i == x + 1))
                                {
                                    tilesConnected = false;
                                }
                                
                                if ((k == z - 1) && (i == x + 1))
                                {
                                    tilesConnected = false;
                                }
                                
                                if (tilesConnected)
                                {
                                    Node fromNode = graph.GetNode(nodeIdMatrix [x, z] + "");
                                    Node toNode = graph.GetNode(nodeIdMatrix [i, k] + "");
                                    float cost = (fromNode.Position - toNode.Position).magnitude;
                                    Edge e = new Edge(fromNode, toNode, cost);
                                    fromNode.AddConnetion(e);
                                    graph.AddEdge(e);
                                }
                                
                            }
                        }
                    }
                }
            }
        }

        IList<Edge> edges = graph.Edges;
        foreach (Edge e in edges)
        {
            Debug.DrawLine(e.ToNode.Position, e.FromNode.Position, Color.red, 5.0f);
        }

    }

    bool ObstacleInGrid(float gridCenterPosX, float gridCenterPosZ)
    {
        bool obstacleFound = false;

        RaycastHit hitInfo;
        Vector3 rayStart = new Vector3(gridCenterPosX, 100, gridCenterPosZ);
        Vector3 rayEnd = new Vector3(gridCenterPosX, -100, gridCenterPosZ);
        Vector3 rayDirection = rayEnd - rayStart;
        float rayDistance = rayDirection.magnitude;
        Ray ray = new Ray(rayStart, rayDirection);

        if (Physics.SphereCast(ray, gridSize * .45f, out hitInfo, rayDistance))
        {
            if (hitInfo.collider.tag.Equals("Obstacle") || hitInfo.collider.tag.Equals("SafeZone"))
            {
                obstacleFound = true;
            }
        }

        return obstacleFound;
    }
}
