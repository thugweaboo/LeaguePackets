﻿using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.CommonData;

namespace LeaguePackets.GamePackets
{
    public class ChangeSlotSpellData : GamePacket // 0x17
    {
        public override GamePacketID ID => GamePacketID.ChangeSlotSpellData;
        public ChangeSpellData ChangeSpellData { get; set; } = null;

        public ChangeSlotSpellData(){}

        public ChangeSlotSpellData(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.ChannelID = channelID;
            this.SenderNetID = senderNetID;

            this.ChangeSpellData = reader.ReadChangeSpellData();

            this.ExtraBytes = reader.ReadLeft();
        }

        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteChangeSpellData(ChangeSpellData);
        }
    }
}
