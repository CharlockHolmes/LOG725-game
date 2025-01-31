using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MouvementJoueur : MonoBehaviour
{
    [SerializeField] private float _vitesse = 25f;
    
    private Vector2 _mouvement, _direction;
    
    private Rigidbody2D _rigidBodyJoueur;

    private void Start()
    {
        _rigidBodyJoueur = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _mouvement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if(_mouvement.sqrMagnitude >= 0.01f)
        {
            _direction = _mouvement;
        }
        transform.right = _direction;
    }

    private void FixedUpdate()
    {
        _rigidBodyJoueur.AddForce(_mouvement * (_vitesse * 10f));
    }
}
