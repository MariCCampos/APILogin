using System.Collections.Generic;

namespace APILogin.DATA.Converter
{
    public interface IParser<O, D>
    {
        D Parse(O origin);
        List<D> ParseList(List<O> origin);
    }
}
