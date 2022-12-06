using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoCache : MonoBehaviour
{
    public static List<MonoCache> allUpdate = new();
    public static List<MonoCache> allFixedUpdate = new();

    private void OnEnable() => allUpdate.Add(this);
    private void OnDisable() => allUpdate.Remove(this);
    private void OnDestroy() => allUpdate.Remove(this);

    protected void AddFixedUpdate() => allFixedUpdate.Add(this);
    protected void RemoveFixedUpdate() => allFixedUpdate.Remove(this);
    public void Tick() => OnTick();
    public void FixedTick() => OnFixedTick();
    public virtual void OnTick() { }
    public virtual void OnFixedTick() { }
}
