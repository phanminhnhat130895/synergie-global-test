namespace Application.Common.Helpers
{
    public static class GuidHelper
    {
        public static bool BeAValidGuid(string id)
        {
            return Guid.TryParse(id, out _);
        }
    }
}
