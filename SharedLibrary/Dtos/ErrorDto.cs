namespace SharedLibrary.Dtos
{
    public class ErrorDto
    {
        public List<string> Errors { get; private set; } =new List<string>();
        public bool IsShow { get; private set; }
        public ErrorDto(string errors, bool isShow)
        {
            Errors.Add(errors);
            IsShow = isShow;
        }
        public ErrorDto(List<string> errors, bool isShow)
        {
            Errors = errors;
            IsShow = isShow;
        }
    }
}
