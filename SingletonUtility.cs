using System;
using System.Reflection;

namespace FrameworkUtilityClasses.Core
{
    /// <summary>
    /// Creates Singleton instance of class
    /// </summary>
    /// <typeparam name="T">Type of Object</typeparam>
    public class SingletonUtility<T>
        where T : class
    {
        #region Member
        private static T _instance = default(T);
        private static readonly object _lock = new object();

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = CreateInstance();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion


        #region Constructor
        private SingletonUtility() { }
        #endregion


        #region Private Methods
        private static T CreateInstance()
        {
            //Invoke private constructor.
            ConstructorInfo constructorInfo = typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, Type.EmptyTypes, null);
            if (constructorInfo != null)
            {
                return constructorInfo.Invoke(null) as T;
            }
            throw new Exception("Please create paramterless private constructor. TypeName: " + typeof(T).Name);
        }
        #endregion
    }
}
