using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public abstract class GAction : MonoBehaviour
{
    public string actionName = "Action";
    public float cost = 1.0f;
    public GameObject target;
    public GameObject targetTag;
    public float duration = 0;

    public WorldState[] preConditions;
    public WorldState[] afterEffects;
    public NavMeshAgent agent;

    public Dictionary<string, int> preconditions;
    public Dictionary<string, int> effects;

    public WorldStates agentBelifes;

    public bool running = false;

    public GAction()
    {
        preconditions = new Dictionary<string, int>();
        effects = new Dictionary<string, int>();
    }

    public void Awake()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();

        if (preConditions != null )
        {
            foreach(WorldState w in preConditions)
            {
                preconditions.Add(w.key, w.value);
            }
        }
        if (afterEffects != null)
        {
            foreach (WorldState w in afterEffects)
            {
                effects.Add(w.key, w.value);
            }
        }
    }

    public bool IsAchivable()
    {
        return true;
    }

    public bool IsAchivableGiven(Dictionary<string, int> conditions)
    {
        foreach(KeyValuePair<string, int> kvp in conditions)
        {
            if (!conditions.ContainsKey(kvp.Key))
            {
                return false;
            }
        }
        return true;
    }

    public abstract bool PrePerform();
    public abstract bool PostPerform();
}
