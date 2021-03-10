using BookSeller.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookSeller.Models
{
    // Subclass of the model Cart
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session =
                services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart")
                ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        // Overriding the methods declared in the Cart model
        public override void AddItem(Book book, int quantity)
        {
            base.AddItem(book, quantity);
            Session.SetJson("Cart", this);
        }

        public override void RemoveLine(Book book, int quantity)
        {
            base.RemoveLine(book, quantity);
            Session.SetJson("Cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
