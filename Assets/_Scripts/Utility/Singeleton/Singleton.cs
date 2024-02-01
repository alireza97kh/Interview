using System;

public class Singleton<T> : SingletonBase where T : class, new()
{
    private static T instance;

	public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new T();
			}
			return instance;
        }
    }
}

