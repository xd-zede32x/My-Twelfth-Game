using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _flightSpeed;
    [SerializeField] private float _tapForce = 10;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;

    private Rigidbody2D _rigidbody;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private AudioSource _flyClip;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _flyClip = GetComponent<AudioSource>();

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);

        ResetBird();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
            _rigidbody.velocity = new Vector2(_flightSpeed, 0);
            transform.rotation = _maxRotation;
            _flyClip.Play();
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void ResetBird()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _rigidbody.velocity = Vector2.zero;
    }
}