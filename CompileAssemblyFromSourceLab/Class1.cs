using System;
using System.Threading.Tasks;
public class Startup
{
    public async Task<object> Invoke(object ___input)
    {
        Func<object, Task<object>> func =
            async (input) =>
            {
                return input;
            }
        ;
#line hidden
        return await func(___input);
    }
}