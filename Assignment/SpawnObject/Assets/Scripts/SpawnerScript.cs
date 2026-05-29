using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnerScript : MonoBehaviour
{
    private SpawnAction inputActions;
    [SerializeField] private GameObject[] Prefabs;
    [SerializeField] private Vector3[] randomPos;
    [SerializeField] private Quaternion[] randomRot;

    private void Awake() => inputActions = new SpawnAction();

    private void OnEnable() => inputActions.Enable();

    private void OnDisable() => inputActions.Disable();

    private void Start()
    {
        inputActions.SpawnObj.Spawn.performed += ctx =>
        {
            int randomIndex = Random.Range(0, Prefabs.Length);
            int randomPosition = Random.Range(0, randomPos.Length);
            int randomRotation = Random.Range(0, randomRot.Length);

            GameObject newPrefab = Instantiate(Prefabs[randomIndex], randomPos[randomPosition], randomRot[randomRotation]);
            newPrefab.AddComponent<Rigidbody>();
            newPrefab.name = "CuriosCapsule";
            newPrefab.name = "SmileySphere";
            newPrefab.name = "ConfusedCube";
            newPrefab.name = "ProudPlane";
            newPrefab.name = "CryingCylinder";
        };  
    }


}
