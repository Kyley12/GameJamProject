using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/TreeNode/SequenceNode")]
public class SequenceNode : CompositNode
{
    public override bool Execute(BossAI bossAI)
    {
        foreach(TreeNode child in children)
        {
            if(!child.Execute(bossAI))
            {
                return false;
            }
        }
        return true;
    }
}
