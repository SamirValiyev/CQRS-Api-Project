namespace CQRS_project.Queries.Students
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
