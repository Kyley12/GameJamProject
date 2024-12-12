using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public class Sequence : Node
    {
        public Sequence() : base() {}
        public Sequence(List<Node> children) : base(children) {}
        
        public override NodeState Evalutate()
        {
            bool anyChildIsRunning = false;

            foreach(Node node in children)
            {
                switch(node.Evalutate())
                {
                    case NodeState.Failure:
                        state = NodeState.Failure;
                        return state;
                    case NodeState.Success:
                        continue;
                    case NodeState.Running:
                        continue;
                    default:
                        state = NodeState.Success;
                        return state;
                }
            }

            state = anyChildIsRunning? NodeState.Running : NodeState.Success;
            return state; 
        }
    }
}
