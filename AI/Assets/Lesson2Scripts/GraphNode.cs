using UnityEngine;

public class GraphNode : MonoBehaviour
{
    public GraphNode[] Edges;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        foreach (GraphNode edge in Edges)
        {
            if (edge == null) continue;
            Gizmos.DrawLine(edge.transform.position, transform.position);
        }
    }
}
