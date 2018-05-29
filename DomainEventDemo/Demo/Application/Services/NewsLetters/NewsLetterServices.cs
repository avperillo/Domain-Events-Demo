using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Domain.Model.NewsLetters;
using Demo.Domain.Model;

namespace Demo.Application.Services.NewsLetters
{
    public class NewsLetterServices : INewsLetterService
    {

        private ISubscriberRepository _suscriberRepository;

        public NewsLetterServices(ISubscriberRepository userRepository)
        {
            _suscriberRepository = userRepository;
        }

        public IEnumerable<Subscriber> GetAll()
        {
            return _suscriberRepository.GetAll();
        }

        public void Suscribe(Subscriber subscriber)
        {
            var result = _suscriberRepository.Add(subscriber);
        }
    }
}
