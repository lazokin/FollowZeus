public class HeuristicEucledianDistance : PathFindingHeuristic
{
    public override float Estimate(Node current, Node goal)
    {
        return (current.Position - goal.Position).magnitude;
    }
    
}