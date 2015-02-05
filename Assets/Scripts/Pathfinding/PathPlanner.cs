using UnityEngine;
using System.Collections;

public class PathPlanner : MonoBehaviour
{
    public PathfinderType pathfinderType = PathfinderType.AStar;
    public PathfindingHeuristicType pathfindingHeuristicType = PathfindingHeuristicType.EucledianDistance;
    public bool smoothPath = true;
    public bool useStartAndEndPoints = true;
    public float heuristicRatio = 0.5f;

    public enum PathfinderType
    {
        DFS,
        BFS,
        Dijkstra,
        Greedy,
        AStar
    }

    public enum PathfindingHeuristicType
    {
        EucledianDistance,
        ManhattanDistance
    }

    private PathFinder pathFinderDFS;
    private PathFinder pathFinderBFS;
    private PathFinder pathFinderDijkstra;
    private PathFinder pathFinderGreedy;
    private PathFinder pathFinderAStar;

    private PathFindingHeuristic heuristicEucledianDistance;
    private PathFindingHeuristic heuristicManhattanDistance;

    private PathFinder currentPathFinder;
    private PathFindingHeuristic currentHeuristic;

    void Start()
    {
        pathFinderDFS = GameObject.Find("Pathfinding").GetComponent<PathFinderDFS>();
        pathFinderBFS = GameObject.Find("Pathfinding").GetComponent<PathFinderBFS>();
        pathFinderDijkstra = GameObject.Find("Pathfinding").GetComponent<PathFinderDijkstra>();
        pathFinderGreedy = GameObject.Find("Pathfinding").GetComponent<PathFinderGreedy>();
        pathFinderAStar = GameObject.Find("Pathfinding").GetComponent<PathFinderAStar>();

        heuristicEucledianDistance = new HeuristicEucledianDistance();
        heuristicManhattanDistance = new HeuristicManhattanDistance();
    }

    public Path FindPath(Node startNode, Node endNode)
    {
        currentPathFinder = GetPathFinder();
        currentHeuristic = GetHeuristic();

        if (smoothPath == true)
        {
            return currentPathFinder.FindSmoothedPath(startNode, endNode, currentHeuristic, heuristicRatio);
        } else
        {
            return currentPathFinder.FindRawPath(startNode, endNode, currentHeuristic, heuristicRatio);
        }
    }

    public Path FindPath(Vector3 startPosition, Vector3 endPosition)
    {
        currentPathFinder = GetPathFinder();
        currentHeuristic = GetHeuristic();
        
        if (smoothPath == true)
        {
            if (useStartAndEndPoints == true)
            {
                return currentPathFinder.FindSmoothedPathWithStartAndEnd(startPosition, endPosition, currentHeuristic, heuristicRatio);
            } else
            {
                return currentPathFinder.FindSmoothedPath(startPosition, endPosition, currentHeuristic, heuristicRatio);
            }
        } else
        {
            if (useStartAndEndPoints == true)
            {
                return currentPathFinder.FindRawPathWithStartAndEnd(startPosition, endPosition, currentHeuristic, heuristicRatio);
            } else
            {
                return currentPathFinder.FindRawPath(startPosition, endPosition, currentHeuristic, heuristicRatio);
            }
        }
    }

    private PathFinder GetPathFinder()
    {
        switch (pathfinderType)
        {
            case PathfinderType.DFS:
                {
                    return pathFinderDFS;
                }
            case PathfinderType.BFS:
                {
                    return pathFinderBFS;
                }
            case PathfinderType.Dijkstra:
                {
                    return pathFinderDijkstra;
                }
            case PathfinderType.Greedy:
                {
                    return pathFinderGreedy;
                }
            case PathfinderType.AStar:
                {
                    return pathFinderAStar;
                }
            default:
                return null;
        }
    }

    private PathFindingHeuristic GetHeuristic()
    {
        switch (pathfindingHeuristicType)
        {
            case PathfindingHeuristicType.EucledianDistance:
            {
                return heuristicEucledianDistance;
            }
            case PathfindingHeuristicType.ManhattanDistance:
            {
                return heuristicManhattanDistance;
            }
            default:
                return null;
        }
    }

    public NodeRecordList OpenNodes()
    {
        return currentPathFinder.OpenNodes;
    }
    
    public NodeRecordList ClosedNodes()
    {
        return currentPathFinder.ClosedNodes;
    }
}
