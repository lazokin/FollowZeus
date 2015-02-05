using UnityEngine;
using System.Collections.Generic;

public class PathFinderDijkstra : PathFinder
{
    public override Path FindRawPath(Node startNode, Node endNode, PathFindingHeuristic heuristic, float hRatio)
    {
        // Initialise path variable
        Path path = null;

        // Initialise the open and close lists
        openNodes = new NodeRecordList();
        closedNodes = new NodeRecordList();

        // Initialise parameters
        Node nextNode = null;
        float nextNodeCostSoFar = 0;
        NodeRecord currentNodeRecord = null;
        NodeRecord nextNodeRecord = null;
        IList<Edge> edges;

        // Initialise the start record
        NodeRecord startRecord = new NodeRecord(startNode, null, 0, 0, 0);

        // Add start record to open list
        openNodes.Add(startRecord);

        // Iterate through open nodes
        while (!openNodes.IsEmpty())
        {
            // Find node with the cheapest cost so far
            currentNodeRecord = openNodes.FindCheapestCostSoFar();

            // If cheapest node is end node, stop
            // We found the cheapest path
            if (currentNodeRecord.Node.Id == endNode.Id)
            {
                break;
            }

            // Otherwise get outgoing connections of current node
            edges = currentNodeRecord.Node.Edges;

            // Loop through each connection of current node
            foreach (Edge edge in edges)
            {
                // Get cost estimate for the next node
                nextNode = edge.ToNode;
                nextNodeCostSoFar = currentNodeRecord.CostSoFar + edge.Cost;

                // Next node is closed
                if (closedNodes.Contains(nextNode))
                {
                    continue;
                }
                // Next node is opened
                else if (openNodes.Contains(nextNode))
                {
                    // Get next node record from open list
                    nextNodeRecord = openNodes.GetNodeRecord(nextNode);

                    // We found worse route
                    if (nextNodeRecord.CostSoFar <= nextNodeCostSoFar)
                    {
                        continue;
                    }
                }
                // Next node has not been visisted
                else
                {
                    // Create node record for node
                    nextNodeRecord = new NodeRecord(nextNode, null, 0, 0, 0);
                }

                // Update node record
                nextNodeRecord.Edge = edge;
                nextNodeRecord.CostSoFar = nextNodeCostSoFar;

                // Add node to open list
                if (!openNodes.Contains(nextNode))
                {
                    openNodes.Add(nextNodeRecord);
                }

            }

            // Remove current node from open list
            // Add current node to closed list
            openNodes.Remove(currentNodeRecord);
            closedNodes.Add(currentNodeRecord);
        }

        // Found found a solultion
        if (currentNodeRecord.Node.Id == endNode.Id)
        {
            // Traverse backwards through path and record nodes
            Stack<Node> pathStack = new Stack<Node>();
            pathStack.Push(endNode);
            Node previousNode;
            while (currentNodeRecord.Node.Id != startNode.Id)
            {
                previousNode = currentNodeRecord.Edge.FromNode;
                pathStack.Push(previousNode);
                currentNodeRecord = closedNodes.GetNodeRecord(previousNode);
            }

            // Reverse path to correct order
            path = new Path();
            while (pathStack.Count != 0)
            {
                path.AddNode(pathStack.Pop());
            }
        }

        return path;
    }

}