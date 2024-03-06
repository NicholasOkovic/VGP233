using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMove : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform destinationPoint;
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private float enemyStopDistance = 10;
    private int currentIndex = 0;

    private AIState currentState;

    private Transform playerFound;
    private Transform heardPos;

    [SerializeField] private LensFlare lensFlare;
    [SerializeField] private Light _light;

    private Color _baseLightColor;

    // Start is called before the first frame update
    void Start()
    {
        _baseLightColor = _light.color;


        agent = GetComponent<NavMeshAgent>();
        currentState = AIState.Patrol;
        agent.SetDestination(wayPoints[currentIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == AIState.Patrol)
        {
            Vector3 aiPosition = new Vector3(transform.position.x, wayPoints[currentIndex].position.y, transform.position.z);
            Vector3 wayPointPosition = wayPoints[currentIndex].position;
            float distanceFromPoint = Vector3.Distance(aiPosition, wayPointPosition);

            if (distanceFromPoint <= 0.1f)
            {
                //go to next 
                Debug.Log("reached " + (currentIndex + 1));
                currentIndex = (currentIndex + 1) % wayPoints.Length;

            }
            agent.SetDestination(wayPoints[currentIndex].position);

        }
        else if (currentState == AIState.Chase)
        {
            agent.SetDestination(playerFound.position);
            float distanceToPlayer = Vector3.Distance(playerFound.position, transform.position);

            if (distanceToPlayer >= enemyStopDistance) //must be larger than detection box
            {
                ResetToPatrol();
            }
        }
        else if (currentState == AIState.Heard)
        {
            agent.SetDestination(heardPos.position);
            float distanceToSound = Vector3.Distance(heardPos.position, transform.position);
            Debug.Log(distanceToSound);
            if (distanceToSound <= 1.0f) 
            {
                Invoke(nameof(ResetToPatrol), 1.25f);
            }
        }

    }

    public void FoundPlayer(Transform playertoChase)
    {
        playerFound = playertoChase;
        currentState = AIState.Chase;
        lensFlare.color = Color.red;
        _light.color = Color.red;
            
    }
    public void HeardSomething(Transform soundPos)
    {
        heardPos = soundPos;
        currentState = AIState.Heard;
        lensFlare.color = Color.magenta;
        _light.color = Color.magenta;
    }

    public void ResetToPatrol()
    {
        currentState = AIState.Patrol;
        lensFlare.color = _baseLightColor;
        _light.color = _baseLightColor;
    }


}

public enum AIState
{
    Patrol = 0,
    Chase = 1,
    Heard = 2
}

