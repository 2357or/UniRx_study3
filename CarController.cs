using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class CarController :MonoBehaviour
{
    [SerializeField]
    float speed = 20, deceleration=0.98f;

    void Start() {
        this.UpdateAsObservable()
            .SkipWhile(_ => !Input.GetMouseButtonDown(0))
            .Subscribe(_ =>
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
                speed *= deceleration;

                if (speed < 0.1) speed = 0;
            });
    }
}
