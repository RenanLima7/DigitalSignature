using DigitalSignatureAPI.Model.Entity;

namespace DigitalSignatureAPI.Model
{
    public class User
    {
        public long Id { get; set; }
        public string PlainText { get; set; }
        public Key PairKeys { get; set; }
    }
}
