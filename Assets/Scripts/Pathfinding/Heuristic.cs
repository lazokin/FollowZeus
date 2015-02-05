public class Heuristic
{
    public float Estimate(Node current, Node goal)
    {
        return (current.Position - goal.Position).magnitude;
    }

}


