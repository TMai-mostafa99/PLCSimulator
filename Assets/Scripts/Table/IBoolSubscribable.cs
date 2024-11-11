using System;
using System.Collections.Generic;
using UnityEngine;

public interface IBoolSubscribable 
{
    bool BoolValue { get; }
    void Subscribe(Action<bool> callback);
    void UnSubscribe(Action<bool> callback);
  
}
