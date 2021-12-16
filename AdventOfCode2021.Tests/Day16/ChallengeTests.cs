namespace AdventOfCode2021.Tests.Day16;

using AdventOfCode2021.Day16;

public class ChallengeTests
{
    [Fact]
    public void TestExample1()
    {
        var packet = new Packet(Challenge.ConvertToBinary("D2FE28"));

        Assert.NotEmpty(packet.Binary);
        Assert.Equal(24, packet.Binary.Length);
        Assert.Equal("110100101111111000101000", packet.Binary);

        Assert.Equal(6, packet.PacketVersion);
        Assert.Equal(PacketTypeEnum.Literal, packet.PacketType);
        Assert.Equal(2021,packet.Value);

        Assert.Null(packet.LengthType);
        Assert.Null(packet.Length);
    }

    [Fact]
    public void TestExample2()
    {
        var packet = new Packet(Challenge.ConvertToBinary("38006F45291200"));

        Assert.Equal(1, packet.PacketVersion);
        Assert.Equal(PacketTypeEnum.LesserThan, packet.PacketType);
        Assert.Equal(LengthTypeEnum.LengthInBits, packet.LengthType);
        Assert.Equal(27, packet.Length);
        Assert.Equal("110100010100101001000100100", packet.SubPacketsString);
        Assert.Equal(2, packet.SubPackets!.Count);
        Assert.Equal(10, packet.SubPackets!.First().Value);
        Assert.Equal(20, packet.SubPackets!.Last().Value);
    }

    [Fact]
    public void TestExample3()
    {
        var packet = new Packet(Challenge.ConvertToBinary("EE00D40C823060"));

        Assert.Equal(7, packet.PacketVersion);
        Assert.Equal(PacketTypeEnum.Maximum, packet.PacketType);
        Assert.Equal(LengthTypeEnum.NumberOfSubPackets, packet.LengthType);
        Assert.Equal(3, packet.Length);
        Assert.Equal(3, packet.SubPackets!.Count);
        Assert.Equal(1, packet.SubPackets!.ElementAt(0).Value);
        Assert.Equal(2, packet.SubPackets!.ElementAt(1).Value);
        Assert.Equal(3, packet.SubPackets!.ElementAt(2).Value);
    }

    [Fact]
    public void TestExample4()
    {
        var packet = new Packet(Challenge.ConvertToBinary("8A004A801A8002F478"));

        Assert.Equal(4, packet.PacketVersion);
        var firstSubPacket = packet.SubPackets!.First();
        Assert.Equal(1, firstSubPacket.PacketVersion);
        var secondSubPacket = firstSubPacket.SubPackets!.First();
        Assert.Equal(5, secondSubPacket.PacketVersion);
        Assert.Equal(6, secondSubPacket.SubPackets!.First().PacketVersion);
        Assert.Equal(16, packet.PacketVersionSum);
    }

    [Fact]
    public void TestExample5()
    {
        var packet = new Packet(Challenge.ConvertToBinary("620080001611562C8802118E34"));

        Assert.Equal(3, packet.PacketVersion);
        Assert.Equal(12, packet.PacketVersionSum);
    }

    [Fact]
    public void TestExample6()
    {
        var packet = new Packet(Challenge.ConvertToBinary("C0015000016115A2E0802F182340"));

        Assert.Equal(23, packet.PacketVersionSum);
    }

    [Fact]
    public void TestExample7()
    {
        var packet = new Packet(Challenge.ConvertToBinary("A0016C880162017C3686B18A3D4780"));

        Assert.Equal(31, packet.PacketVersionSum);
    }

    [Fact]
    public void TestExampleSum()
    {
        var packet = new Packet(Challenge.ConvertToBinary("C200B40A82"));

        Assert.Equal(3, packet.Value);
    }

    [Fact]
    public void TestExampleProduct()
    {
        var packet = new Packet(Challenge.ConvertToBinary("04005AC33890"));

        Assert.Equal(54, packet.Value);
    }

    [Fact]
    public void TestExampleMinimum()
    {
        var packet = new Packet(Challenge.ConvertToBinary("880086C3E88112"));

        Assert.Equal(7, packet.Value);
    }

    [Fact]
    public void TestExampleMaximum()
    {
        var packet = new Packet(Challenge.ConvertToBinary("CE00C43D881120"));

        Assert.Equal(9, packet.Value);
    }

    [Fact]
    public void TestExampleLessThan()
    {
        var packet = new Packet(Challenge.ConvertToBinary("D8005AC2A8F0"));

        Assert.Equal(1, packet.Value);
    }

    [Fact]
    public void TestExampleGreaterThan()
    {
        var packet = new Packet(Challenge.ConvertToBinary("F600BC2D8F"));

        Assert.Equal(0, packet.Value);
    }

    [Fact]
    public void TestExampleEqual()
    {
        var packet = new Packet(Challenge.ConvertToBinary("9C005AC2F8F0"));

        Assert.Equal(0, packet.Value);
    }

    [Fact]
    public void TestExampleMultipleCalculation()
    {
        var packet = new Packet(Challenge.ConvertToBinary("9C0141080250320F1802104A08"));

        Assert.Equal(1, packet.Value);
    }

    [Fact]
    public void TestInput()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day16\input.txt");
        Assert.Equal(1012, challenge.Packet.PacketVersionSum);

        Assert.Equal(2223947372407, challenge.Packet.Value);
    }
}