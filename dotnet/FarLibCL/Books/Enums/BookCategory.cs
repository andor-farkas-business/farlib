namespace FarLibCL.Books.Enums;

[Flags]
public enum BookCategory
{
    None = 0,
    Fantasy = 1,
    Romance = 2,
    History = 4,
    ScienceFiction = 8,
    Crime = 16,
    Supernatural = 32,
    Autobiography = 64
}