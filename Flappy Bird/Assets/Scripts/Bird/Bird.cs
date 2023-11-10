using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]

public class Bird : MonoBehaviour
{
    private BirdMover _mover;
    private int _pointsEarned;

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged; 

    private void Start()
    {
        _mover = GetComponent<BirdMover>();
    }

    public void IncreaseScore()
    {
        _pointsEarned++;    
        ScoreChanged?.Invoke(_pointsEarned);
    }

    public void ResetPlayer()
    {
        _pointsEarned = 0;
        ScoreChanged?.Invoke(_pointsEarned);
        _mover.ResetBird(); 
    }

    public void Died()
    {
        GameOver?.Invoke();
    }
}