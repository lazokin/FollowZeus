using UnityEngine;
using System.Collections.Generic;

public class PathFinderBFS : PathFinder
{
    public override Path FindRawPath(Node startNode, Node endNode, PathFindingHeuristic heuristic, float hRatio)
    {
        // Initialise parameters
        NodeRecord currentNodeRecord = null;
        IList<Edge> currentNodeEdges;

        // Initialise path variable
        Path path = null;

        // Initialise a stack
        Queue<NodeRecord> BFS_Queue = new Queue<NodeRecord>();

        // Initialise the open and close lists
        openNodes = new NodeRecordList();
        closedNodes = new NodeRecordList();

        // Initialise the start node record
        NodeRecord startNodeRecord = new NodeRecord(startNode, null, 0, 0, 0);

        // Add start node to open nodes
        openNodes.Add(startNodeRecord);

        // Enqueue start node on queue
        BFS_Queue.Enqueue(startNodeRecord);

        // Iterate while queue is not empty
        while (BFS_Queue.Count != 0)
        {
            // Get next node record
            currentNodeRecord = BFS_Queue.Dequeue();

            // Reached destination node
            if (currentNodeRecord.Node.Id == endNode.Id)
            {
                break;
            }

            // Otherwise get outgoing connections for current node
            currentNodeEdges = currentNodeRecord.Node.Edges;

            // Loop through each connection of current node
            foreach (Edge edge in currentNodeEdges)
            {
                // If connecting node has not already been visited
                if (!openNodes.Contains(edge.ToNode) && !closedNodes.Contains(edge.ToNode))
                {
                    // Create node record
                    NodeRecord connectingNodeRecord = new NodeRecord(edge.ToNode, edge, 0, 0, 0);

                    // Add connecting node to open node list
                    openNodes.Add(connectingNodeRecord);

                    // Enqueue connecting node in queue
                    BFS_Queue.Enqueue(connectingNodeRecord);
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