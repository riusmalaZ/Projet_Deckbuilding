using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeView : MonoBehaviour
{
    public RectTransform rectTransform;
    public TextMeshProUGUI label;

    public Node NodeData;

    public void Init(Node node, Vector2 position)
    {
        NodeData = node;
        rectTransform = GetComponent<RectTransform>();
        label = GetComponentInChildren<TextMeshProUGUI>();

        rectTransform.anchoredPosition = position;
        label.text = node.Type.ToString();
    }
}