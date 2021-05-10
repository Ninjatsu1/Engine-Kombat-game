using UnityEngine;

public class Tower : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        RotateTower();
    }

    //Rotate tanks tower
    private void RotateTower()
    {
        Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }


}
