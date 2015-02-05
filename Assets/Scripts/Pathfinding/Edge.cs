public class Edge
{
    public Node FromNode { get; set; }
    public Node ToNode { get; set; }
    public float Cost { get; set; }

    public Edge(Node fromNode, Node toNode, float cost)
    {
        this.FromNode = fromNode;
        this.ToNode = toNode;
        this.Cost = cost;
    }
        
}


