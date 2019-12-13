using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : Defender
{
    public override void empower()
    {
        base.empower();
        health *= 2;
    }
}
