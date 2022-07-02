﻿using System.Collections.Generic;
using Maple2.Model.Enum;

namespace Maple2.Model.Metadata;

public record RideMetadata(
    int Id,
    string Model,
    RideMetadataBasic Basic,
    RideMetadataSpeed Speed,
    IReadOnlyDictionary<StatAttribute, long> Stats,
    int Passengers);

public record RideMetadataBasic(
    int Type,
    int SkillSetId,
    float SummonTime,
    long RunXStamina,
    bool EnableSwim,
    int FallDamageDown);

public record RideMetadataSpeed(
    float WalkSpeed,
    float RunSpeed,
    float RunXSpeed,
    float SwimSpeed);
