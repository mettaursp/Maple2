﻿using Maple2.Model.Enum;
using Maple2.PacketLib.Tools;
using Maple2.Server.Core.Constants;
using Maple2.Server.Core.PacketHandlers;
using Maple2.Server.Game.Model;
using Maple2.Server.Game.Packets;
using Maple2.Server.Game.Session;

namespace Maple2.Server.Game.PacketHandlers;

public class InteractObjectHandler : PacketHandler<GameSession> {
    public override RecvOp OpCode => RecvOp.InteractObject;

    private enum Command : byte {
        Start = 11,
        End = 12,
    }

    public override void Handle(GameSession session, IByteReader packet) {
        var command = packet.Read<Command>();
        switch (command) {
            case Command.Start:
                HandleStart(session, packet);
                return;
            case Command.End:
                HandleEnd(session, packet);
                return;
        }
    }

    private void HandleStart(GameSession session, IByteReader packet) {
        string entityId = packet.ReadString();

        if (session.Field?.TryGetInteract(entityId, out FieldInteract? interact) != true) {
            return;
        }
    }

    private void HandleEnd(GameSession session, IByteReader packet) {
        string entityId = packet.ReadString();

        if (session.Field?.TryGetInteract(entityId, out FieldInteract? interact) == true && interact.React()) {
            switch (interact.Value.Type) {
                case InteractType.Mesh:
                    session.Send(InteractObjectPacket.Interact(interact));
                    break;
                case InteractType.Telescope:
                    // TODO: this should only be sent if telescope not found yet?
                    session.Send(InteractObjectPacket.Result(InteractResult.s_interact_find_new_telescope, interact));
                    break;
                case InteractType.Ui:
                    session.Send(InteractObjectPacket.Interact(interact));
                    break;
                case InteractType.Web:
                case InteractType.DisplayImage:
                case InteractType.Gathering:
                case InteractType.GuildPoster:
                case InteractType.BillBoard: // AdBalloon
                case InteractType.WatchTower:
                    break;
            }
        }
    }
}