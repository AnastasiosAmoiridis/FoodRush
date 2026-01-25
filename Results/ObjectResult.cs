namespace Results
{
    public class ObjectResult<T> : ResultBase where T : class
    {
        public T Item { get; protected set; }

        public void SetSuccess(T item)
        {
            base.SetSuccess();
            Item = item;
        }
    }
}
