using AutoMapper;
using EmprestaGame.API.ReturnMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmprestaGame.API.Model
{
    public class ModelBase<T>
    {
        public Message Mensagem { get; set; }

        private object model;

        public object Model
        {
            get { return model; }

            set
            {
                model = Mapper.Map<T>(value);
            }
        }

    }
}