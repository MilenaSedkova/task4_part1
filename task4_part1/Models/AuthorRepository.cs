namespace task4_part1.Models
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly List<Author> _authors= new List<Author>();
        private int _id=1;

        public IEnumerable<Author> GetAll()
        {
            return _authors;
        }

        public Author? GetById(int id)
        {
            return _authors.FirstOrDefault(a => a.Id == id);
        }

        public Author Add(Author author)
        {
            author.Id = _id++;
            _authors.Add(author);
            return author;
        }
        public void Update(Author author)
        {
            var index = _authors.FindIndex(a => a.Id == author.Id);
            if (index != -1)
            {
                _authors[index] = author;
            }
        }
        public void Delete(int id)
        {
            var author = GetById(id);
            if (author != null)
            {
                _authors.Remove(author);
            }
        }
    }
}
