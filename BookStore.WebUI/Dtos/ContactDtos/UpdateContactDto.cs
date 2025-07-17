namespace BookStore.WebUI.Dtos.ContactDtos
{
    public class UpdateContactDto
    {
        public int ContactId { get; set; }
        public string AboutUs { get; set; }
        public string Email { get; set; }
        public string ContactAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string SocialMedia { get; set; }
    }
}
