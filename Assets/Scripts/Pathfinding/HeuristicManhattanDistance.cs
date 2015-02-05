using UnityEngine;

public class HeuristicManhattanDistance : PathFindingHeuristic
{
    public override float Estimate(Node current, Node goal)
    {
        float dx = Mathf.Abs(goal.Position.x - current.Position.x);
        float dz = Mathf.Abs(goal.Position.z - current.Position.z);
        return (dx + dz);
    }
    
}