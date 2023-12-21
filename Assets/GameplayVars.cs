using System.Collections.Generic;

//an overengineered yet robust solution to a small problem
//found at https://stackoverflow.com/questions/42393259/load-scene-with-param-variable-unity. Thanks to Hasan Bayat for the answer!
//problem: when the player dies and goes to the game over scene, how do I get the most-recently-loaded scene? 
//          I want to load that scene when the user selects "try again"
//solution: global variables in unity!

// A simple static class to get and set globally accessible variables through a key-value approach.
// Uses a key-value approach (dictionary) for storing and modifying variables.
// It also uses a lock to ensure consistency between the threads.
public static class GameplayVars
{
    private static readonly object lockObject = new object();
    private static Dictionary<string, object> variablesDictionary = new Dictionary<string, object>();

    // The underlying key-value storage (dictionary).
    // <value>Gets the underlying variables dictionary</value>
    public static Dictionary<string, object> VariablesDictionary => variablesDictionary;

    // Retrieves all global variables.
    // <returns>The global variables dictionary object.</returns>
    public static Dictionary<string, object> GetAll()
    {
        return variablesDictionary;
    }

    // Gets a variable and casts it to the provided type argument.
    // <typeparam name="T">The type of the variable</typeparam>
    // <param name="key">The variable key</param>
    // <returns>The casted variable value</returns>
    public static T Get<T>(string key)
    {
        if (variablesDictionary == null || !variablesDictionary.ContainsKey(key))
        {
            return default(T);
        }

        return (T)variablesDictionary[key];
    }

    // Sets the variable, the existing value gets overridden.
    // <remarks>It uses a lock under the hood to ensure consistensy between threads</remarks>
    // <param name="key">The variable name/key</param>
    // <param name="value">The variable value</param>
    public static void Set(string key, object value)
    {
        lock (lockObject)
        {
            if (variablesDictionary == null)
            {
                variablesDictionary = new Dictionary<string, object>();
            }
            variablesDictionary[key] = value;
        }
    }

}