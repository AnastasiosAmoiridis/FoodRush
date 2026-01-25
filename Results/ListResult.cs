namespace Results
{
    public class ListResult<T> : ResultBase where T : class
    {
        public List<T> Items { get; protected set; } = new List<T>();

        public void SetSucess(List<T> listItems)
        {
            base.SetSuccess();
            Items = listItems;
        }
    }
}
