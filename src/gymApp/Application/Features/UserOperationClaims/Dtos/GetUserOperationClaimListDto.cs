namespace Application.Features.UserOperationClaims.Dtos
{
    public class GetUserOperationClaimListDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OperationClaimName { get; set; }
    }
}
