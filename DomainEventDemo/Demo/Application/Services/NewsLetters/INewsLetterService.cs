using Demo.Domain.Model.NewsLetters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Services.NewsLetters
{
    public interface INewsLetterService
    {
        void Suscribe(Subscriber suscriber);

        IEnumerable<Subscriber> GetAll();
    }
}
