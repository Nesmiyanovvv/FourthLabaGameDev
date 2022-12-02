using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Material False;
    public Material True;
    public Collider ResultCube;
    
    private readonly List<Collider> _cubes = new();
    
    private void OnTriggerEnter(Collider other)
    {
        _cubes.Add(other);
        
        if (_cubes.Count != 2)
            return;

        ResultCube
            .gameObject
            .GetComponent<Renderer>()
            .material = DotProductBias() > 0 ? True : False;
    }

    private double DotProductBias()
    {
        var w = new[] {
            0.9300813312530518,
            1.84646213054657
        };

        const double b = -2.7456431686782;

        var d = 0.0;

        for (var i = 0; i < _cubes.Count; i++)
            d += (_cubes[i].gameObject.GetComponent<Renderer>().material.color == False.color ? 0 : 1) * w[i];
        
        return d + b;
    }
}
