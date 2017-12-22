using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestaGame.DTO
{
    public class DTOBase
    {
        public int Id { get; set; }
        public int Status { get; set; }

        public T ToEntity<T>()
        {
            return Mapper.Map<T>(this);
        }
    }
}
