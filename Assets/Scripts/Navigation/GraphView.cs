using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GraphView : MonoBehaviour
{
    public RectTransform graphContainer, EdgeContainer, NodeContainer;
    public GameObject nodePrefab;
    public GraphGenerator generator;
    public GraphRewriter rewriter;

    private Dictionary<Node, NodeView> nodeToView = new();

    void Start()
    {
        Graph graph;

        if (GraphHolder.Instance.CurrentGraph != null)
        {
            graph = GraphHolder.Instance.CurrentGraph;
        }
        else
        {
            graph = generator.Generate();
            rewriter = new GraphRewriter();
            rewriter.Rewrite(graph);
            GraphHolder.Instance.CurrentGraph = graph;
        }

        DrawGraph(graph);
    }

    void DrawGraph(Graph graph)
    {
        float xSpacing = 200f;
        float ySpacing = -150f;

        for (int layer = 0; layer < graph.Layers.Count; layer++)
        {
            List<Node> nodes = graph.Layers[layer];
            float startX = -((nodes.Count - 1) * xSpacing / 2f);

            for (int i = 0; i < nodes.Count; i++)
            {
                Vector2 pos = new Vector2(startX + i * xSpacing, layer * ySpacing);
                GameObject obj = Instantiate(nodePrefab, NodeContainer);
                NodeView view = obj.GetComponent<NodeView>();
                view.Init(nodes[i], pos);
                nodeToView[nodes[i]] = view;
            }
        }

        DrawEdges(graph);
    }

    void DrawEdges(Graph graph)
    {
        foreach (var layer in graph.Layers)
        {
            foreach (var node in layer)
            {
                NodeView fromView = nodeToView[node];

                foreach (Node neighbor in node.Neighbors)
                {
                    NodeView toView = nodeToView[neighbor];
                    Vector2 fromPos = new Vector2(fromView.RectTransform.anchoredPosition.x + 50, fromView.RectTransform.anchoredPosition.y + 50);
                    Vector2 toPos = new Vector2(toView.RectTransform.anchoredPosition.x + 50, toView.RectTransform.anchoredPosition.y + 50);
                    DrawLine(fromPos, toPos);
                }
            }
        }
    }

    void DrawLine(Vector2 start, Vector2 end)
    {
        //creer une ligne en code en instanciant une image
        GameObject line = new GameObject("Edge", typeof(Image));
        line.transform.SetParent(EdgeContainer, false);
        Image img = line.GetComponent<Image>();
        img.color = Color.black;

        RectTransform rt = line.GetComponent<RectTransform>();
        Vector2 dir = (end - start).normalized;
        float dist = Vector2.Distance(start, end);

        rt.anchorMin = rt.anchorMax = Vector2.zero;
        rt.sizeDelta = new Vector2(dist, 2f);
        rt.anchoredPosition = start + dir * dist / 2f;
        rt.rotation = Quaternion.FromToRotation(Vector3.right, end - start);
    }
}
