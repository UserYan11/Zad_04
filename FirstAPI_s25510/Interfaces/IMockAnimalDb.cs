namespace FirstAPI_s25510;

public interface IMockAnimalDb
{
    public ICollection<Animal> GetAll();
    public bool Add(Animal animal);
    public Animal GetAnimalById(int id);
    public bool Update(int id, Animal updatedAnimal);
    public bool Delete(int id);
}