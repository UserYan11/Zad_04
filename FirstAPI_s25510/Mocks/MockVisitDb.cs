namespace FirstAPI_s25510;

public class MockVisitDb : IMockVisitDb
{
    private ICollection<Visit> _visits;

    public MockVisitDb()
    {
        _visits = new List<Visit>();
        _visits.Add(new Visit
        {
            id = 1,
            visitDate = DateTime.Now.AddDays(-7),
            description = "Pierwsza wizyta",
            price = 50.0
        });

        _visits.Add(new Visit
        {
            id = 1,
            visitDate = DateTime.Now.AddDays(-5),
            description = "Druga wizyta",
            price = 75.0
        });

        _visits.Add(new Visit
        {
            id = 3,
            visitDate = DateTime.Now.AddDays(-2),
            description = "Pierwsza wizyta",
            price = 100.0
        });
    }

    public ICollection<Visit> GetAll()
    {
        return _visits;
    }
    
    public List<Visit> GetVisitsByAnimalId(int animalId)
    {
        return _visits.Where(visit => visit.id == animalId).ToList();
    }

    public bool Add(Visit visit)
    {
        _visits.Add(visit);
        return true;
    }
}