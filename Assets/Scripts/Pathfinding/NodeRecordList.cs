using System.Collections.Generic;

public class NodeRecordList
{
    IDictionary<string, NodeRecord> nodeRecords = new Dictionary<string, NodeRecord>();

    public IDictionary<string, NodeRecord> NodeRecords
    {
        get
        {
            return nodeRecords;
        }
    }

    public void Add(NodeRecord nr)
    {
        nodeRecords.Add(nr.Node.Id, nr);
    }

    public bool Remove(NodeRecord nr)
    {
        return nodeRecords.Remove(nr.Node.Id);
    }

    public bool IsEmpty()
    {
        return (nodeRecords.Count == 0) ? true : false;
    }

    public int Count
    {
        get
        {
            return nodeRecords.Count;
        }
    }

    public NodeRecord FindCheapestCostSoFar()
    {
        float cheapestCostSoFar = int.MaxValue;
        NodeRecord cheapestNode = null;
        foreach (KeyValuePair<string, NodeRecord> entry in nodeRecords)
        {
            if (entry.Value.CostSoFar < cheapestCostSoFar)
            {
                cheapestCostSoFar = entry.Value.CostSoFar;
                cheapestNode = entry.Value;
            }
        }
        return cheapestNode;
    }

    public NodeRecord FindCheapestEstimatedCostToGo()
    {
        float cheapestCostToGo = int.MaxValue;
        NodeRecord cheapestNode = null;
        foreach (KeyValuePair<string, NodeRecord> entry in nodeRecords)
        {
            if (entry.Value.EstimatedCostToGo < cheapestCostToGo)
            {
                cheapestCostToGo = entry.Value.EstimatedCostToGo;
                cheapestNode = entry.Value;
            }
        }
        return cheapestNode;
    }

    public NodeRecord FindCheapestEstimatedTotalCost()
    {
        float cheapestEstimatedTotalCost = int.MaxValue;
        NodeRecord cheapestNode = null;
        foreach (KeyValuePair<string, NodeRecord> entry in nodeRecords)
        {
            if (entry.Value.EstimatedTotalCost < cheapestEstimatedTotalCost)
            {
                cheapestEstimatedTotalCost = entry.Value.EstimatedTotalCost;
                cheapestNode = entry.Value;
            }
        }
        return cheapestNode;
    }

    public bool Contains(Node node)
    {
        return nodeRecords.ContainsKey(node.Id);
    }

    public NodeRecord GetNodeRecord(Node node)
    {
        NodeRecord value = null;
        nodeRecords.TryGetValue(node.Id, out value);
        return value;
    }
        
}
