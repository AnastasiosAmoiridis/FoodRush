namespace Results
{
    public class Result<T> : ResultBase where T : class
    {
        public T Item { get; protected set; }

        public void SetSuccess(T item)
        {
            base.SetSuccess();
            Item = item;
        }
    }
}
