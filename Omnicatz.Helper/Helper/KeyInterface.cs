using Omnicatz.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnicatz.Helper
{
    //ok so i should have this as two separete files but meh it only a inparameter class so i can use params...

    public class KeyHook
    {
        public KeyHook(ConsoleKey key, Action action) {
            this.Key = key;
            this.Action = action;
        }
        public ConsoleKey Key { get; set; }
        public Action Action { get; set; }
    }

    public class KeyInterface
    {
        public KeyInterface(params KeyHook[] hooks) {
            dictionary = new Dictionary<ConsoleKey, Action>();
            foreach (var hook in hooks) {
                dictionary.Add(hook.Key, hook.Action);
            }
        }
        Dictionary<ConsoleKey, Action> dictionary;
        List<ConsoleKey> pressed = new List<ConsoleKey>();
        public void Listen()
        {
            //if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                if (dictionary.ContainsKey(key))
                {
                    dictionary[key].Invoke();
                }
              //  System.Threading.Thread.Sleep(300);
            }
        }
    }
}
