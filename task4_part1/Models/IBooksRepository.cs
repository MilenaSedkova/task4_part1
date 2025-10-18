namespace task4_part1.Models
{
    public interface IBooksRepository
    {
        IEnumerable<Books> GetAll();
        Books GetById(int id);
        Books Add(Books book);
        void Update(Books id); 
        void Delete(Books id);

     
    }
}
