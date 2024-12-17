using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public TreeNode rootNode;
    public static Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target").transform;
    }

    private void Update()
    {
        if(rootNode != null)
        {
            rootNode.Execute(this);
        }
    }
    
}
