using System.Collections.Generic;

public class Factory
{
    public int cost;
    public int earn;
    public float ethics; // going up is bad, going down is good
    //public Dictionary<string, int> expenses;
    //public Dictionary<string, int> products;
    public string placeableArea;

    public Factory()
    {
        cost = 0;
        earn = 0;
        ethics = 0;
        //expenses = new Dictionary<string, int>();
        //products = new Dictionary<string, int>();
        placeableArea = "";
    }

    public void GetFactory(string _name)
    {
        // probably a very bad way of doing this...
        switch (_name) {
            case "Gold_mine":
                cost = 100;
                earn = 1;
                ethics = -0.5f;
                //products.Add("Gold", 1);
                placeableArea = "Land";
                break;
            case "Gold_forge":
                cost = 500;
                earn = 10;
                ethics = 0.5f;
                //expenses.Add("Gold", 10);
                //products.Add("Gold Bar", 1);
                placeableArea = "Land";
                break;
            case "Gold_store":
                cost = 2000;
                earn = 50;
                ethics = -1f;
                placeableArea = "Land";
                break;
            case "Oil_platform":
                cost = 100000;
                earn = 100;
                ethics = 5;
                placeableArea = "Sea";
                break;
            case "Windmill":
                cost = 500000;
                earn = 100;
                ethics = -1;
                placeableArea = "Sea";
                break;
        }
    }
}

