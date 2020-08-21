using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application
{
    public class DictionaryModifyRequest:DictionaryAddRequest
    {
        public Guid Id { get; set; }
    }
}
