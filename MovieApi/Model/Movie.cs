namespace MovieApi.Model;

public class Movie
{
	public Movie(int id, string name)
	{
		Id = id;
		Name = name;
	}

	public int Id { get; set; }

	public string Name { get; set; }
}
