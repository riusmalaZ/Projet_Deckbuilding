using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class NodeView : MonoBehaviour
{
    public RectTransform RectTransform;
    public TextMeshProUGUI NameText;

    public Node NodeData;
    [SerializeField] List<Sprite> _nodeSprites;

    public void Init(Node node, Vector2 position)
    {
        NodeData = node;
        RectTransform = GetComponent<RectTransform>();
        NameText = GetComponentInChildren<TextMeshProUGUI>();

        RectTransform.anchoredPosition = position;
        NameText.text = node.Type.ToString();
        GetComponent<Button>().onClick.AddListener(OnClick);
        if (NodeData.Type == NodeType.Start && GraphHolder.Instance.CurrentNode == null)
        {
            GraphHolder.Instance.CurrentNode = NodeData;
            GraphHolder.Instance.PlayerPosition = new Vector2(NodeData.Layer, NodeData.Column);
        }
        Image img = GetComponent<Image>();
        Vector2 nodePos = new Vector2(NodeData.Layer, NodeData.Column);
        //couleur de la node
        if (GraphHolder.Instance.PlayerPosition == nodePos)
        { img.color = Color.red; }
        else if (GraphHolder.Instance.CurrentNode.Neighbors.Contains(NodeData))
        { img.color = Color.magenta; }
        else
        { img.color = Color.black; }

        if (NodeData.Type == NodeType.Start)
            img.sprite = _nodeSprites[0];
        else if (NodeData.Type == NodeType.Fight)
            img.sprite = _nodeSprites[1];
        else if (NodeData.Type == NodeType.Treasure)
            img.sprite = _nodeSprites[2];
        else if (NodeData.Type == NodeType.Shop)
            img.sprite = _nodeSprites[3];
        else if (NodeData.Type == NodeType.Boss)
            img.sprite = _nodeSprites[4];
        
    }

    void OnClick()
    {
        if (GraphHolder.Instance.CurrentNode.Neighbors.Contains(NodeData))
        {
            if (NodeData.Type == NodeType.Boss)
                NodeData.Type = NodeType.Fight;
            print("Node ajoutée");
            GraphHolder.Instance.CurrentNode = NodeData;
            GraphHolder.Instance.PlayerPosition = new Vector2(NodeData.Layer, NodeData.Column);
            SceneManager.LoadScene(NodeData.Type.ToString());
        }
    }
}