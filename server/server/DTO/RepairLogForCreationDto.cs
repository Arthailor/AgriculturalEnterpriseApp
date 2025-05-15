namespace server.DTO
{
    public record RepairLogForCreationDto(DateTime DateOfBreakage, DateTime DateOfRepair, string CauseOfBreakage);
}
