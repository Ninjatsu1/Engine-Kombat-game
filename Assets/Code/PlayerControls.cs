using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    public bool facingRight = true;
    public bool facingTop = false;
    private void Start()
    {
        movePoint.parent = null;
       
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
       
        Vector3 horizontalAxis = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        Vector3 verticalAxis = new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
        float floatHorizontal = Input.GetAxisRaw("Horizontal");
        float floatVertical = Input.GetAxisRaw("Vertical");

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(floatHorizontal) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + horizontalAxis, .2f, whatStopsMovement ))
                {
                    movePoint.position += horizontalAxis;
                }
                
            } if (Mathf.Abs(floatVertical) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + verticalAxis, .2f, whatStopsMovement))
                {
                    movePoint.position += verticalAxis;
                }
                
            }
        }
       
    }
    
}
