using UnityEngine;
using System.Collections.Generic;

public class Graph
{
    IDictionary<string, Node> nodes = new Dictionary<string, Node>();
    IList<Edge> edges = new List<Edge>();

    public IList<Edge> Edges
    {
        get { return edges; }
    }

    public IDictionary<string, Node> Nodes
    {
        get { return nodes; }
    }

    public Graph()
    {

    }

    public Graph(Node[] nodes, Edge[] edges)
    {
        foreach (Node node in nodes)
        {
            this.nodes.Add(node.Id, node);
        }
        foreach (Edge edge in edges)
        {
            this.edges.Add(edge);
        }
    }

    public void AddNode(Node node)
    {
        nodes.Add(node.Id, node);
    }
        
    public void RemoveNode(Node node)
    {
        nodes.Remove(node.Id);
    }
        
    public void AddEdge(Edge edge)
    {
        edges.Add(edge);
    }
        
    public void RemoveEdge(Edge edge)
    {
        edges.Remove(edge);
    }

    public Node GetNode(string nodeId)
    {
        Node value = null;
        nodes.TryGetValue(nodeId, out value);
        return value;
    }

    public Node PickRandomNode()
    {
        int randomIdx = Random.Range(0, edges.Count - 1);
        return edges [randomIdx].FromNode;
    }
        
}