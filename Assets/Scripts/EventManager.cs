using System;
using UnityEngine;
public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }
    
    public event EventHandler onDedicateCoin;
    public event EventHandler onDamage;

    public void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        onDedicateCoin?.Invoke(this, EventArgs.Empty);
        onDamage?.Invoke(this, EventArgs.Empty);
    }
}
