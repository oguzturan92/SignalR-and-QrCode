using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Abstract;
using Data.Concrete;
using Data.Repository;
using Entity.Concrete;

namespace Data.EntityFramework
{
    public class MessageDal : GenericRepository<Message>, IMessageDal
    {
        public MessageDal(Context context) : base(context)
        {

        }

        public List<Message> GetMessagesDateTimeBy()
        {
            using (var context = new Context())
            {
                return context.Messages.OrderByDescending(x => x.MessageDate).ToList();
            }
        }
    }
}