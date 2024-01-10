using UnityEngine;
using CnControls;

// This is merely an example, it's for an example purpose only
// Your game WILL require a custom controller scripts, there's just no generic character control systems, 
// they at least depend on the animations

[RequireComponent(typeof(CharacterController))]
public class ThidPersonExampleController : MonoBehaviour
{
    public float MovementSpeed = 10f;

    private Transform _mainCameraTransform;
    private Transform _transform;
    private CharacterController _characterController;
	Rigidbody rb;
    private void OnEnable()
    {
        _mainCameraTransform = Camera.main.GetComponent<Transform>();
        _characterController = GetComponent<CharacterController>();
        _transform = GetComponent<Transform>();
	
    }

    public void Update()
    {
        // Just use CnInputManager. instead of Input. and you're good to go
		var inputVector = new Vector3(CnInputManager.GetAxis("Horizontal")*MovementSpeed*Time.deltaTime,0,0);
		var inputVector2 = new Vector3(CnInputManager.GetAxis("Vertical")*MovementSpeed*Time.deltaTime,0,0);
		transform.Translate (-inputVector.x, 0, -inputVector2.x);

        // If we have some input
        
    }
}
