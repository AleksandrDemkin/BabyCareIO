using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
public class Cube : InteractiveObject
{
    private List<GameObject> PlaceCube = new List<GameObject>();
    private List<GameObject> PlaceCastle = new List<GameObject>();
    private List<GameObject> CastleCube = new List<GameObject>();
    private GameObject _playerBaby;
    private GameObject _cubes;
    private bool isCube = false;
    private  float _speedFlyCube = 0.02f;
    



    private void Awake()
    {
        PlaceCube.AddRange(GameObject.FindGameObjectsWithTag("PlaceCube"));
        PlaceCastle.AddRange(GameObject.FindGameObjectsWithTag("PlaceCastle"));
        _playerBaby = GameObject.Find("ToonBabyA (2)");
        _cubes = GameObject.Find("PlaceCastle");
        


    }
    public override void Execute()
    {
        if (isCube == true)
        {
            MoveCubes();
        }
       
    }

    protected override void Interaction()
    {
        transform.rotation = _playerBaby.transform.rotation;
        PlayerBase._countCube++;
        gameObject.transform.tag = "Cube";
        CastleCube.AddRange(GameObject.FindGameObjectsWithTag("Cube"));
        gameObject.transform.SetParent(_playerBaby.transform);
        gameObject.transform.position = PlaceCube[PlayerBase._countCube].transform.position;
        Debug.Log(CastleCube.Count);
    }

    protected override void SecondInteraction()
    {
        isCube = true;
        PlayerBase._countCube = 0;
        gameObject.transform.SetParent(_cubes.transform);
        transform.rotation = Quaternion.Euler(0,0,0);
        

    }
    private   void MoveCubes()
    {
        for (int i = 0; i < CastleCube.Count; i++)
        {
            CastleCube[i].transform.position = Vector3.MoveTowards(CastleCube [i].transform.position,
               PlaceCastle[i].transform.position, _speedFlyCube);
            if (CastleCube[CastleCube.IndexOf(gameObject)].transform.position == PlaceCastle[CastleCube.IndexOf(gameObject)].transform.position)
            {
                
                Debug.Log(CastleCube.Count);
                isCube = false;
            }  
        }
    }
}
    
    
