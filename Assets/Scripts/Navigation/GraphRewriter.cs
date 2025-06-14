using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class GraphRewriter
{
    public void Rewrite(Graph graph)
    {
        bool rewrited = true;
        int iteration = 0;
        while (rewrited && iteration < 20)
        {
            iteration++;
            rewrited = false;
            foreach (var layer in graph.Layers)
            {

                for (int i = 0; i < layer.Count - 1; i++)
                {
                    //pas + de 2 shops ou tresors consécutifs
                    if (layer[i].Type != NodeType.Fight && layer[i].Type != NodeType.Start)
                    {
                        foreach (var neighbor in layer[i].Neighbors)
                        {
                            if (neighbor.Type != NodeType.Fight && neighbor.Type != NodeType.Boss)
                            {
                                neighbor.Type = NodeType.Fight;
                                rewrited = true;
                            }

                        }
                    }
                    //pas + de 3 combats consécutifs
                    else if (layer[i].Type == NodeType.Fight)
                    {
                        foreach (var neighbor in layer[i].Neighbors)
                        {
                            if (neighbor.Type == NodeType.Fight)
                                foreach (var neighbor2 in neighbor.Neighbors)
                                {
                                    if (neighbor2.Type == NodeType.Fight)
                                    {
                                        float r = Random.value;
                                        if (r < 0.33f) layer[i].Type = NodeType.Treasure;
                                        else if (r < 0.66f) neighbor.Type = NodeType.Shop;
                                        else neighbor2.Type = NodeType.Treasure;
                                        rewrited = true;
                                    }
                                }

                        }
                    }
                    foreach (var neighbor in layer[i].Neighbors)
                    {
                        if (neighbor.Type == NodeType.Boss)
                        {
                            if (Random.value < 0.5f) layer[i].Type = NodeType.Treasure;
                            else layer[i].Type = NodeType.Shop;
                        }
                    }

                }

            }
        }
    }
}