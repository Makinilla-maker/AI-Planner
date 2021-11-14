using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Generated.Semantic.Traits;

public class PlannerCallback : MonoBehaviour
{
    Moves moves;
    UnityEngine.AI.NavMeshAgent agent;
    Robber robber;

    GameObject treasure;
    GameObject copGO;

    void Start()
    {
        moves = this.GetComponent<Moves>();
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        robber = this.GetComponent<Robber>();
        copGO = GameObject.Find("Cop");
        treasure = GameObject.Find("Treasure");
    }

    public void Steal()
    {
        Debug.Log("Steal");
        treasure.GetComponent<MeshRenderer>().enabled = false;
    }

    public IEnumerator Seek()
    {
        Debug.Log("Approach");
        agent.SetDestination(treasure.transform.position);
        while ((Vector3.Distance(treasure.transform.position, transform.position) > 2f) &&
               (Vector3.Distance(treasure.transform.position, copGO.transform.position) > 10f))
            yield return null;
        if (Vector3.Distance(treasure.transform.position, copGO.transform.position) < 10f)
        {
            robber.CopAway = false;
        }
        else
        {
            robber.Ready2steal = true;
        }
    }

    public IEnumerator Wander()
    {
        Debug.Log("Wander");
        while (Vector3.Distance(treasure.transform.position, copGO.transform.position) < 10f)
        {
            moves.Wander();
            yield return null;
        }
    }
}
