using UnityEngine;
using System.Collections.Generic;

public class Node
{
    private IList<Edge> edges = new List<Edge>();

    public string Id { get; set; }
    public Vector3 Position { get; set; }
    public IList<Edge> Edges
    {
        get
        {
            return edges;
        }
    }


    public Node(string id, Vector3 position)
    {
        this.Id = id;
        this.Position = position;
    }

    public void AddConnetion(Edge edge)
    {
        edges.Add(edge);
    }
    
    public void RemoveConnection(Edge edge)
    {
        edges.Remove(edge);
    }

}


