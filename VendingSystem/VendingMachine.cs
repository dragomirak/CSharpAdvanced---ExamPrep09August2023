using System.Text;

namespace VendingSystem;

public class VendingMachine
{
    public VendingMachine(int buttonCapacity)
    {
        ButtonCapacity = buttonCapacity;
        Drinks = new List<Drink>();
    }

    public int ButtonCapacity { get; set; }
    public List<Drink> Drinks { get; set; }
    public int GetCount => this.Drinks.Count();

    public void AddDrink(Drink drink)
    {
        if (GetCount < ButtonCapacity)
        {
            Drinks.Add(drink);
        }
    }
    public bool RemoveDrink(string name)
    {
        Drink drinkToRemove = Drinks.FirstOrDefault(x => x.Name == name);
        if (drinkToRemove != null)
        {
            return Drinks.Remove(drinkToRemove);
        }
        return false;
    }
    public Drink GetLongest()
    {
        Drink biggestDrink = Drinks.OrderByDescending(d => d.Volume).First();
        return biggestDrink;
    }
    public Drink GetCheapest()
    {
        Drink cheapestDrink = Drinks.OrderBy(d => d.Price).First();
        return cheapestDrink;
    }
    public string BuyDrink(string name)
    {
        Drink drinkToBuy = Drinks.FirstOrDefault(x => x.Name == name);
        return drinkToBuy.ToString();
    }
    public string Report()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Drinks available:");
        foreach (Drink drink in Drinks)
        {
            sb.AppendLine(drink.ToString());
        }
        
        return sb.ToString().Trim();
    }
}
