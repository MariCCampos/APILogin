using System.Collections.Generic;
using Tapioca.HATEOAS;

namespace APILogin.DATA.VO
{
    public class LoginVO : ISupportsHyperMedia
    {
        public long? Id { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
