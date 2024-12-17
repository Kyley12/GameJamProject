using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/TreeNode/CompositNode")]
public abstract class CompositNode : TreeNode
{
    public List<TreeNode> children = new List<TreeNode>();
}
