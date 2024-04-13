namespace FirstAPI_s25510;

public class MockAnimalDb : IMockAnimalDb
{
    private ICollection<Animal> _animals;

    public MockAnimalDb()
    {
        _animals = new List<Animal>();
        _animals.Add(new Animal
            {
                id = 1,
                name = "Bob",
                category = "Cat",
                color = "Black",
                mass = 10.4
            });
        _animals.Add(new Animal
        {
            id = 2,
            name = "Jack",
            category = "Dog",
            color = "Silver",
            mass = 13.8
        });
        _animals.Add(new Animal
        {
            id = 3,
            name = "Luna",
            category = "Dog",
            color = "White",
            mass = 5.2
        });
    }
    
    public ICollection<Animal> GetAll()
    {
        return _animals;
    }

    public bool Add(Animal animal)
    {
        if (_animals.Any(a => a.id == animal.id))
        {
            return false;
        }
    
        _animals.Add(animal);
        return true;
    }

    public Animal? GetAnimalById(int id)
    {
        return _animals.FirstOrDefault(animal => animal.id == id);
    }
    
    public bool Update(int id, Animal updatedAnimal)
    {
        var existingAnimal = _animals.FirstOrDefault(animal => animal.id == id);
        if (existingAnimal != null)
        {
            _animals.Remove(existingAnimal);
            _animals.Add(updatedAnimal);
            return true;
        }
        
        return false;
    }

    public bool Delete(int id)
    {
        var existingAnimal = _animals.FirstOrDefault(animal => animal.id == id);
        if (existingAnimal != null)
        {
            _animals.Remove(existingAnimal);
            return true;
        }

        return false;
    }
}