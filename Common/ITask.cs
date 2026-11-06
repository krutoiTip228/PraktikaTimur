namespace CSharpPraktikum.Common;

public interface ITask {

	string Title { get; }
	string Description { get; }
	string[] Requirements { get; }
	void Run();
}