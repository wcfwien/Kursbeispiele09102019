using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ta.Data;

namespace Ta.Business
{
    public class ReviewManager
    {
        List<Sight> sights = new List<Sight>();
        List<Review> reviews = new List<Review>();

        public ReviewManager()
        {
            sights.Add(new Sight { Id = 1, Name = "Albertina" });
            sights.Add(new Sight { Id = 2, Name = "Belvedere" });
            sights.Add(new Sight { Id = 3, Name = "Schönbrunn" });
            sights.Add(new Sight { Id = 4, Name = "Stephansdom" });

            reviews.Add(new Review { Id = 1, Description = "Die Albertina ist ein Kunstmuseum im 1. Wiener Gemeindebezirk, der Inneren Stadt. Sie beherbergt unter anderem eine der bedeutendsten grafischen Sammlungen der Welt.", SightId = 1 });
            reviews.Add(new Review { Id = 2, Description = "Seit das Museum 2007 die Leihgabe der Privatsammlung Batliner erhielt, wird ein Teil der Ausstellungsfläche nicht mehr für die Präsentation der grafischen Sammlung verwendet, sondern für eine permanente Schau zur klassischen Moderne: Monet bis Picasso. Die Sammlung Batliner.", SightId = 1 });
            reviews.Add(new Review { Id = 3, Description = "Oberes Belvedere: österreichische Kunst um Gustav Klimt und Egon Schiele", SightId = 2 });
            reviews.Add(new Review { Id = 4, Description = "Schloss Schönbrunn, luxuriöse Sommerresidenz der Habsburger", SightId = 3 });
            reviews.Add(new Review { Id = 5, Description = "Der von den Wienern auch kurz Steffl genannte römisch-katholische Dom gilt als Wahrzeichen Wiens und wird häufig auch als österreichisches Nationalheiligtum bezeichnet.", SightId = 4 });
        }

        public List<Sight> GetSights() 
        {
            return sights;
        }

        public List<Review> GetReviewsForSight(int sightId) 
        {
            return reviews.Where(s => s.SightId == sightId).ToList();
        }

        public void AddReview(Review review) 
        {
            reviews.Add(review);
        }
    }
}
