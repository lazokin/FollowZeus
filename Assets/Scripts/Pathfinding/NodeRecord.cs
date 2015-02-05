public class NodeRecord
{
    public Node Node { get; set; }
    public Edge Edge { get; set; }
    public float CostSoFar { get; set; }
    public float EstimatedCostToGo { get; set; }
    public float EstimatedTotalCost { get; set; }
        
    public NodeRecord(Node node, Edge edge, float costSoFar, float EstimatedCostToGo, float estimatedTotalCost)
    {
        this.Node = node;
        this.Edge = edge;
        this.CostSoFar = costSoFar;
        this.EstimatedCostToGo = EstimatedCostToGo;
        this.EstimatedTotalCost = estimatedTotalCost;
    }
        
}
