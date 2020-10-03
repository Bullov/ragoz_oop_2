namespace ragoz_oop_2.Components
{
    public class WheelType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public WheelType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}