using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    private AudioSource _coinSelection;

    private void Start()
    {
        _coinSelection = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bird bird))
        {
            _coinSelection.Play();
        }
    }
}