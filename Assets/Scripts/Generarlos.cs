using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generarlos : MonoBehaviour
{
    // Dentro de la clase que se genera, declaramos las variables:
    public GameObject robot;
    public GameObject caja;

    public int clonesRobot;
    public int clonesCaja;

    GameObject[] agents;

    float[,] P = new float[15, 3];

    // Start is called before the first frame update
    void Start()
    {
        int numOfAgents = clonesRobot + clonesCaja;
        agents = new GameObject[numOfAgents];
        float posX, posZ;
        for (int i = 0; i < numOfAgents; i++)
        {
            posX = UnityEngine.Random.Range(2.0f, 30.0f);
            posZ = UnityEngine.Random.Range(2.0f, 30.0f);
            P[i, 0] = posX;
            P[i, 1] = 0.3f;
            P[i, 2] = posZ;
            
            if(i<clonesRobot)
            {
                agents[i] = Instantiate(robot, new Vector3(posX, 0.3f, posZ), Quaternion.identity);
            } else
            {
                agents[i] = Instantiate(caja, new Vector3(posX, 0.3f, posZ), Quaternion.identity);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int s = 0; s < clonesRobot; s++)
        {
            int opc;
            float px = 0f, pz = 0f, step = 0.2f;
            opc = UnityEngine.Random.Range(1, 8);
            switch (opc)
            {
                case 1: 
                    px = -step; pz = -step; break;
                case 2: 
                    px = 0f; pz = -step; break;
                case 3: 
                    px = step; pz = -step; break;
                case 4: 
                    px = -step; pz = 0f; break;
                case 5: 
                    px = step; pz = 0f; break;
                case 6: 
                    px = -step; pz = step; break;
                case 7: 
                    px = 0f; pz = step; break;
                case 8: 
                    px = step; pz = step; break;
            }

            if (P[s, 0] < 0) px = +step;
            if (P[s, 2] > 100) pz = -step;
            if (P[s, 0] > 100) px = -step;
            if (P[s, 2] < 0) pz = +step;

            P[s, 0] += px;
            P[s, 2] += pz;
            agents[s].transform.localPosition = new Vector3(P[s, 0], P[s, 1], P[s, 2]);
        }
    }
}
