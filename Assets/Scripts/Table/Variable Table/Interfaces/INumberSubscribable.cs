using System;
public interface INumberSubscribable
{
    int numberValue { get; }
    void Subscribe(Action<int> callback);
    void UnSubscribe(Action<int> callback);
}
