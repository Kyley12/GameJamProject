using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/TreeNode")]
public abstract class TreeNode : ScriptableObject
{
    public abstract bool Execute(BossAI bossAI);
}
