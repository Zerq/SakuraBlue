using System;

namespace SakuraBlue.Entities {
    public abstract class Renderable {
      /// <summary>
      ///   Should never be implementedOutputtingMore then 2 characters
      ///   might make a concreete method that calls graphics truncating it at 2 and sedning it to what ever function returning this 
      /// </summary>
      public abstract  string Graphics { get; }           
      public abstract  ConsoleColor ColorA { get; } // for First character
      public abstract  ConsoleColor ColorB { get; } // for second character
      public abstract ConsoleColor ColorA2 { get; } // for First character
      public abstract ConsoleColor ColorB2 { get; } // for second character
    }
}