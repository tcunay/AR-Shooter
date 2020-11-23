using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bulletTemplate;


    private void Update()
    {
        if (Input.touchCount > 0) //Input.GetMouseButtonDown(0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
            Instantiate(_bulletTemplate, _shootPoint);
            }
        }
    }
}
