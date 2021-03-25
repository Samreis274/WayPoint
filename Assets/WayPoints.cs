using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints: MonoBehaviour
{
    //Criacao da lista de gameoblect dos pontos
    public GameObject[] waypoints;

    int currentWP = 0;
    //velocidade do player
    float speed = 7.0f;
    float accuracy = 1.0f;
    //velocidade da rotacao do player
    float rotSpeed = 1.5f;
    void Start()
    {
        //pega a tag dos pontos
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }
    void LateUpdate()
    {
        //if para contagem dos pontos e movimentaçao
        if (waypoints.Length == 0) return;
        
        //vector para a posicao do target do ponto
        Vector3 lookAtGoal = new Vector3(waypoints[currentWP].transform.position.x,
        this.transform.position.y,
        waypoints[currentWP].transform.position.z);
        
        //vector para rotacao do player
        Vector3 direction = lookAtGoal - this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
        Quaternion.LookRotation(direction),
        Time.deltaTime * rotSpeed);
        
        //if para vereficar e resetar a contagem dos pontos
        if (direction.magnitude < accuracy)
        {
            currentWP++;
            
            if (currentWP >= waypoints.Length)
            {
                currentWP = 0;
            }
        }
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
