using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    float CAR_SPAWN_THRESHOLD = .02f;

    public List<Road> listOfRoads = new List<Road>();

    public GameObject CarPrefab;
    
    // Runtime

    void Start()
    {
        int[,] road1WP = new int[,] { {-10, 0}, {0, 0} };
        int[,] road2WP = new int[,] { {0, 0}, {10, 0} };
        
        listOfRoads.Add(new Road(1, road1WP));
        listOfRoads.Add(new Road(2, road2WP));
    }

    void Update()
    {
        if (Random.Range(0f, 1f) < CAR_SPAWN_THRESHOLD)
        {
            GameObject newCar = Instantiate(CarPrefab, new Vector3(listOfRoads[0].waypoints[0,0], 1, listOfRoads[0].waypoints[0,1]), Quaternion.identity, transform);
            newCar.GetComponent<Car>().Create(new Vector3(listOfRoads[0].waypoints[1,0], 1, listOfRoads[0].waypoints[1,1]));
        }
    }
}

public struct Road
{
    public int roadID { get; set; }
    public int[,] waypoints;

    public Road (int _roadID, int[,] _waypoints)
    {
        roadID = _roadID;
        waypoints = _waypoints;
    }
}
