
using UnityEngine;

public class PlayerMouseControl : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private CharacterController characterController;
    private UnityEngine.Vector3 targetPosition;
   [SerializeField] private float moveSpeed = 10;
   private Animator animator;
    void Start()
    {
        characterController = GetComponent < CharacterController>();
        targetPosition = transform.position;
        animator = GetComponent <Animator>();
    }
    
    void Update()
    {
        float distToTarget = Vector3.Distance(transform.position, targetPosition);
        if (distToTarget > 1f && PlayerHealth.isAlive)
        {
            Vector3 targetDirection = UnityEngine.Vector3.Normalize(targetPosition - transform.position);
            characterController.Move(targetDirection * moveSpeed * Time.deltaTime);
            transform.LookAt(targetPosition);
            animator.SetBool("Running", true);
        }

        else
        {
            animator.SetBool("Running",false );
        }

        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 500, layerMask))
            {
                Debug.Log("hit: "+ hit.collider.name);
                targetPosition = hit.point;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("chop");
        }
    }
}
