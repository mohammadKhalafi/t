var bills = new List<int> { 25,5,10 };

var tempBills = bills.Select(x => x / 5).ToList();
var billCounts = new List<int>{0, 0, 0, 0, 0};

Console.WriteLine(CanPay(0));

bool CanPay(int i)
{
    if (i == bills.Count)
    {
        return true;
    }
    var bill = tempBills[i];
    billCounts[bill-1]++;

    if (bill == 1)
    {
        return CanPay(i+1);
    }
    else
    {
        var coefficients = GetCoefficients(bill);
        foreach (var cs in coefficients)
        {
            if (Enumerable.Range(0, 5).All(i => billCounts[i] >= cs[i]))
            {
                for (var j = 0; j < 5; j++)
                {
                    billCounts[j] -= cs[j];
                }
                
                var canPay = CanPay(i + 1);
                
                
                for (var j = 0; j < 5; j++)
                {
                    billCounts[j] += cs[j];
                }
                
                if (canPay)
                {
                    return true;
                }
            }
        }

        return false;
    }
}

List<List<int>> GetCoefficients(int bill)
{
    if (bill == 2)
    {
        return new List<List<int>>()
        {
            new List<int>{1,0,0,0,0}
        };
    }
    
    
    if (bill == 3)
    {
        return new List<List<int>>()
        {
            new List<int>{2,0,0,0,0},
            new List<int>{0,1,0,0,0},
        };
    }
    
    
    if (bill == 4)
    {
        return new List<List<int>>()
        {
            new List<int>{3,0,0,0,0},
            new List<int>{1,1,0,0,0},
            new List<int>{0,0,1,0,0}
        };
    }
    
    
    if (bill == 5)
    {
        return new List<List<int>>()
        {
            new List<int>{4,0,0,0,0},
            new List<int>{2,1,0,0,0},
            new List<int>{1,0,1,0,0},
            new List<int>{0,0,0,1,0},
            new List<int>{0,2,0,0,0},
        };
    }

    throw new InvalidOperationException();
}