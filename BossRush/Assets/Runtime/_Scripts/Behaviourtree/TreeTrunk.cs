using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace BehaviourTree
{
    public abstract class TreeTrunk : MonoBehaviour
    {
        private Node _root = null;

        protected void Start()
        {
            _root = SetUpTree();
        }

        private void Update()
        {
            if(_root != null)
            {
                _root.Evalutate();
            }
        }

        protected abstract Node SetUpTree();
    }
}
