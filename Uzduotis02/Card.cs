namespace Uzduotis02
{
    internal class Card
    {
        public string Face { get; set; }
        public string Order { get; set; }

        public Card(string face, string order)
        {
            Face = face;
            Order = order;
        }

        public string GetFace()
        {
            return Face;
        }
        public void SetFace(string face)
        {
            Face = face;
        }
        public string GetOrder()
        {
            return Order;
        }
        public void SetOrder(string order)
        {
            Order = order;
        }


        public override string ToString()
        {
            return $"{Order} of {Face}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            Card card = (Card)obj;
            if (card.Face == this.Face && card.Order == this.Order)
                return true;
            else
                return false;
        }
    }
}
