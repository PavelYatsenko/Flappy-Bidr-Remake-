using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMoverer))]
public class Bird : MonoBehaviour
{
    private BirdMoverer _mover;
    private int _score;

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;

    public int Score => _score;

    private void Start()
    {
        _mover = GetComponent<BirdMoverer>();      
    }
    public void ResetPlayer()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
        _mover.ResetBird();
    }
    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }
    public void Die()
    {

        GameOver?.Invoke();
    }



}
