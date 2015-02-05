using UnityEngine;
using System.Collections.Generic;

public class Path
{
    private List<Node> nodePath = new List<Node>();
    private List<Vector3> vectorPath = new List<Vector3>();

    public int Length
    {
        get
        {
            return nodePath.Count;
        }
    }
        
    public void AddNode(Node node)
    {
        nodePath.Add(node);
        vectorPath.Add(node.Position);
    }

    public void AddPosition(Vector3 position)
    {
        nodePath.Add(new Node("" + nodePath.Count, position));
        vectorPath.Add(position);
    }

    public void UpdateStartPosition(Vector3 startPosition)
    {
        nodePath [0] = new Node("0", startPosition);
        vectorPath [0] = startPosition;
    }

    public void UpdateEndPosition(Vector3 finalPosition)
    {
        nodePath [nodePath.Count - 1] = new Node("0", finalPosition);
        vectorPath [nodePath.Count - 1] = finalPosition;
    }

    public Node GetNode(int idx)
    {
        return nodePath [idx];
    }

    public Vector3 GetPosition(int idx)
    {
        return vectorPath [idx];
    }

    public int GetLength()
    {
        return nodePath.Count;
    }
        
    public Node[] ToNodeArray()
    {
        return nodePath.ToArray();
    }

    public Vector3[] ToPositionArray()
    {
        return vectorPath.ToArray();
    }

    public void SmoothPath()
    {
//        for (int i = 1; i < nodePath.Count; i++)
//        {
//            Debug.DrawLine(nodePath [i].Position, nodePath [i - 1].Position, Color.green, 1.0f);
//        }

        if (nodePath.Count <= 2)
        {
            return;
        }

        List<Node> smoothedNodePath = new List<Node>();
        List<Vector3> smoothedVectorPath = new List<Vector3>();
        smoothedNodePath.Add(nodePath [0]);
        smoothedVectorPath.Add(vectorPath [0]);

        int inputIndex = 2;

        while (inputIndex < nodePath.Count)
        {
            if (PathBlocked(smoothedNodePath [smoothedNodePath.Count - 1], nodePath [inputIndex]))
            {
                smoothedNodePath.Add(nodePath [inputIndex - 1]);
                smoothedVectorPath.Add(vectorPath [inputIndex - 1]);
            }
            inputIndex++;
        }
        smoothedNodePath.Add(nodePath [nodePath.Count - 1]);
        smoothedVectorPath.Add(vectorPath [nodePath.Count - 1]);

//        for (int i = 1; i < smoothedNodePath.Count; i++)
//        {
//            Debug.DrawLine(smoothedNodePath [i].Position, smoothedNodePath [i - 1].Position, Color.yellow, 1.0f);
//        }

        nodePath = smoothedNodePath;
        vectorPath = smoothedVectorPath;
    }

    private bool PathBlocked(Node nodeA, Node nodeB)
    {
        bool result = false;
        Vector3 direction = nodeB.Position - nodeA.Position;
        Ray ray = new Ray(nodeA.Position, direction);
        RaycastHit hitInfo;
        float distance = Vector3.Distance(nodeA.Position, nodeB.Position);
//        Debug.DrawRay(nodeA.Position, direction, Color.red, 1.0f);
        if (Physics.Raycast(ray, out hitInfo, distance))
        {
            if (true)
            {
                result = true;
            }
        }
        return result;

    }
        
}