namespace CQRS_project.CQRS.Queries
{
    public class GetByIdQuery
    {
        public int Id { get; set; }

        public GetByIdQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
