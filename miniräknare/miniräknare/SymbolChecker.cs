using System;

public class SymbolChecker
{
    public static bool IsSymbolValid(string symbol)
    {
        return symbol == "+" || 
               symbol == "-" || 
               symbol == "*" || 
               symbol == "/" || 
               symbol == "^" || 
               symbol == "roten";
    }
}
