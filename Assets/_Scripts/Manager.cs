public abstract class Manager<T> : Singleton<T> where T : Manager<T>
{   
    public abstract void Initialize();
}