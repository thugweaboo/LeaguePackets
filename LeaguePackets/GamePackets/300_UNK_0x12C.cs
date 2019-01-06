﻿using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class UNK_0x12C : GamePacket // 0x12C
    {
        public override GamePacketID ID => GamePacketID.UNK_0x12C;
        // This could be "IsMyTeam" or "IsOrder" or something else
        public bool Unknown1 { get; set; }
        // If this is not 0 the rest doesn't get processed
        public uint Unknown2 { get; set; }
        // This value gets stored
        public uint Unknown3 { get; set; }

        public UNK_0x12C(){}

        public UNK_0x12C(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            byte bitfield = reader.ReadByte();
            Unknown1 = (bitfield & 0x01) != 0;

            Unknown2 = reader.ReadUInt32();
            Unknown3 = reader.ReadUInt32();

            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            byte bitfield = 0;
            if (Unknown1)
                bitfield |= 0x01;
            writer.WriteByte(bitfield);

            writer.WriteUInt32(Unknown2);
            writer.WriteUInt32(Unknown3);
        }
    }
}
