using UnityEngine;
using UnityEngine.InputSystem;

public class TestInputSystem : MonoBehaviour
{

    #region Old Input System
    /*[SerializeField] private Transform testGameObject;
    [SerializeField] private Vector3 changePosition = new Vector3(0.3f, 0);

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            testGameObject.position += changePosition;
            //testGameObject.position += new Vector3(0.3f, 0) // = 2D
                                      // new Vector3(0.3f, 0, 0) = 3D

            //Debug.Log("Space is pressed");
        }
    }*/
    #endregion

    #region New Input System

    private PlayerTestInput inputActions;

    [Header("GameObject Properties")]
    [SerializeField] private Transform testGameObject;
    [SerializeField] private Vector3 changePosition = new Vector3(0.3f, 0);

    [Header("Enum")]
    [SerializeField] private EnumTypes types;

    [Header("Array of Objects")]
    [SerializeField] private GameObject[] listOfGameObjects;

    private void Awake()
    {
        inputActions = new PlayerTestInput();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Start()
    {
        inputActions.TestInputAction.ChangePosition.performed += ctx =>
        {
            //testGameObject.position += changePosition;
            switch (types)
            {
                case EnumTypes.OneObject:
                    listOfGameObjects[0].transform.position += changePosition;
                    break;
                case EnumTypes.TwoObject:
                    listOfGameObjects[0].transform.position += changePosition;
                    listOfGameObjects[1].transform.position += changePosition;
                    break;
                case EnumTypes.ThreeObject:
                    listOfGameObjects[0].transform.position += changePosition;
                    listOfGameObjects[1].transform.position += changePosition;
                    listOfGameObjects[2].transform.position += changePosition;
                    break;
            }
        };
    }
    #endregion
}

public enum EnumTypes
{
    OneObject,
    TwoObject,
    ThreeObject,
}