﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteNoise;

public sealed class ProjectileData
{
    public Vector2 Position { get; set; }
    public float Rotation { get; set; }
    public float Lifespan { get; set; }
    public float Speed { get; set; }
}


