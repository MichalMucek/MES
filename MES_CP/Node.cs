namespace MES_CP
{
    public struct Node
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double InitialTemperature { get; set; }
        public int Id { get; set; }
        public bool IsBoundary { get; set; }

        public override string ToString()
        {
            return $">>NODE<< ID: {Id} => X: {X} | Y: {Y} | InitialTemperature: {InitialTemperature} | IsBoundary: {IsBoundary}";
        }
    }
}
