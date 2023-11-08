using UnityEngine;

[RequireComponent(typeof(BirdMover))]

public class Bird : MonoBehaviour
{
    private BirdMover _mover;
    private int _pointsEarned;

    private void Start()
    {
        _mover = GetComponent<BirdMover>();
    }

    public void ResetPlayer()
    {
        _pointsEarned = 0;   
        _mover.ResetBird(); 
    }

    public void Died()
    {
        Debug.Log("Player of death");
        Time.timeScale = 0f;
    }
}