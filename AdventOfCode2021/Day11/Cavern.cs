namespace AdventOfCode2021.Day11;

public class Cavern
{
    public Cavern(List<Octopus> octopi)
    {
        Octopi = octopi;
    }

    public List<Octopus> Octopi { get; private set; }

    public int TotalFlashes { get; private set; } = 0;

    public void NextStep()
    {
        for (var i = 0; i < Octopi.Count; i++)
        {
            Octopi.ElementAt(i).AddEnergy();
        }

        while (Octopi.Any(x => x.CanFlash))
        {
            var octopusToFlash = Octopi.First(x => x.CanFlash);
            TotalFlashes++;
            octopusToFlash.Flash();

            var adjecentOctopiToAddEnergy = Octopi.Where(x => x.IsAdjacent(octopusToFlash) && x.Energy != 10).ToList();

            for (var i = 0; i < adjecentOctopiToAddEnergy.Count; i++)
            {
                adjecentOctopiToAddEnergy.ElementAt(i).AddEnergy();
            }
        }

        var octipiThatCanFlash = Octopi.Where(x => x.CanFlash).ToList();
        if(octipiThatCanFlash.Any())
        {

        }

        var octopusToCheck = Octopi.First(x => x.X == 1 && x.Y == 1);

        var octopiToReset = Octopi.Where(x => x.Energy == 10).ToList();

        for (var i = 0; i < octopiToReset.Count; i++)
        {
            octopiToReset.ElementAt(i).Reset();
        }
    }
}
