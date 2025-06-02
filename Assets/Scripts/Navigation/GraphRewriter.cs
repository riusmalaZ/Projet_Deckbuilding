public class GraphRewriter
{
    public void Rewrite(Graph graph)
    {
        foreach (var layer in graph.Layers)
        {
            //pas + de 2 shops consécutifs
            for (int i = 0; i < layer.Count - 1; i++)
            {
                foreach (var neighbor in layer[i].Neighbors)
                {
                    if (neighbor.Type == NodeType.Shop)
                        neighbor.Type = NodeType.Combat;
                }
            }
        }
    }
}