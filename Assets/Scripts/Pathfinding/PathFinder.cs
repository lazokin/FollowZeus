using UnityEngine;
using System.Collections;

public abstract class PathFinder : MonoBehaviour
{
    protected Graph graph;
    protected NodeMap nodeMap;
    
    protected NodeRecordList openNodes;
    protected NodeRecordList closedNodes;

    void Start()
    {
        graph = GameObject.Find("Level Manager").GetComponent<LevelData>().Graph;
        nodeMap = GameObject.Find("Level Manager").GetComponent<LevelData>().NodeMap;
    }

    public abstract Path FindRawPath(Node startNode, Node endNode, PathFindingHeuristic heuristic, float hRatio);

    public Path FindRawPath(Vector3 startPosition, Vector3 endPosition, PathFindingHeuristic heuristic, float hRatio)
    {
        Path path = null;
        
        int startNodeId = nodeMap.ClosestNodeId(startPosition);
        int endNodeId = nodeMap.ClosestNodeId(endPosition);
        
        Node startNode = graph.GetNode(startNodeId + "");
        Node endNode = graph.GetNode(endNodeId + "");
        
        if ((startNode != null) && (endNode != null))
        {
            path = FindRawPath(startNode, endNode, heuristic, hRatio);
        }
        
        return path;
    }

    public Path FindSmoothedPath(Node startNode, Node endNode, PathFindingHeuristic heuristic, float hRatio)
    {
        Path path = FindRawPath(startNode, endNode, heuristic, hRatio);
        if (path != null)
        {
            path.SmoothPath();
        }
        return path;
    }

    public Path FindSmoothedPath(Vector3 startPosition, Vector3 endPosition, PathFindingHeuristic heuristic, float hRatio)
    {
        Path path = FindRawPath(startPosition, endPosition, heuristic, hRatio);
        if (path != null)
        {
            path.SmoothPath();
        }
        return path;
    }

    public Path FindRawPathWithStartAndEnd(Vector3 startPosition, Vector3 endPosition, PathFindingHeuristic heuristic, float hRatio)
    {
        Path path = FindRawPath(startPosition, endPosition, heuristic, hRatio);
        if (path != null)
        {
            path.UpdateStartPosition(startPosition);
            path.UpdateEndPosition(endPosition);
        }
        return path;
    }

    public Path FindSmoothedPathWithStartAndEnd(Vector3 startPosition, Vector3 endPosition, PathFindingHeuristic heuristic, float hRatio)
    {
        Path path = FindRawPath(startPosition, endPosition, heuristic, hRatio);
        if (path != null)
        {
            path.UpdateStartPosition(startPosition);
            path.UpdateEndPosition(endPosition);
            path.SmoothPath();
        }
        return path;
    }

    public NodeRecordList OpenNodes
    {
        get
        {
            return openNodes;
        }
    }
    
    public NodeRecordList ClosedNodes
    {
        get
        {
            return closedNodes;
        }
    }

}
