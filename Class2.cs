using System;

public class Class2
{
    public string DefangIPaddr(string address)
    {
        string res = "";
        for (int i = 0; i < address.Length; i++)
        {
            if (address[i] == '.')
            {
                res += "[.]";
            }
            else res += address[i];
        }
        return res;
    }
}
