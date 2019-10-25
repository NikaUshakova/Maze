namespace MazeLibrary.Cells
{
    public class Ground : BaseCell
    {
        public bool Visited { get; set; }
        public Ground(Coordinates coordinates) : base(coordinates, ' ')
        {
        }

        public Ground(int x, int y) : base(x, y, ' ')
        {
        }

        public Ground(int x, int y, bool visited) : base(x, y, ' ')
        {
            Visited = visited;
        }

        public override bool TryToStep()
        {
            return true;
        }
    }
}
