﻿using System;
using System.Collections.Generic;
using Maple2.Model.Enum;
using Maple2.Model.Metadata;
using Maple2.PacketLib.Tools;
using Maple2.Tools;

namespace Maple2.Model.Game;

public class Home : IByteSerializable {
    private const byte HOME_PERMISSION_COUNT = 9;

    public long AccountId { get; init; }
    public int MapId { get; init; }
    public int Number { get; init; }

    public byte Area { get; private set; }
    public byte Height { get; private set; }

    public int CurrentArchitectScore { get; set; }
    public int ArchitectScore { get; set; }

    // Interior Settings
    public byte Background { get; set; }
    public byte Lighting { get; set; }
    public byte Camera { get; set; }
    public string? Password { get; set; }
    public readonly IDictionary<HomePermission, HomePermissionSetting> Permissions;

    private string name;
    public string Name {
        get => name;
        set {
            if (!string.IsNullOrWhiteSpace(value)) {
                name = value;
            }
        }
    }

    private string message;
    public string Message {
        get => message;
        set {
            if (!string.IsNullOrWhiteSpace(value)) {
                message = value;
            }
        }
    }

    public PlotInfo Indoor { get; set; }
    public PlotInfo? Outdoor { get; set; }

    public int PlotMapId => Outdoor?.MapId ?? 0;
    public int PlotNumber => Outdoor?.Number ?? 0;
    public int ApartmentNumber => Outdoor?.ApartmentNumber ?? 0;
    public PlotState State => Outdoor?.State ?? PlotState.Open;

    public Home() {
        name = "Unknown";
        message = "Thanks for visiting. Come back soon!";
        Permissions = new Dictionary<HomePermission, HomePermissionSetting>();
    }

    public byte SetArea(int area) {
        Area = (byte) Math.Clamp(area, Constant.MinHomeArea, Constant.MaxHomeArea);
        return Area;
    }

    public byte SetHeight(int height) {
        Height = (byte) Math.Clamp(height, Constant.MinHomeHeight, Constant.MaxHomeHeight);
        return Height;
    }

    public void WriteTo(IByteWriter writer) {
        writer.WriteLong(AccountId);
        writer.WriteUnicodeString(Name);
        writer.WriteUnicodeString(Message);
        writer.WriteByte();
        writer.WriteInt(CurrentArchitectScore);
        writer.WriteInt(ArchitectScore);
        writer.WriteInt(PlotMapId);
        writer.WriteInt(PlotNumber);
        writer.WriteByte(); // (1=Removes Top-Right UI)
        writer.WriteByte(Area);
        writer.WriteByte(Height);
        writer.WriteByte(Background);
        writer.WriteByte(Lighting);
        writer.WriteByte(Camera);

        writer.WriteByte(HOME_PERMISSION_COUNT);
        for (byte i = 0; i < HOME_PERMISSION_COUNT; i++) {
            bool enabled = Permissions.TryGetValue((HomePermission) i, out HomePermissionSetting setting);
            writer.WriteBool(enabled);
            if (enabled) {
                writer.Write<HomePermissionSetting>(setting);
            }
        }
    }
}
