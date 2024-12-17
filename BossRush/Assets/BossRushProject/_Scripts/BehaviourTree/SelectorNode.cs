using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/TreeNode/SelectorNode")]
public class SelectorNode : CompositNode
{
    public override bool Execute(BossAI bossAI)
    {
        foreach(TreeNode child in children)
        {
            if(child.Execute(bossAI))
            {
                return true;
            }
        }
        return false;
    }
}
