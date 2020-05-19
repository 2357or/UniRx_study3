using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class OpeTest :MonoBehaviour
{
    [SerializeField] float value;

    void Start() {
        this.UpdateAsObservable()
            .TakeWhile(_ => value < 500)
            .Subscribe(_ => value++);

        Observable.Interval(TimeSpan.FromSeconds(1))
            .SkipWhile(_ => value < 500)
            .Subscribe(_ => Debug.Log(Time.time.ToString("00.0")))
	        .AddTo(this.gameObject);

        this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Subscribe(_ =>
            {
                value -= 200;
                Debug.Log("value : " + value);
            });
    }
}
