using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnerScript : MonoBehaviour
{
    private SpawnAction inputActions;
    [SerializeField] private GameObject[] Prefabs; 

    private void Awake() => inputActions = new SpawnAction();

    private void OnEnable() => inputActions.Enable();

    private void OnDisable() => inputActions.Disable();

    private void Start()
    {
        inputActions.SpawnObj.Spawn.performed += ctx =>
        {
            int randomPrefab = Random.Range(0, 3);
        };  
    }


}
