namespace FirstAPI_s25510;

public interface IMockVisitDb
{
    public ICollection<Visit> GetAll();
    public List<Visit> GetVisitsByAnimalId(int animalId);
    public bool Add(Visit visit);
}