using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _destroyXPosition = -5f;

    private void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;

        // Destroy pipe when it moves off screen
        if (transform.position.x < _destroyXPosition)
        {
            Destroy(gameObject);
        }
    }
}
