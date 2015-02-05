using UnityEngine;

public abstract class PathFindingHeuristic
{
    public abstract float Estimate(Node current, Node goal);
    
}