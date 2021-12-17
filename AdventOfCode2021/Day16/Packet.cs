namespace AdventOfCode2021.Day16;

using System.Collections.Generic;

public class Packet
{
    public Packet(string binary)
    {
        Binary = binary;
    }

    public string Binary { get; }

    public int PacketVersion => Convert.ToInt32(Binary[..3], 2);

    public PacketTypeEnum PacketType => GetPacketType(Binary);

    public LengthTypeEnum? LengthType => GetLengthType(Binary, PacketType);

    public int? Length => GetLength(Binary, LengthType);

    public long Value => GetValue(Binary, PacketType, SubPackets);

    public string? SubPacketsString => GetSubPacketsString(Binary, LengthType, Length);

    public List<Packet>? SubPackets => GetSubPackets(Binary, PacketType, LengthType, Length);

    public int PacketVersionSum => PacketVersion + (SubPackets?.Sum(x => x.PacketVersionSum) ?? 0);

    public string TruncatedBinary => GetTruncatedBinary();

    private string GetTruncatedBinary()
    {
        if(PacketType == PacketTypeEnum.Literal)
        {
            return GetLiteralPacketString(Binary);
        }

        return GetHeaderString(Binary, LengthType!.Value) + string.Join(string.Empty, SubPackets!.Select(x => x.TruncatedBinary));
    }

    private static string GetHeaderString(string binary, LengthTypeEnum lengthType)
    {

        if (lengthType == LengthTypeEnum.LengthInBits)
        {
            return binary[..(7 + 15)];
        }

        if (lengthType == LengthTypeEnum.NumberOfSubPackets)
        {
            return binary[..(7 + 11)];
        }

        throw new InvalidOperationException();
    }

    public static string? GetSubPacketsString(string binary, LengthTypeEnum? lengthType, int? length)
    {
        if(lengthType == null || length == null)
        {
            return null;
        }

        if(lengthType == LengthTypeEnum.LengthInBits)
        {
            var subPacketBits = binary.Substring(7+15, length.Value);
            return subPacketBits;
        }

        if (lengthType == LengthTypeEnum.NumberOfSubPackets)
        {
            var subPacketBits = binary[(7 + 11)..];
            return subPacketBits;
        }

        return null;
    }

    private static LengthTypeEnum? GetLengthType(string binary, PacketTypeEnum packetType)
    {
        return packetType == PacketTypeEnum.Literal ? null : (LengthTypeEnum)Convert.ToInt32(binary.Substring(6, 1), 2);
    }

    private static PacketTypeEnum GetPacketType(string binary)
    {
        return (PacketTypeEnum)Convert.ToInt32(binary.Substring(3, 3), 2);
    }

    private static int? GetLength(string binary, LengthTypeEnum? lengthType)
    {
        return lengthType switch {
            LengthTypeEnum.LengthInBits => Convert.ToInt32(binary.Substring(7, 15), 2),
            LengthTypeEnum.NumberOfSubPackets => Convert.ToInt32(binary.Substring(7, 11), 2),
            _ => null
        };
    }

    private static long GetValue(string binary, PacketTypeEnum packetType, List<Packet>? subPackets)
    {
        if (packetType != PacketTypeEnum.Literal && subPackets == null)
        {
            throw new InvalidOperationException();
        }

        return packetType switch {
            PacketTypeEnum.Sum => subPackets!.Sum(x => x.Value),
            PacketTypeEnum.Product => subPackets!.Select(x => x.Value).Aggregate((a, b) => a * b),
            PacketTypeEnum.Mininum => subPackets!.Min(x => x.Value),
            PacketTypeEnum.Maximum => subPackets!.Max(x => x.Value),
            PacketTypeEnum.Literal => GetLiteralValue(binary),
            PacketTypeEnum.GreaterThan => subPackets!.First().Value > subPackets!.Last().Value ? 1 : 0,
            PacketTypeEnum.LesserThan => subPackets!.First().Value < subPackets!.Last().Value ? 1 : 0,
            PacketTypeEnum.Equal => subPackets!.First().Value == subPackets!.Last().Value ? 1 : 0,
            _ => throw new InvalidOperationException(),
        };
    }

    private static long GetLiteralValue(string binary)
    {
        var bytes = binary[6..].Chunk(5).Where(x => x.Length == 5).Select(x => string.Join(string.Empty, x).Substring(1, 4));
        return Convert.ToInt64(string.Join(string.Empty, bytes), 2);
    }

    private static string GetLiteralPacketString(string binary)
    {
        var bytes = binary[6..].Chunk(5).Where(x => x.Length == 5).ToList();
        var lastByte = bytes.FindIndex(x => x.First() == '0');

        return binary[..(((lastByte + 1) * 5) + 6)];
    }

    public static List<Packet>? GetSubPackets(string binary, PacketTypeEnum packetType, LengthTypeEnum? lengthType, int? length)
    {
        if (lengthType == null || length == null)
        {
            return null;
        }

        if (packetType == PacketTypeEnum.Literal)
        {
            return null;
        }

        var subPackets = new List<Packet>();
        var stringSubPackets = GetSubPacketsString(binary,lengthType,length);


        if (lengthType == LengthTypeEnum.LengthInBits)
        {
            while (stringSubPackets!.Length > 0)
            {
                var subPacket = FirstPacket(stringSubPackets);

                subPackets.Add(subPacket);
                stringSubPackets = stringSubPackets[subPacket.TruncatedBinary.Length..];
            }
        }
        if (lengthType == LengthTypeEnum.NumberOfSubPackets)
        {
            for (var i = 0; i < length; i++)
            {
                var subPacket = FirstPacket(stringSubPackets!);

                subPackets.Add(subPacket);
                stringSubPackets = stringSubPackets![subPacket.TruncatedBinary.Length..];
            }
        }

        return subPackets;
    }

    private static Packet FirstPacket(string stringSubPackets)
    {
        var subPacketType = GetPacketType(stringSubPackets);
        if (subPacketType == PacketTypeEnum.Literal)
        {
            var subPacketString = GetLiteralPacketString(stringSubPackets);
            return new Packet(subPacketString);
        }
        else
        {
            var subPacketString = GetOperatorPacketString(stringSubPackets, subPacketType);
            return new Packet(subPacketString);
        }
    }

    private static string GetOperatorPacketString(string stringSubPackets, PacketTypeEnum packetType)
    {
        var lengthType = GetLengthType(stringSubPackets, packetType)!.Value;
        var length = GetLength(stringSubPackets, lengthType)!.Value;

        if (lengthType == LengthTypeEnum.LengthInBits)
        {
            return GetHeaderString(stringSubPackets, lengthType) + GetSubPacketsString(stringSubPackets,lengthType, length);
        }

        if (lengthType == LengthTypeEnum.NumberOfSubPackets)
        {
            return GetHeaderString(stringSubPackets, lengthType) + GetSubPacketsString(stringSubPackets, lengthType, length);
        }

        throw new NotImplementedException();
    }
}